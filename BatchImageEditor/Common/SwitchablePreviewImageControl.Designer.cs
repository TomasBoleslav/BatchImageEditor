
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
			this._controlPanel = new System.Windows.Forms.Panel();
			this._controlPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// _previewSwitchButton
			// 
			this._previewSwitchButton.Location = new System.Drawing.Point(0, 2);
			this._previewSwitchButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._previewSwitchButton.Name = "_previewSwitchButton";
			this._previewSwitchButton.Size = new System.Drawing.Size(105, 26);
			this._previewSwitchButton.TabIndex = 8;
			this._previewSwitchButton.Text = "Show original";
			this._previewSwitchButton.UseVisualStyleBackColor = true;
			this._previewSwitchButton.Click += new System.EventHandler(this.PreviewSwitchButton_Click);
			// 
			// _previewImageControl
			// 
			this._previewImageControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this._previewImageControl.Image = null;
			this._previewImageControl.Location = new System.Drawing.Point(0, 32);
			this._previewImageControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._previewImageControl.Name = "_previewImageControl";
			this._previewImageControl.Size = new System.Drawing.Size(424, 276);
			this._previewImageControl.TabIndex = 9;
			// 
			// _controlPanel
			// 
			this._controlPanel.Controls.Add(this._previewSwitchButton);
			this._controlPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this._controlPanel.Location = new System.Drawing.Point(0, 0);
			this._controlPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._controlPanel.Name = "_controlPanel";
			this._controlPanel.Size = new System.Drawing.Size(424, 32);
			this._controlPanel.TabIndex = 10;
			// 
			// SwitchablePreviewImageControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._previewImageControl);
			this.Controls.Add(this._controlPanel);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "SwitchablePreviewImageControl";
			this.Size = new System.Drawing.Size(424, 308);
			this._controlPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button _previewSwitchButton;
		private PreviewImageControl _previewImageControl;
		private System.Windows.Forms.Panel _controlPanel;
	}
}
