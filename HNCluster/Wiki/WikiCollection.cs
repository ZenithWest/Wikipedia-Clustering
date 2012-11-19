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

	}
}
