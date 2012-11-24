using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki
{
	public class CosineSimilarity : IDistanceMetric
	{
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

			return sim;
		}
		
		public float MaxValue()
		{
			return float.MinValue;
		}

		public float MinValue()
		{
			return float.MaxValue;
		}

		public bool LessThan(float sim1, float sim2)
		{
			return sim1 > sim2;
		}

		public bool GreaterThan(float sim1, float sim2)
		{
			return sim1 < sim2;
		}

		public bool Compare(float sim1, float sim2)
		{
			return sim1 > sim2;
		}
	}
}
