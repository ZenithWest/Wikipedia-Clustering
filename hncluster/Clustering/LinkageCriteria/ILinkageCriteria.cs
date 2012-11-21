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
		double GetDistance(Cluster c1, Cluster c2);
		bool Compare(double dist1, double dist2);
	}
}
