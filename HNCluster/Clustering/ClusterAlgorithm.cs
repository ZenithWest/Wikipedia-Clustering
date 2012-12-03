using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wiki;

namespace Clustering
{
	public class ClusterAlgorithm
	{
		HierarchicalCluster HAC;
		Cluster c1;
		Cluster c2;

		Mutex GlobalMutex = new Mutex();
		float GlobalMinimum;

		public ClusterAlgorithm(HierarchicalCluster hac)
		{
			HAC = hac;
		}
	}
}
