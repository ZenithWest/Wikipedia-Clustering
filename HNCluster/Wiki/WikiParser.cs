using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DotNetWikiBot;

namespace Wiki
{


	class WikiParser
	{
		// I'll work this out later - Brandon West
		static public string[] Parse(string text)
		{
			string[] tokenList = new string[5];
			for (int i = 0; i < 5; ++i)
			{
				tokenList[i] = new string(new char[]{(char)(i+'A'), (char)(i+'A'), (char)(i+'A')});
			}
			return tokenList;
		}

		static public WikiToken[] Parse(WikiPage wikipage)
		{
			if (wikipage.page.text == null || wikipage.page.text == "")
			{
				wikipage.page.Load();
			}

			string[] tokenList = Parse(wikipage.page.text);
			WikiToken[] TD_IDF_Vector = new WikiToken[tokenList.Length];

			for (int i=0; i<tokenList.Length; ++i)
			{
				TD_IDF_Vector[i] = new WikiToken(tokenList[i]);
				TD_IDF_Vector[i].Count += 1;
				// need to check if already in vector
				// need to increment a global counter
			}
			return TD_IDF_Vector;
		}
	}
}
