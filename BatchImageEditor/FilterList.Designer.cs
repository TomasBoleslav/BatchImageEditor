
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
			this._editButton = new System.Windows.Forms.Button();
			this._removeButton = new System.Windows.Forms.Button();
			this._addButton = new System.Windows.Forms.Button();
			this._filterListBox = new System.Windows.Forms.CheckedListBox();
			this._upButton = new System.Windows.Forms.Button();
			this._downButton = new System.Windows.Forms.Button();
			this._controlPanel = new System.Windows.Forms.Panel();
			this._controlPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// _editButton
			// 
			this._editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._editButton.Location = new System.Drawing.Point(3, 85);
			this._editButton.Name = "_editButton";
			this._editButton.Size = new System.Drawing.Size(100, 35);
			this._editButton.TabIndex = 4;
			this._editButton.Text = "Edit";
			this._editButton.UseVisualStyleBackColor = true;
			this._editButton.Click += new System.EventHandler(this.EditButton_Click);
			// 
			// _removeButton
			// 
			this._removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._removeButton.Location = new System.Drawing.Point(3, 44);
			this._removeButton.Name = "_removeButton";
			this._removeButton.Size = new System.Drawing.Size(100, 35);
			this._removeButton.TabIndex = 3;
			this._removeButton.Text = "Remove";
			this._removeButton.UseVisualStyleBackColor = true;
			this._removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
			// 
			// _addButton
			// 
			this._addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._addButton.Location = new System.Drawing.Point(3, 3);
			this._addButton.Name = "_addButton";
			this._addButton.Size = new System.Drawing.Size(100, 35);
			this._addButton.TabIndex = 2;
			this._addButton.Text = "Add";
			this._addButton.UseVisualStyleBackColor = true;
			this._addButton.Click += new System.EventHandler(this.AddButton_Click);
			// 
			// _filterListBox
			// 
			this._filterListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this._filterListBox.FormattingEnabled = true;
			this._filterListBox.Location = new System.Drawing.Point(0, 0);
			this._filterListBox.Name = "_filterListBox";
			this._filterListBox.Size = new System.Drawing.Size(254, 507);
			this._filterListBox.TabIndex = 5;
			this._filterListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.FilterList_ItemCheck);
			// 
			// _upButton
			// 
			this._upButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._upButton.Location = new System.Drawing.Point(3, 164);
			this._upButton.Name = "_upButton";
			this._upButton.Size = new System.Drawing.Size(40, 40);
			this._upButton.TabIndex = 6;
			this._upButton.Text = "▲";
			this._upButton.UseVisualStyleBackColor = true;
			this._upButton.Click += new System.EventHandler(this.UpButton_Click);
			// 
			// _downButton
			// 
			this._downButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._downButton.Location = new System.Drawing.Point(3, 210);
			this._downButton.Name = "_downButton";
			this._downButton.Size = new System.Drawing.Size(40, 40);
			this._downButton.TabIndex = 7;
			this._downButton.Text = "▼";
			this._downButton.UseVisualStyleBackColor = true;
			this._downButton.Click += new System.EventHandler(this.DownButton_Click);
			// 
			// _controlPanel
			// 
			this._controlPanel.Controls.Add(this._addButton);
			this._controlPanel.Controls.Add(this._editButton);
			this._controlPanel.Controls.Add(this._downButton);
			this._controlPanel.Controls.Add(this._removeButton);
			this._controlPanel.Controls.Add(this._upButton);
			this._controlPanel.Dock = System.Windows.Forms.DockStyle.Right;
			this._controlPanel.Location = new System.Drawing.Point(254, 0);
			this._controlPanel.Name = "_controlPanel";
			this._controlPanel.Size = new System.Drawing.Size(106, 507);
			this._controlPanel.TabIndex = 8;
			// 
			// FilterList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._filterListBox);
			this.Controls.Add(this._controlPanel);
			this.Name = "FilterList";
			this.Size = new System.Drawing.Size(360, 507);
			this._controlPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button _editButton;
		private System.Windows.Forms.Button _removeButton;
		private System.Windows.Forms.Button _addButton;
		private System.Windows.Forms.CheckedListBox _filterListBox;
		private System.Windows.Forms.Button _upButton;
		private System.Windows.Forms.Button _downButton;
		private System.Windows.Forms.Panel _controlPanel;
	}
}
