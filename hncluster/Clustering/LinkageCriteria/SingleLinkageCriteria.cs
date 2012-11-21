using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wiki;

namespace Clustering
{
	public class SingleLinkageCriteria : ILinkageCriteria
	{
		public double GetDistance(Cluster c1, Cluster c2)
		{

			//return GetDistanceParallel(c1, c2);

			double minimum = WikiPage.metric.MaxValue();
			foreach (WikiPage page1 in c1.pages)
			{
				foreach (WikiPage page2 in c2.pages)
				{
					double distance = page1.GetDistance(page2);
					if (WikiPage.metric.Compare(distance, minimum))
					{
						minimum = distance;
					}
				}
			}
			return minimum;
		}

		public double GetDistanceParallel(Cluster c1, Cluster c2)
		{
			double GlobalMinimum = WikiPage.metric.MaxValue();
			Mutex GlobalMutex = new Mutex();
			Parallel.For(0, c1.pages.Count, i =>
			{
				Thread.CurrentThread.Priority = ThreadPriority.Lowest;
				Mutex LocalMutex = new Mutex();
				double LocalMinimum = WikiPage.metric.MaxValue();
				Parallel.For(0, c2.pages.Count, n =>
				{
					Thread.CurrentThread.Priority = ThreadPriority.Lowest;
					double distance = c1.pages[i].GetDistance(c2.pages[n]);
					if (WikiPage.metric.Compare(distance, LocalMinimum))
					{
						LocalMutex.WaitOne();
						if (WikiPage.metric.Compare(distance, LocalMinimum))
						{
							LocalMinimum = distance;
						}
						LocalMutex.ReleaseMutex();
					}
				});
				if (WikiPage.metric.Compare(LocalMinimum, GlobalMinimum))
				{
					GlobalMutex.WaitOne();
					if (WikiPage.metric.Compare(LocalMinimum, GlobalMinimum))
					{
						GlobalMinimum = LocalMinimum;
					}
					GlobalMutex.ReleaseMutex();
				}

			});
			return GlobalMinimum;
		}

		public bool Compare(double dist1, double dist2)
		{
			return WikiPage.metric.Compare(dist1, dist2);
		}
	}
}
