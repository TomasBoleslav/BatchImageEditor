
namespace BatchImageEditor
{
	partial class LoadScene
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
			this.label2 = new System.Windows.Forms.Label();
			this.loadedPreviewBox = new System.Windows.Forms.PictureBox();
			this._imageListView = new System.Windows.Forms.ListView();
			this._nameHeader = new System.Windows.Forms.ColumnHeader();
			this._dateHeader = new System.Windows.Forms.ColumnHeader();
			this._sizeHeader = new System.Windows.Forms.ColumnHeader();
			this._pathHeader = new System.Windows.Forms.ColumnHeader();
			this._removeButton = new System.Windows.Forms.Button();
			this._loadFolderButton = new System.Windows.Forms.Button();
			this._loadImageButton = new System.Windows.Forms.Button();
			this._imagesGroup = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.loadedPreviewBox)).BeginInit();
			this._imagesGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(620, 211);
			this.label2.Margin = new System.Windows.Forms.Padding(6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 20);
			this.label2.TabIndex = 13;
			this.label2.Text = "Preview:";
			// 
			// loadedPreviewBox
			// 
			this.loadedPreviewBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.loadedPreviewBox.BackColor = System.Drawing.SystemColors.Window;
			this.loadedPreviewBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.loadedPreviewBox.Location = new System.Drawing.Point(620, 243);
			this.loadedPreviewBox.Margin = new System.Windows.Forms.Padding(6);
			this.loadedPreviewBox.Name = "loadedPreviewBox";
			this.loadedPreviewBox.Size = new System.Drawing.Size(260, 250);
			this.loadedPreviewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.loadedPreviewBox.TabIndex = 12;
			this.loadedPreviewBox.TabStop = false;
			// 
			// _imageListView
			// 
			this._imageListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._imageListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._nameHeader,
            this._dateHeader,
            this._sizeHeader,
            this._pathHeader});
			this._imageListView.FullRowSelect = true;
			this._imageListView.HideSelection = false;
			this._imageListView.Location = new System.Drawing.Point(15, 32);
			this._imageListView.Margin = new System.Windows.Forms.Padding(6);
			this._imageListView.Name = "_imageListView";
			this._imageListView.Size = new System.Drawing.Size(593, 458);
			this._imageListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this._imageListView.TabIndex = 10;
			this._imageListView.UseCompatibleStateImageBehavior = false;
			this._imageListView.View = System.Windows.Forms.View.Details;
			this._imageListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ImageListView_ItemSelectionChanged);
			// 
			// nameHeader
			// 
			this._nameHeader.Text = "Name";
			this._nameHeader.Width = 200;
			// 
			// dateHeader
			// 
			this._dateHeader.Text = "Date modified";
			this._dateHeader.Width = 200;
			// 
			// sizeHeader
			// 
			this._sizeHeader.Text = "Size";
			this._sizeHeader.Width = 100;
			// 
			// pathHeader
			// 
			this._pathHeader.Text = "Path";
			this._pathHeader.Width = 200;
			// 
			// _removeButton
			// 
			this._removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._removeButton.Location = new System.Drawing.Point(620, 126);
			this._removeButton.Margin = new System.Windows.Forms.Padding(6);
			this._removeButton.Name = "_removeButton";
			this._removeButton.Size = new System.Drawing.Size(110, 35);
			this._removeButton.TabIndex = 9;
			this._removeButton.Text = "Remove";
			this._removeButton.UseVisualStyleBackColor = true;
			this._removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
			// 
			// _loadFolderButton
			// 
			this._loadFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._loadFolderButton.Location = new System.Drawing.Point(620, 79);
			this._loadFolderButton.Margin = new System.Windows.Forms.Padding(6);
			this._loadFolderButton.Name = "_loadFolderButton";
			this._loadFolderButton.Size = new System.Drawing.Size(110, 35);
			this._loadFolderButton.TabIndex = 8;
			this._loadFolderButton.Text = "Load folder";
			this._loadFolderButton.UseVisualStyleBackColor = true;
			this._loadFolderButton.Click += new System.EventHandler(this.LoadFolderButton_Click);
			// 
			// _loadImageButton
			// 
			this._loadImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._loadImageButton.Location = new System.Drawing.Point(620, 32);
			this._loadImageButton.Margin = new System.Windows.Forms.Padding(6);
			this._loadImageButton.Name = "_loadImageButton";
			this._loadImageButton.Size = new System.Drawing.Size(110, 35);
			this._loadImageButton.TabIndex = 7;
			this._loadImageButton.Text = "Load images";
			this._loadImageButton.UseVisualStyleBackColor = true;
			this._loadImageButton.Click += new System.EventHandler(this.LoadImageButton_Click);
			// 
			// _imagesGroup
			// 
			this._imagesGroup.Controls.Add(this.label2);
			this._imagesGroup.Controls.Add(this.loadedPreviewBox);
			this._imagesGroup.Controls.Add(this._imageListView);
			this._imagesGroup.Controls.Add(this._removeButton);
			this._imagesGroup.Controls.Add(this._loadFolderButton);
			this._imagesGroup.Controls.Add(this._loadImageButton);
			this._imagesGroup.Dock = System.Windows.Forms.DockStyle.Fill;
			this._imagesGroup.Location = new System.Drawing.Point(15, 15);
			this._imagesGroup.Name = "_imagesGroup";
			this._imagesGroup.Padding = new System.Windows.Forms.Padding(6);
			this._imagesGroup.Size = new System.Drawing.Size(892, 505);
			this._imagesGroup.TabIndex = 14;
			this._imagesGroup.TabStop = false;
			this._imagesGroup.Text = "Images";
			// 
			// LoadScene
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._imagesGroup);
			this.Name = "LoadScene";
			this.Padding = new System.Windows.Forms.Padding(15);
			this.Size = new System.Drawing.Size(922, 535);
			((System.ComponentModel.ISupportInitialize)(this.loadedPreviewBox)).EndInit();
			this._imagesGroup.ResumeLayout(false);
			this._imagesGroup.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox loadedPreviewBox;
		private System.Windows.Forms.ListView _imageListView;
		private System.Windows.Forms.ColumnHeader _nameHeader;
		private System.Windows.Forms.ColumnHeader _dateHeader;
		private System.Windows.Forms.ColumnHeader _sizeHeader;
		private System.Windows.Forms.ColumnHeader _pathHeader;
		private System.Windows.Forms.Button _removeButton;
		private System.Windows.Forms.Button _loadFolderButton;
		private System.Windows.Forms.Button _loadImageButton;
		private System.Windows.Forms.GroupBox _imagesGroup;
	}
}
