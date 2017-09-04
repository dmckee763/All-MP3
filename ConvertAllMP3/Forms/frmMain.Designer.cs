namespace ConvertAllMP3
{
	partial class frmMain
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
            this.btnSelectInput = new System.Windows.Forms.Button();
            this.txtInputPath = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.btnSelectOutput = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // btnSelectInput
            // 
            this.btnSelectInput.Location = new System.Drawing.Point(49, 41);
            this.btnSelectInput.Name = "btnSelectInput";
            this.btnSelectInput.Size = new System.Drawing.Size(84, 26);
            this.btnSelectInput.TabIndex = 0;
            this.btnSelectInput.Text = "Select Input";
            this.btnSelectInput.UseVisualStyleBackColor = true;
            this.btnSelectInput.Click += new System.EventHandler(this.btnSelectInput_Click);
            // 
            // txtInputPath
            // 
            this.txtInputPath.Location = new System.Drawing.Point(153, 44);
            this.txtInputPath.Name = "txtInputPath";
            this.txtInputPath.Size = new System.Drawing.Size(227, 20);
            this.txtInputPath.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(49, 133);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(84, 26);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(153, 80);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(227, 20);
            this.txtOutputPath.TabIndex = 5;
            // 
            // btnSelectOutput
            // 
            this.btnSelectOutput.Location = new System.Drawing.Point(49, 77);
            this.btnSelectOutput.Name = "btnSelectOutput";
            this.btnSelectOutput.Size = new System.Drawing.Size(84, 26);
            this.btnSelectOutput.TabIndex = 4;
            this.btnSelectOutput.Text = "Select Output";
            this.btnSelectOutput.UseVisualStyleBackColor = true;
            this.btnSelectOutput.Click += new System.EventHandler(this.btnSelectOutput_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 323);
            this.Controls.Add(this.txtOutputPath);
            this.Controls.Add(this.btnSelectOutput);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtInputPath);
            this.Controls.Add(this.btnSelectInput);
            this.Name = "frmMain";
            this.Text = "Convert All to MP3";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnSelectInput;
		private System.Windows.Forms.TextBox txtInputPath;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Button btnSelectOutput;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

