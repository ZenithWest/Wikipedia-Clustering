using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki;
using Clustering;

namespace Recommender
{
    public class UserData
    {
        public string userName;
        public List<string> likedPages;
        public List<WikiPage> likedWikiPages;
        public Cluster likedPagesCluster;

        public UserData()
        {
            userName = "";
            likedPages = new List<string>();
            likedWikiPages = new List<WikiPage>();
            likedPagesCluster = new Cluster();
        }

        public UserData(string name)
        {
            userName = name;
            likedPages = new List<string>();
            likedWikiPages = new List<WikiPage>();
            likedPagesCluster = new Cluster();
        }
    }
}
