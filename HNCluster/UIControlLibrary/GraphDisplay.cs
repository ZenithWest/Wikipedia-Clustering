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
			graph = new RootGraph("Clusters", true, true);
			url = new Uri(SVGFilePath); 
		}

		public void GenerateGraph(HierarchicalCluster hac)
		{
			HAC = hac;
			if (HAC.clusters.Count > 0)
			{
				AddNode("Main_Cluster");
				HAC.clusters[0].SVGNodeName = "Main_Cluster";
				GenerateGraph(HAC.clusters[0], "Main_Cluster", 0, "0");
				GenerateSVG();
				webBrowser1.Url = url;
			}
			
		}

		private void GenerateGraph(Cluster cluster, string ParentNode, int depth, string LR)
		{
			if (cluster != null)
			{
				string NodeName1 = "";
				string NodeName2 = "";

				foreach (Wiki.WikiPage page in cluster.pages)
				{
					string NodeName = page.title + " ";
					AddNode(NodeName);
					AddEdge(ParentNode, NodeName);
				}

				if (cluster.cluster1 != null)
				{
					NodeName1 = GenerateNodeName(cluster.cluster1, depth + 1, LR + "0");
					cluster.cluster1.SVGNodeName = NodeName1;
					AddNode(NodeName1);
					AddEdge(ParentNode, NodeName1);
					GenerateGraph(cluster.cluster1, NodeName1, depth + 1, LR + "0");
				}

				if (cluster.cluster2 != null)
				{
					NodeName2 = GenerateNodeName(cluster.cluster2, depth + 1, LR + "1");
					cluster.cluster2.SVGNodeName = NodeName2;
					AddNode(NodeName2);
					AddEdge(ParentNode, NodeName2);
					GenerateGraph(cluster.cluster2, NodeName2, depth + 1, LR + "1");
				}
				/*
				if (cluster.cluster1 != null)
				{
					GenerateGraph(cluster.cluster1, NodeName1, depth + 1, LR + "0");
				}

				if (cluster.cluster2 != null)
				{
					GenerateGraph(cluster.cluster2, NodeName2, depth + 1, LR + "1");
				}*/

				
			}
		}

		string GenerateNodeName(Cluster cluster, int depth, string LR)
		{
			int num = 0;
			int count = 0;
			string str = "";
			for (int i = 0; i < LR.Length; i++)
			{
				num += int.Parse(LR[i].ToString()) * (int)Math.Pow(2.0, count++);
				if (count >= 6)
				{
					count = 0;
					str += char.ConvertFromUtf32(num + 'À');
					num = 0;
				}
			}
			if (count < 6)
			{
				str += char.ConvertFromUtf32(num + 'À');
			}
			return String.Format("L{0}_{1}", depth, str);
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
				int a = 0;
				++a;
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
				int a = 0;
				++a;
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
			FormatSVG();

			ZoomFactor = -2;

			SVGFile.Attribute("currentScale").SetValue(Math.Pow(1.25, ZoomFactor));
			SVGFile.Attribute("width").SetValue(((int)(SVGWidth * Math.Pow(1.25, ZoomFactor))) + "px");
			SVGFile.Attribute("height").SetValue(((int)(SVGHeight * Math.Pow(1.25, ZoomFactor))) + "px");
			SVGFile.Save(SVGFilePath);
			webBrowser1.Refresh();
		}

		int SVGWidth = 0;
		int SVGHeight = 0;
		private void FormatSVG()
		{
			string strWidth = SVGFile.Attribute("width").Value;
			strWidth = strWidth.Replace("px", "");
			string strHeight = SVGFile.Attribute("height").Value;
			strHeight = strHeight.Replace("px", "");
			SVGWidth = int.Parse(strWidth);
			SVGHeight = int.Parse(strHeight);
			SVGFile.Add(new XAttribute("currentScale", 1));

			XNamespace NS = SVGFile.GetDefaultNamespace();
			XElement graph = SVGFile.Element(NS + "g");
			foreach (XElement node in graph.Elements(NS + "g"))
			{
				if (node.Attribute("class").Value == "node")
				{
					string title = node.Element(NS + "title").Value;
					if (title.StartsWith("L") && char.IsDigit(title[1]))
					{
						XElement ellipse = node.Element(NS + "ellipse");
						int red = 0;
						int green = 0;
						int blue = 0;

						if (char.IsDigit(title[2]))
						{
							if (!char.IsDigit(title[3]))
							{
								int digit = int.Parse(title[1].ToString());
								if (digit >= 2)
								{
									blue = 100;
								}

								if (digit >= 4)
								{
									green = 100;
								}

								if (digit >= 6)
								{
									red = 100;
									blue = 0;
								}

								if (digit >= 8)
								{
									red = 100;
									blue = 0;
									green = 0;
								}
								switch (digit)
								{
									case 1:
										blue = 50 + 5 * int.Parse(title[2].ToString());
										break;
									case 2:
										green = 0 + 5 * int.Parse(title[2].ToString());
										break;
									case 3:
										green = 50 + 5 * int.Parse(title[2].ToString());
										break;
									case 4:
										red = 0 + 5 * int.Parse(title[2].ToString());
										blue = 100 - 5 * int.Parse(title[2].ToString());
										break;
									case 5:
										red = 50 + 5 * int.Parse(title[2].ToString());
										blue = 50 - 5 * int.Parse(title[2].ToString());
										break;
									case 6:
										green = 100 - 5 * int.Parse(title[2].ToString());
										break;
									case 7:
										green = 50 - 5 * int.Parse(title[2].ToString());
										break;
									case 8:
										blue = 5 * int.Parse(title[2].ToString());
										green = 5 * int.Parse(title[2].ToString());
										break;
									case 9:
										blue = 50 + 5 * int.Parse(title[2].ToString());
										green = 50 + 5 * int.Parse(title[2].ToString());
										break;
								}
							}
							else
							{
								blue = 100;
								green = 100;
								red = 100;
							}
						}
						else
						{
							blue = 5 * int.Parse(title[1].ToString());
						}

						string style = string.Format("fill:rgb({0}%, {1}%, {2}%);stroke:black;", red, green, blue);
						ellipse.Attribute("style").SetValue(style);
					}
				}
			}
			SVGFile.Save(SVGFilePath);
		}
		int ZoomFactor = 0;
		private void buttonZoomIn_Click(object sender, EventArgs e)
		{
			if (ZoomFactor <= 0)
			{
				++ZoomFactor;

				SVGFile.Attribute("currentScale").SetValue(Math.Pow(1.25, ZoomFactor));
				SVGFile.Attribute("width").SetValue(((int)(SVGWidth * Math.Pow(1.25, ZoomFactor))) + "px");
				SVGFile.Attribute("height").SetValue(((int)(SVGHeight * Math.Pow(1.25, ZoomFactor))) + "px");
				SVGFile.Save(SVGFilePath);
				webBrowser1.Refresh();
			}
		}

		private void buttonZoomOut_Click(object sender, EventArgs e)
		{
			--ZoomFactor;

			SVGFile.Attribute("currentScale").SetValue(Math.Pow(1.25, ZoomFactor));
			SVGFile.Attribute("width").SetValue(((int)(SVGWidth * Math.Pow(1.25, ZoomFactor)))+ "px");
			SVGFile.Attribute("height").SetValue(((int)(SVGHeight * Math.Pow(1.25, ZoomFactor))) + "px");
			SVGFile.Save(SVGFilePath);
			webBrowser1.Refresh();
		}
	}
}
