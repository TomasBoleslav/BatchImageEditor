
namespace BatchImageEditor
{
	partial class ResizingFilterSettings
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
			this._resizingTypeBox = new System.Windows.Forms.ComboBox();
			this._typeLabel = new System.Windows.Forms.Label();
			this._widthLabel = new System.Windows.Forms.Label();
			this._heightLabel = new System.Windows.Forms.Label();
			this._widthInput = new System.Windows.Forms.NumericUpDown();
			this._heightInput = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this._widthInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._heightInput)).BeginInit();
			this.SuspendLayout();
			// 
			// _resizingTypeBox
			// 
			this._resizingTypeBox.FormattingEnabled = true;
			this._resizingTypeBox.Location = new System.Drawing.Point(77, 3);
			this._resizingTypeBox.Name = "_resizingTypeBox";
			this._resizingTypeBox.Size = new System.Drawing.Size(150, 28);
			this._resizingTypeBox.TabIndex = 0;
			// 
			// _typeLabel
			// 
			this._typeLabel.AutoSize = true;
			this._typeLabel.Location = new System.Drawing.Point(3, 6);
			this._typeLabel.Name = "_typeLabel";
			this._typeLabel.Size = new System.Drawing.Size(43, 20);
			this._typeLabel.TabIndex = 1;
			this._typeLabel.Text = "Type:";
			// 
			// _widthLabel
			// 
			this._widthLabel.AutoSize = true;
			this._widthLabel.Location = new System.Drawing.Point(3, 39);
			this._widthLabel.Name = "_widthLabel";
			this._widthLabel.Size = new System.Drawing.Size(52, 20);
			this._widthLabel.TabIndex = 2;
			this._widthLabel.Text = "Width:";
			// 
			// _heightLabel
			// 
			this._heightLabel.AutoSize = true;
			this._heightLabel.Location = new System.Drawing.Point(3, 72);
			this._heightLabel.Name = "_heightLabel";
			this._heightLabel.Size = new System.Drawing.Size(57, 20);
			this._heightLabel.TabIndex = 3;
			this._heightLabel.Text = "Height:";
			// 
			// _widthInput
			// 
			this._widthInput.Location = new System.Drawing.Point(77, 37);
			this._widthInput.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this._widthInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this._widthInput.Name = "_widthInput";
			this._widthInput.Size = new System.Drawing.Size(100, 27);
			this._widthInput.TabIndex = 4;
			this._widthInput.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this._widthInput.ValueChanged += new System.EventHandler(this.WidthInput_ValueChanged);
			// 
			// _heightInput
			// 
			this._heightInput.Location = new System.Drawing.Point(77, 70);
			this._heightInput.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this._heightInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this._heightInput.Name = "_heightInput";
			this._heightInput.Size = new System.Drawing.Size(100, 27);
			this._heightInput.TabIndex = 5;
			this._heightInput.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this._heightInput.ValueChanged += new System.EventHandler(this.HeightInput_ValueChanged);
			// 
			// ResizingFilterSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._heightInput);
			this.Controls.Add(this._widthInput);
			this.Controls.Add(this._heightLabel);
			this.Controls.Add(this._widthLabel);
			this.Controls.Add(this._typeLabel);
			this.Controls.Add(this._resizingTypeBox);
			this.Name = "ResizingFilterSettings";
			this.Size = new System.Drawing.Size(230, 123);
			((System.ComponentModel.ISupportInitialize)(this._widthInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._heightInput)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox _resizingTypeBox;
		private System.Windows.Forms.Label _typeLabel;
		private System.Windows.Forms.Label _widthLabel;
		private System.Windows.Forms.Label _heightLabel;
		private System.Windows.Forms.NumericUpDown _widthInput;
		private System.Windows.Forms.NumericUpDown _heightInput;
	}
}
