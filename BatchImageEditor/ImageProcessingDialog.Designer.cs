
namespace BatchImageEditor
{
	partial class ImageProcessingDialog
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
			this._progressBar = new System.Windows.Forms.ProgressBar();
			this._headingLabel = new System.Windows.Forms.Label();
			this._cancelButton = new System.Windows.Forms.Button();
			this._statusLabel = new System.Windows.Forms.Label();
			this._statusContentLabel = new System.Windows.Forms.Label();
			this._showLogButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// _progressBar
			// 
			this._progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._progressBar.Location = new System.Drawing.Point(18, 48);
			this._progressBar.Name = "_progressBar";
			this._progressBar.Size = new System.Drawing.Size(517, 45);
			this._progressBar.TabIndex = 0;
			// 
			// _headingLabel
			// 
			this._headingLabel.AutoSize = true;
			this._headingLabel.Location = new System.Drawing.Point(18, 15);
			this._headingLabel.Name = "_headingLabel";
			this._headingLabel.Size = new System.Drawing.Size(220, 20);
			this._headingLabel.TabIndex = 1;
			this._headingLabel.Text = "Processing total of 1000 images";
			// 
			// _cancelButton
			// 
			this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._cancelButton.Location = new System.Drawing.Point(435, 118);
			this._cancelButton.Name = "_cancelButton";
			this._cancelButton.Size = new System.Drawing.Size(100, 30);
			this._cancelButton.TabIndex = 4;
			this._cancelButton.Text = "Cancel";
			this._cancelButton.UseVisualStyleBackColor = true;
			// 
			// _statusLabel
			// 
			this._statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this._statusLabel.AutoSize = true;
			this._statusLabel.Location = new System.Drawing.Point(18, 123);
			this._statusLabel.Name = "_statusLabel";
			this._statusLabel.Size = new System.Drawing.Size(49, 20);
			this._statusLabel.TabIndex = 5;
			this._statusLabel.Text = "Status";
			// 
			// _statusContentLabel
			// 
			this._statusContentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this._statusContentLabel.AutoSize = true;
			this._statusContentLabel.Location = new System.Drawing.Point(89, 123);
			this._statusContentLabel.Name = "_statusContentLabel";
			this._statusContentLabel.Size = new System.Drawing.Size(100, 20);
			this._statusContentLabel.TabIndex = 6;
			this._statusContentLabel.Text = "done, 0 errors";
			// 
			// _showLogButton
			// 
			this._showLogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._showLogButton.Location = new System.Drawing.Point(329, 118);
			this._showLogButton.Name = "_showLogButton";
			this._showLogButton.Size = new System.Drawing.Size(100, 30);
			this._showLogButton.TabIndex = 7;
			this._showLogButton.Text = "Show Log";
			this._showLogButton.UseVisualStyleBackColor = true;
			// 
			// ImageProcessingDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(553, 166);
			this.Controls.Add(this._showLogButton);
			this.Controls.Add(this._statusContentLabel);
			this.Controls.Add(this._statusLabel);
			this.Controls.Add(this._cancelButton);
			this.Controls.Add(this._headingLabel);
			this.Controls.Add(this._progressBar);
			this.Name = "ImageProcessingDialog";
			this.Padding = new System.Windows.Forms.Padding(15);
			this.Text = "Processing images";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar _progressBar;
		private System.Windows.Forms.Label _headingLabel;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.Label _statusLabel;
		private System.Windows.Forms.Label _statusContentLabel;
		private System.Windows.Forms.Button _showLogButton;
	}
}