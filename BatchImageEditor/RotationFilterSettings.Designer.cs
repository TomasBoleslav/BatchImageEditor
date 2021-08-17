
namespace BatchImageEditor
{
	partial class RotationFilterSettings
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
			this._angleLabel = new System.Windows.Forms.Label();
			this._angleInput = new System.Windows.Forms.NumericUpDown();
			this._backColorLabel = new System.Windows.Forms.Label();
			this._selectBackgroundButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this._angleInput)).BeginInit();
			this.SuspendLayout();
			// 
			// _angleLabel
			// 
			this._angleLabel.AutoSize = true;
			this._angleLabel.Location = new System.Drawing.Point(3, 5);
			this._angleLabel.Name = "_angleLabel";
			this._angleLabel.Size = new System.Drawing.Size(48, 20);
			this._angleLabel.TabIndex = 0;
			this._angleLabel.Text = "Angle";
			// 
			// _angleInput
			// 
			this._angleInput.Location = new System.Drawing.Point(110, 3);
			this._angleInput.Name = "_angleInput";
			this._angleInput.Size = new System.Drawing.Size(100, 27);
			this._angleInput.TabIndex = 1;
			this._angleInput.ValueChanged += new System.EventHandler(this.AngleInput_ValueChanged);
			// 
			// _backColorLabel
			// 
			this._backColorLabel.AutoSize = true;
			this._backColorLabel.Location = new System.Drawing.Point(3, 40);
			this._backColorLabel.Name = "_backColorLabel";
			this._backColorLabel.Size = new System.Drawing.Size(88, 20);
			this._backColorLabel.TabIndex = 2;
			this._backColorLabel.Text = "Background";
			// 
			// _selectBackgroundButton
			// 
			this._selectBackgroundButton.Location = new System.Drawing.Point(110, 36);
			this._selectBackgroundButton.Name = "_selectBackgroundButton";
			this._selectBackgroundButton.Size = new System.Drawing.Size(100, 29);
			this._selectBackgroundButton.TabIndex = 3;
			this._selectBackgroundButton.Text = "Select";
			this._selectBackgroundButton.UseVisualStyleBackColor = true;
			this._selectBackgroundButton.Click += new System.EventHandler(this.SelectBackgroundButton_Click);
			// 
			// RotationFilterSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._selectBackgroundButton);
			this.Controls.Add(this._backColorLabel);
			this.Controls.Add(this._angleInput);
			this.Controls.Add(this._angleLabel);
			this.Name = "RotationFilterSettings";
			this.Size = new System.Drawing.Size(230, 95);
			((System.ComponentModel.ISupportInitialize)(this._angleInput)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label _angleLabel;
		private System.Windows.Forms.NumericUpDown _angleInput;
		private System.Windows.Forms.Label _backColorLabel;
		private System.Windows.Forms.Button _selectBackgroundButton;
	}
}
