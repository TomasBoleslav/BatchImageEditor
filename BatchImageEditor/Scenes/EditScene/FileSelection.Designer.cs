
namespace BatchImageEditor
{
	partial class FileSelection
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
			this._selectionBox = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// _selectionBox
			// 
			this._selectionBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this._selectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._selectionBox.FormattingEnabled = true;
			this._selectionBox.Location = new System.Drawing.Point(0, 3);
			this._selectionBox.Name = "_selectionBox";
			this._selectionBox.Size = new System.Drawing.Size(155, 28);
			this._selectionBox.Sorted = true;
			this._selectionBox.TabIndex = 0;
			this._selectionBox.SelectedIndexChanged += new System.EventHandler(this.SelectionBox_SelectedIndexChanged);
			// 
			// FileSelection
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._selectionBox);
			this.Name = "FileSelection";
			this.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.Size = new System.Drawing.Size(155, 34);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox _selectionBox;
	}
}
