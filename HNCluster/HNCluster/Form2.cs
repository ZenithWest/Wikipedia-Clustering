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
using System.Xml.Linq;
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
			/*
			string DotFilePath = String.Format(@"C:\Users\Zenith\AppData\Roaming\HNClusterUI\HNClusterUI\1.0.0.0\DOTFILE - Copy - Copy.dot");
			//graph.ToDotFile(DotFilePath);

			DOT dotfile2 = new DOT();
			string DotFile1 = File.ReadAllText(DotFilePath);
			string svg2 = dotfile2.ToSvg(DotFile1);
			return;*/


			this.MouseWheel += new System.Windows.Forms.MouseEventHandler(Form2_MouseWheel);
			this.KeyDown += Form2_KeyDown_KeyUp;
			this.KeyUp += Form2_KeyDown_KeyUp;
			this.KeyPreview = true;
			webBrowser1.WebBrowserShortcutsEnabled = false;
			webBrowser1.IsWebBrowserContextMenuEnabled = false;
			webBrowser1.PreviewKeyDown += webBrowser1_PreviewKeyDown;
			Control c = webBrowser1;
			c.KeyDown += Form2_KeyDown_KeyUp;
			c.KeyUp += Form2_KeyDown_KeyUp;
			//c.Enabled = false;
			/*
			foreach (Control control in this.Controls)
			{
				control.KeyDown += new KeyEventHandler(Form2_KeyDown_KeyUp);
				control.KeyUp += new KeyEventHandler(Form2_KeyDown_KeyUp);
				//control.KeyPress += new KeyEventHandler(Form2_KeyDown_KeyUp);
			}*/

			graph = new Xglore.Plugin.Graphviz.RootGraph("Clusters", false, false);
			string MainNode = " _3D.P–r,i:nt–ing'L13_01111111101-- 010Noro–Frenkel_law_of_corresponding___stat&es+ ";
			AddNode(MainNode);

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


			AddEdge(MainNode, "0");
			AddEdge(MainNode, "1");

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


			string dotPath = String.Format("{0}\\DOTFILE.dot", Application.UserAppDataPath);
			graph.ToDotFile(dotPath);
						
			DOT dotfile = new DOT();
			string strBlah3 = System.IO.File.ReadAllText(dotPath);
			
			string svg = dotfile.ToSvg(strBlah3);

			System.IO.File.WriteAllText(String.Format("{0}\\SVG.svg", Application.UserAppDataPath), svg);

			//webBrowser1.Url = new Uri(@"C:\Users\Zenith\Documents\GitHub\Wikipedia-Clustering\HNCluster\HNCluster\bin\Debug\" + "SVG.svg");
			Uri url = new Uri(String.Format("{0}\\SVG.svg", Application.UserAppDataPath));
			webBrowser1.Url = url;
			XDocument doc = XDocument.Parse(svg);
			SVGFile = (XElement)doc.LastNode;
			//SVGFile = XDocument.Parse(svg).Element("svg");
			this.Focus();
			
		}

		void webBrowser1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			Control c = webBrowser1;
			c.Enabled = false;

		}

		XElement SVGFile;
		void SaveToSVGFile()
		{

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
			if (!CtrlIsDown)
			{
				Control c = webBrowser1;
				c.Enabled = true;
			}
		}

		private void Form2_MouseWheel(object sender, MouseEventArgs e)
		{
			if (CtrlIsDown)
			{
				Zoom(Math.Sign(e.Delta));
			}
		}
		float ZoomSize = 1.0f;
		Size WBSize = new Size(1727, 1044);
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
			Size size = new Size((int)(ZoomSize * WBSize.Width), (int)(ZoomSize * WBSize.Height));
			SVGFile.SetAttributeValue("viewBox", String.Format("0 0 {0} {1}", size.Width, size.Height));
			//SVGFile.Attribute("width").SetValue((int)(ZoomSize * WBSize.Width));
			//SVGFile.Attribute("height").SetValue((int)(ZoomSize * WBSize.Height));
			SVGFile.Save("SVG.svg");
			webBrowser1.Refresh();
			
			//webBrowser1.Scale(new SizeF(ZoomSize, ZoomSize));
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (msg.Msg == 0x100)
			{
				if (keyData == Keys.Control)
				{
					int a;
					
				}

			}
			return false;
		}

		private void Form2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.Control)
			{
				e.IsInputKey = true;
			}
		}

	}
}
