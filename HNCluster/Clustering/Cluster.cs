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
		public List<WikiPage> pages = new List<WikiPage>();
		//public HashSet<string> tokenKeys = new HashSet<string>();
		public WikiPage page = null;
		public string SVGNodeName = "";
		//public Dictionary<string, float> tfIDF_Vec;

		public static ILinkageCriteria criteria = new CompleteLinkageCriteria();
		//public static ILinkageCriteria criteria = new AverageLinkageCriteria();
		//public static ILinkageCriteria criteria = new SingleLinkageCriteria();
		//public float MeanDistance = 0;

		public Cluster()
		{
			//tfIDF_Vec = new Dictionary<string, float>();
		}

		public Cluster(WikiPage pg)
		{
			page = pg;
			pages.Add(pg);
			/*
			tfIDF_Vec = new Dictionary<string, float>();
			foreach(string tokenkey in page.tf_IDF_Vec.Keys) {
				tfIDF_Vec[tokenkey] = page.tf_IDF_Vec[tokenkey];
			}*/
		}

		public Cluster(Cluster c1, Cluster c2)
		{
			cluster1 = c1;
			cluster2 = c2;

			pages.AddRange(c1.pages);
			pages.AddRange(c2.pages);

			//tokenKeys.UnionWith(c1.tokenKeys);
			//tokenKeys.UnionWith(c2.tokenKeys);
		}

		public Cluster(Cluster c1, Cluster c2, float [,] DistanceMatrix)
		{
			cluster1 = c1;
			cluster2 = c2;

			pages.AddRange(c1.pages);
			pages.AddRange(c2.pages);



			//tokenKeys.UnionWith(c1.tokenKeys);
			//tokenKeys.UnionWith(c2.tokenKeys);
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
