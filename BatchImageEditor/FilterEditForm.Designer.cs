﻿
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
			this.imagePreview1 = new BatchImageEditor.ImagePreview();
			this._previewGroup = new System.Windows.Forms.GroupBox();
			this._previewGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// imagePreview1
			// 
			this.imagePreview1.Location = new System.Drawing.Point(6, 26);
			this.imagePreview1.Name = "imagePreview1";
			this.imagePreview1.Size = new System.Drawing.Size(461, 394);
			this.imagePreview1.TabIndex = 0;
			// 
			// _previewGroup
			// 
			this._previewGroup.Controls.Add(this.imagePreview1);
			this._previewGroup.Location = new System.Drawing.Point(12, 12);
			this._previewGroup.Name = "_previewGroup";
			this._previewGroup.Size = new System.Drawing.Size(473, 426);
			this._previewGroup.TabIndex = 1;
			this._previewGroup.TabStop = false;
			this._previewGroup.Text = "Preview";
			// 
			// FilterEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this._previewGroup);
			this.Name = "FilterEditForm";
			this.Text = "FilterEditForm";
			this._previewGroup.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private ImagePreview imagePreview1;
		private System.Windows.Forms.GroupBox _previewGroup;
	}
}