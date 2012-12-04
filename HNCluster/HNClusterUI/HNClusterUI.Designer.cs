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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pageDisplay1 = new UIControlLibrary.PageDisplay();
            this.treeCluster = new UIControlLibrary.TreeCluster();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.graphDisplay1 = new UIControlLibrary.GraphDisplay();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1244, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 700);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1244, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1244, 676);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pageDisplay1);
            this.tabPage1.Controls.Add(this.treeCluster);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1236, 650);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pageDisplay1
            // 
            this.pageDisplay1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pageDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageDisplay1.Location = new System.Drawing.Point(3, 3);
            this.pageDisplay1.Margin = new System.Windows.Forms.Padding(0);
            this.pageDisplay1.Name = "pageDisplay1";
            this.pageDisplay1.Size = new System.Drawing.Size(899, 644);
            this.pageDisplay1.TabIndex = 0;
            // 
            // treeCluster
            // 
            this.treeCluster.Dock = System.Windows.Forms.DockStyle.Right;
            this.treeCluster.Location = new System.Drawing.Point(902, 3);
            this.treeCluster.Margin = new System.Windows.Forms.Padding(0);
            this.treeCluster.Name = "treeCluster";
            this.treeCluster.Size = new System.Drawing.Size(331, 644);
            this.treeCluster.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.graphDisplay1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1376, 740);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // graphDisplay1
            // 
            this.graphDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphDisplay1.Location = new System.Drawing.Point(3, 3);
            this.graphDisplay1.Name = "graphDisplay1";
            this.graphDisplay1.Size = new System.Drawing.Size(1370, 734);
            this.graphDisplay1.TabIndex = 0;
            // 
            // HNClusterUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 722);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HNClusterUI";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private UIControlLibrary.PageDisplay pageDisplay1;
		private UIControlLibrary.TreeCluster treeCluster;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private UIControlLibrary.GraphDisplay graphDisplay1;

	}
}

