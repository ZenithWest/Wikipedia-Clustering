using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Wiki;

namespace Clustering
{
	public class MinimumEnergyLinkageCriteria : ILinkageCriteria
	{
		public float GetDistance(Cluster c1, Cluster c2)
		{
			float maximum = float.MinValue;
			foreach (WikiPage page1 in c1.pages)
			{
				foreach (WikiPage page2 in c2.pages)
				{
					float distance = page1.GetDistance(page2);
					if (WikiPage.metric.Compare(distance, maximum))
					{
						maximum = distance;
					}
				}
			}
			return maximum;
		}

		public float GetDistance(Cluster c1, Cluster c2, float[,] DistanceMatrix)
		{
			float maximum = float.MinValue;
			foreach (WikiPage page1 in c1.pages)
			{
				foreach (WikiPage page2 in c2.pages)
				{
					float distance = DistanceMatrix[page1.id, page2.id];
					if (WikiPage.metric.Compare(distance, maximum))
					{
						maximum = distance;
					}
				}
			}
			return maximum;
		}

		public bool Compare(float dist1, float dist2)
		{
			return dist1 < dist2;
		}
	}
}
