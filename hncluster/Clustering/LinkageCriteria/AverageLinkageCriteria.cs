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
		public double GetDistance(Cluster c1, Cluster c2)
		{
			double mean = 0.0;
			foreach (WikiPage page1 in c1.pages)
			{
				foreach (WikiPage page2 in c2.pages)
				{
					mean += page1.GetDistance(page2);
				}
			}

			mean /= c1.pages.Count * c2.pages.Count;

			return mean;
		}

		public bool Compare(double dist1, double dist2)
		{
			return dist1 < dist2;
		}
	}
}
