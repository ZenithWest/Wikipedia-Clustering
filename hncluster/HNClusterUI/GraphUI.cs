using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wiki;
using Clustering;

namespace HNClusterUI
{
	public partial class GraphUI : Form
	{
		public GraphUI()
		{
			InitializeComponent();
		}

		public void GenerateGraph(HierarchicalCluster hac)
		{
			graphDisplay1.GenerateGraph(hac);
		}
	}
}
