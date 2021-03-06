﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki
{
	public class WikiToken
	{
		//public char Token { get; set; }
		public string Stemmed { get; set; }
		public float TF_IDF { get; set; }
		public int TF { get; set; }
		//public short DF { get; set; }

		public WikiToken()
		{
			TF = 1;
			//DF = 1;
		}

		public WikiToken(string token)
		{
			//Token = token;
			TF = 1;
			//DF = 1;
		}

		public WikiToken(string token, string stemmed)
		{
			//Token = token; Token = "";
			Stemmed = stemmed;
			TF = 1;
			//DF = 1;
		}

		public bool Equals(WikiToken one)
		{
			// Adjust according to requirements
			return StringComparer.InvariantCulture.Compare(one.Stemmed, Stemmed) != 0;
		}
	}

	public class WikiTokenComparer : IEqualityComparer<WikiToken>
	{
		public bool Equals(WikiToken one, WikiToken two)
		{
			// Adjust according to requirements
			return StringComparer.InvariantCulture.Compare(one.Stemmed, two.Stemmed) != 0;
		}


		public int GetHashCode(WikiToken item)
		{
			return StringComparer.InvariantCultureIgnoreCase.GetHashCode(item.Stemmed);

		}

	}
}
