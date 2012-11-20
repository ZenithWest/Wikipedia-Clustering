using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Wiki;

namespace Clustering
{
	public class Cluster
	{
		public Cluster cluster1 = null;
		public Cluster cluster2 = null;
		public WikiPage page = null;
		public Dictionary<string, double> TF_IDF_Vector;

		public Cluster()
		{
			TF_IDF_Vector = new Dictionary<string, double>();
		}

		public Cluster(WikiPage pg)
		{
			page = pg;
			TF_IDF_Vector = new Dictionary<string, double>();

			foreach(string tokenkey in page.TF_IDF_Vector.Keys) {
				TF_IDF_Vector[tokenkey] = page.TF_IDF_Vector[tokenkey].TF_IDF;
			}
		}

		public Cluster(Cluster c1, Cluster c2)
		{
			cluster1 = c1;
			cluster2 = c2;

			TF_IDF_Vector = new Dictionary<string, double>();

			List<string> tokenKeys = c1.TF_IDF_Vector.Keys.ToList<string>();
			tokenKeys.AddRange(c1.TF_IDF_Vector.Keys.ToList<string>());
			foreach (string tokenKey in tokenKeys)
			{
				TF_IDF_Vector[tokenKey] = 0.0;
			}
			SumVec(c1, TF_IDF_Vector, tokenKeys);
			SumVec(c2, TF_IDF_Vector, tokenKeys);
			double magnitude = Magnitude();
			foreach (string tokenKey in tokenKeys)
			{
				TF_IDF_Vector[tokenKey] /= magnitude;
			}

			/*foreach (string tokenKey in tokenKeys)
			{
				double value1 = c1.TF_IDF_Vector.ContainsKey(tokenKey) ? c1.TF_IDF_Vector[tokenKey] : 0.0;
				value1 += c2.TF_IDF_Vector.ContainsKey(tokenKey) ? c2.TF_IDF_Vector[tokenKey] : 0.0;
				TF_IDF_Vector[tokenKey] = value1 / 2.0;
			}*/
		}

		public void SumVec(Cluster c1, Dictionary<string, double> vec, List<string> tokenKeys)
		{
			if (c1 == null) return;
			if (c1.cluster1 != null) SumVec(c1.cluster1, vec, tokenKeys);
			if (c1.cluster2 != null) SumVec(c1.cluster2, vec, tokenKeys);

			if (c1.page != null)
			foreach (string tokenKey in tokenKeys)
			{
				double value1 = c1.page.TF_IDF_Vector.ContainsKey(tokenKey) ? c1.page.TF_IDF_Vector[tokenKey].TF_IDF : 0.0;
				//if (TF_IDF_Vector.ContainsKey(tokenKey))
					TF_IDF_Vector[tokenKey] += value1;
				//else
				//{
				//	TF_IDF_Vector[tokenKey] = value1;
				//}
			}
		}
		public double Cosine(Cluster cluster)
		{
			return Cosine(TF_IDF_Vector, cluster.TF_IDF_Vector);
		}
		public static double Cosine(Dictionary<string, double> vec1, Dictionary<string, double> vec2)
		{
			double cosine = 0.0;
			foreach (string tokenKey in vec1.Keys)
			{
				if (vec2.ContainsKey(tokenKey))
				{
					cosine += vec1[tokenKey] * vec2[tokenKey];
				}
			}

			return cosine;
		}



		public double EuclideanDistance(Cluster cluster)
		{
			return EuclideanDistance(TF_IDF_Vector, cluster.TF_IDF_Vector);
		}
		public static double EuclideanDistance(Dictionary<string, double> vec1, Dictionary<string, double> vec2)
		{
			return Math.Sqrt(SquaredEuclideanDistance(vec1, vec2));
		}


		public double SquaredEuclideanDistance(Cluster cluster)
		{
			return SquaredEuclideanDistance(TF_IDF_Vector, cluster.TF_IDF_Vector);
		}
		public static double SquaredEuclideanDistance(Dictionary<string, double> vec1, Dictionary<string, double> vec2)
		{
			double euclidean = 0.0;

			List<string> tokenKeys = vec1.Keys.ToList<string>();
			tokenKeys.AddRange(vec2.Keys.ToList<string>());

			foreach (string tokenKey in tokenKeys)
			{
				double value1 = vec1.ContainsKey(tokenKey) ? vec1[tokenKey] : 0.0;
				value1 -= vec2.ContainsKey(tokenKey) ? vec2[tokenKey] : 0.0;
				value1 *= value1;
				euclidean += value1;
			}

			return euclidean;
		}


		public double ManhattanDistance(Cluster cluster)
		{
			return ManhattanDistance(TF_IDF_Vector, cluster.TF_IDF_Vector);
		}
		public static double ManhattanDistance(Dictionary<string, double> vec1, Dictionary<string, double> vec2)
		{
			double manhattan = 0.0;

			List<string> tokenKeys = vec1.Keys.ToList<string>();
			tokenKeys.AddRange(vec2.Keys.ToList<string>());

			foreach (string tokenKey in tokenKeys)
			{
				double value1 = vec1.ContainsKey(tokenKey) ? vec1[tokenKey] : 0.0;
				value1 -= vec2.ContainsKey(tokenKey) ? vec2[tokenKey] : 0.0;
				manhattan += Math.Abs(value1);
			}

			return manhattan;
		}


		public double MaximumDistance(Cluster cluster)
		{
			return MaximumDistance(TF_IDF_Vector, cluster.TF_IDF_Vector);
		}
		public static double MaximumDistance(Dictionary<string, double> vec1, Dictionary<string, double> vec2)
		{
			double maximum = 0.0;

			List<string> tokenKeys = vec1.Keys.ToList<string>();
			tokenKeys.AddRange(vec2.Keys.ToList<string>());

			foreach (string tokenKey in tokenKeys)
			{
				double value1 = vec1.ContainsKey(tokenKey) ? vec1[tokenKey] : 0.0;
				value1 -= vec2.ContainsKey(tokenKey) ? vec2[tokenKey] : 0.0;
				value1 = Math.Abs(value1);

				if (value1 > maximum)
				{
					maximum = value1;
				}
			}

			return maximum;
		}

		public double Magnitude()
		{
			double magnitude = 0.0;

			foreach (string tokenKey in TF_IDF_Vector.Keys)
			{
				magnitude += TF_IDF_Vector[tokenKey] * TF_IDF_Vector[tokenKey];
			}

			return Math.Sqrt(magnitude);
		}
	}
}
