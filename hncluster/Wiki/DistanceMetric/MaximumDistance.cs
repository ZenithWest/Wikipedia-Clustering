using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki
{
	public class MaximumDistance : IDistanceMetric
	{
		public double GetDistance(TF_IDF_Vector vec1, TF_IDF_Vector vec2)
		{
			double maximum = 0.0;

			List<string> tokenKeys = vec1.Keys.ToList<string>();
			tokenKeys.AddRange(vec2.Keys.ToList<string>());

			foreach (string tokenKey in tokenKeys)
			{
				double value1 = vec1.ContainsKey(tokenKey) ? vec1[tokenKey].TF_IDF : 0.0;
				value1 -= vec2.ContainsKey(tokenKey) ? vec2[tokenKey].TF_IDF : 0.0;
				value1 = Math.Abs(value1);
				if (value1 > maximum)
				{
					maximum = value1;
				}
			}

			return maximum;
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
