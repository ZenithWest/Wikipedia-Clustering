using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Clustering;
using Wiki;
using System.Xml.Linq;

namespace UIControlLibrary
{
	public partial class TreeCluster : UserControl
	{
		HierarchicalCluster HAC;
		XElement OutputClusters;

		public TreeCluster()
		{
			InitializeComponent();
		}

		public void LoadClusters(HierarchicalCluster hac)
		{
			HAC = hac;
			OutputClusters = new XElement("Cluster");
			foreach (Cluster cluster in HAC.clusters)
			{
				TreeNode node = new TreeNode("Cluster");
				node.ForeColor = Color.Lime;
				AddClustersMethod(node, OutputClusters, cluster);
				treeViewClusters.Nodes.Add(node);
			}
		}

		public void AddClustersMethod(TreeNode node, XElement element, Cluster cluster)
		{
			foreach (Wiki.WikiPage page in cluster.pages)
			{
				TreeNode node3 = new TreeNode(page.title);
				node3.NodeFont = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular);
				node3.ForeColor = Color.White;
				node.Nodes.Add(node3);

				XElement element3 = new XElement("Cluster");
				element3.SetValue(page.title);
				element.Add(element3);
			}

			int N = 10;
			if (cluster.cluster1 != null)
			{
				List<string> tokens = cluster.cluster1.TopTokens(N);
				string name = "";

				for (int i = 0; i < tokens.Count - 1; ++i)
				{
					name += tokens[i] + " | ";
				}
				name += tokens[tokens.Count - 1];

				TreeNode node1 = new TreeNode(name);
				node1.ForeColor = Color.Lime;
				node.Nodes.Add(node1);

				XElement element1 = new XElement("Cluster");
				element.Add(element1);

				AddClustersMethod(node1, element1, cluster.cluster1);
			}

			if (cluster.cluster2 != null)
			{
				List<string> tokens = cluster.cluster2.TopTokens(N);
				string name = "";

				for (int i = 0; i < tokens.Count - 1; ++i)
				{
					name += tokens[i] + " | ";
				}
				name += tokens[tokens.Count - 1];


				TreeNode node2 = new TreeNode(name);
				node2.ForeColor = Color.Lime;
				node.Nodes.Add(node2);

				XElement element2 = new XElement("Cluster");
				element.Add(element2);

				AddClustersMethod(node2, element2, cluster.cluster2);
			}
			 
		}

		public void AddPagesFromCluster(TreeNode node)
		{
			if (node.Nodes.Count == 0)
			{
				listViewClusters.Items.Add(node.Text);
			}
			foreach (TreeNode n in node.Nodes)
			{
				AddPagesFromCluster(n);
			}

		}

	}
}
