using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Wiki;

namespace Clustering
{
	public interface ILinkageCriteria
	{
		float GetDistance(Cluster c1, Cluster c2);
		float GetDistance(Cluster c1, Cluster c2, float[,] DistanceMatrix);
		bool Compare(float dist1, float dist2);
	}
}
