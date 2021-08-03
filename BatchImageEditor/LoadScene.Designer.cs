
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
			this.imageListView = new System.Windows.Forms.ListView();
			this.nameHeader = new System.Windows.Forms.ColumnHeader();
			this.dateHeader = new System.Windows.Forms.ColumnHeader();
			this.sizeHeader = new System.Windows.Forms.ColumnHeader();
			this.pathHeader = new System.Windows.Forms.ColumnHeader();
			this.removeButton = new System.Windows.Forms.Button();
			this.loadFolderButton = new System.Windows.Forms.Button();
			this.loadImageButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.loadedPreviewBox)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(614, 205);
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
			this.loadedPreviewBox.Location = new System.Drawing.Point(614, 237);
			this.loadedPreviewBox.Margin = new System.Windows.Forms.Padding(6);
			this.loadedPreviewBox.Name = "loadedPreviewBox";
			this.loadedPreviewBox.Size = new System.Drawing.Size(260, 250);
			this.loadedPreviewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.loadedPreviewBox.TabIndex = 12;
			this.loadedPreviewBox.TabStop = false;
			// 
			// imageListView
			// 
			this.imageListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.imageListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameHeader,
            this.dateHeader,
            this.sizeHeader,
            this.pathHeader});
			this.imageListView.FullRowSelect = true;
			this.imageListView.HideSelection = false;
			this.imageListView.Location = new System.Drawing.Point(15, 32);
			this.imageListView.Margin = new System.Windows.Forms.Padding(6);
			this.imageListView.Name = "imageListView";
			this.imageListView.Size = new System.Drawing.Size(587, 452);
			this.imageListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.imageListView.TabIndex = 10;
			this.imageListView.UseCompatibleStateImageBehavior = false;
			this.imageListView.View = System.Windows.Forms.View.Details;
			this.imageListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ImageListView_ItemSelectionChanged);
			// 
			// nameHeader
			// 
			this.nameHeader.Text = "Name";
			this.nameHeader.Width = 200;
			// 
			// dateHeader
			// 
			this.dateHeader.Text = "Date modified";
			this.dateHeader.Width = 200;
			// 
			// sizeHeader
			// 
			this.sizeHeader.Text = "Size";
			this.sizeHeader.Width = 100;
			// 
			// pathHeader
			// 
			this.pathHeader.Text = "Path";
			this.pathHeader.Width = 200;
			// 
			// removeButton
			// 
			this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.removeButton.Location = new System.Drawing.Point(614, 126);
			this.removeButton.Margin = new System.Windows.Forms.Padding(6);
			this.removeButton.Name = "removeButton";
			this.removeButton.Size = new System.Drawing.Size(110, 35);
			this.removeButton.TabIndex = 9;
			this.removeButton.Text = "Remove";
			this.removeButton.UseVisualStyleBackColor = true;
			this.removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
			// 
			// loadFolderButton
			// 
			this.loadFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.loadFolderButton.Location = new System.Drawing.Point(614, 79);
			this.loadFolderButton.Margin = new System.Windows.Forms.Padding(6);
			this.loadFolderButton.Name = "loadFolderButton";
			this.loadFolderButton.Size = new System.Drawing.Size(110, 35);
			this.loadFolderButton.TabIndex = 8;
			this.loadFolderButton.Text = "Load folder";
			this.loadFolderButton.UseVisualStyleBackColor = true;
			this.loadFolderButton.Click += new System.EventHandler(this.LoadFolderButton_Click);
			// 
			// loadImageButton
			// 
			this.loadImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.loadImageButton.Location = new System.Drawing.Point(614, 32);
			this.loadImageButton.Margin = new System.Windows.Forms.Padding(6);
			this.loadImageButton.Name = "loadImageButton";
			this.loadImageButton.Size = new System.Drawing.Size(110, 35);
			this.loadImageButton.TabIndex = 7;
			this.loadImageButton.Text = "Load images";
			this.loadImageButton.UseVisualStyleBackColor = true;
			this.loadImageButton.Click += new System.EventHandler(this.LoadImageButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.loadedPreviewBox);
			this.groupBox1.Controls.Add(this.imageListView);
			this.groupBox1.Controls.Add(this.removeButton);
			this.groupBox1.Controls.Add(this.loadFolderButton);
			this.groupBox1.Controls.Add(this.loadImageButton);
			this.groupBox1.Location = new System.Drawing.Point(18, 18);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
			this.groupBox1.Size = new System.Drawing.Size(886, 499);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Images";
			// 
			// LoadScene
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox1);
			this.Name = "LoadScene";
			this.Padding = new System.Windows.Forms.Padding(15);
			this.Size = new System.Drawing.Size(922, 535);
			((System.ComponentModel.ISupportInitialize)(this.loadedPreviewBox)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox loadedPreviewBox;
		private System.Windows.Forms.ListView imageListView;
		private System.Windows.Forms.ColumnHeader nameHeader;
		private System.Windows.Forms.ColumnHeader dateHeader;
		private System.Windows.Forms.ColumnHeader sizeHeader;
		private System.Windows.Forms.ColumnHeader pathHeader;
		private System.Windows.Forms.Button removeButton;
		private System.Windows.Forms.Button loadFolderButton;
		private System.Windows.Forms.Button loadImageButton;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
