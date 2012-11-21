using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Wiki;

namespace Clustering
{
	public class HierarchicalCluster
	{
		public WikiCollection wikiCollection;

		public List<Cluster> clusters;

		public HierarchicalCluster(WikiCollection wikis)
		{
			wikiCollection = wikis;
			clusters = new List<Cluster>();
		}

		public void initializeClusters()
		{
			foreach (WikiPage page in wikiCollection.wikiPages)
			{
				clusters.Add(new Cluster(page));
			}
		}

		private void ClusterDoubleParallel()
		{
			Cluster c1 = clusters[0];
			Cluster c2 = clusters[1];
			System.Diagnostics.Debug.Print(clusters.Count.ToString());
			double GlobalMinimum = WikiPage.metric.MaxValue();
			Mutex GlobalMutex = new Mutex();
			Parallel.For(0, clusters.Count, i =>
			{
				Thread.CurrentThread.Priority = ThreadPriority.Lowest;
				Mutex LocalMutex = new Mutex();
				double LocalMinimum = WikiPage.metric.MaxValue();
				int LocalMinimum_n = 1;
				Parallel.For(i + 1, clusters.Count, n =>
				{
					if (i != n)
					{
						Thread.CurrentThread.Priority = ThreadPriority.Lowest;
						double distance = clusters[i].GetDistance(clusters[n]);
						if (WikiPage.metric.Compare(distance, LocalMinimum))
						{
							LocalMutex.WaitOne();
							if (WikiPage.metric.Compare(distance, LocalMinimum))
							{
								LocalMinimum = distance;
								LocalMinimum_n = n;
							}
							LocalMutex.ReleaseMutex();
						}
					}
				});
				if (WikiPage.metric.Compare(LocalMinimum, GlobalMinimum))
				{
					GlobalMutex.WaitOne();
					if (WikiPage.metric.Compare(LocalMinimum, GlobalMinimum))
					{
						GlobalMinimum = LocalMinimum;
						c1 = clusters[i];
						c2 = clusters[LocalMinimum_n];
					}
					GlobalMutex.ReleaseMutex();
				}

			});

			Cluster newCluster = new Cluster(c1, c2);
			clusters.Remove(c1);
			clusters.Remove(c2);
			clusters.Add(newCluster);
		}

		private void ClusterOuterParallel()
		{
			Cluster c1 = clusters[0];
			Cluster c2 = clusters[1];
			System.Diagnostics.Debug.Print(clusters.Count.ToString());
			double GlobalMinimum = WikiPage.metric.MaxValue();
			Mutex GlobalMutex = new Mutex();
			Parallel.For(1, clusters.Count, i =>
			{
				Thread.CurrentThread.Priority = ThreadPriority.Lowest;
				double LocalMinimum = WikiPage.metric.MaxValue();
				int LocalMinimum_n = 1;
				for (int n = 0; n < 1; ++n)
				//for (int n = i + 1; n < clusters.Count; ++n)
				{
					Thread.CurrentThread.Priority = ThreadPriority.Lowest;
					double distance = clusters[i].GetDistance(clusters[n]);
					if (WikiPage.metric.Compare(distance, LocalMinimum))
					{
						LocalMinimum = distance;
						LocalMinimum_n = n;
					}
				}
				if (WikiPage.metric.Compare(LocalMinimum, GlobalMinimum))
				{
					GlobalMutex.WaitOne();
					if (WikiPage.metric.Compare(LocalMinimum, GlobalMinimum))
					{
						GlobalMinimum = LocalMinimum;
						c1 = clusters[i];
						c2 = clusters[LocalMinimum_n];
					}
					GlobalMutex.ReleaseMutex();
				}

			});

			Cluster newCluster = new Cluster(c1, c2);
			clusters.Remove(c1);
			clusters.Remove(c2);
			clusters.Add(newCluster);
		}

		private void ClusterInnerParallel()
		{
			Cluster c1 = clusters[0];
			Cluster c2 = clusters[1];
			System.Diagnostics.Debug.Print(clusters.Count.ToString());
			double GlobalMinimum = WikiPage.metric.MaxValue();
			Mutex GlobalMutex = new Mutex();
			for (int i = 0; i < clusters.Count; ++i)
			{
				Thread.CurrentThread.Priority = ThreadPriority.Lowest;
				Mutex LocalMutex = new Mutex();
				double LocalMinimum = WikiPage.metric.MaxValue();
				int LocalMinimum_n = 1;
				Parallel.For(i + 1, clusters.Count, n =>
				{
					if (i != n)
					{
						Thread.CurrentThread.Priority = ThreadPriority.Lowest;
						double distance = clusters[i].GetDistance(clusters[n]);
						if (WikiPage.metric.Compare(distance, LocalMinimum))
						{
							LocalMutex.WaitOne();
							if (WikiPage.metric.Compare(distance, LocalMinimum))
							{
								LocalMinimum = distance;
								LocalMinimum_n = n;
							}
							LocalMutex.ReleaseMutex();
						}
					}
				});
				if (WikiPage.metric.Compare(LocalMinimum, GlobalMinimum))
				{
					GlobalMutex.WaitOne();
					if (WikiPage.metric.Compare(LocalMinimum, GlobalMinimum))
					{
						GlobalMinimum = LocalMinimum;
						c1 = clusters[i];
						c2 = clusters[LocalMinimum_n];
					}
					GlobalMutex.ReleaseMutex();
				}

			}

			Cluster newCluster = new Cluster(c1, c2);
			clusters.Remove(c1);
			clusters.Remove(c2);
			clusters.Add(newCluster);
		}

		private void ClusterNoParallel()
		{
			Cluster c1 = clusters[0];
			Cluster c2 = clusters[1];
			System.Diagnostics.Debug.Print(clusters.Count.ToString());
			double GlobalMinimum = WikiPage.metric.MaxValue();
			Mutex GlobalMutex = new Mutex();
			for (int i = 0; i < clusters.Count; ++i)
			{
				for (int n = i + 1; n < clusters.Count; ++n)
				{
					double distance = clusters[i].GetDistance(clusters[n]);
					if (WikiPage.metric.Compare(distance, GlobalMinimum))
					{
						GlobalMinimum = distance;
						c1 = clusters[i];
						c2 = clusters[n];
					}
				}
			}

			Cluster newCluster = new Cluster(c1, c2);
			clusters.Remove(c1);
			clusters.Remove(c2);
			clusters.Add(newCluster);
		}

		public void Cluster()
		{
			while (clusters.Count > 1)
			{
				//ClusterDoubleParallel();
				ClusterOuterParallel();
				//ClusterInnerParallel();
				//ClusterNoParallel();
			}
		}
	}
}

