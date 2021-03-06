﻿namespace HNClusterUI
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
			this.tabPageDisplay = new System.Windows.Forms.TabPage();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.pageDisplay1 = new UIControlLibrary.PageDisplay();
			this.treeCluster = new UIControlLibrary.TreeCluster();
			this.tabPageGraph = new System.Windows.Forms.TabPage();
			this.graphDisplay1 = new UIControlLibrary.GraphDisplay();
			this.tabPageRecommender = new System.Windows.Forms.TabPage();
			this.recPageDisplay = new UIControlLibrary.PageDisplay();
			this.recommenderDisplay = new UIControlLibrary.RecommenderDisplay();
			this.tabControl1.SuspendLayout();
			this.tabPageDisplay.SuspendLayout();
			this.tabPageGraph.SuspendLayout();
			this.tabPageRecommender.SuspendLayout();
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
			this.tabControl1.Controls.Add(this.tabPageDisplay);
			this.tabControl1.Controls.Add(this.tabPageGraph);
			this.tabControl1.Controls.Add(this.tabPageRecommender);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 24);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1244, 676);
			this.tabControl1.TabIndex = 4;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
			// 
			// tabPageDisplay
			// 
			this.tabPageDisplay.Controls.Add(this.splitter1);
			this.tabPageDisplay.Controls.Add(this.pageDisplay1);
			this.tabPageDisplay.Controls.Add(this.treeCluster);
			this.tabPageDisplay.Location = new System.Drawing.Point(4, 22);
			this.tabPageDisplay.Name = "tabPageDisplay";
			this.tabPageDisplay.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDisplay.Size = new System.Drawing.Size(1236, 650);
			this.tabPageDisplay.TabIndex = 0;
			this.tabPageDisplay.Text = "Display";
			this.tabPageDisplay.UseVisualStyleBackColor = true;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
			this.splitter1.Location = new System.Drawing.Point(661, 3);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(5, 644);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// pageDisplay1
			// 
			this.pageDisplay1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pageDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pageDisplay1.Location = new System.Drawing.Point(3, 3);
			this.pageDisplay1.Margin = new System.Windows.Forms.Padding(0);
			this.pageDisplay1.Name = "pageDisplay1";
			this.pageDisplay1.Size = new System.Drawing.Size(663, 644);
			this.pageDisplay1.TabIndex = 0;
			// 
			// treeCluster
			// 
			this.treeCluster.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.treeCluster.Dock = System.Windows.Forms.DockStyle.Right;
			this.treeCluster.Location = new System.Drawing.Point(666, 3);
			this.treeCluster.Margin = new System.Windows.Forms.Padding(0);
			this.treeCluster.Name = "treeCluster";
			this.treeCluster.Size = new System.Drawing.Size(567, 644);
			this.treeCluster.TabIndex = 1;
			// 
			// tabPageGraph
			// 
			this.tabPageGraph.Controls.Add(this.graphDisplay1);
			this.tabPageGraph.Location = new System.Drawing.Point(4, 22);
			this.tabPageGraph.Name = "tabPageGraph";
			this.tabPageGraph.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGraph.Size = new System.Drawing.Size(1236, 650);
			this.tabPageGraph.TabIndex = 1;
			this.tabPageGraph.Text = "Graph";
			this.tabPageGraph.UseVisualStyleBackColor = true;
			// 
			// graphDisplay1
			// 
			this.graphDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.graphDisplay1.Location = new System.Drawing.Point(3, 3);
			this.graphDisplay1.Name = "graphDisplay1";
			this.graphDisplay1.Size = new System.Drawing.Size(1230, 644);
			this.graphDisplay1.TabIndex = 0;
			// 
			// tabPageRecommender
			// 
			this.tabPageRecommender.Controls.Add(this.recPageDisplay);
			this.tabPageRecommender.Controls.Add(this.recommenderDisplay);
			this.tabPageRecommender.Location = new System.Drawing.Point(4, 22);
			this.tabPageRecommender.Name = "tabPageRecommender";
			this.tabPageRecommender.Size = new System.Drawing.Size(1236, 650);
			this.tabPageRecommender.TabIndex = 2;
			this.tabPageRecommender.Text = "Recommender";
			this.tabPageRecommender.UseVisualStyleBackColor = true;
			// 
			// recPageDisplay
			// 
			this.recPageDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.recPageDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
			this.recPageDisplay.Location = new System.Drawing.Point(0, 0);
			this.recPageDisplay.Margin = new System.Windows.Forms.Padding(0);
			this.recPageDisplay.Name = "recPageDisplay";
			this.recPageDisplay.Size = new System.Drawing.Size(836, 650);
			this.recPageDisplay.TabIndex = 2;
			// 
			// recommenderDisplay
			// 
			this.recommenderDisplay.Dock = System.Windows.Forms.DockStyle.Right;
			this.recommenderDisplay.Location = new System.Drawing.Point(836, 0);
			this.recommenderDisplay.Name = "recommenderDisplay";
			this.recommenderDisplay.Size = new System.Drawing.Size(400, 650);
			this.recommenderDisplay.TabIndex = 0;
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
			this.Text = "HNCluster";
			this.tabControl1.ResumeLayout(false);
			this.tabPageDisplay.ResumeLayout(false);
			this.tabPageGraph.ResumeLayout(false);
			this.tabPageRecommender.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private UIControlLibrary.PageDisplay pageDisplay1;
		private UIControlLibrary.TreeCluster treeCluster;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPageDisplay;
		private System.Windows.Forms.TabPage tabPageGraph;
		private UIControlLibrary.GraphDisplay graphDisplay1;
        private System.Windows.Forms.TabPage tabPageRecommender;
        private UIControlLibrary.RecommenderDisplay recommenderDisplay;
        private UIControlLibrary.PageDisplay recPageDisplay;
		  private System.Windows.Forms.Splitter splitter1;
	}
}

