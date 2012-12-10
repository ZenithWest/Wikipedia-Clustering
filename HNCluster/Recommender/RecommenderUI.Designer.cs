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
            
            this.recommenderDisplay1 = new UIControlLibrary.RecommenderDisplay();
			// 
			// recommenderDisplay1
			// 
			this.recommenderDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.recommenderDisplay1.Location = new System.Drawing.Point(0, 0);
			this.recommenderDisplay1.Name = "recommenderDisplay1";
			this.recommenderDisplay1.Size = new System.Drawing.Size(1174, 771);
			this.recommenderDisplay1.TabIndex = 0;
            this.SuspendLayout();
            // 
            // RecommenderUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1174, 771);
            this.Name = "RecommenderUI";
            this.Text = "RecommenderUI";
            this.ResumeLayout(false);
        }

		#endregion

		private UIControlLibrary.RecommenderDisplay recommenderDisplay1;
    }
}