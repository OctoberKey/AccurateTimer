namespace AccuracyTimer
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStopStart = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTimeIntervalInMiliseconds = new System.Windows.Forms.TextBox();
            this.lstbxElapsedTime = new System.Windows.Forms.ListBox();
            this.btnClearList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // btnStopStart
            // 
            this.btnStopStart.Location = new System.Drawing.Point(46, 159);
            this.btnStopStart.Name = "btnStopStart";
            this.btnStopStart.Size = new System.Drawing.Size(75, 23);
            this.btnStopStart.TabIndex = 2;
            this.btnStopStart.Text = "Start";
            this.btnStopStart.UseVisualStyleBackColor = true;
            this.btnStopStart.Click += new System.EventHandler(this.btnStopStart_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Time Interval in miliseconds";
            // 
            // txtTimeIntervalInMiliseconds
            // 
            this.txtTimeIntervalInMiliseconds.Location = new System.Drawing.Point(139, 161);
            this.txtTimeIntervalInMiliseconds.Name = "txtTimeIntervalInMiliseconds";
            this.txtTimeIntervalInMiliseconds.Size = new System.Drawing.Size(114, 20);
            this.txtTimeIntervalInMiliseconds.TabIndex = 4;
            // 
            // lstbxElapsedTime
            // 
            this.lstbxElapsedTime.FormattingEnabled = true;
            this.lstbxElapsedTime.Location = new System.Drawing.Point(64, 199);
            this.lstbxElapsedTime.Name = "lstbxElapsedTime";
            this.lstbxElapsedTime.Size = new System.Drawing.Size(175, 238);
            this.lstbxElapsedTime.TabIndex = 5;
            // 
            // btnClearList
            // 
            this.btnClearList.Location = new System.Drawing.Point(245, 248);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(43, 23);
            this.btnClearList.TabIndex = 6;
            this.btnClearList.Text = "Clear";
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 474);
            this.Controls.Add(this.btnClearList);
            this.Controls.Add(this.lstbxElapsedTime);
            this.Controls.Add(this.txtTimeIntervalInMiliseconds);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStopStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStopStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTimeIntervalInMiliseconds;
        private System.Windows.Forms.ListBox lstbxElapsedTime;
        private System.Windows.Forms.Button btnClearList;
    }
}

