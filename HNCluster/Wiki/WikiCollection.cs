using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using DotNetWikiBot;

using PorterStemmerAlgorithm;

namespace Wiki
{
	public class WikiCollection
	{
		public Hashtable tokenTable;
		public List<WikiPage> wikiPages;

		public WikiCollection()
		{
			tokenTable = new Hashtable();
			wikiPages = new List<WikiPage>();
		}

		public void ParseXML()
		{
			XElement wikipedia = XElement.Load("Wikipedia-ComputerScience.xml");
			XNamespace nspace = wikipedia.GetDefaultNamespace();
			XName name = nspace + "page";
			foreach (XElement page in wikipedia.Elements(name))
			{
				wikiPages.Add(new WikiPage(page));
			}
		}
		public void ExtractTokens()
		{
			string str = "";
			for (int i = 0; i < 128; ++i)
			{
				char ch = (char)i;
				if (!char.IsLetter(ch) && ch != '\'') {
					str += ch;
				}
			}
			char[] delimiterChars = str.ToCharArray();

			PorterStemmer stemmer = new PorterStemmer();

			foreach (WikiPage page in wikiPages)
			{
				string[] tokenStrings = page.text.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
				foreach (string tokenString in tokenStrings)
				{
					page.TF_IDF_Vector.Add(new WikiToken(tokenString, stemmer.stemTerm(tokenString)));
				}
			}
		}

	}
}
