using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Clustering;
using Wiki;

namespace UIControlLibrary
{
	public partial class PageDisplay : UserControl
	{
		public HierarchicalCluster HAC;

		public PageDisplay()
		{
			InitializeComponent();
		}

		public void InitializePageDisplay(HierarchicalCluster hac) {
			HAC = hac;
		}

		public void LoadPage(WikiPage page)
		{
			//webBrowser1.Url = new Uri(http://en.wikipedia.org/w/api.php)
			webBrowser1.Url = new Uri("http://en.wikipedia.org/wiki/" + page.title);
			//webBrowser1.Url = new Uri("http://en.wikipedia.org/wiki/" + ConvertTitle(page.title));
			//new UriBuilder()
		}

		public void LoadPage(string title)
		{
			webBrowser1.Url = new Uri("http://en.wikipedia.org/wiki/" + title);
		}

		private string ConvertTitle(string title) {
			title = title.Replace(" ", "%20");
			title = title.Replace("\"", "%20");
			title = title.Replace("%", "%20");
			title = title.Replace("-", "%20");
			title = title.Replace(".", "%20");
			title = title.Replace("<", "%20");
			title = title.Replace(">", "%20");
			title = title.Replace("\\", "%20");
			title = title.Replace("^", "%20");
			title = title.Replace(" ", "%20");
			return title;
		}
	}
}
