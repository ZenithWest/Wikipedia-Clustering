using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Wiki;

namespace Clustering
{
	public class AverageLinkageCriteria : ILinkageCriteria
	{
		public float GetDistance(Cluster c1, Cluster c2)
		{
			float mean = 0;
			foreach (WikiPage page1 in c1.AllPagesInCluster)
			{
				foreach (WikiPage page2 in c2.AllPagesInCluster)
				{
					mean += page1.GetDistance(page2);
				}
			}

			mean /= c1.AllPagesInCluster.Count * c2.AllPagesInCluster.Count;

			return mean;
		}
		
		public float GetDistance(Cluster c1, Cluster c2, float[,] DistanceMatrix)
		{
			float mean = 0;
			foreach (WikiPage page1 in c1.AllPagesInCluster)
			{
				foreach (WikiPage page2 in c2.AllPagesInCluster)
				{
					mean += DistanceMatrix[page1.id, page2.id];
				}
			}

			mean /= c1.AllPagesInCluster.Count * c2.AllPagesInCluster.Count;

			return mean;
		}

		public bool Compare(float dist1, float dist2)
		{
			return dist1 < dist2;
		}
	}
}
