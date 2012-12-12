using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Wiki;
using Clustering;
using Recommender;

namespace HNClusterUI
{
	public partial class HNClusterUI : Form
	{
		WikiCollection wikiCollection;
		HierarchicalCluster HAC;
		public delegate void ClusteringWikipediaFinishedHandler();
		public event ClusteringWikipediaFinishedHandler ClusteringWikipediaFinished;
		GraphUI graphUI = new GraphUI();
        RecommenderUI recommenderUI = new RecommenderUI();
        RecommenderFeature recommenderFeature = new RecommenderFeature();

		TabPage GraphTabPage;
        TabPage RecommenderTabPage;


		public HNClusterUI()
		{
			InitializeComponent();

			GraphTabPage = tabControl1.TabPages[1];
            RecommenderTabPage = tabControl1.TabPages[2];

			//tabControl1.TabPages.Remove(GraphTabPage);
            tabControl1.TabPages[1].Enabled = false;            // Just disable the tab until content is ready instead of removing it
            tabControl1.TabPages[2].Enabled = false;


			graphUI = new GraphUI();
			wikiCollection = new WikiCollection();
            recommenderFeature = new RecommenderFeature();
			ClusteringWikipediaFinished += new ClusteringWikipediaFinishedHandler(OnClusteringWikipediaFinished);
			treeCluster.treeViewClusters.AfterSelect += treeViewClusters_AfterSelect;
			treeCluster.listViewClusters.ItemActivate += listViewClusters_ItemActivate;

            recommenderDisplay.listBoxLikedPages.SelectedIndexChanged += listBoxLikedPages_SelectedIndexChanged;
            recommenderDisplay.listBoxRecommendedPages.SelectedIndexChanged += listBoxRecommendedPages_SelectedIndexChanged;
            recommenderDisplay.btnGenerateRecs.Click += btnGenerateRecs_Click;

			Task.Factory.StartNew(ClusterWikipedia);
		}

		public void ClusterWikipedia()
		{
			WikiCollection WikiComputerScience = new WikiCollection();
			WikiComputerScience.ParseXML(@"Wikipedia-ComputerScience.xml");
			//WikiComputerScience.ParseXML(@"WikiTestData.xml");
			WikiComputerScience.ExtractTokens();
			HierarchicalCluster HACComputerScience = new HierarchicalCluster(WikiComputerScience);
			HACComputerScience.initializeClusters();
			HACComputerScience.Cluster();
			HACComputerScience.clusters[0].SVGNodeName = "HNCluster Computer Science";
			
			/*
			WikiCollection WikiScience = new WikiCollection();
			WikiScience.ParseXML(@"Wikipedia-Science.xml");
			//WikiScience.ParseXML(@"WikiTestData.xml");
			WikiScience.ExtractTokens();
			HierarchicalCluster HACScience = new HierarchicalCluster(WikiScience);
			HACScience.initializeClusters();
			HACScience.Cluster();
			HACScience.clusters[0].SVGNodeName = "HNCluster Science";*/

			WikiCollection WikiGeneticEngineering = new WikiCollection();
			WikiGeneticEngineering.ParseXML(@"Wikipedia-Genetic-Engineering.xml");
			//WikiGeneticEngineering.ParseXML(@"WikiTestData.xml");
			WikiGeneticEngineering.ExtractTokens();
			HierarchicalCluster HACGeneticEngineering = new HierarchicalCluster(WikiGeneticEngineering);
			HACGeneticEngineering.initializeClusters();
			HACGeneticEngineering.Cluster();
			HACGeneticEngineering.clusters[0].SVGNodeName = "HNCluster Genetic Engineering";

			HAC = new HierarchicalCluster();
			
			HAC.clusters.AddRange(HACComputerScience.clusters);
			//HAC.clusters.AddRange(HACScience.clusters);
			HAC.clusters.AddRange(HACGeneticEngineering.clusters);


			//wikiCollection.ParseXML(@"Wikipedia-ComputerScience.xml");
			//wikiCollection.ParseXML(@"Wikipedia-Science.xml");
			//wikiCollection.ParseXML(@"Wikipedia-Genetic-Engineering.xml");
			//wikiCollection.ParseXML(@"Wikipedia-Algorithms-and-Data-Structures.xml");
         //wikiCollection.ParseXML(@"WikiTestData.xml");           // Use this data file for testing since it is extremely small

			/*
			wikiCollection.ExtractTokens();
			HAC = new HierarchicalCluster(wikiCollection);
			HAC.initializeClusters();
			HAC.Cluster();*/
			graphDisplay1.GenerateGraph(HAC);
			this.Invoke(ClusteringWikipediaFinished);
		}

		public void OnClusteringWikipediaFinished()
		{
			//tabControl1.TabPages.Add(GraphTabPage);
            tabControl1.TabPages[1].Enabled = true;         // Enable the graph tab page once content is finished loading
            tabControl1.TabPages[2].Enabled = true;
			tabControl1.SelectedIndex = 1;
			treeCluster.LoadClusters(HAC);
		}

		public void treeViewClusters_AfterSelect(object sender, TreeViewEventArgs e)
		{
			TreeView treeViewCluster = (TreeView)sender;
			ListView listView = treeCluster.listViewClusters;
			listView.Items.Clear();
			treeCluster.AddPagesFromCluster(e.Node);
			if (e.Node.Nodes.Count == 0)
			{
				LoadWikiWebPage(e.Node.Text);
			}

		}

		private void listViewClusters_ItemActivate(object sender, EventArgs e)
		{
			ListView listView = (ListView)sender;

			if (listView.SelectedItems.Count > 0)
			{
				LoadWikiWebPage(listView.SelectedItems[0].Text);
			}
		}

		void LoadWikiWebPage(string title)
		{
			pageDisplay1.LoadPage(title);
			pageDisplay1.textBoxTitle.Text = title;

			if (recommenderDisplay.userLoggedOn == true)
			{
				WikiPage wikiPage = HAC.FindPage(title);
				recommenderFeature.userViewedPage(wikiPage);
				recommenderDisplay.updateLikedPages(recommenderFeature.userData.likedWikiPages);
			}
		}

        private void listBoxLikedPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listView = (ListBox)sender;

            if (listView.SelectedItems.Count > 0)
            {
                recPageDisplay.LoadPage(listView.Items[listView.SelectedIndex].ToString());
                recPageDisplay.textBoxTitle.Text = listView.Items[listView.SelectedIndex].ToString();

                if (recommenderDisplay.userLoggedOn == true)
                {
                    //recommenderFeature.userViewedPage(listView.SelectedItems[0].Text);
                    //WikiPage wikiPage = HAC.wikiCollection.wikiPages.Find(WikiPage => WikiPage.title == listView.SelectedItems[0].Text);
                    //recommenderFeature.userViewedPage(wikiPage);
                    //recommenderDisplay.updateLikedPages(recommenderFeature.userData.likedWikiPages);
                }
            }
        }

        private void listBoxRecommendedPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listView = (ListBox)sender;

            if (listView.SelectedItems.Count > 0)
            {
                recPageDisplay.LoadPage(listView.Items[listView.SelectedIndex].ToString());
                recPageDisplay.textBoxTitle.Text = listView.Items[listView.SelectedIndex].ToString();

                if (recommenderDisplay.userLoggedOn == true)
                {
                    //recommenderFeature.userViewedPage(listView.SelectedItems[0].Text);
                    //WikiPage wikiPage = HAC.wikiCollection.wikiPages.Find(WikiPage => WikiPage.title == listView.SelectedItems[0].Text);
                    //recommenderFeature.userViewedPage(wikiPage);
                    //recommenderDisplay.updateLikedPages(recommenderFeature.userData.likedWikiPages);
                }
            }
        }

        private void btnGenerateRecs_Click(object sender, EventArgs e)
        {
            List<WikiPage> recommendedPages = recommenderFeature.generateRecommendations(HAC.clusters[0].AllPagesInCluster);
            recommenderDisplay.updateUserRecommendations(recommendedPages);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageRecommender && recommenderDisplay.userLoggedOn == false)
            {
                UserLoginForm userLogin = new UserLoginForm();
                userLogin.ShowDialog();
                
                // If user authentication is successful, then propogate the authentication to the recommender
                recommenderFeature.userAuthenticated(userLogin.userName);
                recommenderDisplay.userLoggedIn(userLogin.userName);
                recommenderDisplay.updateLikedPages(recommenderFeature.userData.likedWikiPages);

            }
        }

        // Method is called when user selects a new tab page, but before the page is loaded and displayed to the user
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            // If user selects the graph tab then we need to make sure content has been loaded before allowing user to select Graph tab
            if (e.TabPage == tabControl1.TabPages[1] && tabControl1.TabPages[1].Enabled == false)
            {
                e.Cancel = true;
            }

            if (e.TabPage == tabControl1.TabPages[2] && tabControl1.TabPages[2].Enabled == false)
            {
                e.Cancel = true;
            }
        }

	}
}
