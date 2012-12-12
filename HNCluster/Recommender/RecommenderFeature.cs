using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using Wiki;

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
            loadUserData(username);
            //userData.userName = username;
        }

        public void userViewedPage(string pagename)
        {
            userData.likedPages.Add(pagename);
            saveUserData();
        }

        public void userViewedPage(WikiPage page)
        {
            userData.likedWikiPages.Add(page);
            userData.likedPagesCluster.AddPage(page);
            saveUserData();
        }

        public List<WikiPage> generateRecommendations(List<WikiPage> allWikiPages)
        {
            clusterUsersPages();

            CosineSimilarity cSimilarity = new CosineSimilarity();
            Dictionary<string, float> pageDistances = new Dictionary<string, float>(allWikiPages.Count);
            List<WikiPage> recommendedPages = new List<WikiPage>();

            foreach (WikiPage page in allWikiPages)
            {
                // If the WikiPage is one that the user like's, no need to calculate distance
                if (userData.likedWikiPages.Find(WikiPage => WikiPage.title == page.title) == null)
                {
						 if (!pageDistances.ContainsKey(page.title))
						 {
							 pageDistances.Add(page.title, cSimilarity.GetDistance(userData.likedPagesCluster.tf_IDF_Vec, page.tf_IDF_Vec));
						 }
                }
            }

            var sortedDict = pageDistances.OrderByDescending(x => x.Value).Take(20);

            foreach(var item in sortedDict)
            {
                recommendedPages.Add(allWikiPages.Find(WikiPage => WikiPage.title == item.Key));
            }

            return recommendedPages;
        }

        private void clusterUsersPages()
        {
            if (userData.likedWikiPages.Count > 1)
            {
                // Clear the conents of the cluster to prepare for clustering
                userData.likedPagesCluster.pages.Clear();
                userData.likedPagesCluster.AllPagesInCluster.Clear();

                userData.likedPagesCluster.AddPages(userData.likedWikiPages);
            }
        }

        public void createNewFile(string username)
        {

            string curDirectory = System.IO.Directory.GetCurrentDirectory() + "\\";
            var serializer = new DataContractSerializer(typeof(UserData));
            UserData dummyData = new UserData(username);

            using (var sw = new StringWriter())
            {
                using (var writer = new FileStream(curDirectory + username + ".xml", FileMode.CreateNew, FileAccess.Write))
                {
                    serializer.WriteObject(writer, dummyData);
                    writer.Flush();
                }
            }


        }

        public void saveUserData()
        {
            string curDirectory = System.IO.Directory.GetCurrentDirectory() + "\\";

            var serializer = new DataContractSerializer(typeof(UserData));

            using (var sw = new StringWriter())
            {
                using (var writer = new FileStream(curDirectory + userData.userName + ".xml", FileMode.Open, FileAccess.Write))
                {
                    serializer.WriteObject(writer, userData);
                    writer.Flush();
                }
            }

        }

        public void loadUserData(string username)
        {

            string curDirectory = System.IO.Directory.GetCurrentDirectory() + "\\";
            var serializer = new DataContractSerializer(typeof(UserData));
            string curFile = curDirectory + username + ".xml";

            if (File.Exists(curFile))
            {
                using (var sr = new StringReader(curDirectory + username + ".xml"))
                {
                    using (var reader = new FileStream(curFile, FileMode.Open, FileAccess.Read))
                    {
                        userData = (UserData)serializer.ReadObject(reader);
                        reader.Close();
                    }
                }
            }
            else
            {
                createNewFile(username);
            }
        }
    }
}
