
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
			this._imagePreview = new BatchImageEditor.ImagePreview();
			this._addButton = new System.Windows.Forms.Button();
			this._resetButton = new System.Windows.Forms.Button();
			this._settingsPanel = new System.Windows.Forms.Panel();
			this._previewGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// _previewGroup
			// 
			this._previewGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._previewGroup.Controls.Add(this._imagePreview);
			this._previewGroup.Location = new System.Drawing.Point(12, 12);
			this._previewGroup.Name = "_previewGroup";
			this._previewGroup.Size = new System.Drawing.Size(510, 446);
			this._previewGroup.TabIndex = 1;
			this._previewGroup.TabStop = false;
			this._previewGroup.Text = "Preview";
			// 
			// _imagePreview
			// 
			this._imagePreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._imagePreview.Location = new System.Drawing.Point(6, 26);
			this._imagePreview.Name = "_imagePreview";
			this._imagePreview.Size = new System.Drawing.Size(498, 414);
			this._imagePreview.TabIndex = 2;
			// 
			// _addButton
			// 
			this._addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._addButton.Location = new System.Drawing.Point(600, 423);
			this._addButton.Name = "_addButton";
			this._addButton.Size = new System.Drawing.Size(90, 35);
			this._addButton.TabIndex = 3;
			this._addButton.Text = "Add";
			this._addButton.UseVisualStyleBackColor = true;
			this._addButton.Click += new System.EventHandler(this.AddButton_Click);
			// 
			// _resetButton
			// 
			this._resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._resetButton.Location = new System.Drawing.Point(696, 423);
			this._resetButton.Name = "_resetButton";
			this._resetButton.Size = new System.Drawing.Size(90, 35);
			this._resetButton.TabIndex = 4;
			this._resetButton.Text = "Reset";
			this._resetButton.UseVisualStyleBackColor = true;
			// 
			// _settingsPanel
			// 
			this._settingsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._settingsPanel.Location = new System.Drawing.Point(528, 12);
			this._settingsPanel.Name = "_settingsPanel";
			this._settingsPanel.Size = new System.Drawing.Size(258, 405);
			this._settingsPanel.TabIndex = 5;
			// 
			// FilterEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(798, 470);
			this.Controls.Add(this._settingsPanel);
			this.Controls.Add(this._resetButton);
			this.Controls.Add(this._addButton);
			this.Controls.Add(this._previewGroup);
			this.Name = "FilterEditForm";
			this.Text = "FilterEditForm";
			this._previewGroup.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.GroupBox _previewGroup;
		private ImagePreview _imagePreview;
		private System.Windows.Forms.Button _addButton;
		private System.Windows.Forms.Button _resetButton;
		private System.Windows.Forms.Panel _settingsPanel;
	}
}