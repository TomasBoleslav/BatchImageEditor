
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
			this._errorsListView = new System.Windows.Forms.ListView();
			this._inFilenameColumn = new System.Windows.Forms.ColumnHeader();
			this._outFilenameColumn = new System.Windows.Forms.ColumnHeader();
			this._errorMessageColumn = new System.Windows.Forms.ColumnHeader();
			this._errorsLabel = new System.Windows.Forms.Label();
			this._errorCountLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// _progressBar
			// 
			this._progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._progressBar.Location = new System.Drawing.Point(18, 49);
			this._progressBar.Name = "_progressBar";
			this._progressBar.Size = new System.Drawing.Size(546, 45);
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
			this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._cancelButton.Location = new System.Drawing.Point(464, 109);
			this._cancelButton.Name = "_cancelButton";
			this._cancelButton.Size = new System.Drawing.Size(100, 30);
			this._cancelButton.TabIndex = 4;
			this._cancelButton.Text = "Cancel";
			this._cancelButton.UseVisualStyleBackColor = true;
			this._cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// _statusLabel
			// 
			this._statusLabel.AutoSize = true;
			this._statusLabel.Location = new System.Drawing.Point(18, 114);
			this._statusLabel.Name = "_statusLabel";
			this._statusLabel.Size = new System.Drawing.Size(49, 20);
			this._statusLabel.TabIndex = 5;
			this._statusLabel.Text = "Status";
			// 
			// _statusContentLabel
			// 
			this._statusContentLabel.AutoSize = true;
			this._statusContentLabel.Location = new System.Drawing.Point(89, 114);
			this._statusContentLabel.Name = "_statusContentLabel";
			this._statusContentLabel.Size = new System.Drawing.Size(43, 20);
			this._statusContentLabel.TabIndex = 6;
			this._statusContentLabel.Text = "done";
			// 
			// _errorsListView
			// 
			this._errorsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._errorsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._inFilenameColumn,
            this._outFilenameColumn,
            this._errorMessageColumn});
			this._errorsListView.HideSelection = false;
			this._errorsListView.Location = new System.Drawing.Point(18, 193);
			this._errorsListView.Name = "_errorsListView";
			this._errorsListView.Size = new System.Drawing.Size(546, 142);
			this._errorsListView.TabIndex = 8;
			this._errorsListView.UseCompatibleStateImageBehavior = false;
			this._errorsListView.View = System.Windows.Forms.View.Details;
			// 
			// _inFilenameColumn
			// 
			this._inFilenameColumn.Text = "Input Filename";
			this._inFilenameColumn.Width = 150;
			// 
			// _outFilenameColumn
			// 
			this._outFilenameColumn.Text = "Output Filename";
			this._outFilenameColumn.Width = 150;
			// 
			// _errorMessageColumn
			// 
			this._errorMessageColumn.Text = "Error Message";
			this._errorMessageColumn.Width = 200;
			// 
			// _errorsLabel
			// 
			this._errorsLabel.AutoSize = true;
			this._errorsLabel.Location = new System.Drawing.Point(18, 160);
			this._errorsLabel.Name = "_errorsLabel";
			this._errorsLabel.Size = new System.Drawing.Size(47, 20);
			this._errorsLabel.TabIndex = 9;
			this._errorsLabel.Text = "Errors";
			// 
			// _errorCountLabel
			// 
			this._errorCountLabel.AutoSize = true;
			this._errorCountLabel.Location = new System.Drawing.Point(89, 160);
			this._errorCountLabel.Name = "_errorCountLabel";
			this._errorCountLabel.Size = new System.Drawing.Size(17, 20);
			this._errorCountLabel.TabIndex = 10;
			this._errorCountLabel.Text = "0";
			// 
			// ImageProcessingDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(582, 353);
			this.Controls.Add(this._errorCountLabel);
			this.Controls.Add(this._errorsLabel);
			this.Controls.Add(this._errorsListView);
			this.Controls.Add(this._statusContentLabel);
			this.Controls.Add(this._statusLabel);
			this.Controls.Add(this._cancelButton);
			this.Controls.Add(this._headingLabel);
			this.Controls.Add(this._progressBar);
			this.MinimumSize = new System.Drawing.Size(600, 400);
			this.Name = "ImageProcessingDialog";
			this.Padding = new System.Windows.Forms.Padding(15);
			this.Text = "Processing images";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImageProcessingDialog_FormClosing);
			this.Shown += new System.EventHandler(this.ImageProcessingDialog_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar _progressBar;
		private System.Windows.Forms.Label _headingLabel;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.Label _statusLabel;
		private System.Windows.Forms.Label _statusContentLabel;
		private System.Windows.Forms.ListView _errorsListView;
		private System.Windows.Forms.Label _errorsLabel;
		private System.Windows.Forms.Label _errorCountLabel;
		private System.Windows.Forms.ColumnHeader _inFilenameColumn;
		private System.Windows.Forms.ColumnHeader _outFilenameColumn;
		private System.Windows.Forms.ColumnHeader _errorMessageColumn;
	}
}