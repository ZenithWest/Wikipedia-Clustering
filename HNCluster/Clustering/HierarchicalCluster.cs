using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Wiki;

namespace Clustering
{
	public class HierarchicalCluster
	{
		public WikiCollection wikiCollection;

		public HierarchicalCluster(WikiCollection wikis)
		{
			wikiCollection = wikis;
		}
	}
}

