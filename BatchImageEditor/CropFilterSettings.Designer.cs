
namespace BatchImageEditor
{
	partial class CropFilterSettings
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
			this.label1 = new System.Windows.Forms.Label();
			this._cropTypeComboBox = new System.Windows.Forms.ComboBox();
			this._xLabel = new System.Windows.Forms.Label();
			this._xInput = new System.Windows.Forms.NumericUpDown();
			this._yInput = new System.Windows.Forms.NumericUpDown();
			this._yLabel = new System.Windows.Forms.Label();
			this._widthInput = new System.Windows.Forms.NumericUpDown();
			this._widthLabel = new System.Windows.Forms.Label();
			this._heightInput = new System.Windows.Forms.NumericUpDown();
			this._heightLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this._xInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._yInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._widthInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._heightInput)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Type";
			// 
			// _cropTypeComboBox
			// 
			this._cropTypeComboBox.FormattingEnabled = true;
			this._cropTypeComboBox.Location = new System.Drawing.Point(76, 3);
			this._cropTypeComboBox.Name = "_cropTypeComboBox";
			this._cropTypeComboBox.Size = new System.Drawing.Size(151, 28);
			this._cropTypeComboBox.TabIndex = 1;
			// 
			// _xLabel
			// 
			this._xLabel.AutoSize = true;
			this._xLabel.Location = new System.Drawing.Point(3, 39);
			this._xLabel.Name = "_xLabel";
			this._xLabel.Size = new System.Drawing.Size(18, 20);
			this._xLabel.TabIndex = 2;
			this._xLabel.Text = "X";
			// 
			// _xInput
			// 
			this._xInput.Location = new System.Drawing.Point(76, 37);
			this._xInput.Name = "_xInput";
			this._xInput.Size = new System.Drawing.Size(100, 27);
			this._xInput.TabIndex = 3;
			this._xInput.ValueChanged += new System.EventHandler(this.XInput_ValueChanged);
			// 
			// _yInput
			// 
			this._yInput.Location = new System.Drawing.Point(76, 70);
			this._yInput.Name = "_yInput";
			this._yInput.Size = new System.Drawing.Size(100, 27);
			this._yInput.TabIndex = 5;
			this._yInput.ValueChanged += new System.EventHandler(this.YInput_ValueChanged);
			// 
			// _yLabel
			// 
			this._yLabel.AutoSize = true;
			this._yLabel.Location = new System.Drawing.Point(3, 72);
			this._yLabel.Name = "_yLabel";
			this._yLabel.Size = new System.Drawing.Size(17, 20);
			this._yLabel.TabIndex = 4;
			this._yLabel.Text = "Y";
			// 
			// _widthInput
			// 
			this._widthInput.Location = new System.Drawing.Point(76, 103);
			this._widthInput.Name = "_widthInput";
			this._widthInput.Size = new System.Drawing.Size(100, 27);
			this._widthInput.TabIndex = 7;
			this._widthInput.ValueChanged += new System.EventHandler(this.WidthInput_ValueChanged);
			// 
			// _widthLabel
			// 
			this._widthLabel.AutoSize = true;
			this._widthLabel.Location = new System.Drawing.Point(3, 105);
			this._widthLabel.Name = "_widthLabel";
			this._widthLabel.Size = new System.Drawing.Size(49, 20);
			this._widthLabel.TabIndex = 6;
			this._widthLabel.Text = "Width";
			// 
			// _heightInput
			// 
			this._heightInput.Location = new System.Drawing.Point(76, 136);
			this._heightInput.Name = "_heightInput";
			this._heightInput.Size = new System.Drawing.Size(100, 27);
			this._heightInput.TabIndex = 9;
			this._heightInput.ValueChanged += new System.EventHandler(this.HeightInput_ValueChanged);
			// 
			// _heightLabel
			// 
			this._heightLabel.AutoSize = true;
			this._heightLabel.Location = new System.Drawing.Point(3, 138);
			this._heightLabel.Name = "_heightLabel";
			this._heightLabel.Size = new System.Drawing.Size(54, 20);
			this._heightLabel.TabIndex = 8;
			this._heightLabel.Text = "Height";
			// 
			// CropFilterSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._heightInput);
			this.Controls.Add(this._heightLabel);
			this.Controls.Add(this._widthInput);
			this.Controls.Add(this._widthLabel);
			this.Controls.Add(this._yInput);
			this.Controls.Add(this._yLabel);
			this.Controls.Add(this._xInput);
			this.Controls.Add(this._xLabel);
			this.Controls.Add(this._cropTypeComboBox);
			this.Controls.Add(this.label1);
			this.Name = "CropFilterSettings";
			this.Size = new System.Drawing.Size(230, 190);
			((System.ComponentModel.ISupportInitialize)(this._xInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._yInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._widthInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._heightInput)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox _cropTypeComboBox;
		private System.Windows.Forms.Label _xLabel;
		private System.Windows.Forms.NumericUpDown _xInput;
		private System.Windows.Forms.NumericUpDown _yInput;
		private System.Windows.Forms.Label _yLabel;
		private System.Windows.Forms.NumericUpDown _widthInput;
		private System.Windows.Forms.Label _widthLabel;
		private System.Windows.Forms.NumericUpDown _heightInput;
		private System.Windows.Forms.Label _heightLabel;
	}
}
