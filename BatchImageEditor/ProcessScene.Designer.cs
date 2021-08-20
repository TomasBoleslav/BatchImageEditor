
namespace BatchImageEditor
{
	partial class ProcessScene
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
			this._outputGroup = new System.Windows.Forms.GroupBox();
			this._selectOutputFolderButton = new System.Windows.Forms.Button();
			this._outputFolderBox = new System.Windows.Forms.TextBox();
			this._outputFolderLabel = new System.Windows.Forms.Label();
			this._processButton = new System.Windows.Forms.Button();
			this._threadCountLabel = new System.Windows.Forms.Label();
			this._threadCountInput = new System.Windows.Forms.NumericUpDown();
			this._coreCountCheckBox = new System.Windows.Forms.CheckBox();
			this._cpuGroup = new System.Windows.Forms.GroupBox();
			this._outputGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._threadCountInput)).BeginInit();
			this._cpuGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// _outputGroup
			// 
			this._outputGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._outputGroup.Controls.Add(this._selectOutputFolderButton);
			this._outputGroup.Controls.Add(this._outputFolderBox);
			this._outputGroup.Controls.Add(this._outputFolderLabel);
			this._outputGroup.Location = new System.Drawing.Point(18, 18);
			this._outputGroup.Name = "_outputGroup";
			this._outputGroup.Padding = new System.Windows.Forms.Padding(10);
			this._outputGroup.Size = new System.Drawing.Size(711, 87);
			this._outputGroup.TabIndex = 0;
			this._outputGroup.TabStop = false;
			this._outputGroup.Text = "Output";
			// 
			// _selectOutputFolderButton
			// 
			this._selectOutputFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._selectOutputFolderButton.Location = new System.Drawing.Point(598, 33);
			this._selectOutputFolderButton.Name = "_selectOutputFolderButton";
			this._selectOutputFolderButton.Size = new System.Drawing.Size(100, 30);
			this._selectOutputFolderButton.TabIndex = 4;
			this._selectOutputFolderButton.Text = "Select";
			this._selectOutputFolderButton.UseVisualStyleBackColor = true;
			this._selectOutputFolderButton.Click += new System.EventHandler(this.SelectOutputFolderButton_Click);
			// 
			// _outputFolderBox
			// 
			this._outputFolderBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._outputFolderBox.Location = new System.Drawing.Point(142, 35);
			this._outputFolderBox.Name = "_outputFolderBox";
			this._outputFolderBox.Size = new System.Drawing.Size(438, 27);
			this._outputFolderBox.TabIndex = 3;
			// 
			// _outputFolderLabel
			// 
			this._outputFolderLabel.AutoSize = true;
			this._outputFolderLabel.Location = new System.Drawing.Point(13, 38);
			this._outputFolderLabel.Name = "_outputFolderLabel";
			this._outputFolderLabel.Size = new System.Drawing.Size(51, 20);
			this._outputFolderLabel.TabIndex = 1;
			this._outputFolderLabel.Text = "Folder";
			// 
			// _processButton
			// 
			this._processButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._processButton.Location = new System.Drawing.Point(629, 442);
			this._processButton.Name = "_processButton";
			this._processButton.Size = new System.Drawing.Size(100, 30);
			this._processButton.TabIndex = 0;
			this._processButton.Text = "Process";
			this._processButton.UseVisualStyleBackColor = true;
			this._processButton.Click += new System.EventHandler(this.ProcessButton_Click);
			// 
			// _threadCountLabel
			// 
			this._threadCountLabel.AutoSize = true;
			this._threadCountLabel.Location = new System.Drawing.Point(13, 35);
			this._threadCountLabel.Name = "_threadCountLabel";
			this._threadCountLabel.Size = new System.Drawing.Size(98, 20);
			this._threadCountLabel.TabIndex = 6;
			this._threadCountLabel.Text = "Thread Count";
			// 
			// _threadCountInput
			// 
			this._threadCountInput.Location = new System.Drawing.Point(142, 33);
			this._threadCountInput.Name = "_threadCountInput";
			this._threadCountInput.Size = new System.Drawing.Size(70, 27);
			this._threadCountInput.TabIndex = 7;
			// 
			// _coreCountCheckBox
			// 
			this._coreCountCheckBox.AutoSize = true;
			this._coreCountCheckBox.Checked = true;
			this._coreCountCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this._coreCountCheckBox.Location = new System.Drawing.Point(261, 34);
			this._coreCountCheckBox.Name = "_coreCountCheckBox";
			this._coreCountCheckBox.Size = new System.Drawing.Size(133, 24);
			this._coreCountCheckBox.TabIndex = 8;
			this._coreCountCheckBox.Text = "Use Core Count";
			this._coreCountCheckBox.UseVisualStyleBackColor = true;
			this._coreCountCheckBox.CheckedChanged += new System.EventHandler(this.CoreCountCheckBox_CheckedChanged);
			// 
			// _cpuGroup
			// 
			this._cpuGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._cpuGroup.Controls.Add(this._coreCountCheckBox);
			this._cpuGroup.Controls.Add(this._threadCountInput);
			this._cpuGroup.Controls.Add(this._threadCountLabel);
			this._cpuGroup.Location = new System.Drawing.Point(18, 111);
			this._cpuGroup.Name = "_cpuGroup";
			this._cpuGroup.Padding = new System.Windows.Forms.Padding(10);
			this._cpuGroup.Size = new System.Drawing.Size(711, 90);
			this._cpuGroup.TabIndex = 9;
			this._cpuGroup.TabStop = false;
			this._cpuGroup.Text = "CPU";
			// 
			// ProcessScene
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._cpuGroup);
			this.Controls.Add(this._outputGroup);
			this.Controls.Add(this._processButton);
			this.Name = "ProcessScene";
			this.Padding = new System.Windows.Forms.Padding(15);
			this.Size = new System.Drawing.Size(747, 490);
			this._outputGroup.ResumeLayout(false);
			this._outputGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this._threadCountInput)).EndInit();
			this._cpuGroup.ResumeLayout(false);
			this._cpuGroup.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox _outputGroup;
		private System.Windows.Forms.Button _processButton;
		private System.Windows.Forms.Button _selectOutputFolderButton;
		private System.Windows.Forms.TextBox _outputFolderBox;
		private System.Windows.Forms.Label _outputFolderLabel;
		private System.Windows.Forms.Label _threadCountLabel;
		private System.Windows.Forms.NumericUpDown _threadCountInput;
		private System.Windows.Forms.CheckBox _coreCountCheckBox;
		private System.Windows.Forms.GroupBox _cpuGroup;
	}
}
