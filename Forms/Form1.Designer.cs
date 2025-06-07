namespace WindowMover
{
    partial class Form1
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
            this.buttonStandardView = new System.Windows.Forms.Button();
            this.buttonDetailedView = new System.Windows.Forms.Button();
            this.formLoader = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // buttonStandardView
            // 
            this.buttonStandardView.Location = new System.Drawing.Point(12, 12);
            this.buttonStandardView.Name = "buttonStandardView";
            this.buttonStandardView.Size = new System.Drawing.Size(88, 23);
            this.buttonStandardView.TabIndex = 5;
            this.buttonStandardView.Text = "Standard";
            this.buttonStandardView.UseVisualStyleBackColor = true;
            this.buttonStandardView.Click += new System.EventHandler(this.buttonStandardView_Click);
            // 
            // buttonDetailedView
            // 
            this.buttonDetailedView.Location = new System.Drawing.Point(12, 41);
            this.buttonDetailedView.Name = "buttonDetailedView";
            this.buttonDetailedView.Size = new System.Drawing.Size(88, 23);
            this.buttonDetailedView.TabIndex = 6;
            this.buttonDetailedView.Text = "Detailed";
            this.buttonDetailedView.UseVisualStyleBackColor = true;
            this.buttonDetailedView.Click += new System.EventHandler(this.buttonDetailedView_Click);
            // 
            // formLoader
            // 
            this.formLoader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formLoader.Location = new System.Drawing.Point(106, 12);
            this.formLoader.Name = "formLoader";
            this.formLoader.Size = new System.Drawing.Size(873, 426);
            this.formLoader.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 450);
            this.Controls.Add(this.formLoader);
            this.Controls.Add(this.buttonDetailedView);
            this.Controls.Add(this.buttonStandardView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonStandardView;
        private System.Windows.Forms.Button buttonDetailedView;
        private System.Windows.Forms.Panel formLoader;
    }
}

