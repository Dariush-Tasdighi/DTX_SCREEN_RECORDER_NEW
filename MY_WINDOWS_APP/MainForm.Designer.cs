namespace MY_WINDOWS_APP
{
	partial class MainForm
	{
		private System.ComponentModel.IContainer components = null;

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
			this.startButton = new System.Windows.Forms.Button();
			this.stopButton = new System.Windows.Forms.Button();
			this.logsListBox = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// startButton
			// 
			this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.startButton.Location = new System.Drawing.Point(13, 13);
			this.startButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(358, 43);
			this.startButton.TabIndex = 0;
			this.startButton.Text = "&Start";
			this.startButton.UseVisualStyleBackColor = true;
			this.startButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// stopButton
			// 
			this.stopButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.stopButton.Location = new System.Drawing.Point(13, 64);
			this.stopButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.stopButton.Name = "stopButton";
			this.stopButton.Size = new System.Drawing.Size(358, 43);
			this.stopButton.TabIndex = 1;
			this.stopButton.Text = "&Stop";
			this.stopButton.UseVisualStyleBackColor = true;
			this.stopButton.Click += new System.EventHandler(this.StopButton_Click);
			// 
			// logsListBox
			// 
			this.logsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.logsListBox.FormattingEnabled = true;
			this.logsListBox.ItemHeight = 16;
			this.logsListBox.Location = new System.Drawing.Point(13, 114);
			this.logsListBox.Name = "logsListBox";
			this.logsListBox.Size = new System.Drawing.Size(358, 228);
			this.logsListBox.TabIndex = 2;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 361);
			this.Controls.Add(this.logsListBox);
			this.Controls.Add(this.stopButton);
			this.Controls.Add(this.startButton);
			this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(400, 400);
			this.Name = "MainForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DTX Screen Recorder - Version 1.0.0";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.Button stopButton;
		private System.Windows.Forms.ListBox logsListBox;
	}
}
