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
		public float[,] DistanceMatrix;
		public float DistanceMatrixTime = 0;
		public float AverageClusterIterationTime = 0;
		public long Iterations = 0;
		public float TotalClusteringTime = 0;

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

			DistanceMatrix = new float[wikiCollection.wikiPages.Count, wikiCollection.wikiPages.Count];
			//for (int outer = 0; outer < wikiCollection.wikiPages.Count; ++outer)
			long timeStart = DateTime.Now.Ticks;
			Parallel.For(0, wikiCollection.wikiPages.Count, outer =>
			{
				Thread.CurrentThread.Priority = ThreadPriority.Lowest;
				for (int inner = 0; inner <= outer; ++inner)
				{
					DistanceMatrix[outer, inner] = wikiCollection.wikiPages[outer].GetDistance(wikiCollection.wikiPages[inner]);
				}
				wikiCollection.wikiPages[outer].id = outer;
			});
			Parallel.For(0, wikiCollection.wikiPages.Count, outer =>
			{
				Thread.CurrentThread.Priority = ThreadPriority.Lowest;
				for (int inner = 0; inner < outer; ++inner)
				{
					DistanceMatrix[inner, outer] = DistanceMatrix[outer, inner];
				}
			});
			long time = DateTime.Now.Ticks - timeStart;
			DistanceMatrixTime = (float)TimeSpan.FromTicks(time).TotalMilliseconds;
			System.Diagnostics.Debug.Print(String.Format("Distance Matrix: {0}ms", DistanceMatrixTime));
			int a = 1;
			++a;
		}

		public void Cluster()
		{
			long timeStart = DateTime.Now.Ticks;
			long globalTime = DateTime.Now.Ticks;
			while (clusters.Count > 1)
			{
				long time = DateTime.Now.Ticks - timeStart;
				timeStart = DateTime.Now.Ticks;
				System.Diagnostics.Debug.Print(String.Format("{0}, {1}", clusters.Count, TimeSpan.FromTicks(time).TotalMilliseconds));
				AverageClusterIterationTime += (float)TimeSpan.FromTicks(time).TotalMilliseconds;
				++Iterations;

				Cluster c1 = clusters[0];
				Cluster c2 = clusters[1];
				float GlobalMinimum = WikiPage.metric.MaxValue();
				Mutex GlobalMutex = new Mutex();

				Parallel.For(0, clusters.Count, i =>
				{
					Thread.CurrentThread.Priority = ThreadPriority.Lowest;
					float LocalMinimum = WikiPage.metric.MaxValue();
					int LocalMinimum_n = 1;
					for (int n = i + 1; n < clusters.Count; ++n)
					{
						Thread.CurrentThread.Priority = ThreadPriority.Lowest;
						float distance = clusters[i].GetDistance(clusters[n], DistanceMatrix);
						
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

			globalTime = DateTime.Now.Ticks - globalTime;
			TotalClusteringTime = (float)TimeSpan.FromTicks(globalTime).TotalMilliseconds;
			AverageClusterIterationTime /= Iterations;
		}

	}
}
