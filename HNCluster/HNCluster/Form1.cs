﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

using MediaWikiEngine;
using MediaWikiEngine.Command;
using MediaWikiEngine.Domain;
using MediaWikiEngine.Language;

using DotNetWikiBot;
using System.Threading;

using Wiki;
using Clustering;

namespace HNCluster
{
	public partial class Form1 : Form
	{
		public delegate void IncrementPagesLoadedDelegate();
		public IncrementPagesLoadedDelegate IncrementPagesLoaded;

		public delegate void UpdateTextDelegate();
		public UpdateTextDelegate UpdateText;

		public delegate void IncrementPagesLoadedByValDelegate(int n);
		public IncrementPagesLoadedByValDelegate IncrementPagesLoadedByVal;

		public delegate void CheckSiteLoadedDelegate();
		public CheckSiteLoadedDelegate CheckSiteLoaded;

		public delegate void CheckPageTitlesLoadedDelegate();
		public CheckPageTitlesLoadedDelegate CheckTitlesLoaded;

		public delegate void CheckTokenizedDelegate();
		public CheckTokenizedDelegate CheckTokenized;

		public delegate void CheckCheckBox4Delegate();
		public CheckCheckBox4Delegate CheckCheckBox4;

		public delegate void CheckCheckBox5Delegate();
		public CheckCheckBox5Delegate CheckCheckBox5;

		public delegate void AddClustersDelegate();
		public AddClustersDelegate AddClusters;

		public delegate void AddPageTextDelegate(Page page);
		public AddPageTextDelegate AddPageText;

		//bool pressed = false;
		int currentPage = 0;
		PageList pageList;
		Site site;
		int pagesLoaded = 0;

		string[] titlesList;

		WikiCollection wikiCollection;
		private ListViewColumnSorter lvwColumnSorter;
		HierarchicalCluster hierarchicalCluster;

		XElement OutputClusters;

		public Form1()
		{
			InitializeComponent();

			lvwColumnSorter = new ListViewColumnSorter();
			this.listView1.ListViewItemSorter = lvwColumnSorter;
			OutputClusters = new XElement("Clusters");
			wikiCollection = new WikiCollection();

			IncrementPagesLoaded = new IncrementPagesLoadedDelegate(IncrementPagesLoadedMethod);
			IncrementPagesLoadedByVal = new IncrementPagesLoadedByValDelegate(IncrementPagesLoadedByValMethod);
			CheckSiteLoaded = new CheckSiteLoadedDelegate(CheckSiteLoadedMethod);
			CheckTitlesLoaded = new CheckPageTitlesLoadedDelegate(CheckPageTitlesLoadedMethod);
			CheckTokenized = new CheckTokenizedDelegate(CheckTokenizedMethod);
			CheckCheckBox4 = new CheckCheckBox4Delegate(CheckCheckBox4Method);
			CheckCheckBox5 = new CheckCheckBox5Delegate(CheckCheckBox5Method);
			AddPageText = new AddPageTextDelegate(AddPageTextMethod);
			UpdateText = new UpdateTextDelegate(UpdateTextMethod);
			AddClusters = new AddClustersDelegate(AddClustersMethod);
			//Task.Factory.StartNew(LoadPages);
			Task.Factory.StartNew(LoadWikipediaXML);
			
			treeView1.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold | FontStyle.Underline);
			//treeView1.BackColor = Color.Blue;
			/*
			WikiConnection wiki = new WikiConnection("localhost");
            
			GetPage page = new GetPage(wiki, "", "List of trigonometric identities");
			CommandResult result = page.Execute();*/

		}



		private void button1_Click(object sender, EventArgs e)
		{/*
            if (!pressed)
            {
                pressed = true;
                Task.Factory.StartNew(LoadPages);
            }*/
		}

		void LoadTitles()
		{
			titlesList = System.IO.File.ReadAllLines(@"ComputerScienceWikipediaPagesList");
		}

		void LoadWikipediaXML()
		{
			//wikiCollection.ParseXML(@"C:\Users\Zenith\Documents\GitHub\Wikipedia-Clustering\Data\Wikipedia-Popular.xml");
			
			//wikiCollection.ParseXML(@"Wikipedia-ComputerScience.xml");
			wikiCollection.ParseXML(@"Wikipedia-Science.xml");
			//wikiCollection.ParseXML(@"Wikipedia-Genetic-Engineering.xml");
			//wikiCollection.ParseXML(@"Wikipedia-Algorithms-and-Data-Structures.xml");
			Invoke(IncrementPagesLoadedByVal, wikiCollection.wikiPages.Count);
			pagesLoaded += wikiCollection.wikiPages.Count;
			test = true;
			if (InvokeRequired)
			{
				Invoke(UpdateText);
			}
			else
			{
				UpdateTextMethod();
			}

			wikiCollection.ExtractTokens();
			Invoke(CheckTokenized);
			hierarchicalCluster = new HierarchicalCluster(wikiCollection);
			hierarchicalCluster.initializeClusters();
			Invoke(CheckCheckBox4);
			hierarchicalCluster.Cluster();
			Invoke(CheckCheckBox5);
			Invoke(AddClusters);
		}

		void LoadPages()
		{
			//site = new Site("http://localhost/index.php/", "ZenithBot", "Bot");
			site = new Site("http://en.wikipedia.org/", "HNCluster", "csce470");
			Invoke(CheckSiteLoaded);

			
			pageList = new PageList(site);
			//pageList.FillFromFile(@"ComputerScienceWikipediaPagesList");
			pageList.FillAndLoadFromXMLDump(@"Wikipedia-ComputerScience.xml");

			wikiCollection.LoadFromPageList(pageList);
			Invoke(IncrementPagesLoadedByVal, wikiCollection.wikiPages.Count);
			pagesLoaded += wikiCollection.wikiPages.Count;

			if (InvokeRequired)
			{
				Invoke(UpdateText);
			}
			else
			{
				UpdateTextMethod();
			}


			Invoke(CheckTitlesLoaded);
			wikiCollection.ExtractTokens();
			Invoke(CheckTokenized);
			if (InvokeRequired)
			{
				Invoke(UpdateText);
			}
			else
			{
				UpdateTextMethod();
			}
			/*
			int num = 100;

			for (int i = 0; i < pageList.pages.Count; ++i)
			{
				if (i + num < pageList.pages.Count)
				{
					Parallel.For(i, i + num, n =>
					{
						pageList.pages[n].Load();
					});
					i += num - 1;
					pagesLoaded += num;
					Invoke(IncrementPagesLoadedByVal, num);
				}
				else
				{
					Parallel.For(i, pageList.pages.Count, n =>
					{
						pageList.pages[n].Load();
					});
					i += num - 1;
					pagesLoaded += pageList.pages.Count - i;
					Invoke(IncrementPagesLoadedByVal, pageList.pages.Count - i);
				}

			}*/
			/*
			foreach (Page page in pageList)
			{
				page.Load();
				if (numericUpDown1.Value == 0)
				{
					Invoke(AddPageText, new object[] { pageList[0] });
				}
				pagesLoaded += 1;
				Invoke(IncrementPagesLoaded);
				//Application.DoEvents();
			}*/
		}

		public void LoadPage(Page page)
		{
			page.Load();
			Invoke(IncrementPagesLoaded);
		}

		public void IncrementPagesLoadedMethod()
		{
			numericUpDown1.Value += 1;
		}

		public void IncrementPagesLoadedByValMethod(int val)
		{
			numericUpDown1.Value += val;
			numericUpDown2.Maximum += val;
		}

		public void CheckSiteLoadedMethod()
		{
			checkBox1.Checked = true;
		}

		public void CheckPageTitlesLoadedMethod()
		{
			checkBox2.Checked = true;
		}

		public void CheckTokenizedMethod()
		{
			checkBox3.Checked = true;
		}

		public void CheckCheckBox4Method()
		{
			checkBox4.Checked = true;
		}

		public void CheckCheckBox5Method()
		{
			checkBox5.Checked = true;
		}

		public void AddPageTextMethod(Page page)
		{
			textBox1.Text = page.text;
			label2.Text = "Title: " + page.title;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (numericUpDown1.Value > 0 && currentPage > 0)
			{
				--currentPage;/*
				textBox1.Text = pageList[currentPage].text;
				label2.Text = "Title: " + pageList[currentPage].title;*/
				numericUpDown2.Value = currentPage;
				if (InvokeRequired)
				{
					//Invoke(UpdateText);
				}
				else
				{
					//UpdateTextMethod();
				}
			}
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			if (numericUpDown1.Value > 0 && currentPage < pagesLoaded - 1)
			{
				++currentPage;/*
				textBox1.Text = pageList[currentPage].text;
				label2.Text = "Title: " + pageList[currentPage].title;*/
				numericUpDown2.Value = currentPage;
				if (InvokeRequired)
				{
					//Invoke(UpdateText);
				}
				else
				{
					//UpdateTextMethod();
				}

			}
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			listView1.View = View.Tile;
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			listView1.View = View.List;
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{

			listView1.View = View.SmallIcon;
		}

		private void radioButton4_CheckedChanged(object sender, EventArgs e)
		{

			listView1.View = View.LargeIcon;
		}

		private void radioButton5_CheckedChanged(object sender, EventArgs e)
		{

			listView1.View = View.Details;
		}

		private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			// Determine if clicked column is already the column that is being sorted.
			if (e.Column == lvwColumnSorter.SortColumn)
			{
				// Reverse the current sort direction for this column.
				if (lvwColumnSorter.Order == SortOrder.Ascending)
				{
					lvwColumnSorter.Order = SortOrder.Descending;
				}
				else
				{
					lvwColumnSorter.Order = SortOrder.Ascending;
				}
			}
			else
			{
				// Set the column number that is to be sorted; default to ascending.
				lvwColumnSorter.SortColumn = e.Column;
				lvwColumnSorter.Order = SortOrder.Ascending;
			}

			// Perform the sort with these new sort options.
			this.listView1.Sort();

		}

		private void numericUpDown2_ValueChanged(object sender, EventArgs e)
		{
			currentPage = (int)numericUpDown2.Value;
			if (InvokeRequired)
			{
				Invoke(UpdateText);
			}
			else
			{
				UpdateTextMethod();
			}
		}
		bool test = false;
		private void UpdateTextMethod()
		{
			if (!test)
			{
				test = true;
				return;
			}
			textBox1.Text = wikiCollection.wikiPages[currentPage].text;
			label2.Text = "Title: " + wikiCollection.wikiPages[currentPage].title;
			listView1.Items.Clear();

			listView1.Columns.Clear();
			listView1.Columns.Add("Token");
			listView1.Columns.Add("Stemmed Token");
			listView1.Columns.Add("TF_IDF");
			listView1.Columns.Add("TF");
			listView1.Columns.Add("DF");

			foreach (ColumnHeader column in listView1.Columns)
			{
				column.Width = 100;
			}

			listView1.Columns[0].Width = 150;
			listView1.Columns[1].Width = 150;
			//listView1.Groups.Clear();
			//listView1.Groups.Add(new ListViewGroup("Tokens"));

			foreach (string tokenKey in wikiCollection.wikiPages[currentPage].tf_IDF_Vec.Keys)
			{
				WikiToken token = wikiCollection.wikiPages[currentPage].tf_IDF_Vec[tokenKey];
				ListViewItem item = new ListViewItem(new string[] { token.Token, token.Stemmed, token.TF_IDF.ToString(), token.TF.ToString(), token.DF.ToString() });
				//ListViewItem item = new ListViewItem(listView1.Groups[0]);
				item.Text = token.Token;
				listView1.Items.Add(item);
			}

		}

		private void button3_Click(object sender, EventArgs e)
		{
			treeView1.ExpandAll();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			treeView1.CollapseAll();
		}

		public void AddClustersMethod()
		{
			OutputClusters.Add(new XElement("DistanceMetric", Wiki.WikiPage.metric.ToString()));
			OutputClusters.Add(new XElement("LinkageCriteria", Cluster.criteria.ToString()));
			OutputClusters.Add(new XElement("DistanceMatrixTime", hierarchicalCluster.DistanceMatrixTime.ToString()));
			OutputClusters.Add(new XElement("TotalClusteringTime", hierarchicalCluster.TotalClusteringTime.ToString()));
			OutputClusters.Add(new XElement("AverageClusterIterationTime", hierarchicalCluster.AverageClusterIterationTime.ToString()));
			OutputClusters.Add(new XElement("Iterations", hierarchicalCluster.Iterations.ToString()));
			foreach (Cluster cluster in hierarchicalCluster.clusters)
			{
				TreeNode node = new TreeNode("Cluster");
				AddClustersMethod(node, OutputClusters, cluster);
				treeView1.Nodes.Add(node);
			}

			string datetime = DateTime.Now.ToString();

			datetime = datetime.Replace("/", "-");
			datetime = datetime.Replace(":", "_");

			OutputClusters.Save("Clusters " + datetime + ".xml");

		}
		/*
		public void TreeCleanUp(TreeNode nodes)
		{
			bool nonclusters = false;
			bool clusters = false;
			foreach (TreeNode node in nodes.Nodes)
			{
				if (node.Text == "Clusters")
				{
					clusters = true;
				}
				else
				{
					nonclusters = true;
				}
			}

			i

		}*/

		public void AddClustersMethod(TreeNode node, XElement element, Cluster cluster)
		{
			if (cluster.pages.Count != 0)
			{
				if (cluster.cluster1 != null || cluster.cluster2 != null)
				{
					foreach (Wiki.WikiPage page in cluster.pages)
					{
						TreeNode node3 = new TreeNode(page.title);
						node.Nodes.Add(node3);

						XElement element3 = new XElement("Cluster");
						element3.SetValue(page.title);
						element.Add(element3);
					}
				}
				else
				{
					foreach (Wiki.WikiPage page in cluster.pages)
					{
						node.Text = page.title;
						element.SetValue(page.title);
						element.Name = "Cluster";
						node.NodeFont = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular);
						node.ForeColor = Color.White;
						return;
					}
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
	}
}
