
namespace BatchImageEditor
{
	partial class ImagePreview
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
			this._imageBox = new System.Windows.Forms.PictureBox();
			this._sizeLabel = new System.Windows.Forms.Label();
			this._zoomInButton = new System.Windows.Forms.Button();
			this._zoomOutButton = new System.Windows.Forms.Button();
			this._zoomLabel = new System.Windows.Forms.Label();
			this._previewSwitchButton = new System.Windows.Forms.Button();
			this._zoomPanel = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this._imageBox)).BeginInit();
			this._zoomPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// _imageBox
			// 
			this._imageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._imageBox.BackColor = System.Drawing.Color.White;
			this._imageBox.Location = new System.Drawing.Point(3, 44);
			this._imageBox.Name = "_imageBox";
			this._imageBox.Size = new System.Drawing.Size(479, 322);
			this._imageBox.TabIndex = 0;
			this._imageBox.TabStop = false;
			// 
			// _sizeLabel
			// 
			this._sizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this._sizeLabel.AutoSize = true;
			this._sizeLabel.Location = new System.Drawing.Point(3, 379);
			this._sizeLabel.Name = "_sizeLabel";
			this._sizeLabel.Size = new System.Drawing.Size(92, 20);
			this._sizeLabel.TabIndex = 3;
			this._sizeLabel.Text = "500 x 500 px";
			// 
			// _zoomInButton
			// 
			this._zoomInButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._zoomInButton.Location = new System.Drawing.Point(170, 0);
			this._zoomInButton.Name = "_zoomInButton";
			this._zoomInButton.Size = new System.Drawing.Size(100, 35);
			this._zoomInButton.TabIndex = 5;
			this._zoomInButton.Text = "Zoom in";
			this._zoomInButton.UseVisualStyleBackColor = true;
			this._zoomInButton.Click += new System.EventHandler(this.ZoomInButton_Click);
			// 
			// _zoomOutButton
			// 
			this._zoomOutButton.Location = new System.Drawing.Point(0, 0);
			this._zoomOutButton.Name = "_zoomOutButton";
			this._zoomOutButton.Size = new System.Drawing.Size(100, 35);
			this._zoomOutButton.TabIndex = 6;
			this._zoomOutButton.Text = "Zoom out";
			this._zoomOutButton.UseVisualStyleBackColor = true;
			this._zoomOutButton.Click += new System.EventHandler(this.ZoomOutButton_Click);
			// 
			// _zoomLabel
			// 
			this._zoomLabel.AutoSize = true;
			this._zoomLabel.Location = new System.Drawing.Point(110, 7);
			this._zoomLabel.Name = "_zoomLabel";
			this._zoomLabel.Size = new System.Drawing.Size(45, 20);
			this._zoomLabel.TabIndex = 7;
			this._zoomLabel.Text = "100%";
			// 
			// _previewSwitchButton
			// 
			this._previewSwitchButton.Location = new System.Drawing.Point(3, 3);
			this._previewSwitchButton.Name = "_previewSwitchButton";
			this._previewSwitchButton.Size = new System.Drawing.Size(120, 35);
			this._previewSwitchButton.TabIndex = 8;
			this._previewSwitchButton.Text = "Show original";
			this._previewSwitchButton.UseVisualStyleBackColor = true;
			this._previewSwitchButton.Click += new System.EventHandler(this.PreviewSwitchButton_Click);
			// 
			// _zoomPanel
			// 
			this._zoomPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._zoomPanel.Controls.Add(this._zoomOutButton);
			this._zoomPanel.Controls.Add(this._zoomInButton);
			this._zoomPanel.Controls.Add(this._zoomLabel);
			this._zoomPanel.Location = new System.Drawing.Point(212, 372);
			this._zoomPanel.Name = "_zoomPanel";
			this._zoomPanel.Size = new System.Drawing.Size(270, 35);
			this._zoomPanel.TabIndex = 9;
			// 
			// ImagePreview
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._zoomPanel);
			this.Controls.Add(this._previewSwitchButton);
			this.Controls.Add(this._sizeLabel);
			this.Controls.Add(this._imageBox);
			this.Name = "ImagePreview";
			this.Size = new System.Drawing.Size(485, 410);
			((System.ComponentModel.ISupportInitialize)(this._imageBox)).EndInit();
			this._zoomPanel.ResumeLayout(false);
			this._zoomPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox _imageBox;
		private System.Windows.Forms.Label _sizeLabel;
		private System.Windows.Forms.Button _zoomInButton;
		private System.Windows.Forms.Button _zoomOutButton;
		private System.Windows.Forms.Label _zoomLabel;
		private System.Windows.Forms.Button _previewSwitchButton;
		private System.Windows.Forms.Panel _zoomPanel;
	}
}
