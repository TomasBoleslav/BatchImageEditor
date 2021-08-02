
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
			this._filtersGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// filterList1
			// 
			this.filterList1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.filterList1.InputBitmap = null;
			this.filterList1.Location = new System.Drawing.Point(3, 23);
			this.filterList1.Name = "filterList1";
			this.filterList1.Size = new System.Drawing.Size(349, 514);
			this.filterList1.TabIndex = 0;
			// 
			// _filtersGroup
			// 
			this._filtersGroup.Controls.Add(this.filterList1);
			this._filtersGroup.Location = new System.Drawing.Point(18, 18);
			this._filtersGroup.Name = "_filtersGroup";
			this._filtersGroup.Size = new System.Drawing.Size(355, 540);
			this._filtersGroup.TabIndex = 1;
			this._filtersGroup.TabStop = false;
			this._filtersGroup.Text = "Filters";
			// 
			// EditScene
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._filtersGroup);
			this.Name = "EditScene";
			this.Padding = new System.Windows.Forms.Padding(15);
			this.Size = new System.Drawing.Size(1011, 576);
			this._filtersGroup.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private FilterList filterList1;
		private System.Windows.Forms.GroupBox _filtersGroup;
	}
}
