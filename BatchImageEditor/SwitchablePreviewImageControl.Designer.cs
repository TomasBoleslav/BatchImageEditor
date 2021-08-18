
namespace BatchImageEditor
{
	partial class SwitchablePreviewImageControl
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
			this._previewSwitchButton = new System.Windows.Forms.Button();
			this._previewImageControl = new BatchImageEditor.PreviewImageControl();
			this.SuspendLayout();
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
			// _previewImageControl
			// 
			this._previewImageControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._previewImageControl.Location = new System.Drawing.Point(3, 44);
			this._previewImageControl.Name = "_previewImageControl";
			this._previewImageControl.Image = null;
			this._previewImageControl.Size = new System.Drawing.Size(479, 363);
			this._previewImageControl.TabIndex = 9;
			// 
			// SwitchablePreviewImageControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._previewImageControl);
			this.Controls.Add(this._previewSwitchButton);
			this.Name = "SwitchablePreviewImageControl";
			this.Size = new System.Drawing.Size(485, 410);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button _previewSwitchButton;
		private PreviewImageControl _previewImageControl;
	}
}
