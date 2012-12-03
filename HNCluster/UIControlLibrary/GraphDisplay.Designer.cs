namespace UIControlLibrary
{
	partial class GraphDisplay
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
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.panel1 = new System.Windows.Forms.Panel();
			this.buttonZoomIn = new System.Windows.Forms.Button();
			this.buttonZoomOut = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// webBrowser1
			// 
			this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webBrowser1.Location = new System.Drawing.Point(0, 0);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new System.Drawing.Size(468, 400);
			this.webBrowser1.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.buttonZoomOut);
			this.panel1.Controls.Add(this.buttonZoomIn);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 400);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(468, 39);
			this.panel1.TabIndex = 1;
			// 
			// buttonZoomIn
			// 
			this.buttonZoomIn.Location = new System.Drawing.Point(3, 6);
			this.buttonZoomIn.Name = "buttonZoomIn";
			this.buttonZoomIn.Size = new System.Drawing.Size(75, 23);
			this.buttonZoomIn.TabIndex = 0;
			this.buttonZoomIn.Text = "Zoom In";
			this.buttonZoomIn.UseVisualStyleBackColor = true;
			this.buttonZoomIn.Click += new System.EventHandler(this.buttonZoomIn_Click);
			// 
			// buttonZoomOut
			// 
			this.buttonZoomOut.Location = new System.Drawing.Point(84, 6);
			this.buttonZoomOut.Name = "buttonZoomOut";
			this.buttonZoomOut.Size = new System.Drawing.Size(75, 23);
			this.buttonZoomOut.TabIndex = 1;
			this.buttonZoomOut.Text = "Zoom Out";
			this.buttonZoomOut.UseVisualStyleBackColor = true;
			this.buttonZoomOut.Click += new System.EventHandler(this.buttonZoomOut_Click);
			// 
			// GraphDisplay
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.webBrowser1);
			this.Controls.Add(this.panel1);
			this.Name = "GraphDisplay";
			this.Size = new System.Drawing.Size(468, 439);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.WebBrowser webBrowser1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonZoomOut;
		private System.Windows.Forms.Button buttonZoomIn;
	}
}
