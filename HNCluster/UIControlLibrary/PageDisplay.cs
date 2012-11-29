using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Clustering;

namespace UIControlLibrary
{
	public partial class PageDisplay : UserControl
	{
		public HierarchicalCluster HAC;
		public PageDisplay()
		{
			InitializeComponent();
		}

		public void InitializePageDisplay(HierarchicalCluster hac) {
			HAC = hac;
		}
	}
}
