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

			Task.Factory.StartNew(ClusterWikipedia);
		}

		public void ClusterWikipedia()
		{
			//wikiCollection.ParseXML(@"Wikipedia-ComputerScience.xml");
			//wikiCollection.ParseXML(@"Wikipedia-Science.xml");
			//wikiCollection.ParseXML(@"Wikipedia-Genetic-Engineering.xml");
			//wikiCollection.ParseXML(@"Wikipedia-Algorithms-and-Data-Structures.xml");
            wikiCollection.ParseXML(@"WikiTestData.xml");           // Use this data file for testing since it is extremely small
			wikiCollection.ExtractTokens();
			HAC = new HierarchicalCluster(wikiCollection);
			HAC.initializeClusters();
			HAC.Cluster();
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
			if (e.Node.Text == "Cluster")
			{
				ListView listView = treeCluster.listViewClusters;
				listView.Items.Clear();
				treeCluster.AddPagesFromCluster(e.Node);
			}

		}

		private void listViewClusters_ItemActivate(object sender, EventArgs e)
		{
			ListView listView = (ListView)sender;

			if (listView.SelectedItems.Count > 0)
			{
				pageDisplay1.LoadPage(listView.SelectedItems[0].Text);
				pageDisplay1.textBoxTitle.Text = listView.SelectedItems[0].Text;

                if (recommenderDisplay.userLoggedOn == true)
                {
                    //recommenderFeature.userViewedPage(listView.SelectedItems[0].Text);
                    WikiPage wikiPage = HAC.wikiCollection.wikiPages.Find(WikiPage => WikiPage.title == listView.SelectedItems[0].Text);
                    recommenderFeature.userViewedPage(wikiPage);
                    recommenderDisplay.updateLikedPages(recommenderFeature.userData.likedWikiPages);
                }
			}
		}

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageRecommender && recommenderDisplay.userLoggedOn == false)
            {
                UserLoginForm userLogin = new UserLoginForm();
                userLogin.ShowDialog();
                
                // If user authentication is successful, then propogate the authentication to the recommender
                recommenderFeature.userAuthenticated(userLogin.username);
                recommenderDisplay.userLoggedIn(userLogin.username);
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
