﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki;

namespace Recommender
{
    public class UserData
    {
        public string userName;
        public List<string> likedPages;
        public List<WikiPage> likedWikiPages;
        public TF_IDF_Vector likedPagesCentroid;

        public UserData()
        {
            userName = "";
            likedPages = new List<string>();
            likedWikiPages = new List<WikiPage>();
            likedPagesCentroid = new TF_IDF_Vector();
        }

        public UserData(string name)
        {
            userName = name;
            likedPages = new List<string>();
            likedWikiPages = new List<WikiPage>();
            likedPagesCentroid = new TF_IDF_Vector();
        }
    }
}
