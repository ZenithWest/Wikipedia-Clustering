using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Xml;
using System.Xml.Linq;
using DotNetWikiBot;

using PorterStemmerAlgorithm;
using System.Text.RegularExpressions;

namespace Wiki
{
	public class WikiCollection
	{
		public Dictionary<string, int> inverseTokens;
		public List<WikiPage> wikiPages;

		public WikiCollection()
		{
			inverseTokens = new Dictionary<string, int>();
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


		public void LoadFromPageList(PageList pageList)
		{
			foreach (Page page in pageList)
			{
				wikiPages.Add(new WikiPage(page));
			}
		}

		public void ExtractTokens()
		{
			string str = "";
			for (int i = 0; i < 256; ++i)
			{
				char ch = (char)i;
				if (!char.IsLetter(ch) && ch != '\'' )
				{
					str += ch;
				}
			}
			char[] delimiterChars = str.ToCharArray();

			PorterStemmer stemmer = new PorterStemmer();

			foreach (WikiPage page in wikiPages)
			{
				string temp = page.text;/*
				bool test = false;
				foreach (char ch in page.text)
				{
					if (char.GetNumericValue(ch) < 256)
					{
						temp += ch;
						test = false;
					}
					else
					{
						if (!test)
						{
							temp += ' ';
							test = true;
						}
					}
				}*/
				//temp = Regex.Replace(page.text, @"[^\u0000-\u007F]", " ");
				//temp = Regex.Replace(page.text, @"<math>.*</math>", " ");
				//temp = Regex.Replace(page.text, @"<ref>.*</ref>", " ");
				//temp = Regex.Replace(page.text, @"<source.*</source>", " ");
				temp = temp.Replace("\'\'", " ");
				temp = temp.Replace(" \'", " ");
				temp = temp.Replace("\' ", " ");
				string[] tokenStrings = temp.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
				//string[] tokenStrings = page.text.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
				foreach (string tokenString in tokenStrings)
				{
					string stem = stemmer.stemTerm(tokenString).ToLower();
					if (page.TF_IDF_Vector.ContainsKey(stem))
					{
						++page.TF_IDF_Vector[stem].TF;
					}
					else
					{
						page.TF_IDF_Vector[stem] = new WikiToken(tokenString, stem);
						if (inverseTokens.ContainsKey(stem))
						{
							++inverseTokens[stem];
						}
						else
						{
							inverseTokens[stem] = 1;
						}
					}
				}
			}

			foreach (WikiPage page in wikiPages)
			{
				double squaredSummed = 0;
				//double summed = 0;
				foreach (string token in page.TF_IDF_Vector.Keys )
				{
					WikiToken wikiToken = page.TF_IDF_Vector[token];
					wikiToken.DF = inverseTokens[wikiToken.Stemmed];
					wikiToken.TF_IDF = (1+ Math.Log((double)wikiToken.TF, 2)) * Math.Log((double)wikiPages.Count / wikiToken.DF, 2);
					squaredSummed += wikiToken.TF_IDF * wikiToken.TF_IDF;
					//summed += wikiToken.TF_IDF;
				}

				double magnitude = Math.Sqrt(squaredSummed);
				foreach (string token in page.TF_IDF_Vector.Keys)
				{
					WikiToken wikiToken = page.TF_IDF_Vector[token];
					wikiToken.TF_IDF /= magnitude;
					//wikiToken.TF_IDF /= summed;
				}
			}
		}


	}
}
