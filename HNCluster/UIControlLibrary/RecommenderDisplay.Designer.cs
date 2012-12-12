namespace UIControlLibrary
{
    partial class RecommenderDisplay
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxUsername = new System.Windows.Forms.TextBox();
            this.listBoxLikedPages = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxRecommendedPages = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGenerateRecs = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Logged In As";
            // 
            // txtBoxUsername
            // 
            this.txtBoxUsername.Location = new System.Drawing.Point(297, 3);
            this.txtBoxUsername.Name = "txtBoxUsername";
            this.txtBoxUsername.ReadOnly = true;
            this.txtBoxUsername.Size = new System.Drawing.Size(100, 20);
            this.txtBoxUsername.TabIndex = 1;
            // 
            // listBoxLikedPages
            // 
            this.listBoxLikedPages.FormattingEnabled = true;
            this.listBoxLikedPages.Location = new System.Drawing.Point(27, 40);
            this.listBoxLikedPages.Name = "listBoxLikedPages";
            this.listBoxLikedPages.Size = new System.Drawing.Size(296, 238);
            this.listBoxLikedPages.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pages you have recently viewed";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(123, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Pages you might like";
            // 
            // listBoxRecommendedPages
            // 
            this.listBoxRecommendedPages.FormattingEnabled = true;
            this.listBoxRecommendedPages.Location = new System.Drawing.Point(27, 327);
            this.listBoxRecommendedPages.Name = "listBoxRecommendedPages";
            this.listBoxRecommendedPages.Size = new System.Drawing.Size(296, 238);
            this.listBoxRecommendedPages.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxRecommendedPages);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.listBoxLikedPages);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(21, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 589);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnGenerateRecs
            // 
            this.btnGenerateRecs.AutoSize = true;
            this.btnGenerateRecs.Location = new System.Drawing.Point(119, 650);
            this.btnGenerateRecs.Name = "btnGenerateRecs";
            this.btnGenerateRecs.Size = new System.Drawing.Size(152, 23);
            this.btnGenerateRecs.TabIndex = 2;
            this.btnGenerateRecs.Text = "Generate Recommendations";
            this.btnGenerateRecs.UseVisualStyleBackColor = true;
            // 
            // RecommenderDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGenerateRecs);
            this.Controls.Add(this.txtBoxUsername);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "RecommenderDisplay";
            this.Size = new System.Drawing.Size(400, 771);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;

        public System.Windows.Forms.ListBox listBoxLikedPages;
        public System.Windows.Forms.ListBox listBoxRecommendedPages;
        public System.Windows.Forms.Button btnGenerateRecs;
    }
}
