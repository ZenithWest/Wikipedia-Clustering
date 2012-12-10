using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recommender
{
    public class RecommenderFeature
    {
        public UserData userData;

        public RecommenderFeature()
        {
            userData = new UserData();
        }

        public void userAuthenticated(string username)
        {
            userData.userName = username;
        }

        public void userViewedPage(string pagename)
        {
            userData.likedPages.Add(pagename);
        }
    }
}
