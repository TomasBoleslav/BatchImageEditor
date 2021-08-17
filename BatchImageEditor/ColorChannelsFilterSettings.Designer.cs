
namespace BatchImageEditor
{
	partial class ColorChannelsFilterSettings
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
			this._deltaRInput = new System.Windows.Forms.NumericUpDown();
			this._deltaRedLabel = new System.Windows.Forms.Label();
			this._deltaGreenLabel = new System.Windows.Forms.Label();
			this._deltaGInput = new System.Windows.Forms.NumericUpDown();
			this._deltaBlueLabel = new System.Windows.Forms.Label();
			this._deltaBInput = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this._deltaRInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._deltaGInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._deltaBInput)).BeginInit();
			this.SuspendLayout();
			// 
			// _deltaRedInput
			// 
			this._deltaRInput.Location = new System.Drawing.Point(100, 3);
			this._deltaRInput.Name = "_deltaRedInput";
			this._deltaRInput.Size = new System.Drawing.Size(100, 27);
			this._deltaRInput.TabIndex = 0;
			this._deltaRInput.ValueChanged += new System.EventHandler(this.DeltaRInput_ValueChanged);
			// 
			// _deltaRedLabel
			// 
			this._deltaRedLabel.AutoSize = true;
			this._deltaRedLabel.Location = new System.Drawing.Point(3, 5);
			this._deltaRedLabel.Name = "_deltaRedLabel";
			this._deltaRedLabel.Size = new System.Drawing.Size(58, 20);
			this._deltaRedLabel.TabIndex = 1;
			this._deltaRedLabel.Text = "Delta R";
			// 
			// _deltaGreenLabel
			// 
			this._deltaGreenLabel.AutoSize = true;
			this._deltaGreenLabel.Location = new System.Drawing.Point(3, 38);
			this._deltaGreenLabel.Name = "_deltaGreenLabel";
			this._deltaGreenLabel.Size = new System.Drawing.Size(59, 20);
			this._deltaGreenLabel.TabIndex = 3;
			this._deltaGreenLabel.Text = "Delta G";
			// 
			// _deltaGreenInput
			// 
			this._deltaGInput.Location = new System.Drawing.Point(100, 36);
			this._deltaGInput.Name = "_deltaGreenInput";
			this._deltaGInput.Size = new System.Drawing.Size(100, 27);
			this._deltaGInput.TabIndex = 2;
			this._deltaGInput.ValueChanged += new System.EventHandler(this.DeltaGInput_ValueChanged);
			// 
			// _deltaBlueLabel
			// 
			this._deltaBlueLabel.AutoSize = true;
			this._deltaBlueLabel.Location = new System.Drawing.Point(3, 71);
			this._deltaBlueLabel.Name = "_deltaBlueLabel";
			this._deltaBlueLabel.Size = new System.Drawing.Size(58, 20);
			this._deltaBlueLabel.TabIndex = 5;
			this._deltaBlueLabel.Text = "Delta B";
			// 
			// _deltaBlueInput
			// 
			this._deltaBInput.Location = new System.Drawing.Point(100, 69);
			this._deltaBInput.Name = "_deltaBlueInput";
			this._deltaBInput.Size = new System.Drawing.Size(100, 27);
			this._deltaBInput.TabIndex = 4;
			this._deltaBInput.ValueChanged += new System.EventHandler(this.DeltaBInput_ValueChanged);
			// 
			// RgbColorFilterSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._deltaBlueLabel);
			this.Controls.Add(this._deltaBInput);
			this.Controls.Add(this._deltaGreenLabel);
			this.Controls.Add(this._deltaGInput);
			this.Controls.Add(this._deltaRedLabel);
			this.Controls.Add(this._deltaRInput);
			this.Name = "RgbColorFilterSettings";
			this.Size = new System.Drawing.Size(230, 125);
			((System.ComponentModel.ISupportInitialize)(this._deltaRInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._deltaGInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._deltaBInput)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown _deltaRInput;
		private System.Windows.Forms.Label _deltaRedLabel;
		private System.Windows.Forms.Label _deltaGreenLabel;
		private System.Windows.Forms.NumericUpDown _deltaGInput;
		private System.Windows.Forms.Label _deltaBlueLabel;
		private System.Windows.Forms.NumericUpDown _deltaBInput;
	}
}
