
namespace BatchImageEditor
{
	partial class MedianFilterSettings
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
			this._radiusInput = new System.Windows.Forms.NumericUpDown();
			this._radiusLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this._radiusInput)).BeginInit();
			this.SuspendLayout();
			// 
			// _radiusInput
			// 
			this._radiusInput.Location = new System.Drawing.Point(77, 3);
			this._radiusInput.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this._radiusInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this._radiusInput.Name = "_radiusInput";
			this._radiusInput.Size = new System.Drawing.Size(100, 27);
			this._radiusInput.TabIndex = 0;
			this._radiusInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this._radiusInput.ValueChanged += new System.EventHandler(this.RadiusInput_ValueChanged);
			// 
			// _radiusLabel
			// 
			this._radiusLabel.AutoSize = true;
			this._radiusLabel.Location = new System.Drawing.Point(3, 5);
			this._radiusLabel.Name = "_radiusLabel";
			this._radiusLabel.Size = new System.Drawing.Size(56, 20);
			this._radiusLabel.TabIndex = 1;
			this._radiusLabel.Text = "Radius:";
			// 
			// MedianFilterSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._radiusLabel);
			this.Controls.Add(this._radiusInput);
			this.Name = "MedianFilterSettings";
			this.Size = new System.Drawing.Size(230, 41);
			((System.ComponentModel.ISupportInitialize)(this._radiusInput)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown _radiusInput;
		private System.Windows.Forms.Label _radiusLabel;
	}
}
