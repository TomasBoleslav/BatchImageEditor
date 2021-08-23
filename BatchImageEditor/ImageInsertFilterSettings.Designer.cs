
namespace BatchImageEditor
{
	partial class ImageInsertFilterSettings
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this._loadImageButton = new System.Windows.Forms.Button();
			this._placementLabel = new System.Windows.Forms.Label();
			this._placementComboBox = new System.Windows.Forms.ComboBox();
			this._dXLabel = new System.Windows.Forms.Label();
			this._dXInput = new System.Windows.Forms.NumericUpDown();
			this._dYInput = new System.Windows.Forms.NumericUpDown();
			this._dYLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this._dXInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._dYInput)).BeginInit();
			this.SuspendLayout();
			// 
			// _loadImageButton
			// 
			this._loadImageButton.Location = new System.Drawing.Point(3, 3);
			this._loadImageButton.Name = "_loadImageButton";
			this._loadImageButton.Size = new System.Drawing.Size(120, 30);
			this._loadImageButton.TabIndex = 0;
			this._loadImageButton.Text = "Load image";
			this._loadImageButton.UseVisualStyleBackColor = true;
			this._loadImageButton.Click += new System.EventHandler(this.LoadImageButton_Click);
			// 
			// _placementLabel
			// 
			this._placementLabel.AutoSize = true;
			this._placementLabel.Location = new System.Drawing.Point(3, 42);
			this._placementLabel.Name = "_placementLabel";
			this._placementLabel.Size = new System.Drawing.Size(78, 20);
			this._placementLabel.TabIndex = 1;
			this._placementLabel.Text = "Placement";
			// 
			// _placementComboBox
			// 
			this._placementComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._placementComboBox.FormattingEnabled = true;
			this._placementComboBox.Location = new System.Drawing.Point(107, 39);
			this._placementComboBox.Name = "_placementComboBox";
			this._placementComboBox.Size = new System.Drawing.Size(120, 28);
			this._placementComboBox.TabIndex = 2;
			// 
			// _dXLabel
			// 
			this._dXLabel.AutoSize = true;
			this._dXLabel.Location = new System.Drawing.Point(3, 75);
			this._dXLabel.Name = "_dXLabel";
			this._dXLabel.Size = new System.Drawing.Size(88, 20);
			this._dXLabel.TabIndex = 3;
			this._dXLabel.Text = "Delta X (px)";
			// 
			// _dXInput
			// 
			this._dXInput.Location = new System.Drawing.Point(107, 73);
			this._dXInput.Name = "_dXInput";
			this._dXInput.Size = new System.Drawing.Size(120, 27);
			this._dXInput.TabIndex = 4;
			this._dXInput.ValueChanged += new System.EventHandler(this.DXInput_ValueChanged);
			// 
			// _dYInput
			// 
			this._dYInput.Location = new System.Drawing.Point(107, 106);
			this._dYInput.Name = "_dYInput";
			this._dYInput.Size = new System.Drawing.Size(120, 27);
			this._dYInput.TabIndex = 6;
			this._dYInput.ValueChanged += new System.EventHandler(this.DYInput_ValueChanged);
			// 
			// _dYLabel
			// 
			this._dYLabel.AutoSize = true;
			this._dYLabel.Location = new System.Drawing.Point(3, 108);
			this._dYLabel.Name = "_dYLabel";
			this._dYLabel.Size = new System.Drawing.Size(87, 20);
			this._dYLabel.TabIndex = 5;
			this._dYLabel.Text = "Delta Y (px)";
			// 
			// ImageOverlayFilterSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._dYInput);
			this.Controls.Add(this._dYLabel);
			this.Controls.Add(this._dXInput);
			this.Controls.Add(this._dXLabel);
			this.Controls.Add(this._placementComboBox);
			this.Controls.Add(this._placementLabel);
			this.Controls.Add(this._loadImageButton);
			this.Name = "ImageOverlayFilterSettings";
			this.Size = new System.Drawing.Size(230, 150);
			((System.ComponentModel.ISupportInitialize)(this._dXInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._dYInput)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button _loadImageButton;
		private System.Windows.Forms.Label _placementLabel;
		private System.Windows.Forms.ComboBox _placementComboBox;
		private System.Windows.Forms.Label _dXLabel;
		private System.Windows.Forms.NumericUpDown _dXInput;
		private System.Windows.Forms.NumericUpDown _dYInput;
		private System.Windows.Forms.Label _dYLabel;
	}
}
