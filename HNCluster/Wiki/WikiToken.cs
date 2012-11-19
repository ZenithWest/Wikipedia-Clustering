using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki
{
	unsafe public class WikiToken
	{
		public string Token { get; set; }
		public long Count { get; set; }
		public double TF_IDF { get; set; }
		public double TF { get; set; }
		public double* IDF { get; set; }

		public WikiToken()
		{

		}

		public WikiToken(string token)
		{
			Token = token;
		}

	}
}
