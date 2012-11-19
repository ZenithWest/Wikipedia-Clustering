using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaWikiEngine;
using MediaWikiEngine.Command;
using MediaWikiEngine.Domain;
using MediaWikiEngine.Language;

using DotNetWikiBot;
using System.Threading;
using System.Threading.Tasks;

using Wiki;

namespace HNCluster
{
	public partial class Form1 : Form
	{
		public delegate void IncrementPagesLoadedDelegate();
		public IncrementPagesLoadedDelegate IncrementPagesLoaded;

		public delegate void IncrementPagesLoadedByValDelegate(int n);
		public IncrementPagesLoadedByValDelegate IncrementPagesLoadedByVal;

		public delegate void CheckSiteLoadedDelegate();
		public CheckSiteLoadedDelegate CheckSiteLoaded;

		public delegate void CheckPageTitlesLoadedDelegate();
		public CheckPageTitlesLoadedDelegate CheckTitlesLoaded;

		public delegate void CheckTokenizedDelegate();
		public CheckTokenizedDelegate CheckTokenized;

		public delegate void AddPageTextDelegate(Page page);
		public AddPageTextDelegate AddPageText;

		bool pressed = false;
		int currentPage = 0;
		PageList pageList;
		Site site;
		int pagesLoaded = 0;

		string[] titlesList;

		WikiCollection wikiCollection;

		public Form1()
		{
			InitializeComponent();
			wikiCollection = new WikiCollection();

			IncrementPagesLoaded = new IncrementPagesLoadedDelegate(IncrementPagesLoadedMethod);
			IncrementPagesLoadedByVal = new IncrementPagesLoadedByValDelegate(IncrementPagesLoadedByValMethod);
			CheckSiteLoaded = new CheckSiteLoadedDelegate(CheckSiteLoadedMethod);
			CheckTitlesLoaded = new CheckPageTitlesLoadedDelegate(CheckPageTitlesLoadedMethod);
			CheckTokenized = new CheckTokenizedDelegate(CheckTokenizedMethod);
			AddPageText = new AddPageTextDelegate(AddPageTextMethod);
			//Task.Factory.StartNew(LoadPages);
			Task.Factory.StartNew(LoadWikipediaXML);


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
			wikiCollection.ParseXML();
			Invoke(IncrementPagesLoadedByVal, wikiCollection.wikiPages.Count);
			pagesLoaded += wikiCollection.wikiPages.Count;
			wikiCollection.ExtractTokens();
			Invoke(CheckTokenized);
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
			Invoke(CheckTitlesLoaded);
			wikiCollection.ExtractTokens();
			Invoke(CheckTokenized);
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
				textBox1.Text = wikiCollection.wikiPages[currentPage].text;
				label2.Text = "Title: " + wikiCollection.wikiPages[currentPage].title;
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
				textBox1.Text = wikiCollection.wikiPages[currentPage].text;
				label2.Text = "Title: " + wikiCollection.wikiPages[currentPage].title;
				listView1.Items.Clear();
				
				listView1.Columns.Clear();
				listView1.Columns.Add("Token");
				listView1.Columns.Add("TF_IDF");
				listView1.Columns.Add("TF");
				listView1.Columns.Add("DF");
				
				foreach (ColumnHeader column in listView1.Columns)
				{
					column.Width = 100;
				}

				listView1.Columns[0].Width = 300;
				//listView1.Groups.Clear();
				//listView1.Groups.Add(new ListViewGroup("Tokens"));

				foreach (string tokenKey in wikiCollection.wikiPages[currentPage].TF_IDF_Vector.Keys)
				{
					WikiToken token = wikiCollection.wikiPages[currentPage].TF_IDF_Vector[tokenKey];
				ListViewItem item = new ListViewItem(new string[] {token.Token, token.TF_IDF.ToString(), token.TF.ToString(), token.DF.ToString()});
				//ListViewItem item = new ListViewItem(listView1.Groups[0]);
				item.Text = token.Token;
				listView1.Items.Add(item);
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
	}
}
