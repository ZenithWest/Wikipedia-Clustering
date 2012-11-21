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
		public HashSet<string> tokenKeys = new HashSet<string>();
		public WikiPage page = null;
		public Dictionary<string, double> tfIDF_Vec;

		public ILinkageCriteria criteria = new SingleLinkageCriteria();

		public Cluster()
		{
			tfIDF_Vec = new Dictionary<string, double>();
		}

		public Cluster(WikiPage pg)
		{
			page = pg;
			tfIDF_Vec = new Dictionary<string, double>();
			pages.Add(pg);
			foreach(string tokenkey in page.tfIDF_Vec.Keys) {
				tfIDF_Vec[tokenkey] = page.tfIDF_Vec[tokenkey];
			}
		}

		public Cluster(Cluster c1, Cluster c2)
		{
			cluster1 = c1;
			cluster2 = c2;

			pages.AddRange(c1.pages);
			pages.AddRange(c2.pages);

			tokenKeys.UnionWith(c1.tokenKeys);
			tokenKeys.UnionWith(c2.tokenKeys);
		}

		public double GetDistance(Cluster cluster)
		{
			return criteria.GetDistance(this, cluster);
		}

		public bool Compare(double dist1, double dist2)
		{
			return criteria.Compare(dist1, dist2);
		}



		public double Magnitude()
		{
			double magnitude = 0.0;

			foreach (string tokenKey in tfIDF_Vec.Keys)
			{
				magnitude += tfIDF_Vec[tokenKey] * tfIDF_Vec[tokenKey];
			}

			return Math.Sqrt(magnitude);
		}
	}
}
