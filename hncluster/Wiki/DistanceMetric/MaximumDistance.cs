using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki
{
	public class MaximumDistance : IDistanceMetric
	{
		public float GetDistance(TF_IDF_Vector vec1, TF_IDF_Vector vec2)
		{
			float maximum = 0;

			List<string> tokenKeys = vec1.Keys.ToList<string>();
			tokenKeys.AddRange(vec2.Keys.ToList<string>());

			foreach (string tokenKey in tokenKeys)
			{
				float value1 = vec1.ContainsKey(tokenKey) ? vec1[tokenKey].TF_IDF : 0;
				value1 -= vec2.ContainsKey(tokenKey) ? vec2[tokenKey].TF_IDF : 0;
				value1 = Math.Abs(value1);
				if (value1 > maximum)
				{
					maximum = value1;
				}
			}

			return maximum;
		}

		public float MaxValue()
		{
			return float.MaxValue;
		}

		public float MinValue()
		{
			return float.MinValue;
		}

		public bool LessThan(float dist1, float dist2)
		{
			return dist1 < dist2;
		}

		public bool GreaterThan(float dist1, float dist2)
		{
			return dist1 > dist2;
		}

		public bool Compare(float dist1, float dist2)
		{
			return dist1 < dist2;
		}
	}
}
