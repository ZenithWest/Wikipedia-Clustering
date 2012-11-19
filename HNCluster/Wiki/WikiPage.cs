using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DotNetWikiBot;

namespace Wiki
{
    public class WikiPage
    {
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
    }
}
