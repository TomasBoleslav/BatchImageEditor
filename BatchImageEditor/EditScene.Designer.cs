
namespace BatchImageEditor
{
	partial class EditScene
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
			this.filterList1 = new BatchImageEditor.FilterList();
			this._filtersGroup = new System.Windows.Forms.GroupBox();
			this._previewGroup = new System.Windows.Forms.GroupBox();
			this.imagePreview1 = new BatchImageEditor.ImagePreview();
			this._selectedImageComboBox = new System.Windows.Forms.ComboBox();
			this._filtersGroup.SuspendLayout();
			this._previewGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// filterList1
			// 
			this.filterList1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.filterList1.InputBitmap = null;
			this.filterList1.Location = new System.Drawing.Point(10, 30);
			this.filterList1.Name = "filterList1";
			this.filterList1.Size = new System.Drawing.Size(335, 500);
			this.filterList1.TabIndex = 0;
			// 
			// _filtersGroup
			// 
			this._filtersGroup.Controls.Add(this.filterList1);
			this._filtersGroup.Location = new System.Drawing.Point(18, 18);
			this._filtersGroup.Name = "_filtersGroup";
			this._filtersGroup.Padding = new System.Windows.Forms.Padding(10);
			this._filtersGroup.Size = new System.Drawing.Size(355, 540);
			this._filtersGroup.TabIndex = 1;
			this._filtersGroup.TabStop = false;
			this._filtersGroup.Text = "Filters";
			// 
			// _previewGroup
			// 
			this._previewGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._previewGroup.Controls.Add(this.imagePreview1);
			this._previewGroup.Controls.Add(this._selectedImageComboBox);
			this._previewGroup.Location = new System.Drawing.Point(379, 18);
			this._previewGroup.Name = "_previewGroup";
			this._previewGroup.Padding = new System.Windows.Forms.Padding(10);
			this._previewGroup.Size = new System.Drawing.Size(614, 540);
			this._previewGroup.TabIndex = 2;
			this._previewGroup.TabStop = false;
			this._previewGroup.Text = "Preview";
			// 
			// imagePreview1
			// 
			this.imagePreview1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imagePreview1.Location = new System.Drawing.Point(10, 58);
			this.imagePreview1.Name = "imagePreview1";
			this.imagePreview1.Size = new System.Drawing.Size(594, 472);
			this.imagePreview1.TabIndex = 1;
			// 
			// _selectedImageComboBox
			// 
			this._selectedImageComboBox.Dock = System.Windows.Forms.DockStyle.Top;
			this._selectedImageComboBox.FormattingEnabled = true;
			this._selectedImageComboBox.Location = new System.Drawing.Point(10, 30);
			this._selectedImageComboBox.Name = "_selectedImageComboBox";
			this._selectedImageComboBox.Size = new System.Drawing.Size(594, 28);
			this._selectedImageComboBox.TabIndex = 0;
			this._selectedImageComboBox.Text = "Select image for preview";
			// 
			// EditScene
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._previewGroup);
			this.Controls.Add(this._filtersGroup);
			this.Name = "EditScene";
			this.Padding = new System.Windows.Forms.Padding(15);
			this.Size = new System.Drawing.Size(1011, 576);
			this._filtersGroup.ResumeLayout(false);
			this._previewGroup.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private FilterList filterList1;
		private System.Windows.Forms.GroupBox _filtersGroup;
		private System.Windows.Forms.GroupBox _previewGroup;
		private ImagePreview imagePreview1;
		private System.Windows.Forms.ComboBox _selectedImageComboBox;
	}
}
