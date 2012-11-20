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


		 public Dictionary<string, WikiToken> TF_IDF_Vector;
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

			 TF_IDF_Vector = new Dictionary<string, WikiToken>();
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
			 TF_IDF_Vector = new Dictionary<string, WikiToken>();

			 //this.page = new Page();
			 
		 }

		 public double Cosine(WikiPage page)
		 {
			 return Cosine(TF_IDF_Vector, page.TF_IDF_Vector);
		 }
		 public static double Cosine(Dictionary<string, WikiToken> vec1, Dictionary<string, WikiToken> vec2)
		 {
			 double cosine = 0.0;
			 foreach (string tokenKey in vec1.Keys)
			 {
				 if (vec2.ContainsKey(tokenKey)) {
					 cosine += vec1[tokenKey].TF_IDF * vec2[tokenKey].TF_IDF;
				 }
			 }

			 return cosine;
		 }



		 public double EuclideanDistance(WikiPage page)
		 {
			 return EuclideanDistance(TF_IDF_Vector, page.TF_IDF_Vector);
		 }
		 public static double EuclideanDistance(Dictionary<string, WikiToken> vec1, Dictionary<string, WikiToken> vec2)
		 {
			 return Math.Sqrt(SquaredEuclideanDistance(vec1, vec2));
		 }


		 public double SquaredEuclideanDistance(WikiPage page)
		 {
			 return SquaredEuclideanDistance(TF_IDF_Vector, page.TF_IDF_Vector);
		 }
		 public static double SquaredEuclideanDistance(Dictionary<string, WikiToken> vec1, Dictionary<string, WikiToken> vec2)
		 {
			 double euclidean = 0.0;

			 List<string> tokenKeys = vec1.Keys.ToList<string>();
			 tokenKeys.AddRange(vec2.Keys.ToList<string>());

			 foreach (string tokenKey in tokenKeys)
			 {
				 double value1 = vec1.ContainsKey(tokenKey) ? vec1[tokenKey].TF_IDF : 0.0;
				 value1 -= vec2.ContainsKey(tokenKey) ? vec2[tokenKey].TF_IDF : 0.0;
				 value1 *= value1;
				 euclidean += value1;
			 }

			 return euclidean;
		 }


		 public double ManhattanDistance(WikiPage page)
		 {
			 return ManhattanDistance(TF_IDF_Vector, page.TF_IDF_Vector);
		 }
		 public static double ManhattanDistance(Dictionary<string, WikiToken> vec1, Dictionary<string, WikiToken> vec2)
		 {
			 double manhattan = 0.0;

			 List<string> tokenKeys = vec1.Keys.ToList<string>();
			 tokenKeys.AddRange(vec2.Keys.ToList<string>());

			 foreach (string tokenKey in tokenKeys)
			 {
				 double value1 = vec1.ContainsKey(tokenKey) ? vec1[tokenKey].TF_IDF : 0.0;
				 value1 -= vec2.ContainsKey(tokenKey) ? vec2[tokenKey].TF_IDF : 0.0;
				 manhattan += Math.Abs(value1);
			 }

			 return manhattan;
		 }


		 public double MaximumDistance(WikiPage page)
		 {
			 return MaximumDistance(TF_IDF_Vector, page.TF_IDF_Vector);
		 }
		 public static double MaximumDistance(Dictionary<string, WikiToken> vec1, Dictionary<string, WikiToken> vec2)
		 {
			 double maximum = 0.0;

			 List<string> tokenKeys = vec1.Keys.ToList<string>();
			 tokenKeys.AddRange(vec2.Keys.ToList<string>());

			 foreach (string tokenKey in tokenKeys)
			 {
				 double value1 = vec1.ContainsKey(tokenKey) ? vec1[tokenKey].TF_IDF : 0.0;
				 value1 -= vec2.ContainsKey(tokenKey) ? vec2[tokenKey].TF_IDF : 0.0;
				 value1 = Math.Abs(value1);

				 if (value1 > maximum)
				 {
					 maximum = value1;
				 }
			 }

			 return maximum;
		 }

		 public double Magnitude()
		 {
			 double magnitude = 0.0;

			 foreach (string tokenKey in TF_IDF_Vector.Keys)
			 {
				 magnitude += TF_IDF_Vector[tokenKey].TF_IDF * TF_IDF_Vector[tokenKey].TF_IDF;
			 }

			 return Math.Sqrt(magnitude);
		 }
    }
}
