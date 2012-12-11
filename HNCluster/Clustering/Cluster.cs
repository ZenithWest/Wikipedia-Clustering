using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Wiki;

namespace Clustering
{
	public class Cluster
	{
		public Cluster cluster1 = null;
		public Cluster cluster2 = null;
		public List<WikiPage> AllPagesInCluster = new List<WikiPage>();
		//public HashSet<string> tokenKeys = new HashSet<string>();
		public List<WikiPage> pages = new List<WikiPage>();
		public bool leaf = false;
		public string SVGNodeName = "";
		public TF_IDF_Vector tf_IDF_Vec = new TF_IDF_Vector();

		public static ILinkageCriteria criteria = new CompleteLinkageCriteria();
		//public static ILinkageCriteria criteria = new AverageLinkageCriteria();
		//public static ILinkageCriteria criteria = new SingleLinkageCriteria();
		//public float MeanDistance = 0;

		public Cluster()
		{

		}

		public Cluster(WikiPage page)
		{
			pages.Add(page);
			AllPagesInCluster.Add(page);
			leaf = true;

			AddTokensFrom(page);
		}

		public Cluster(Cluster c1, Cluster c2)
		{
			cluster1 = c1;
			cluster2 = c2;

			AllPagesInCluster.AddRange(c1.AllPagesInCluster);
			AllPagesInCluster.AddRange(c2.AllPagesInCluster);

			AddTokensFrom(c1);
			AddTokensFrom(c2);

			//tokenKeys.UnionWith(c1.tokenKeys);
			//tokenKeys.UnionWith(c2.tokenKeys);
		}

		public Cluster(Cluster c1, Cluster c2, float [,] DistanceMatrix)
		{
			cluster1 = c1;
			cluster2 = c2;

			AllPagesInCluster.AddRange(c1.AllPagesInCluster);
			AllPagesInCluster.AddRange(c2.AllPagesInCluster);

			AddTokensFrom(c1);
			AddTokensFrom(c2);



			//tokenKeys.UnionWith(c1.tokenKeys);
			//tokenKeys.UnionWith(c2.tokenKeys);
		}

		public void AddPage(WikiPage page)
		{
			pages.Add(page);
			AllPagesInCluster.Add(page);
			AddTokensFrom(page);
		}

		public void AddPages(List<WikiPage> pgs)
		{
			pages.AddRange(pgs);
			AllPagesInCluster.AddRange(pgs);
			foreach (WikiPage page in pgs)
			{
				AddTokensFrom(page);
			}
		}

		private void AddTokensFrom(WikiPage page)
		{
			if (tf_IDF_Vec.Count != 0)
			{
				foreach (string tokenkey in page.tf_IDF_Vec.Keys)
				{
					if (tf_IDF_Vec.ContainsKey(tokenkey))
					{
						tf_IDF_Vec[tokenkey].TF_IDF += page.tf_IDF_Vec[tokenkey].TF_IDF;
						tf_IDF_Vec[tokenkey].TF += page.tf_IDF_Vec[tokenkey].TF;
					}
					else
					{
						tf_IDF_Vec[tokenkey] = new WikiToken(page.tf_IDF_Vec[tokenkey]);
					}
				}
			}
			else
			{
				foreach (string tokenkey in page.tf_IDF_Vec.Keys)
				{
					tf_IDF_Vec[tokenkey] = new WikiToken(page.tf_IDF_Vec[tokenkey]);
				}
			}
		}

		private void AddTokensFrom(Cluster cluster)
		{
			if (tf_IDF_Vec.Count != 0)
			{
				foreach (string tokenkey in cluster.tf_IDF_Vec.Keys)
				{
					if (tf_IDF_Vec.ContainsKey(tokenkey))
					{
						tf_IDF_Vec[tokenkey].TF_IDF += cluster.tf_IDF_Vec[tokenkey].TF_IDF;
						tf_IDF_Vec[tokenkey].TF += cluster.tf_IDF_Vec[tokenkey].TF;
					}
					else
					{
						tf_IDF_Vec[tokenkey] = new WikiToken(cluster.tf_IDF_Vec[tokenkey]);
					}
				}
			}
			else
			{
				foreach (string tokenkey in cluster.tf_IDF_Vec.Keys)
				{
					tf_IDF_Vec[tokenkey] = new WikiToken(cluster.tf_IDF_Vec[tokenkey]);
				}
			}
		}

		static public HashSet<string> stopwords = new HashSet<string>(){ 
"the","and","for","that","with","http","thi","from","can","name",
"system","which","first","commun","titl","www","cite","energi",
"categori","not","journal","also","last","year","have","other",
"such","publish","com","book","their","new","page","more","exampl",
"work","volum","gener","mai","when","time","develop","refer","date",
"studi","these","number","thei","but","org","two","url","between",
"all","point","isbn","differ","chang","will","includ","than","there",
"see","web","some","where","form","into","relat","html","term","been",
"onli","issu","natur","valu","mani","doi","right","pdf","most","call",
"through","then","organ","ani","ndash","defin","each","line","need",
"accessd","about","make","align","link","public","were","file","type",
"set","data","edu","often","same","case","part","requir","thumb",
"definit","left","wai","becaus","given","follow","both","how",
"high","like","over","howev","provid","known","well","non","would",
"what","while","posit","list","within","who","thu","allow","show",
"occur","must","found","jpg","three","pdf", "base", "user", "method",
"sourc", "class", "style", "object" };

		private bool IsStopWord(string stem)
		{
			foreach (string s in stopwords)
			{
				if (stem == s) return true;
			}

			/*
			if (stem == "the" || stem == "and" || stem == "for" ||
				stem == "that" || stem == "with" || stem == "http" ||
				stem == "thi" || stem == "from" || stem == "can" ||
				stem == "name" || stem == "which" || stem == "commun" ||
				stem == "titl" || stem == "www" || stem == "cite" ||
				stem == "not" || stem == "com" || stem == "journal" ||
				stem == "system" || stem == "first" || stem == "categori" ||
				stem == "also" || stem == "last" || stem == "have" ||
				stem == "other" || stem == "year" || stem == "book" ||
				stem == "publisher" || stem == "volume" )
				return true;*/

			return false;
		}

		public List<string> TopTokens(int N = 3, bool StemmedVersion = false, bool RemoveStopWords = true)
		{
			List<float> tokenMax = new List<float>();
			List<string> tokens = new List<string>();

			for (int i = 0; i < N; ++i)
			{
				tokenMax.Add(float.MinValue);
				tokens.Add("Cluster");
			}

			foreach (string tokenkey in tf_IDF_Vec.Keys)
			{
				if (RemoveStopWords)
				{
					if (IsStopWord(tokenkey)) continue;
				}
				for (int k = 0; k < N; ++k)
				{
					if (tokenMax[k] <= tf_IDF_Vec[tokenkey].TF)
					{
						for (int i = N-1; i > k; --i)
						{
							tokenMax[i] = tokenMax[i - 1];
							tokens[i] = tokens[i - 1];
						}
						tokenMax[k] = tf_IDF_Vec[tokenkey].TF;
						if (StemmedVersion)
						{
							tokens[k] = tf_IDF_Vec[tokenkey].Stemmed;
						}
						else
						{
							tokens[k] = tf_IDF_Vec[tokenkey].Token;
						}
						break;
					}
				}
			}

			for (int i = 0; i < N; ++i)
			{
				if (tokenMax[i] == float.MinValue)
				{
					tokens.RemoveRange(i, N - i);
					break;
				}
			}

			return tokens;
		}

		public float GetDistance(Cluster cluster)
		{
			return criteria.GetDistance(this, cluster);
		}

		public float GetDistance(Cluster cluster, float[,] DistanceMatrix)
		{
			return criteria.GetDistance(this, cluster, DistanceMatrix);
		}

		public bool Compare(float dist1, float dist2)
		{
			return criteria.Compare(dist1, dist2);
		}


		/*
		public float Magnitude()
		{
			float magnitude = 0;

			foreach (string tokenKey in tfIDF_Vec.Keys)
			{
				magnitude += tfIDF_Vec[tokenKey] * tfIDF_Vec[tokenKey];
			}

			return (float)Math.Sqrt(magnitude);
		}*/
	}
}
