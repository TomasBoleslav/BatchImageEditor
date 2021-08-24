
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
			this._filterListControl = new BatchImageEditor.FilterList();
			this._filtersGroup = new System.Windows.Forms.GroupBox();
			this._previewGroup = new System.Windows.Forms.GroupBox();
			this._previewControl = new BatchImageEditor.SwitchablePreviewImageControl();
			this._fileSelectionControl = new BatchImageEditor.FileSelection();
			this._filtersGroup.SuspendLayout();
			this._previewGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// _filterListControl
			// 
			this._filterListControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._filterListControl.InputImage = null;
			this._filterListControl.Location = new System.Drawing.Point(10, 30);
			this._filterListControl.Name = "_filterListControl";
			this._filterListControl.Size = new System.Drawing.Size(335, 506);
			this._filterListControl.TabIndex = 0;
			this._filterListControl.ListChanged += new System.EventHandler(this.FilterListControl_ListChanged);
			// 
			// _filtersGroup
			// 
			this._filtersGroup.Controls.Add(this._filterListControl);
			this._filtersGroup.Dock = System.Windows.Forms.DockStyle.Left;
			this._filtersGroup.Location = new System.Drawing.Point(15, 15);
			this._filtersGroup.Name = "_filtersGroup";
			this._filtersGroup.Padding = new System.Windows.Forms.Padding(10);
			this._filtersGroup.Size = new System.Drawing.Size(355, 546);
			this._filtersGroup.TabIndex = 1;
			this._filtersGroup.TabStop = false;
			this._filtersGroup.Text = "Filters";
			// 
			// _previewGroup
			// 
			this._previewGroup.Controls.Add(this._previewControl);
			this._previewGroup.Controls.Add(this._fileSelectionControl);
			this._previewGroup.Dock = System.Windows.Forms.DockStyle.Fill;
			this._previewGroup.Location = new System.Drawing.Point(370, 15);
			this._previewGroup.Name = "_previewGroup";
			this._previewGroup.Padding = new System.Windows.Forms.Padding(10);
			this._previewGroup.Size = new System.Drawing.Size(626, 546);
			this._previewGroup.TabIndex = 2;
			this._previewGroup.TabStop = false;
			this._previewGroup.Text = "Preview";
			// 
			// _previewControl
			// 
			this._previewControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this._previewControl.Location = new System.Drawing.Point(10, 64);
			this._previewControl.Name = "_previewControl";
			this._previewControl.OriginalImage = null;
			this._previewControl.PreviewImage = null;
			this._previewControl.Size = new System.Drawing.Size(606, 472);
			this._previewControl.TabIndex = 1;
			// 
			// _fileSelectionControl
			// 
			this._fileSelectionControl.Dock = System.Windows.Forms.DockStyle.Top;
			this._fileSelectionControl.Location = new System.Drawing.Point(10, 30);
			this._fileSelectionControl.Name = "_fileSelectionControl";
			this._fileSelectionControl.Size = new System.Drawing.Size(606, 34);
			this._fileSelectionControl.TabIndex = 0;
			this._fileSelectionControl.SelectionChanged += new System.EventHandler(this.FileSelectionControl_SelectionChanged);
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

		private FilterList _filterListControl;
		private System.Windows.Forms.GroupBox _filtersGroup;
		private System.Windows.Forms.GroupBox _previewGroup;
		private SwitchablePreviewImageControl _previewControl;
		private FileSelection _fileSelectionControl;
	}
}
