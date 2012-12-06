namespace Recommender
{
    partial class RecommenderUI
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
            this.recPageDisplay = new UIControlLibrary.PageDisplay();
            this.SuspendLayout();
            //
            // recPageDisplay
            //
            this.recPageDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recPageDisplay.Location = new System.Drawing.Point(0, 0);
            this.recPageDisplay.Name = "graphDisplay1";
            this.recPageDisplay.Size = new System.Drawing.Size(1174, 771);
            this.recPageDisplay.TabIndex = 0;

            // 
            // RecommenderUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1174, 771);
            this.Controls.Add(this.recPageDisplay);
            this.Name = "RecommenderUI";
            this.Text = "RecommenderUI";
            this.ResumeLayout(false);
        }

        #endregion

        private UIControlLibrary.PageDisplay recPageDisplay;
    }
}