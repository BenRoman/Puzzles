namespace PuzzleDevCom
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
            this.LinkBox = new System.Windows.Forms.TextBox();
            this.OK = new System.Windows.Forms.Button();
            this.LinkPictureBox = new System.Windows.Forms.PictureBox();
            this.unsort = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LinkPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LinkBox
            // 
            this.LinkBox.Location = new System.Drawing.Point(69, 60);
            this.LinkBox.Name = "LinkBox";
            this.LinkBox.Size = new System.Drawing.Size(377, 20);
            this.LinkBox.TabIndex = 0;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(491, 32);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(63, 48);
            this.OK.TabIndex = 1;
            this.OK.Text = "next ";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // LinkPictureBox
            // 
            this.LinkPictureBox.Location = new System.Drawing.Point(1, 0);
            this.LinkPictureBox.Name = "LinkPictureBox";
            this.LinkPictureBox.Size = new System.Drawing.Size(331, 196);
            this.LinkPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LinkPictureBox.TabIndex = 2;
            this.LinkPictureBox.TabStop = false;
            this.LinkPictureBox.Visible = false;
            // 
            // unsort
            // 
            this.unsort.Location = new System.Drawing.Point(396, 329);
            this.unsort.Name = "unsort";
            this.unsort.Size = new System.Drawing.Size(75, 23);
            this.unsort.TabIndex = 8;
            this.unsort.Text = "unsort";
            this.unsort.UseVisualStyleBackColor = true;
            this.unsort.Click += new System.EventHandler(this.unsort_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Give me image URL";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(765, 304);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.unsort);
            this.Controls.Add(this.LinkPictureBox);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.LinkBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.LinkPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LinkBox;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.PictureBox LinkPictureBox;
        private System.Windows.Forms.Button unsort;
        private System.Windows.Forms.Label label1;
    }
}

