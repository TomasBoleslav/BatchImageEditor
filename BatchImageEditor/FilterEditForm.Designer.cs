
namespace BatchImageEditor
{
	partial class FilterEditForm
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
			this._previewGroup = new System.Windows.Forms.GroupBox();
			this.imagePreview1 = new BatchImageEditor.ImagePreview();
			this._settingsGroup = new System.Windows.Forms.GroupBox();
			this._previewGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// _previewGroup
			// 
			this._previewGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._previewGroup.Controls.Add(this.imagePreview1);
			this._previewGroup.Location = new System.Drawing.Point(12, 12);
			this._previewGroup.Name = "_previewGroup";
			this._previewGroup.Size = new System.Drawing.Size(510, 446);
			this._previewGroup.TabIndex = 1;
			this._previewGroup.TabStop = false;
			this._previewGroup.Text = "Preview";
			// 
			// imagePreview1
			// 
			this.imagePreview1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.imagePreview1.Location = new System.Drawing.Point(6, 26);
			this.imagePreview1.Name = "imagePreview1";
			this.imagePreview1.Size = new System.Drawing.Size(498, 414);
			this.imagePreview1.TabIndex = 2;
			// 
			// _settingsGroup
			// 
			this._settingsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._settingsGroup.Location = new System.Drawing.Point(528, 12);
			this._settingsGroup.Name = "_settingsGroup";
			this._settingsGroup.Size = new System.Drawing.Size(258, 446);
			this._settingsGroup.TabIndex = 2;
			this._settingsGroup.TabStop = false;
			this._settingsGroup.Text = "Settings";
			// 
			// FilterEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(798, 470);
			this.Controls.Add(this._settingsGroup);
			this.Controls.Add(this._previewGroup);
			this.Name = "FilterEditForm";
			this.Text = "FilterEditForm";
			this._previewGroup.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.GroupBox _previewGroup;
		private ImagePreview imagePreview1;
		private System.Windows.Forms.GroupBox _settingsGroup;
	}
}