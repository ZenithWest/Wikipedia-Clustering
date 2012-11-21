
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Wiki
{
	public class TF_IDF_Vector : Dictionary<string, WikiToken>
	{
		public TF_IDF_Vector() : base() { }
		public TF_IDF_Vector(int capacity) : base(capacity) { }
	}
}
