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

namespace HNClusterUI
{
	public partial class HNClusterUI : Form
	{
		WikiCollection wikiCollection;
		HierarchicalCluster hierarchicalCluster;

		public HNClusterUI()
		{
			InitializeComponent();
			wikiCollection = new WikiCollection();
		}

		private void startToolStripMenuItem_Click(object sender, EventArgs e)
		{
			wikiCollection.ParseXML(@"Wikipedia-Science.xml");
			wikiCollection.ExtractTokens();
			hierarchicalCluster = new HierarchicalCluster(wikiCollection);
			hierarchicalCluster.initializeClusters();
			hierarchicalCluster.Cluster();
			GraphUI gui = new GraphUI();
			gui.Show();
			gui.GenerateGraph(hierarchicalCluster);
		}
	}
}
