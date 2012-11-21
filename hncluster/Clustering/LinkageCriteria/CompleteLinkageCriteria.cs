using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Wiki;

namespace Clustering
{
	public class CompleteLinkageCriteria : ILinkageCriteria
	{
		public double GetDistance(Cluster c1, Cluster c2)
		{
			double maximum = double.MinValue;
			foreach (WikiPage page1 in c1.pages)
			{
				foreach (WikiPage page2 in c2.pages)
				{
					double distance = page1.GetDistance(page2);
					if (!WikiPage.metric.Compare(distance, maximum))
					{
						maximum = distance;
					}
				}
			}
			return maximum;
		}

		public bool Compare(double dist1, double dist2)
		{
			return dist1 < dist2;
		}
	}
}
