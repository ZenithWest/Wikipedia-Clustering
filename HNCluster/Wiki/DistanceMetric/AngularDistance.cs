using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki
{
	class AngularDistance : IDistanceMetric
	{
		const double Constant = 2.0 / Math.PI;
		public float GetDistance(TF_IDF_Vector vec1, TF_IDF_Vector vec2)
		{
			float sim = 0;
			foreach (string tokenKey in vec1.Keys)
			{
				if (vec2.ContainsKey(tokenKey))
				{
					sim += vec1[tokenKey].TF_IDF * vec2[tokenKey].TF_IDF;
				}
			}

			return (float)(Constant * Math.Acos(sim));
		}

		public float MaxValue()
		{
			return float.MaxValue;
		}

		public float MinValue()
		{
			return float.MinValue;
		}

		public bool LessThan(float sim1, float sim2)
		{
			return sim1 < sim2;
		}

		public bool GreaterThan(float sim1, float sim2)
		{
			return sim1 > sim2;
		}

		public bool Compare(float sim1, float sim2)
		{
			return sim1 < sim2;
		}
	}
}
