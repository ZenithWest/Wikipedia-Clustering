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

        public Form1()
        {
            InitializeComponent();
            IncrementPagesLoaded = new IncrementPagesLoadedDelegate(IncrementPagesLoadedMethod);
            CheckSiteLoaded = new CheckSiteLoadedDelegate(CheckSiteLoadedMethod);
            CheckTitlesLoaded = new CheckPageTitlesLoadedDelegate(CheckPageTitlesLoadedMethod);

            /*
            WikiConnection wiki = new WikiConnection("localhost");
            
            GetPage page = new GetPage(wiki, "", "List of trigonometric identities");
            CommandResult result = page.Execute();*/

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(LoadPages);
        }

        void LoadPages()
        {
            Site site = new Site("http://localhost/index.php/", "ZenithBot", "Bot");
            Invoke(CheckSiteLoaded);
            PageList pageList = new PageList(site);
            pageList.FillFromAllPages("", 0, false, 2);
            Invoke(CheckTitlesLoaded);
            foreach (Page page in pageList)
            {
                page.Load();
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
    }
}
