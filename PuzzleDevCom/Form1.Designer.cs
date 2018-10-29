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
            this.LinkPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.check = new System.Windows.Forms.Button();
            this.auto = new System.Windows.Forms.Button();
            this.tip1 = new System.Windows.Forms.Label();
            this.tip2 = new System.Windows.Forms.Label();
            this.SizeBox = new System.Windows.Forms.TextBox();
            this.second_auto = new System.Windows.Forms.Button();
            this.tips = new PuzzleDevCom.CircularButton();
            this.unsort = new PuzzleDevCom.CircularButton();
            this.OK = new PuzzleDevCom.CircularButton();
            ((System.ComponentModel.ISupportInitialize)(this.LinkPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LinkBox
            // 
            this.LinkBox.Location = new System.Drawing.Point(43, 52);
            this.LinkBox.Name = "LinkBox";
            this.LinkBox.Size = new System.Drawing.Size(215, 20);
            this.LinkBox.TabIndex = 0;
            // 
            // LinkPictureBox
            // 
            this.LinkPictureBox.Location = new System.Drawing.Point(12, 12);
            this.LinkPictureBox.Name = "LinkPictureBox";
            this.LinkPictureBox.Size = new System.Drawing.Size(331, 196);
            this.LinkPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LinkPictureBox.TabIndex = 2;
            this.LinkPictureBox.TabStop = false;
            this.LinkPictureBox.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Give me image URL                   and              N  ( NxN size )";
            // 
            // check
            // 
            this.check.Location = new System.Drawing.Point(386, 60);
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(75, 23);
            this.check.TabIndex = 10;
            this.check.Text = "check";
            this.check.UseVisualStyleBackColor = true;
            this.check.Visible = false;
            this.check.Click += new System.EventHandler(this.check_Click);
            // 
            // auto
            // 
            this.auto.Location = new System.Drawing.Point(386, 149);
            this.auto.Name = "auto";
            this.auto.Size = new System.Drawing.Size(75, 23);
            this.auto.TabIndex = 11;
            this.auto.Text = "auto";
            this.auto.UseVisualStyleBackColor = true;
            this.auto.Visible = false;
            this.auto.Click += new System.EventHandler(this.auto_Click);
            // 
            // tip1
            // 
            this.tip1.AutoSize = true;
            this.tip1.ForeColor = System.Drawing.Color.Black;
            this.tip1.Location = new System.Drawing.Point(79, 221);
            this.tip1.Name = "tip1";
            this.tip1.Size = new System.Drawing.Size(178, 13);
            this.tip1.TabIndex = 14;
            this.tip1.Text = "RIGHT mouse button click for rotate";
            this.tip1.Visible = false;
            // 
            // tip2
            // 
            this.tip2.AutoSize = true;
            this.tip2.Location = new System.Drawing.Point(548, 221);
            this.tip2.Name = "tip2";
            this.tip2.Size = new System.Drawing.Size(201, 13);
            this.tip2.TabIndex = 15;
            this.tip2.Text = "DRAG AND DROP puzzles into free cells";
            this.tip2.Visible = false;
            // 
            // SizeBox
            // 
            this.SizeBox.Location = new System.Drawing.Point(315, 52);
            this.SizeBox.Name = "SizeBox";
            this.SizeBox.Size = new System.Drawing.Size(65, 20);
            this.SizeBox.TabIndex = 17;
            // 
            // second_auto
            // 
            this.second_auto.Location = new System.Drawing.Point(386, 185);
            this.second_auto.Name = "second_auto";
            this.second_auto.Size = new System.Drawing.Size(75, 23);
            this.second_auto.TabIndex = 18;
            this.second_auto.Text = "second auto";
            this.second_auto.UseVisualStyleBackColor = true;
            this.second_auto.Visible = false;
            this.second_auto.Click += new System.EventHandler(this.second_auto_Click);
            // 
            // tips
            // 
            this.tips.Location = new System.Drawing.Point(395, 89);
            this.tips.Name = "tips";
            this.tips.Size = new System.Drawing.Size(54, 49);
            this.tips.TabIndex = 16;
            this.tips.Text = "TIPS";
            this.tips.UseVisualStyleBackColor = true;
            this.tips.Visible = false;
            this.tips.Click += new System.EventHandler(this.tips_Click);
            // 
            // unsort
            // 
            this.unsort.Location = new System.Drawing.Point(386, 12);
            this.unsort.Name = "unsort";
            this.unsort.Size = new System.Drawing.Size(75, 196);
            this.unsort.TabIndex = 13;
            this.unsort.Text = "unsort";
            this.unsort.UseVisualStyleBackColor = true;
            this.unsort.Visible = false;
            this.unsort.Click += new System.EventHandler(this.unsort_Click);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(431, 20);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(53, 52);
            this.OK.TabIndex = 12;
            this.OK.Text = "Next";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(533, 88);
            this.Controls.Add(this.second_auto);
            this.Controls.Add(this.SizeBox);
            this.Controls.Add(this.tips);
            this.Controls.Add(this.tip2);
            this.Controls.Add(this.tip1);
            this.Controls.Add(this.unsort);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.auto);
            this.Controls.Add(this.check);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LinkPictureBox);
            this.Controls.Add(this.LinkBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.LinkPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LinkBox;
        private System.Windows.Forms.PictureBox LinkPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button check;
        private System.Windows.Forms.Button auto;
        private CircularButton OK;
        private CircularButton unsort;
        private System.Windows.Forms.Label tip1;
        private System.Windows.Forms.Label tip2;
        private CircularButton tips;
        private System.Windows.Forms.TextBox SizeBox;
        private System.Windows.Forms.Button second_auto;
    }
}

