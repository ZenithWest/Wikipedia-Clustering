﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Wiki;

namespace Clustering
{
	public class HierarchicalCluster
	{
		public WikiCollection wikiCollection;

		List<Cluster> clusters;

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
				double minDistance = 10;

				for (int n = 0; n < clusters.Count; ++n)
				{
					for (int i = n+1; i < clusters.Count; ++i)
					{
						double distance = clusters[n].Cosine(clusters[i]);
						if (distance < minDistance)
						{
							minDistance = distance;
							c1 = clusters[n];
							c2 = clusters[i];
						}
					}
				}

				Cluster newCluster = new Cluster(c1, c2);
				clusters.Remove(c1);
				clusters.Remove(c2);
				clusters.Add(newCluster);




			}
		}
	}
}

