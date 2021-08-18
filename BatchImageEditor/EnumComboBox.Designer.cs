
namespace BatchImageEditor
{
	partial class EnumComboBox<TEnum>
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
			this._comboBox = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// _comboBox
			// 
			this._comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this._comboBox.FormattingEnabled = true;
			this._comboBox.Location = new System.Drawing.Point(0, 0);
			this._comboBox.Name = "_comboBox";
			this._comboBox.Size = new System.Drawing.Size(151, 28);
			this._comboBox.TabIndex = 0;
			// 
			// EnumComboBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._comboBox);
			this.Name = "EnumComboBox";
			this.Size = new System.Drawing.Size(151, 28);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox _comboBox;
	}
}
