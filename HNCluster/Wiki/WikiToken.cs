using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Wiki
{
	public class WikiToken
	{
		public string Token { get; set; }
		public string Stemmed { get; set; }
		public float TF_IDF { get; set; }
		public int TF { get; set; }
		public int DF { get; set; }

		public WikiToken()
		{
			TF = 1;
			DF = 1;
		}

		public WikiToken(WikiToken prevToken)
		{
			Token = prevToken.Token;
			Stemmed = prevToken.Stemmed;
			TF_IDF = prevToken.TF_IDF;
			TF = prevToken.TF; ;
			DF = prevToken.DF; ;
		}

		public WikiToken(string token)
		{
			Token = token;
			TF = 1;
			DF = 1;
		}

		public WikiToken(string token, string stemmed)
		{
			Token = token;
			Stemmed = stemmed;
			TF = 1;
			DF = 1;
		}

		public static implicit operator float(WikiToken token)
		{
			return token.TF_IDF;
		}

		public bool Equals(WikiToken one)
		{
			return StringComparer.InvariantCulture.Compare(one.Stemmed, Stemmed) != 0;
		}
	}

	public class WikiTokenComparer : IEqualityComparer<WikiToken>
	{
		public bool Equals(WikiToken one, WikiToken two)
		{
			return StringComparer.InvariantCulture.Compare(one.Stemmed, two.Stemmed) != 0;
		}

		public int GetHashCode(WikiToken item)
		{
			return StringComparer.InvariantCultureIgnoreCase.GetHashCode(item.Stemmed);
		}

	}
}
