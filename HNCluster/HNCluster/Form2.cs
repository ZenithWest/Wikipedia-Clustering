using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using Xglore;
using Xglore.Plugin;
using Xglore.Plugin.Graphviz;
using WINGRAPHVIZLib;
using Microsoft.VisualBasic;
using System.IO;
//using Microsoft.Glee;
//using Microsoft.Glee.Splines;

namespace HNCluster
{
	public partial class Form2 : Form
	{
		public RootGraph graph;

		public void AddNode(string name)
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

		public void AddEdge(string src, string dest)
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

		public Form2()
		{
			InitializeComponent();
			this.MouseWheel += new System.Windows.Forms.MouseEventHandler(Form2_MouseWheel);

			graph = new Xglore.Plugin.Graphviz.RootGraph("Clusters", false, false);
			AddNode("Clusters");

			AddNode("0");
			AddNode("00");
			AddNode("000");
			AddNode("001");
			AddNode("01");
			AddNode("010");
			AddNode("011");



			AddNode("1");
			AddNode("10");
			AddNode("100");
			AddNode("101");
			AddNode("11");
			AddNode("110");
			AddNode("111");


			AddEdge("Clusters", "0");
			AddEdge("Clusters", "1");

			AddEdge("0", "00");
			AddEdge("00", "000");
			AddEdge("00", "001");
			AddEdge("0", "01");
			AddEdge("01", "010");
			AddEdge("01", "011");
			AddEdge("1", "10");
			AddEdge("10", "100");
			AddEdge("10", "101");
			AddEdge("1", "11");
			AddEdge("11", "110");
			AddEdge("11", "111");

			for (int i = 0; i < 10; ++i)
			{
				AddNode(i.ToString());
			}

			for (int x = 0; x < 10; ++x)
			{
				for (int y = x; y < 10; ++y)
				{
					if (x != y)
					AddEdge(x.ToString(), y.ToString());
				}
			}



			graph.ToDotFile("DOTFILE.dot");
						
			DOT dotfile = new DOT();
			string strBlah3 = System.IO.File.ReadAllText("DOTFILE.dot");
			string svg = dotfile.ToSvg(strBlah3);
			System.IO.File.WriteAllText("SVG.svg", svg);
			webBrowser1.Url = new Uri(@"C:\Users\Zenith\Documents\GitHub\Wikipedia-Clustering\HNCluster\HNCluster\bin\Debug\" + "SVG.svg");

		}

		private void button1_Click(object sender, EventArgs e)
		{
			System.Net.HttpWebRequest webRequest = (HttpWebRequest)System.Net.WebRequest.Create("http://en.wikipedia.org/wiki/Special:Export/Train");
			webRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;
			webRequest.Accept = "text/xml";
			System.Net.HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
			System.IO.Stream responseStream = webResponse.GetResponseStream();
			System.Xml.XmlTextReader reader = new XmlTextReader(responseStream);
			string NS = "http://www.mediawiki.org/xml/export-0.3/";
			XPathDocument doc = new XPathDocument(reader);
			reader.Close();
			webResponse.Close();
			XPathNavigator myXPathNavigator = doc.CreateNavigator();
			XPathNodeIterator nodesText = myXPathNavigator.SelectDescendants("text", NS, false);

			//System.Net.FileWebResponse
			while (nodesText.MoveNext())
			{

				//Response.Write((nodesText.Current.InnerXml + " "));


			}

		}
		bool CtrlIsDown = false;
		private void Form2_KeyDown_KeyUp(object sender, KeyEventArgs e)
		{
			CtrlIsDown = e.Control;
		}

		private void Form2_MouseWheel(object sender, MouseEventArgs e)
		{
			if (CtrlIsDown)
			{
				Zoom(Math.Sign(e.Delta));
			}
		}
		float ZoomSize = 1.0f;
		private void Zoom(int direction)
		{
			if (direction < 0)
			{
				ZoomSize -= 0.1f;
			}
			else if (direction > 0)
			{
				ZoomSize += 0.1f;
			}
			webBrowser1.Scale(new SizeF(ZoomSize, ZoomSize));
		}
	}
}
