
namespace BatchImageEditor
{
	partial class PreviewImageControl
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
			this._sizeLabel = new System.Windows.Forms.Label();
			this._pictureBox = new System.Windows.Forms.PictureBox();
			this._fitButton = new System.Windows.Forms.Button();
			this._centerButton = new System.Windows.Forms.Button();
			this._controlPanel = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this._pictureBox)).BeginInit();
			this._controlPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// _sizeLabel
			// 
			this._sizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this._sizeLabel.AutoSize = true;
			this._sizeLabel.Location = new System.Drawing.Point(0, 10);
			this._sizeLabel.Name = "_sizeLabel";
			this._sizeLabel.Size = new System.Drawing.Size(92, 20);
			this._sizeLabel.TabIndex = 5;
			this._sizeLabel.Text = "500 x 500 px";
			// 
			// _pictureBox
			// 
			this._pictureBox.BackColor = System.Drawing.Color.White;
			this._pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this._pictureBox.Location = new System.Drawing.Point(0, 0);
			this._pictureBox.Name = "_pictureBox";
			this._pictureBox.Size = new System.Drawing.Size(437, 360);
			this._pictureBox.TabIndex = 4;
			this._pictureBox.TabStop = false;
			// 
			// _fitButton
			// 
			this._fitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._fitButton.Location = new System.Drawing.Point(251, 3);
			this._fitButton.Name = "_fitButton";
			this._fitButton.Size = new System.Drawing.Size(90, 35);
			this._fitButton.TabIndex = 7;
			this._fitButton.Text = "Fit";
			this._fitButton.UseVisualStyleBackColor = true;
			this._fitButton.Click += new System.EventHandler(this.FitButton_Click);
			// 
			// _centerButton
			// 
			this._centerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._centerButton.Location = new System.Drawing.Point(347, 3);
			this._centerButton.Name = "_centerButton";
			this._centerButton.Size = new System.Drawing.Size(90, 35);
			this._centerButton.TabIndex = 8;
			this._centerButton.Text = "Center";
			this._centerButton.UseVisualStyleBackColor = true;
			this._centerButton.Click += new System.EventHandler(this.CenterButton_Click);
			// 
			// _controlPanel
			// 
			this._controlPanel.Controls.Add(this._fitButton);
			this._controlPanel.Controls.Add(this._sizeLabel);
			this._controlPanel.Controls.Add(this._centerButton);
			this._controlPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this._controlPanel.Location = new System.Drawing.Point(0, 319);
			this._controlPanel.Name = "_controlPanel";
			this._controlPanel.Size = new System.Drawing.Size(437, 41);
			this._controlPanel.TabIndex = 9;
			// 
			// PreviewImageControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._controlPanel);
			this.Controls.Add(this._pictureBox);
			this.Name = "PreviewImageControl";
			this.Size = new System.Drawing.Size(437, 360);
			((System.ComponentModel.ISupportInitialize)(this._pictureBox)).EndInit();
			this._controlPanel.ResumeLayout(false);
			this._controlPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label _sizeLabel;
		private System.Windows.Forms.PictureBox _pictureBox;
		private System.Windows.Forms.Button _fitButton;
		private System.Windows.Forms.Button _centerButton;
		private System.Windows.Forms.Panel _controlPanel;
	}
}
