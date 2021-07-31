
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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
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
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(600, 423);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(90, 35);
			this.button1.TabIndex = 3;
			this.button1.Text = "Add";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(696, 423);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(90, 35);
			this.button2.TabIndex = 4;
			this.button2.Text = "Reset";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// FilterEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(798, 470);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this._previewGroup);
			this.Name = "FilterEditForm";
			this.Text = "FilterEditForm";
			this._previewGroup.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.GroupBox _previewGroup;
		private ImagePreview imagePreview1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}