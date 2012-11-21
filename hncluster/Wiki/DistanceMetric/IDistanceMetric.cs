using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki
{
	public interface IDistanceMetric
	{
		double GetDistance(TF_IDF_Vector vec1, TF_IDF_Vector vec2);
		double MaxValue();
		bool Compare(double dist1, double dist2);
	}
}
