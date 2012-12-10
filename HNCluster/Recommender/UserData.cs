using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recommender
{
    public class UserData
    {
        public string userName;
        public List<string> likedPages;

        public UserData()
        {
            userName = "";
            likedPages = new List<string>();
        }

        public UserData(string name)
        {
            userName = name;
            likedPages = new List<string>();
        }
    }
}
