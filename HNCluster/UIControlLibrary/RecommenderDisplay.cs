﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        public void updateLikedPages(List<string> pageList)
        {
            listBoxLikedPages.Items.Clear();

            for (int i = 0; i < pageList.Count; i++)
            {
                listBoxLikedPages.Items.Add(pageList[i]);
            }

            //listBoxLikedPages.Items.Add(listView.SelectedItems[0].Text);

        }


    }
}
