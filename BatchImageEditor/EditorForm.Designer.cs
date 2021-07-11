
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
			this.loadImageButton = new System.Windows.Forms.Button();
			this.menuPanel = new System.Windows.Forms.Panel();
			this.menuButtonsPanel = new System.Windows.Forms.Panel();
			this.menuProcessButton = new System.Windows.Forms.Button();
			this.menuEditButton = new System.Windows.Forms.Button();
			this.menuLoadButton = new System.Windows.Forms.Button();
			this.loadScenePanel = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.loadedPreviewBox = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.imageListView = new System.Windows.Forms.ListView();
			this.nameHeader = new System.Windows.Forms.ColumnHeader();
			this.dateHeader = new System.Windows.Forms.ColumnHeader();
			this.sizeHeader = new System.Windows.Forms.ColumnHeader();
			this.pathHeader = new System.Windows.Forms.ColumnHeader();
			this.removeImageButton = new System.Windows.Forms.Button();
			this.loadFolderButton = new System.Windows.Forms.Button();
			this.editScenePanel = new System.Windows.Forms.Panel();
			this.processScenePanel = new System.Windows.Forms.Panel();
			this.menuPanel.SuspendLayout();
			this.menuButtonsPanel.SuspendLayout();
			this.loadScenePanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.loadedPreviewBox)).BeginInit();
			this.SuspendLayout();
			// 
			// loadImageButton
			// 
			this.loadImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.loadImageButton.Location = new System.Drawing.Point(681, 47);
			this.loadImageButton.Margin = new System.Windows.Forms.Padding(6);
			this.loadImageButton.Name = "loadImageButton";
			this.loadImageButton.Size = new System.Drawing.Size(120, 40);
			this.loadImageButton.TabIndex = 0;
			this.loadImageButton.Text = "Load images";
			this.loadImageButton.UseVisualStyleBackColor = true;
			this.loadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);
			// 
			// menuPanel
			// 
			this.menuPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.menuPanel.Controls.Add(this.menuButtonsPanel);
			this.menuPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.menuPanel.Location = new System.Drawing.Point(0, 0);
			this.menuPanel.Name = "menuPanel";
			this.menuPanel.Size = new System.Drawing.Size(972, 50);
			this.menuPanel.TabIndex = 1;
			// 
			// menuButtonsPanel
			// 
			this.menuButtonsPanel.Controls.Add(this.menuProcessButton);
			this.menuButtonsPanel.Controls.Add(this.menuEditButton);
			this.menuButtonsPanel.Controls.Add(this.menuLoadButton);
			this.menuButtonsPanel.Location = new System.Drawing.Point(285, 0);
			this.menuButtonsPanel.Name = "menuButtonsPanel";
			this.menuButtonsPanel.Size = new System.Drawing.Size(300, 50);
			this.menuButtonsPanel.TabIndex = 0;
			// 
			// menuProcessButton
			// 
			this.menuProcessButton.FlatAppearance.BorderSize = 0;
			this.menuProcessButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.menuProcessButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
			this.menuProcessButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.menuProcessButton.ForeColor = System.Drawing.SystemColors.Window;
			this.menuProcessButton.Location = new System.Drawing.Point(200, 0);
			this.menuProcessButton.Margin = new System.Windows.Forms.Padding(0);
			this.menuProcessButton.Name = "menuProcessButton";
			this.menuProcessButton.Size = new System.Drawing.Size(100, 50);
			this.menuProcessButton.TabIndex = 2;
			this.menuProcessButton.Text = "PROCESS";
			this.menuProcessButton.UseVisualStyleBackColor = true;
			this.menuProcessButton.Click += new System.EventHandler(this.menuProcessButton_Click);
			// 
			// menuEditButton
			// 
			this.menuEditButton.FlatAppearance.BorderSize = 0;
			this.menuEditButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.menuEditButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
			this.menuEditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.menuEditButton.ForeColor = System.Drawing.SystemColors.Window;
			this.menuEditButton.Location = new System.Drawing.Point(100, 0);
			this.menuEditButton.Margin = new System.Windows.Forms.Padding(0);
			this.menuEditButton.Name = "menuEditButton";
			this.menuEditButton.Size = new System.Drawing.Size(100, 50);
			this.menuEditButton.TabIndex = 1;
			this.menuEditButton.Text = "EDIT";
			this.menuEditButton.UseVisualStyleBackColor = false;
			this.menuEditButton.Click += new System.EventHandler(this.menuEditButton_Click);
			// 
			// menuLoadButton
			// 
			this.menuLoadButton.BackColor = System.Drawing.SystemColors.Control;
			this.menuLoadButton.FlatAppearance.BorderSize = 0;
			this.menuLoadButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
			this.menuLoadButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
			this.menuLoadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.menuLoadButton.Location = new System.Drawing.Point(0, 0);
			this.menuLoadButton.Margin = new System.Windows.Forms.Padding(0);
			this.menuLoadButton.Name = "menuLoadButton";
			this.menuLoadButton.Size = new System.Drawing.Size(100, 50);
			this.menuLoadButton.TabIndex = 0;
			this.menuLoadButton.Text = "LOAD";
			this.menuLoadButton.UseVisualStyleBackColor = false;
			this.menuLoadButton.Click += new System.EventHandler(this.menuLoadButton_Click);
			// 
			// loadScenePanel
			// 
			this.loadScenePanel.Controls.Add(this.label2);
			this.loadScenePanel.Controls.Add(this.loadedPreviewBox);
			this.loadScenePanel.Controls.Add(this.label1);
			this.loadScenePanel.Controls.Add(this.imageListView);
			this.loadScenePanel.Controls.Add(this.removeImageButton);
			this.loadScenePanel.Controls.Add(this.loadFolderButton);
			this.loadScenePanel.Controls.Add(this.loadImageButton);
			this.loadScenePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.loadScenePanel.Location = new System.Drawing.Point(0, 50);
			this.loadScenePanel.Name = "loadScenePanel";
			this.loadScenePanel.Size = new System.Drawing.Size(972, 554);
			this.loadScenePanel.TabIndex = 2;
			this.loadScenePanel.Tag = "";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(681, 271);
			this.label2.Margin = new System.Windows.Forms.Padding(6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 20);
			this.label2.TabIndex = 6;
			this.label2.Text = "Preview:";
			// 
			// loadedPreviewBox
			// 
			this.loadedPreviewBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.loadedPreviewBox.BackColor = System.Drawing.SystemColors.Window;
			this.loadedPreviewBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.loadedPreviewBox.Location = new System.Drawing.Point(681, 303);
			this.loadedPreviewBox.Margin = new System.Windows.Forms.Padding(6);
			this.loadedPreviewBox.Name = "loadedPreviewBox";
			this.loadedPreviewBox.Size = new System.Drawing.Size(276, 236);
			this.loadedPreviewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.loadedPreviewBox.TabIndex = 5;
			this.loadedPreviewBox.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 15);
			this.label1.Margin = new System.Windows.Forms.Padding(6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 20);
			this.label1.TabIndex = 4;
			this.label1.Text = "All images:";
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
			this.imageListView.Location = new System.Drawing.Point(15, 47);
			this.imageListView.Margin = new System.Windows.Forms.Padding(6);
			this.imageListView.Name = "imageListView";
			this.imageListView.Size = new System.Drawing.Size(654, 490);
			this.imageListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.imageListView.TabIndex = 3;
			this.imageListView.UseCompatibleStateImageBehavior = false;
			this.imageListView.View = System.Windows.Forms.View.Details;
			this.imageListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.imageListView_ItemSelectionChanged);
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
			// removeImageButton
			// 
			this.removeImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.removeImageButton.Location = new System.Drawing.Point(681, 151);
			this.removeImageButton.Margin = new System.Windows.Forms.Padding(6);
			this.removeImageButton.Name = "removeImageButton";
			this.removeImageButton.Size = new System.Drawing.Size(120, 40);
			this.removeImageButton.TabIndex = 2;
			this.removeImageButton.Text = "Remove";
			this.removeImageButton.UseVisualStyleBackColor = true;
			this.removeImageButton.Click += new System.EventHandler(this.removeImageButton_Click);
			// 
			// loadFolderButton
			// 
			this.loadFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.loadFolderButton.Location = new System.Drawing.Point(681, 99);
			this.loadFolderButton.Margin = new System.Windows.Forms.Padding(6);
			this.loadFolderButton.Name = "loadFolderButton";
			this.loadFolderButton.Size = new System.Drawing.Size(120, 40);
			this.loadFolderButton.TabIndex = 1;
			this.loadFolderButton.Text = "Load folder";
			this.loadFolderButton.UseVisualStyleBackColor = true;
			this.loadFolderButton.Click += new System.EventHandler(this.loadFolderButton_Click);
			// 
			// editScenePanel
			// 
			this.editScenePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.editScenePanel.Location = new System.Drawing.Point(0, 50);
			this.editScenePanel.Name = "editScenePanel";
			this.editScenePanel.Size = new System.Drawing.Size(972, 554);
			this.editScenePanel.TabIndex = 7;
			// 
			// processScenePanel
			// 
			this.processScenePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.processScenePanel.Location = new System.Drawing.Point(0, 50);
			this.processScenePanel.Name = "processScenePanel";
			this.processScenePanel.Size = new System.Drawing.Size(972, 554);
			this.processScenePanel.TabIndex = 8;
			// 
			// AppForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(972, 604);
			this.Controls.Add(this.processScenePanel);
			this.Controls.Add(this.editScenePanel);
			this.Controls.Add(this.loadScenePanel);
			this.Controls.Add(this.menuPanel);
			this.Name = "AppForm";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form_Load);
			this.Resize += new System.EventHandler(this.Form_Resize);
			this.menuPanel.ResumeLayout(false);
			this.menuButtonsPanel.ResumeLayout(false);
			this.loadScenePanel.ResumeLayout(false);
			this.loadScenePanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.loadedPreviewBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		
		private System.Windows.Forms.Button loadImageButton;
		private System.Windows.Forms.Panel menuPanel;
		private System.Windows.Forms.Panel loadScenePanel;
		private System.Windows.Forms.Button removeImageButton;
		private System.Windows.Forms.Button loadFolderButton;
		private System.Windows.Forms.Panel menuButtonsPanel;
		private System.Windows.Forms.Button menuProcessButton;
		private System.Windows.Forms.Button menuEditButton;
		private System.Windows.Forms.Button menuLoadButton;
		private System.Windows.Forms.ListView imageListView;
		private System.Windows.Forms.ColumnHeader nameHeader;
		private System.Windows.Forms.ColumnHeader dateHeader;
		private System.Windows.Forms.ColumnHeader sizeHeader;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox loadedPreviewBox;
		private System.Windows.Forms.ColumnHeader pathHeader;
		private System.Windows.Forms.Panel editScenePanel;
		private System.Windows.Forms.Panel processScenePanel;
	}
}

