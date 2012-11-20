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

				//int n = 0;
				
				//for (n = 0; n < clusters.Count; ++n) // Comment out line for faster performance but won't be as good.
				Mutex mutex = new Mutex();

				Parallel.For(1, clusters.Count, i =>
				{

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

				if (maxSim < 0.9)
				{
					int temp2 = clusters.Count - 1;
					Parallel.For(1, temp2, n =>
					{
						int temp = n+10;
						if (temp > clusters.Count || maxSim < 0.05)
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
				/*
				Parallel.For(1, clusters.Count, n =>
				{
					Cluster LocalC1 = clusters[0];
					Cluster LocalC2 = clusters[1];
					double LocalMaxSim = 0.0;
					int temp = n + 10;
					if (temp > clusters.Count) temp = clusters.Count;
					for (int i = n + 1; i < temp; ++i)
					{

						double sim = clusters[n].Cosine(clusters[i]);
						if (sim > LocalMaxSim)
						{
							LocalMaxSim = sim;
							LocalC1 = clusters[n];
							LocalC2 = clusters[i];
						}
					}

					mutex.WaitOne();
					if (LocalMaxSim > maxSim)
					{
						maxSim = LocalMaxSim;
						c1 = LocalC1;
						c2 = LocalC2;
					}
					mutex.ReleaseMutex();
				});*/
				/*
				Parallel.For(0, clusters.Count, i =>
				{
					double sim = clusters[0].Cosine(clusters[i]);
					if (sim > maxSim)
					{
						mutex.WaitOne();
						if (sim > maxSim)
						{
							maxSim = sim;
							c2 = clusters[i];
						}
						mutex.ReleaseMutex();
					}
				});*/

				/*
				Parallel.For(0, clusters.Count, n =>
				{
					Cluster LocalC1 = clusters[0];
					Cluster LocalC2 = clusters[1];
					double LocalMaxSim = 0.0;
					//bool test = true;
					for (int i = n + 1; i < clusters.Count; ++i)
					{

						double sim = clusters[n].Cosine(clusters[i]);
						if (sim > LocalMaxSim)
						{
							LocalMaxSim = sim;
							LocalC1 = clusters[n];
							LocalC2 = clusters[i];
						}
						if (n!=0 && i > n + 10)
						{
							break;
						}
					}

					mutex.WaitOne();
					if (LocalMaxSim > maxSim)
					{
						maxSim = LocalMaxSim;
						c1 = LocalC1;
						c2 = LocalC2;
					}
					mutex.ReleaseMutex();
				});*/




			}
		}
	}
}

