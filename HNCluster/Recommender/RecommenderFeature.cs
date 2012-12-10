using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

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

        public void createNewFile(string username)
        {

            string curDirectory = System.IO.Directory.GetCurrentDirectory() + "\\";
            XmlSerializer serializer = new XmlSerializer(typeof(UserData));
            TextWriter tw = null;
            UserData dummyData = new UserData(username);

            try
            {
                tw = new StreamWriter(curDirectory + username + ".xml", true);
                serializer.Serialize(tw, dummyData);
            }
            catch (Exception ex)
            {
                tw.Close();
                throw ex;
            }

            tw.Close();

        }

        public void saveUserData()
        {
            string curDirectory = System.IO.Directory.GetCurrentDirectory() + "\\";

            XmlSerializer serializer = new XmlSerializer(typeof(UserData));
            TextWriter tw = null;

            try
            {
                tw = new StreamWriter(curDirectory + userData.userName + ".xml");
                serializer.Serialize(tw, userData);
            }
            catch (Exception ex)
            {
                tw.Close();
                throw ex;
            }

            tw.Close();

        }

        public void loadUserData(string username)
        {

            string curDirectory = System.IO.Directory.GetCurrentDirectory() + "\\";
            string curFile = curDirectory + username + ".xml";

            if (File.Exists(curFile))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(UserData));
                TextReader tr = null;

                UserData ud = new UserData();

                try
                {
                    tr = new StreamReader(curFile);
                    ud = (UserData)serializer.Deserialize(tr);
                }
                catch (Exception ex)
                {
                    tr.Close();
                    throw ex;
                }

                tr.Close();

                userData = ud;
            }
            else
            {
                createNewFile(username);
            }
        }
    }
}
