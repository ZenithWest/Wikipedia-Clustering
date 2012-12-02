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
				AddClustersMethod(node, OutputClusters, cluster);
				treeViewClusters.Nodes.Add(node);
			}
		}

		public void AddClustersMethod(TreeNode node, XElement element, Cluster cluster)
		{
			if (cluster.page != null)
			{
				if (cluster.cluster1 != null || cluster.cluster2 != null)
				{
					TreeNode node3 = new TreeNode(cluster.page.title);
					node.Nodes.Add(node3);

					XElement element3 = new XElement("Cluster");
					element3.SetValue(cluster.page.title);
					element.Add(element3);
				}
				else
				{
					node.Text = cluster.page.title;
					element.SetValue(cluster.page.title);
					element.Name = "Cluster";
					node.NodeFont = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular);
					node.ForeColor = Color.White;
					return;
				}
			}
			if (cluster.cluster1 != null)
			{

				TreeNode node1 = new TreeNode("Cluster");
				node.Nodes.Add(node1);

				XElement element1 = new XElement("Cluster");
				element.Add(element1);

				AddClustersMethod(node1, element1, cluster.cluster1);
			}
			if (cluster.cluster2 != null)
			{
				TreeNode node2 = new TreeNode("Cluster");
				node.Nodes.Add(node2);

				XElement element2 = new XElement("Cluster");
				element.Add(element2);

				AddClustersMethod(node2, element2, cluster.cluster2);
			}
			//node.NodeFont = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold | FontStyle.Underline);
			node.ForeColor = Color.Lime;
		}

		public void AddPagesFromCluster(TreeNode node)
		{
			if (node.Text != "Cluster")
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
