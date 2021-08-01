
namespace BatchImageEditor
{
	partial class FilterList
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
			this.components = new System.ComponentModel.Container();
			this._editButton = new System.Windows.Forms.Button();
			this._removeButton = new System.Windows.Forms.Button();
			this._addButton = new System.Windows.Forms.Button();
			this._filterList = new System.Windows.Forms.CheckedListBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.necoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dalsiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mojeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hahaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// _editButton
			// 
			this._editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._editButton.Location = new System.Drawing.Point(257, 85);
			this._editButton.Name = "_editButton";
			this._editButton.Size = new System.Drawing.Size(100, 35);
			this._editButton.TabIndex = 4;
			this._editButton.Text = "Edit";
			this._editButton.UseVisualStyleBackColor = true;
			// 
			// _removeButton
			// 
			this._removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._removeButton.Location = new System.Drawing.Point(257, 44);
			this._removeButton.Name = "_removeButton";
			this._removeButton.Size = new System.Drawing.Size(100, 35);
			this._removeButton.TabIndex = 3;
			this._removeButton.Text = "Remove";
			this._removeButton.UseVisualStyleBackColor = true;
			// 
			// _addButton
			// 
			this._addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._addButton.Location = new System.Drawing.Point(257, 3);
			this._addButton.Name = "_addButton";
			this._addButton.Size = new System.Drawing.Size(100, 35);
			this._addButton.TabIndex = 2;
			this._addButton.Text = "Add";
			this._addButton.UseVisualStyleBackColor = true;
			this._addButton.Click += new System.EventHandler(this.AddButton_Click);
			// 
			// _filterList
			// 
			this._filterList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._filterList.FormattingEnabled = true;
			this._filterList.Location = new System.Drawing.Point(3, 3);
			this._filterList.Name = "_filterList";
			this._filterList.Size = new System.Drawing.Size(248, 488);
			this._filterList.TabIndex = 5;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.necoToolStripMenuItem,
            this.dalsiToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(211, 80);
			// 
			// necoToolStripMenuItem
			// 
			this.necoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mojeToolStripMenuItem,
            this.hahaToolStripMenuItem});
			this.necoToolStripMenuItem.Name = "necoToolStripMenuItem";
			this.necoToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
			this.necoToolStripMenuItem.Text = "neco";
			// 
			// dalsiToolStripMenuItem
			// 
			this.dalsiToolStripMenuItem.Name = "dalsiToolStripMenuItem";
			this.dalsiToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
			this.dalsiToolStripMenuItem.Text = "dalsi";
			// 
			// mojeToolStripMenuItem
			// 
			this.mojeToolStripMenuItem.Name = "mojeToolStripMenuItem";
			this.mojeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
			this.mojeToolStripMenuItem.Text = "moje";
			// 
			// hahaToolStripMenuItem
			// 
			this.hahaToolStripMenuItem.Name = "hahaToolStripMenuItem";
			this.hahaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
			this.hahaToolStripMenuItem.Text = "haha";
			// 
			// FilterList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._filterList);
			this.Controls.Add(this._addButton);
			this.Controls.Add(this._removeButton);
			this.Controls.Add(this._editButton);
			this.Name = "FilterList";
			this.Size = new System.Drawing.Size(360, 507);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button _editButton;
		private System.Windows.Forms.Button _removeButton;
		private System.Windows.Forms.Button _addButton;
		private System.Windows.Forms.CheckedListBox _filterList;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem necoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mojeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hahaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem dalsiToolStripMenuItem;
	}
}
