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

namespace HNCluster
{
	public partial class Form1 : Form
	{
		public delegate void IncrementPagesLoadedDelegate();
		public IncrementPagesLoadedDelegate IncrementPagesLoaded;

		public delegate void CheckSiteLoadedDelegate();
		public CheckSiteLoadedDelegate CheckSiteLoaded;

		public delegate void CheckPageTitlesLoadedDelegate();
		public CheckPageTitlesLoadedDelegate CheckTitlesLoaded;

		public delegate void AddPageTextDelegate(Page page);
		public AddPageTextDelegate AddPageText;

		bool pressed = false;
		int currentPage = 0;
		PageList pageList;
		Site site;

		public Form1()
		{
			InitializeComponent();
			IncrementPagesLoaded = new IncrementPagesLoadedDelegate(IncrementPagesLoadedMethod);
			CheckSiteLoaded = new CheckSiteLoadedDelegate(CheckSiteLoadedMethod);
			CheckTitlesLoaded = new CheckPageTitlesLoadedDelegate(CheckPageTitlesLoadedMethod);
			AddPageText = new AddPageTextDelegate(AddPageTextMethod);
			Task.Factory.StartNew(LoadPages);
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

		void LoadPages()
		{
			site = new Site("http://localhost/index.php/", "ZenithBot", "Bot");
			Invoke(CheckSiteLoaded);

			Page ComputerSciencePage = new Page(site, "Computer science");
			ComputerSciencePage.Load();
			//Invoke(AddPageText, new object[] { ComputerSciencePage.text });

			pageList = new PageList(site);
			pageList.FillFromAllPages("", 0, false, 100000);
			Invoke(CheckTitlesLoaded);
			foreach (Page page in pageList)
			{
				page.Load();
				if (numericUpDown1.Value == 0)
				{
					Invoke(AddPageText, new object[] { pageList[0] });
				}
				Invoke(IncrementPagesLoaded);
				//Application.DoEvents();
			}
			int a = 1;
		}

		public void IncrementPagesLoadedMethod()
		{
			numericUpDown1.Value += 1;
		}

		public void CheckSiteLoadedMethod()
		{
			checkBox1.Checked = true;
		}

		public void CheckPageTitlesLoadedMethod()
		{
			checkBox2.Checked = true;
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
				--currentPage;
				textBox1.Text = pageList[currentPage].text;
				label2.Text = "Title: " + pageList[currentPage].title;
				numericUpDown1.Value = currentPage;
			}
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			if (numericUpDown1.Value > 0 && currentPage < numericUpDown1.Value - 1)
			{
				++currentPage;
				textBox1.Text = pageList[currentPage].text;
				label2.Text = "Title: " + pageList[currentPage].title;
				numericUpDown1.Value = currentPage;
			}
		}
	}
}
