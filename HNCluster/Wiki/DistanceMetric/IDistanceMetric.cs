using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki
{
	public interface IDistanceMetric
	{
		float GetDistance(TF_IDF_Vector vec1, TF_IDF_Vector vec2);
		float MaxValue();
		float MinValue();
		bool LessThan(float dist1, float dist2);
		bool GreaterThan(float dist1, float dist2);
		bool Compare(float dist1, float dist2);
	}
}
