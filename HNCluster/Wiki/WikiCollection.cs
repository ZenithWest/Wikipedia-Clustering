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
			inverseTokens = new Dictionary<string, int>(1000000);
			wikiPages = new List<WikiPage>(20000);
		}

		public void ParseXML(string path)
		{
			XElement wikipedia = XElement.Load(path);
			XNamespace nspace = wikipedia.GetDefaultNamespace();
			XName name = nspace + "page";
			foreach (XElement page in wikipedia.Elements(name))
			{
				string title = page.Element(page.GetDefaultNamespace() + "title").Value;
				string ns = page.Element(page.GetDefaultNamespace() + "ns").Value;
				//if (title.StartsWith("Template:")) continue;
				//if (title.StartsWith("Portal:")) continue;
				//if (title.StartsWith("Category:")) continue;
				//if (title.StartsWith("User:")) continue;
				//if (title.StartsWith("Wikipedia talk:")) continue;
				//if (title.StartsWith("File:")) continue;
				XElement revision = page.Element(page.GetDefaultNamespace() + "revision");
				string text = revision.Element(revision.GetDefaultNamespace() + "text").Value;
				if (text.StartsWith("#REDIRECT")) continue;

				if (ns != "0") continue;
				bool test = false;
				foreach (WikiPage wpage in wikiPages)
				{
					if (wpage.title == title)
					{
						test = true; break;
					}
				}
				if (test) continue;

				wikiPages.Add(new WikiPage(page));
			}
			
			int i = 0;
			i++;
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
				if (!char.IsLetter(ch) )//&& ch != '\'' )
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
				temp = Regex.Replace(temp, @"[^\u0000-\u007F]", " ");
				//temp = Regex.Replace(temp, @"<math>.*</math>", " ");
				//temp = Regex.Replace(temp, @"<ref>.*</ref>", " ");
				//temp = Regex.Replace(temp, @"<source.*</source>", " ");
				temp = temp.Replace("\'\'", " ");
				temp = temp.Replace(" \'", " ");
				temp = temp.Replace("\' ", " ");
				string[] tokenStrings = temp.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
				//string[] tokenStrings = page.text.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
				foreach (string tokenString in tokenStrings)
				{
					string stem = stemmer.stemTerm(tokenString).ToLower();
					if (page.tf_IDF_Vec.ContainsKey(stem))
					{
						++page.tf_IDF_Vec[stem].TF;
					}
					else
					{
						page.tf_IDF_Vec[stem] = new WikiToken(tokenString, stem);
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
				float squaredSummed = 0;
				//float summed = 0;
				foreach (string token in page.tf_IDF_Vec.Keys )
				{
					WikiToken wikiToken = page.tf_IDF_Vec[token];
					wikiToken.DF = inverseTokens[wikiToken.Stemmed];
					wikiToken.TF_IDF = (float)(1 + Math.Log((float)wikiToken.TF, 2)) * (float)Math.Log((float)wikiPages.Count / wikiToken.DF, 2);
					squaredSummed += wikiToken.TF_IDF * wikiToken.TF_IDF;
					//summed += wikiToken.TF_IDF;
				}

				float magnitude = (float)Math.Sqrt(squaredSummed);
				foreach (string token in page.tf_IDF_Vec.Keys)
				{
					WikiToken wikiToken = page.tf_IDF_Vec[token];
					wikiToken.TF_IDF /= magnitude;
					//wikiToken.TF_IDF /= summed;
				}
			}
		}


	}
}
