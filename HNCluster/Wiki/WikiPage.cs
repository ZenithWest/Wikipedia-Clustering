using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DotNetWikiBot;

namespace Wiki
{
    public class WikiPage
    {
		 public string title = "";
		 public string ns = "";
		 public long id = 0;
		 public long revid = 0;
		 public long parentid = 0;
		 public DateTime timestamp;
		 public string text;
		 public string model;
		 public string format;


		 public WikiToken[] TD_IDF_Vector;
		 public Page page;

		 public WikiPage(Page pg)
		 {
			 page = pg;

			 if (page.text == null || page.text == "")
			 {
				page.Load();
			 }

			 TD_IDF_Vector = WikiParser.Parse(this);
		 }

		 public WikiPage(XElement page)
		 {
			 title = page.Element(page.GetDefaultNamespace() + "title").Value;
			 ns = page.Element(page.GetDefaultNamespace() + "ns").Value;
			 id = long.Parse(page.Element(page.GetDefaultNamespace() + "id").Value);

			 XElement revision = page.Element(page.GetDefaultNamespace() + "revision");
			 revid = long.Parse(revision.Element(revision.GetDefaultNamespace() + "id").Value);
			 try { parentid = long.Parse(revision.Element(revision.GetDefaultNamespace() + "parentid").Value); }
			 catch { }
			 timestamp = DateTime.Parse(revision.Element(revision.GetDefaultNamespace() + "timestamp").Value);
			 text = revision.Element(revision.GetDefaultNamespace() + "text").Value;
		 }
    }
}
