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
		public float GetDistance(Cluster c1, Cluster c2)
		{

			//return GetDistanceParallel(c1, c2);

			float minimum = WikiPage.metric.MaxValue();
			foreach (WikiPage page1 in c1.AllPagesInCluster)
			{
				foreach (WikiPage page2 in c2.AllPagesInCluster)
				{
					float distance = page1.GetDistance(page2);
					if (WikiPage.metric.Compare(distance, minimum))
					{
						minimum = distance;
					}
				}
			}
			return minimum;
		}

		public float GetDistance(Cluster c1, Cluster c2, float[,] DistanceMatrix)
		{

			//return GetDistanceParallel(c1, c2);

			float minimum = WikiPage.metric.MaxValue();
			foreach (WikiPage page1 in c1.AllPagesInCluster)
			{
				foreach (WikiPage page2 in c2.AllPagesInCluster)
				{
					float distance = DistanceMatrix[page1.id, page2.id];
					if (WikiPage.metric.Compare(distance, minimum))
					{
						minimum = distance;
					}
				}
			}
			return minimum;
		}

		public float GetDistanceParallel(Cluster c1, Cluster c2)
		{
			float GlobalMinimum = WikiPage.metric.MaxValue();
			Mutex GlobalMutex = new Mutex();
			Parallel.For(0, c1.AllPagesInCluster.Count, i =>
			{
				Thread.CurrentThread.Priority = ThreadPriority.Lowest;
				Mutex LocalMutex = new Mutex();
				float LocalMinimum = WikiPage.metric.MaxValue();
				Parallel.For(0, c2.AllPagesInCluster.Count, n =>
				{
					Thread.CurrentThread.Priority = ThreadPriority.Lowest;
					float distance = c1.AllPagesInCluster[i].GetDistance(c2.AllPagesInCluster[n]);
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

		public bool Compare(float dist1, float dist2)
		{
			return WikiPage.metric.Compare(dist1, dist2);
		}
	}
}
