using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Wiki;

namespace Clustering
{
	internal class ClusterPair
	{
		Cluster cluster1;
		Cluster cluster2;
		float distance;

		public Cluster Cluster1
		{
			get { return cluster1; }
		}

		public Cluster Cluster2
		{
			get { return cluster2; }
		}

		public float Distance
		{
			get { return distance; }
		}

		public ClusterPair(Cluster cluster1, Cluster cluster2, float distance)
		{
			this.cluster1 = cluster1;
			this.cluster2 = cluster2;
			this.distance = distance;
		}

		internal bool HasCluster(Cluster cluster)
		{
			return cluster1 == cluster || cluster2 == cluster;
		}

	}

	internal class ClusterPairs
	{
		HashSet<ClusterPair> pairs = new HashSet<ClusterPair>();
		Mutex mutex = new Mutex();
		internal ClusterPair LowestDistancePair
		{
			get
			{
				ClusterPair lowestDistancePair = null;
				foreach (ClusterPair pair in pairs)
					if (lowestDistancePair == null || lowestDistancePair.Distance < pair.Distance)
						lowestDistancePair = pair;
				return lowestDistancePair;
			}
		}

		internal int Count
		{
			get { return pairs.Count; }
		}

		internal void AddPair(ClusterPair pair)
		{
			//mutex.WaitOne();
			pairs.Add(pair);
			
			//mutex.ReleaseMutex();
		}

		internal void RemovePairsByOldClusters(Cluster cluster1, Cluster cluster2)
		{
			List<ClusterPair> toRemove = new List<ClusterPair>();
			
			foreach (ClusterPair pair in pairs)
			//Parallel.ForEach(pairs, pair =>
			{
				if (pair.HasCluster(cluster1) || pair.HasCluster(cluster2))
				{
					//mutex.WaitOne();
					toRemove.Add(pair);
					//mutex.ReleaseMutex();
				}
			}//);
			foreach (ClusterPair pair in toRemove)
			{
				pairs.Remove(pair);
			}
		}
	}


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

		public void Cluster2()
		{
			ClusterPairs pairs = new ClusterPairs();
			
			for(int x=0; x< clusters.Count; ++x)
			//Parallel.For(0, clusters.Count, x =>
			{
				for (int y = x + 1; y < clusters.Count; y++)
				{
					if (clusters[x] == clusters[y])
						continue;
					ClusterPair pair = new ClusterPair(clusters[x], clusters[y], clusters[x].GetDistance(clusters[y], DistanceMatrix));
					pairs.AddPair(pair);
				}
			}//);
			
			long timeStart = DateTime.Now.Ticks;
			while (clusters.Count > 1)
			{
				long time = DateTime.Now.Ticks - timeStart;
				timeStart = DateTime.Now.Ticks;
				System.Diagnostics.Debug.Print(String.Format("{0}, {1}", clusters.Count, TimeSpan.FromTicks(time).TotalMilliseconds));
				// a) Merge: Create a new cluster and add the elements of the two old clusters                
				ClusterPair lowestDistancePair = pairs.LowestDistancePair;
				Cluster newCluster = new Cluster(lowestDistancePair.Cluster1, lowestDistancePair.Cluster2);
				//newCluster.AddElements(lowestDistancePair.Cluster1.GetElements());
				//newCluster.AddElements(lowestDistancePair.Cluster2.GetElements());
				// b)Remove the two old clusters from clusters
				clusters.Remove(lowestDistancePair.Cluster1);
				clusters.Remove(lowestDistancePair.Cluster2);
				// c) Remove the two old clusters from pairs
				pairs.RemovePairsByOldClusters(lowestDistancePair.Cluster1, lowestDistancePair.Cluster2);

				// d) Calculate the distance of the new cluster to all other clusters and save each as pair
				for (int x = 0; x < clusters.Count; ++x )
				//Parallel.For(0, clusters.Count, x =>
				{
					ClusterPair pair = new ClusterPair(clusters[x], newCluster, clusters[x].GetDistance(newCluster, DistanceMatrix));
					pairs.AddPair(pair);
				}//);
				// e) Add the new cluster to clusters
				clusters.Add(newCluster);
			}

		}

	}
}
