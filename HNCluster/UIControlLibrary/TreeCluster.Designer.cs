namespace UIControlLibrary
{
	partial class TreeCluster
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.treeViewClusters = new System.Windows.Forms.TreeView();
            this.listViewClusters = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewClusters
            // 
            this.treeViewClusters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.treeViewClusters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewClusters.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewClusters.ItemHeight = 22;
            this.treeViewClusters.Location = new System.Drawing.Point(0, 0);
            this.treeViewClusters.Margin = new System.Windows.Forms.Padding(0);
            this.treeViewClusters.Name = "treeViewClusters";
            this.treeViewClusters.Size = new System.Drawing.Size(400, 277);
            this.treeViewClusters.TabIndex = 16;
            // 
            // listViewClusters
            // 
            this.listViewClusters.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewClusters.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listViewClusters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewClusters.Location = new System.Drawing.Point(0, 277);
            this.listViewClusters.Margin = new System.Windows.Forms.Padding(0);
            this.listViewClusters.Name = "listViewClusters";
            this.listViewClusters.Size = new System.Drawing.Size(400, 277);
            this.listViewClusters.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewClusters.TabIndex = 17;
            this.listViewClusters.UseCompatibleStateImageBehavior = false;
            this.listViewClusters.View = System.Windows.Forms.View.List;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 557);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 40);
            this.panel1.TabIndex = 18;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.treeViewClusters, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listViewClusters, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 600);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // TreeCluster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TreeCluster";
            this.Size = new System.Drawing.Size(400, 600);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.TreeView treeViewClusters;
		public System.Windows.Forms.ListView listViewClusters;
		private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

	}
}
