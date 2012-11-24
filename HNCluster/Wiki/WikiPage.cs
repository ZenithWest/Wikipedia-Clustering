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
		public int ns = 0;
		public long id = 0;
		//public long revid = 0;
		//public long parentid = 0;
		public DateTime timestamp;
		public string text;
		public string model;
		public string format;

		//public static IDistanceMetric metric = new CosineSimilarity();
		//public static IDistanceMetric metric = new CosineSimilarity();
		public static IDistanceMetric metric = new CosineSimilarity();
		//public static IDistanceMetric metric = new EuclideanDistance();



		public TF_IDF_Vector tf_IDF_Vec;
		public Page page;

		public WikiPage(Page pg)
		{
			page = pg;

			if (page.text == null || page.text == "")
			{
				page.Load();
			}

			title = page.text;
			ns = 0;
			id = long.Parse(page.pageID);

			//revid = long.Parse(page.lastRevisionID);
			//try { parentid = long.Parse(page.lastUserID); }
			//catch { }
			timestamp = page.timestamp;
			text = page.text;

			tf_IDF_Vec = new TF_IDF_Vector();
		}

		public WikiPage(XElement page)
		{
			title = page.Element(page.GetDefaultNamespace() + "title").Value;
			ns = int.Parse(page.Element(page.GetDefaultNamespace() + "ns").Value);
			id = long.Parse(page.Element(page.GetDefaultNamespace() + "id").Value);

			XElement revision = page.Element(page.GetDefaultNamespace() + "revision");
			//revid = long.Parse(revision.Element(revision.GetDefaultNamespace() + "id").Value);
			//try { parentid = long.Parse(revision.Element(revision.GetDefaultNamespace() + "parentid").Value); }
			//catch { }
			timestamp = DateTime.Parse(revision.Element(revision.GetDefaultNamespace() + "timestamp").Value);
			text = revision.Element(revision.GetDefaultNamespace() + "text").Value;
			text = text.Replace("\n", "\r\n");
			tf_IDF_Vec = new TF_IDF_Vector();

			//this.page = new Page();

		}

		public float GetDistance(WikiPage page)
		{
			return metric.GetDistance(tf_IDF_Vec, page.tf_IDF_Vec);
		}

		public bool Compare(float dist1, float dist2)
		{
			return metric.Compare(dist1, dist2);
		}
	}
}
