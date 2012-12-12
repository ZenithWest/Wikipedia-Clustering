using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wiki;

namespace UIControlLibrary
{
    public partial class RecommenderDisplay : UserControl
    {

        public bool userLoggedOn;


        public RecommenderDisplay()
        {
            InitializeComponent();
            userLoggedOn = false;
        }

        public void userLoggedIn(string username)
        {
            userLoggedOn = true;
            this.txtBoxUsername.Text = username;
            this.groupBox1.Enabled = true;
        }

        public void updateLikedPages(List<WikiPage> pageList)
        {
            listBoxLikedPages.Items.Clear();

            for (int i = 0; i < pageList.Count; i++)
            {
                listBoxLikedPages.Items.Add(pageList[i].title);
            }

        }

        public void updateUserRecommendations(List<WikiPage> pageList)
        {
            listBoxRecommendedPages.Items.Clear();

            for (int i = 0; i < pageList.Count; i++)
            {
                listBoxRecommendedPages.Items.Add(pageList[i].title);
            }

        }

    }
}
