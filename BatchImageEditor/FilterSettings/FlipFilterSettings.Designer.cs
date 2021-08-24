
namespace BatchImageEditor
{
	partial class FlipFilterSettings
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
			this._flipTypeLabel = new System.Windows.Forms.Label();
			this._flipTypeComboBox = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// _flipTypeLabel
			// 
			this._flipTypeLabel.AutoSize = true;
			this._flipTypeLabel.Location = new System.Drawing.Point(3, 6);
			this._flipTypeLabel.Name = "_flipTypeLabel";
			this._flipTypeLabel.Size = new System.Drawing.Size(40, 20);
			this._flipTypeLabel.TabIndex = 0;
			this._flipTypeLabel.Text = "Type";
			// 
			// _flipTypeComboBox
			// 
			this._flipTypeComboBox.FormattingEnabled = true;
			this._flipTypeComboBox.Location = new System.Drawing.Point(76, 3);
			this._flipTypeComboBox.Name = "_flipTypeComboBox";
			this._flipTypeComboBox.Size = new System.Drawing.Size(151, 28);
			this._flipTypeComboBox.TabIndex = 1;
			// 
			// FlipFilterSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._flipTypeComboBox);
			this.Controls.Add(this._flipTypeLabel);
			this.Name = "FlipFilterSettings";
			this.Size = new System.Drawing.Size(230, 47);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label _flipTypeLabel;
		private System.Windows.Forms.ComboBox _flipTypeComboBox;
	}
}
