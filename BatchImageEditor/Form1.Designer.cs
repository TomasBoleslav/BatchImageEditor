
namespace BatchImageEditor
{
	partial class AppForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Ahoj",
            "b",
            "c",
            "d"}, -1);
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Hele",
            "0",
            "1",
            "2"}, -1);
			this.menuPanel = new System.Windows.Forms.Panel();
			this.menuButtonsPanel = new System.Windows.Forms.Panel();
			this.menuProcessButton = new System.Windows.Forms.Button();
			this.menuLoadButton = new System.Windows.Forms.Button();
			this.menuEditButton = new System.Windows.Forms.Button();
			this.loadScenePanel = new System.Windows.Forms.Panel();
			this.removeImageButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.loadFolderButton = new System.Windows.Forms.Button();
			this.loadPreviewBox = new System.Windows.Forms.PictureBox();
			this.imageListView = new System.Windows.Forms.ListView();
			this.filenameColumn = new System.Windows.Forms.ColumnHeader();
			this.dateColumn = new System.Windows.Forms.ColumnHeader();
			this.dimensionsColumn = new System.Windows.Forms.ColumnHeader();
			this.sizeColumn = new System.Windows.Forms.ColumnHeader();
			this.loadImageButton = new System.Windows.Forms.Button();
			this.menuPanel.SuspendLayout();
			this.menuButtonsPanel.SuspendLayout();
			this.loadScenePanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.loadPreviewBox)).BeginInit();
			this.SuspendLayout();
			// 
			// menuPanel
			// 
			this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.menuPanel.Controls.Add(this.menuButtonsPanel);
			this.menuPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.menuPanel.Location = new System.Drawing.Point(0, 0);
			this.menuPanel.Margin = new System.Windows.Forms.Padding(0);
			this.menuPanel.Name = "menuPanel";
			this.menuPanel.Size = new System.Drawing.Size(959, 60);
			this.menuPanel.TabIndex = 1;
			// 
			// menuButtonsPanel
			// 
			this.menuButtonsPanel.Controls.Add(this.menuProcessButton);
			this.menuButtonsPanel.Controls.Add(this.menuLoadButton);
			this.menuButtonsPanel.Controls.Add(this.menuEditButton);
			this.menuButtonsPanel.Location = new System.Drawing.Point(330, 0);
			this.menuButtonsPanel.Name = "menuButtonsPanel";
			this.menuButtonsPanel.Size = new System.Drawing.Size(300, 60);
			this.menuButtonsPanel.TabIndex = 5;
			// 
			// menuProcessButton
			// 
			this.menuProcessButton.FlatAppearance.BorderSize = 0;
			this.menuProcessButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
			this.menuProcessButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
			this.menuProcessButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.menuProcessButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.menuProcessButton.Location = new System.Drawing.Point(200, 0);
			this.menuProcessButton.Margin = new System.Windows.Forms.Padding(0);
			this.menuProcessButton.Name = "menuProcessButton";
			this.menuProcessButton.Size = new System.Drawing.Size(100, 60);
			this.menuProcessButton.TabIndex = 4;
			this.menuProcessButton.Text = "PROCESS";
			this.menuProcessButton.UseVisualStyleBackColor = false;
			// 
			// menuLoadButton
			// 
			this.menuLoadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.menuLoadButton.FlatAppearance.BorderSize = 0;
			this.menuLoadButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.menuLoadButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.menuLoadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.menuLoadButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.menuLoadButton.Location = new System.Drawing.Point(0, 0);
			this.menuLoadButton.Margin = new System.Windows.Forms.Padding(0);
			this.menuLoadButton.Name = "menuLoadButton";
			this.menuLoadButton.Size = new System.Drawing.Size(100, 60);
			this.menuLoadButton.TabIndex = 2;
			this.menuLoadButton.Text = "LOAD";
			this.menuLoadButton.UseVisualStyleBackColor = false;
			// 
			// menuEditButton
			// 
			this.menuEditButton.FlatAppearance.BorderSize = 0;
			this.menuEditButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
			this.menuEditButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
			this.menuEditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.menuEditButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.menuEditButton.Location = new System.Drawing.Point(100, 0);
			this.menuEditButton.Margin = new System.Windows.Forms.Padding(0);
			this.menuEditButton.Name = "menuEditButton";
			this.menuEditButton.Size = new System.Drawing.Size(100, 60);
			this.menuEditButton.TabIndex = 3;
			this.menuEditButton.Text = "EDIT";
			this.menuEditButton.UseVisualStyleBackColor = false;
			// 
			// loadScenePanel
			// 
			this.loadScenePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.loadScenePanel.Controls.Add(this.removeImageButton);
			this.loadScenePanel.Controls.Add(this.label2);
			this.loadScenePanel.Controls.Add(this.label1);
			this.loadScenePanel.Controls.Add(this.loadFolderButton);
			this.loadScenePanel.Controls.Add(this.loadPreviewBox);
			this.loadScenePanel.Controls.Add(this.imageListView);
			this.loadScenePanel.Controls.Add(this.loadImageButton);
			this.loadScenePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.loadScenePanel.Location = new System.Drawing.Point(0, 60);
			this.loadScenePanel.Name = "loadScenePanel";
			this.loadScenePanel.Size = new System.Drawing.Size(959, 530);
			this.loadScenePanel.TabIndex = 2;
			// 
			// removeImageButton
			// 
			this.removeImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.removeImageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.removeImageButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
			this.removeImageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.removeImageButton.Location = new System.Drawing.Point(688, 152);
			this.removeImageButton.Margin = new System.Windows.Forms.Padding(6);
			this.removeImageButton.Name = "removeImageButton";
			this.removeImageButton.Size = new System.Drawing.Size(120, 40);
			this.removeImageButton.TabIndex = 6;
			this.removeImageButton.Text = "Remove";
			this.removeImageButton.UseVisualStyleBackColor = false;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(688, 227);
			this.label2.Margin = new System.Windows.Forms.Padding(6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 20);
			this.label2.TabIndex = 5;
			this.label2.Text = "Preview:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 16);
			this.label1.Margin = new System.Windows.Forms.Padding(6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 20);
			this.label1.TabIndex = 4;
			this.label1.Text = "All images:";
			// 
			// loadFolderButton
			// 
			this.loadFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.loadFolderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.loadFolderButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
			this.loadFolderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.loadFolderButton.Location = new System.Drawing.Point(688, 100);
			this.loadFolderButton.Margin = new System.Windows.Forms.Padding(6);
			this.loadFolderButton.Name = "loadFolderButton";
			this.loadFolderButton.Size = new System.Drawing.Size(120, 40);
			this.loadFolderButton.TabIndex = 3;
			this.loadFolderButton.Text = "Load folder";
			this.loadFolderButton.UseVisualStyleBackColor = false;
			this.loadFolderButton.Click += new System.EventHandler(this.loadFolderButton_Click);
			// 
			// loadPreviewBox
			// 
			this.loadPreviewBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.loadPreviewBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
			this.loadPreviewBox.Location = new System.Drawing.Point(688, 259);
			this.loadPreviewBox.Margin = new System.Windows.Forms.Padding(6);
			this.loadPreviewBox.Name = "loadPreviewBox";
			this.loadPreviewBox.Size = new System.Drawing.Size(256, 256);
			this.loadPreviewBox.TabIndex = 2;
			this.loadPreviewBox.TabStop = false;
			// 
			// imageListView
			// 
			this.imageListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.imageListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
			this.imageListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.imageListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.filenameColumn,
            this.dateColumn,
            this.dimensionsColumn,
            this.sizeColumn});
			this.imageListView.ForeColor = System.Drawing.Color.Gainsboro;
			this.imageListView.FullRowSelect = true;
			this.imageListView.HideSelection = false;
			this.imageListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
			this.imageListView.Location = new System.Drawing.Point(15, 48);
			this.imageListView.Margin = new System.Windows.Forms.Padding(6);
			this.imageListView.Name = "imageListView";
			this.imageListView.OwnerDraw = true;
			this.imageListView.Size = new System.Drawing.Size(661, 467);
			this.imageListView.TabIndex = 1;
			this.imageListView.UseCompatibleStateImageBehavior = false;
			this.imageListView.View = System.Windows.Forms.View.Details;
			this.imageListView.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.imageListView_ColumnWidthChanged);
			this.imageListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.imageListView_DrawColumnHeader);
			this.imageListView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.imageListView_DrawItem);
			this.imageListView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.imageListView_DrawSubItem);
			this.imageListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imageListView_MouseUp);
			// 
			// filenameColumn
			// 
			this.filenameColumn.Text = "Name";
			this.filenameColumn.Width = 200;
			// 
			// dateColumn
			// 
			this.dateColumn.Text = "Date";
			this.dateColumn.Width = 150;
			// 
			// dimensionsColumn
			// 
			this.dimensionsColumn.Text = "Dimensions";
			this.dimensionsColumn.Width = 150;
			// 
			// sizeColumn
			// 
			this.sizeColumn.Text = "Size";
			this.sizeColumn.Width = 100;
			// 
			// loadImageButton
			// 
			this.loadImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.loadImageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.loadImageButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
			this.loadImageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.loadImageButton.Location = new System.Drawing.Point(688, 48);
			this.loadImageButton.Margin = new System.Windows.Forms.Padding(6);
			this.loadImageButton.Name = "loadImageButton";
			this.loadImageButton.Size = new System.Drawing.Size(120, 40);
			this.loadImageButton.TabIndex = 0;
			this.loadImageButton.Text = "Load image";
			this.loadImageButton.UseVisualStyleBackColor = false;
			this.loadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);
			// 
			// AppForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(959, 590);
			this.Controls.Add(this.loadScenePanel);
			this.Controls.Add(this.menuPanel);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ForeColor = System.Drawing.Color.Gainsboro;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "AppForm";
			this.Text = "Batch Image Editor";
			this.Load += new System.EventHandler(this.Form_Load);
			this.Resize += new System.EventHandler(this.Form_Resize);
			this.menuPanel.ResumeLayout(false);
			this.menuButtonsPanel.ResumeLayout(false);
			this.loadScenePanel.ResumeLayout(false);
			this.loadScenePanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.loadPreviewBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel menuPanel;
		private System.Windows.Forms.Button menuLoadButton;
		private System.Windows.Forms.Button menuEditButton;
		private System.Windows.Forms.Panel loadScenePanel;
		private System.Windows.Forms.Button menuProcessButton;
		private System.Windows.Forms.Button loadImageButton;
		private System.Windows.Forms.PictureBox loadPreviewBox;
		private System.Windows.Forms.ListView imageListView;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button loadFolderButton;
		private System.Windows.Forms.Panel menuButtonsPanel;
		private System.Windows.Forms.ColumnHeader filenameColumn;
		private System.Windows.Forms.ColumnHeader dateColumn;
		private System.Windows.Forms.ColumnHeader dimensionsColumn;
		private System.Windows.Forms.ColumnHeader sizeColumn;
		private System.Windows.Forms.Button removeImageButton;
	}
}

