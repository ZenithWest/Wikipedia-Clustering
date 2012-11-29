namespace UIControlLibrary
{
    partial class PageDisplay
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
			this.ButtonPreviousPage = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.buttonNextPage = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// webBrowser1
			// 
			this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webBrowser1.Location = new System.Drawing.Point(0, 43);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new System.Drawing.Size(600, 507);
			this.webBrowser1.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.buttonNextPage);
			this.panel1.Controls.Add(this.ButtonPreviousPage);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 550);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(600, 50);
			this.panel1.TabIndex = 1;
			// 
			// ButtonPreviousPage
			// 
			this.ButtonPreviousPage.Location = new System.Drawing.Point(3, 6);
			this.ButtonPreviousPage.Name = "ButtonPreviousPage";
			this.ButtonPreviousPage.Size = new System.Drawing.Size(109, 41);
			this.ButtonPreviousPage.TabIndex = 0;
			this.ButtonPreviousPage.Text = "Previous Page";
			this.ButtonPreviousPage.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(600, 43);
			this.panel2.TabIndex = 2;
			// 
			// buttonNextPage
			// 
			this.buttonNextPage.Location = new System.Drawing.Point(488, 6);
			this.buttonNextPage.Name = "buttonNextPage";
			this.buttonNextPage.Size = new System.Drawing.Size(109, 41);
			this.buttonNextPage.TabIndex = 1;
			this.buttonNextPage.Text = "Next Page";
			this.buttonNextPage.UseVisualStyleBackColor = true;
			// 
			// PageDisplay
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.webBrowser1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "PageDisplay";
			this.Size = new System.Drawing.Size(600, 600);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

		  private System.Windows.Forms.WebBrowser webBrowser1;
		  private System.Windows.Forms.Panel panel1;
		  private System.Windows.Forms.Button ButtonPreviousPage;
		  private System.Windows.Forms.Panel panel2;
		  private System.Windows.Forms.Button buttonNextPage;
    }
}
