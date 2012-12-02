namespace HNClusterUI
{
	partial class HNClusterUI
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.treeCluster = new UIControlLibrary.TreeCluster();
			this.pageDisplay1 = new UIControlLibrary.PageDisplay();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1293, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 727);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1293, 22);
			this.statusStrip1.TabIndex = 3;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// treeCluster
			// 
			this.treeCluster.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.treeCluster.Location = new System.Drawing.Point(748, 24);
			this.treeCluster.Margin = new System.Windows.Forms.Padding(0);
			this.treeCluster.Name = "treeCluster";
			this.treeCluster.Size = new System.Drawing.Size(545, 704);
			this.treeCluster.TabIndex = 1;
			// 
			// pageDisplay1
			// 
			this.pageDisplay1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pageDisplay1.Location = new System.Drawing.Point(0, 24);
			this.pageDisplay1.Margin = new System.Windows.Forms.Padding(0);
			this.pageDisplay1.Name = "pageDisplay1";
			this.pageDisplay1.Size = new System.Drawing.Size(748, 704);
			this.pageDisplay1.TabIndex = 0;
			// 
			// HNClusterUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1293, 749);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.treeCluster);
			this.Controls.Add(this.pageDisplay1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "HNClusterUI";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private UIControlLibrary.PageDisplay pageDisplay1;
		private UIControlLibrary.TreeCluster treeCluster;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.StatusStrip statusStrip1;

	}
}

