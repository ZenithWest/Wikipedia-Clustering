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
			this.SuspendLayout();
			// 
			// treeViewClusters
			// 
			this.treeViewClusters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.treeViewClusters.Dock = System.Windows.Forms.DockStyle.Top;
			this.treeViewClusters.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.treeViewClusters.ItemHeight = 22;
			this.treeViewClusters.Location = new System.Drawing.Point(0, 0);
			this.treeViewClusters.Margin = new System.Windows.Forms.Padding(0);
			this.treeViewClusters.Name = "treeViewClusters";
			this.treeViewClusters.Size = new System.Drawing.Size(400, 300);
			this.treeViewClusters.TabIndex = 16;
			// 
			// listViewClusters
			// 
			this.listViewClusters.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.listViewClusters.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewClusters.Location = new System.Drawing.Point(0, 300);
			this.listViewClusters.Margin = new System.Windows.Forms.Padding(0);
			this.listViewClusters.Name = "listViewClusters";
			this.listViewClusters.Size = new System.Drawing.Size(400, 300);
			this.listViewClusters.TabIndex = 17;
			this.listViewClusters.UseCompatibleStateImageBehavior = false;
			this.listViewClusters.View = System.Windows.Forms.View.List;
			// 
			// TreeCluster
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.listViewClusters);
			this.Controls.Add(this.treeViewClusters);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "TreeCluster";
			this.Size = new System.Drawing.Size(400, 600);
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.TreeView treeViewClusters;
		public System.Windows.Forms.ListView listViewClusters;

	}
}
