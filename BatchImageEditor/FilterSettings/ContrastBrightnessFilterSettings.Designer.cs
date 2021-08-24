
namespace BatchImageEditor
{
	partial class ContrastBrightnessFilterSettings
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
			this._contrastLabel = new System.Windows.Forms.Label();
			this._contrastInput = new System.Windows.Forms.NumericUpDown();
			this._brightnessInput = new System.Windows.Forms.NumericUpDown();
			this._brightnessLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this._contrastInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._brightnessInput)).BeginInit();
			this.SuspendLayout();
			// 
			// _contrastLabel
			// 
			this._contrastLabel.AutoSize = true;
			this._contrastLabel.Location = new System.Drawing.Point(3, 6);
			this._contrastLabel.Name = "_contrastLabel";
			this._contrastLabel.Size = new System.Drawing.Size(64, 20);
			this._contrastLabel.TabIndex = 0;
			this._contrastLabel.Text = "Contrast";
			// 
			// _contrastInput
			// 
			this._contrastInput.Location = new System.Drawing.Point(100, 3);
			this._contrastInput.Name = "_contrastInput";
			this._contrastInput.Size = new System.Drawing.Size(100, 27);
			this._contrastInput.TabIndex = 1;
			this._contrastInput.ValueChanged += new System.EventHandler(this.ContrastInput_ValueChanged);
			// 
			// _brightnessInput
			// 
			this._brightnessInput.Location = new System.Drawing.Point(100, 36);
			this._brightnessInput.Name = "_brightnessInput";
			this._brightnessInput.Size = new System.Drawing.Size(100, 27);
			this._brightnessInput.TabIndex = 3;
			this._brightnessInput.ValueChanged += new System.EventHandler(this.BrightnessInput_ValueChanged);
			// 
			// _brightnessLabel
			// 
			this._brightnessLabel.AutoSize = true;
			this._brightnessLabel.Location = new System.Drawing.Point(3, 39);
			this._brightnessLabel.Name = "_brightnessLabel";
			this._brightnessLabel.Size = new System.Drawing.Size(77, 20);
			this._brightnessLabel.TabIndex = 2;
			this._brightnessLabel.Text = "Brightness";
			// 
			// ContrastBrightnessFilterSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._brightnessInput);
			this.Controls.Add(this._brightnessLabel);
			this.Controls.Add(this._contrastInput);
			this.Controls.Add(this._contrastLabel);
			this.Name = "ContrastBrightnessFilterSettings";
			this.Size = new System.Drawing.Size(230, 84);
			((System.ComponentModel.ISupportInitialize)(this._contrastInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._brightnessInput)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label _contrastLabel;
		private System.Windows.Forms.NumericUpDown _contrastInput;
		private System.Windows.Forms.NumericUpDown _brightnessInput;
		private System.Windows.Forms.Label _brightnessLabel;
	}
}
