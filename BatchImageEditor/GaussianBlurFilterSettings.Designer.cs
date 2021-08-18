
namespace BatchImageEditor
{
	partial class GaussianBlurFilterSettings
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
			this._radiusLabel = new System.Windows.Forms.Label();
			this._sigmaLabel = new System.Windows.Forms.Label();
			this._radiusInput = new System.Windows.Forms.NumericUpDown();
			this._sigmaInput = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this._radiusInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._sigmaInput)).BeginInit();
			this.SuspendLayout();
			// 
			// _radiusLabel
			// 
			this._radiusLabel.AutoSize = true;
			this._radiusLabel.Location = new System.Drawing.Point(3, 5);
			this._radiusLabel.Name = "_radiusLabel";
			this._radiusLabel.Size = new System.Drawing.Size(53, 20);
			this._radiusLabel.TabIndex = 0;
			this._radiusLabel.Text = "Radius";
			// 
			// _sigmaLabel
			// 
			this._sigmaLabel.AutoSize = true;
			this._sigmaLabel.Location = new System.Drawing.Point(3, 38);
			this._sigmaLabel.Name = "_sigmaLabel";
			this._sigmaLabel.Size = new System.Drawing.Size(51, 20);
			this._sigmaLabel.TabIndex = 1;
			this._sigmaLabel.Text = "Sigma";
			// 
			// _radiusInput
			// 
			this._radiusInput.Location = new System.Drawing.Point(100, 3);
			this._radiusInput.Name = "_radiusInput";
			this._radiusInput.Size = new System.Drawing.Size(100, 27);
			this._radiusInput.TabIndex = 2;
			this._radiusInput.ValueChanged += new System.EventHandler(this.RadiusInput_ValueChanged);
			// 
			// _sigmaInput
			// 
			this._sigmaInput.Location = new System.Drawing.Point(100, 36);
			this._sigmaInput.Name = "_sigmaInput";
			this._sigmaInput.Size = new System.Drawing.Size(100, 27);
			this._sigmaInput.TabIndex = 3;
			this._sigmaInput.ValueChanged += new System.EventHandler(this.SigmaInput_ValueChanged);
			// 
			// GaussianBlurFilterSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._sigmaInput);
			this.Controls.Add(this._radiusInput);
			this.Controls.Add(this._sigmaLabel);
			this.Controls.Add(this._radiusLabel);
			this.Name = "GaussianBlurFilterSettings";
			this.Size = new System.Drawing.Size(230, 90);
			((System.ComponentModel.ISupportInitialize)(this._radiusInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._sigmaInput)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label _radiusLabel;
		private System.Windows.Forms.Label _sigmaLabel;
		private System.Windows.Forms.NumericUpDown _radiusInput;
		private System.Windows.Forms.NumericUpDown _sigmaInput;
	}
}
