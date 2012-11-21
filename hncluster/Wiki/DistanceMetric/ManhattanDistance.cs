using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki
{
	public class ManhattanDistance : IDistanceMetric
	{
		public double GetDistance(TF_IDF_Vector vec1, TF_IDF_Vector vec2)
		{
			double manhattan = 0.0;

			List<string> tokenKeys = vec1.Keys.ToList<string>();
			tokenKeys.AddRange(vec2.Keys.ToList<string>());

			foreach (string tokenKey in tokenKeys)
			{
				double value1 = vec1.ContainsKey(tokenKey) ? vec1[tokenKey].TF_IDF : 0.0;
				value1 -= vec2.ContainsKey(tokenKey) ? vec2[tokenKey].TF_IDF : 0.0;
				manhattan += Math.Abs(value1);
			}

			return manhattan;
		}

		public double MaxValue()
		{
			return double.MaxValue;
		}

		public bool Compare(double dist1, double dist2)
		{
			return dist1 < dist2;
		}
	}
}
