using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xglore;
using Xglore.Plugin;
using Xglore.Plugin.Graphviz;
using WINGRAPHVIZLib;
using System.IO;
using System.Xml.Linq;
using Clustering;
using Wiki;

namespace UIControlLibrary
{
	public partial class GraphDisplay : UserControl
	{
		public RootGraph graph;
		public XElement SVGFile;
		private string DotFilePath = String.Format("{0}\\DOTFILE.dot", Application.UserAppDataPath);
		private string SVGFilePath = String.Format("{0}\\SVG.svg", Application.UserAppDataPath);
		private string DotFile;
		private HierarchicalCluster HAC;


		private Uri url;

		public GraphDisplay()
		{
			InitializeComponent();
			graph = new RootGraph("Clusters", false, false);
			url = new Uri(SVGFilePath); 
		}

		public void GenerateGraph(HierarchicalCluster hac)
		{
			HAC = hac;
			if (HAC.clusters.Count > 0)
			{
				AddNode("Main_Cluster");
				GenerateGraph(HAC.clusters[0], "Main_Cluster", 0, "0");
				GenerateSVG();
				webBrowser1.Url = url;
			}
			
		}

		private void GenerateGraph(Cluster cluster, string ParentNode, int depth, string LR)
		{
			if (cluster != null)
			{
				if (cluster.page == null)
				{
					int num = 0;
					int count = 0;
					foreach (char ch in LR)
					{
						num += int.Parse(ch.ToString()) * (int)Math.Pow(2.0, count);
						++count;
					}
					string NodeName = String.Format("L{0}_{1}", depth, num);
					AddNode(NodeName);
					AddEdge(ParentNode, NodeName);
					GenerateGraph(cluster.cluster1, NodeName, depth + 1, LR + "0");
					GenerateGraph(cluster.cluster2, NodeName, depth + 1, LR + "1");
				}
				else
				{
					string NodeName = cluster.page.title + " ";

					//NodeName = NodeName.Replace(".", "_");
					//NodeName = NodeName.Replace("'", "_");
					
					//NodeName = NodeName.Replace(":", "_");
					//NodeName = NodeName.Replace("/", "_");






					//NodeName = NodeName.Replace("–", "-");
					//NodeName = NodeName.Replace("–", "-");



					//NodeName = NodeName.Replace("-", "_");
					//NodeName = NodeName.Replace(",", "_");
					//NodeName = NodeName.Replace("+", "_");
					//NodeName = NodeName.Replace("&", "_");
					//NodeName = NodeName.Replace("(", "_");
					//NodeName = NodeName.Replace(")", "_");
					//NodeName = NodeName.Replace(" ", "_");
					/*
					NodeName = NodeName.Replace("ä", "a");
					NodeName = NodeName.Replace("é", "e");
					NodeName = NodeName.Replace("á", "a");
					NodeName = NodeName.Replace("ó", "o");
					NodeName = NodeName.Replace("è", "e");
					NodeName = NodeName.Replace("ü", "u");*/
					AddNode(NodeName);
					AddEdge(ParentNode, NodeName);
				}
			}
		}

		private void AddNode(string name)
		{
			try
			{
				Node node = new Node(name);
				graph.Nodes.Add(name, node);
			}
			catch
			{

			}
		}

		private void AddEdge(string src, string dest)
		{
			try
			{
				Node srcNode = graph.Nodes[src];
				Node destNode = graph.Nodes[dest];
				Port srcPort = new Port(srcNode, "");
				Port destPort = new Port(destNode, "");

				Edge edge = new Edge(srcPort, destPort);
				graph.Edges.Add(edge);
			}
			catch
			{

			}
		}

		private void GenerateSVG()
		{
			string DotFilePath = String.Format("{0}\\DOTFILE.dot", Application.UserAppDataPath);
			graph.ToDotFile(DotFilePath);

			DOT dotfile = new DOT();
			DotFile = File.ReadAllText(DotFilePath);
			string svg = dotfile.ToSvg(DotFile);

			File.WriteAllText(SVGFilePath, svg);

			XDocument doc = XDocument.Parse(svg);
			SVGFile = (XElement)doc.LastNode;
		}
	}
}
