using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

		TabPage GraphTabPage;

		public HNClusterUI()
		{
			InitializeComponent();

			GraphTabPage = tabControl1.TabPages[1];
			tabControl1.TabPages.Remove(GraphTabPage);

			graphUI = new GraphUI();
			wikiCollection = new WikiCollection();
			ClusteringWikipediaFinished += new ClusteringWikipediaFinishedHandler(OnClusteringWikipediaFinished);
			treeCluster.treeViewClusters.AfterSelect += treeViewClusters_AfterSelect;
			treeCluster.listViewClusters.ItemActivate += listViewClusters_ItemActivate;

			Task.Factory.StartNew(ClusterWikipedia);
		}

		public void ClusterWikipedia()
		{
			wikiCollection.ParseXML(@"Wikipedia-ComputerScience.xml");
			//wikiCollection.ParseXML(@"Wikipedia-Science.xml");
			//wikiCollection.ParseXML(@"Wikipedia-Genetic-Engineering.xml");
			//wikiCollection.ParseXML(@"Wikipedia-Algorithms-and-Data-Structures.xml");
			wikiCollection.ExtractTokens();
			HAC = new HierarchicalCluster(wikiCollection);
			HAC.initializeClusters();
			HAC.Cluster();
			graphDisplay1.GenerateGraph(HAC);
			this.Invoke(ClusteringWikipediaFinished);
		}

		public void OnClusteringWikipediaFinished()
		{
			tabControl1.TabPages.Add(GraphTabPage);
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
			}
		}

		

	}
}
