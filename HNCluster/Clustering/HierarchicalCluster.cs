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

		public void Cluster()
		{

			while (clusters.Count > 1)
			{
				Cluster c1 = clusters[0];
				Cluster c2 = clusters[1];
				double maxSim = 0.0;
				Mutex mutex = new Mutex();

				Parallel.For(1, clusters.Count, i =>
				{
					Thread.CurrentThread.Priority = ThreadPriority.Lowest;
					double sim = clusters[0].Cosine(clusters[i]);
					if (sim > maxSim)
					{
						mutex.WaitOne();
						if (sim > maxSim)
						{
							maxSim = sim;
							//c1 = clusters[n];
							c2 = clusters[i];
						}
						mutex.ReleaseMutex();
					}
				});

				if (maxSim < 0.9 && false)
				{
					int temp2 = clusters.Count - 1;
					
					Parallel.For(1, temp2, n =>
					{
						Thread.CurrentThread.Priority = ThreadPriority.Lowest;
						int temp = n+10;
						if (temp > clusters.Count || maxSim < 0.05 || clusters.Count < 500)
						{
							temp = clusters.Count;
						}
						else
						{
							int a = 1;
							++a;
						}
						Parallel.For(n + 1, temp, i =>
						{
							Thread.CurrentThread.Priority = ThreadPriority.Lowest;
							double sim = clusters[n].Cosine(clusters[i]);
							if (sim > maxSim)
							{
								mutex.WaitOne();
								if (sim > maxSim)
								{
									maxSim = sim;
									c1 = clusters[n];
									c2 = clusters[i];
								}
								mutex.ReleaseMutex();
							}
						});
					});
				}
				else
				{
					int a = 1;

					++a;
				}

				Cluster newCluster = new Cluster(c1, c2);
				clusters.Remove(c1);
				clusters.Remove(c2);
				clusters.Add(newCluster);
			}
		}
	}
}

