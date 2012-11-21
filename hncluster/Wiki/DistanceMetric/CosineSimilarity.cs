using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki
{
	public class CosineSimilarity : IDistanceMetric
	{
		public double GetDistance(TF_IDF_Vector vec1, TF_IDF_Vector vec2)
		{
			double sim = 0.0;
			foreach (string tokenKey in vec1.Keys)
			{
				if (vec2.ContainsKey(tokenKey))
				{
					sim += vec1[tokenKey].TF_IDF * vec2[tokenKey].TF_IDF;
				}
			}

			return sim;
		}

		public double MaxValue()
		{
			return double.MinValue;
		}

		public bool Compare(double sim1, double sim2)
		{
			return sim1 > sim2;
		}
	}
}
