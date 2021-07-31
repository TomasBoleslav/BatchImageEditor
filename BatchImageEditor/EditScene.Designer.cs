
namespace BatchImageEditor
{
	partial class EditScene
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
			this.filtersGroup = new System.Windows.Forms.GroupBox();
			this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.filtersGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// filtersGroup
			// 
			this.filtersGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.filtersGroup.Controls.Add(this.button3);
			this.filtersGroup.Controls.Add(this.button2);
			this.filtersGroup.Controls.Add(this.button1);
			this.filtersGroup.Controls.Add(this.checkedListBox1);
			this.filtersGroup.Location = new System.Drawing.Point(18, 18);
			this.filtersGroup.Name = "filtersGroup";
			this.filtersGroup.Padding = new System.Windows.Forms.Padding(6);
			this.filtersGroup.Size = new System.Drawing.Size(319, 540);
			this.filtersGroup.TabIndex = 0;
			this.filtersGroup.TabStop = false;
			this.filtersGroup.Text = "Filters";
			// 
			// checkedListBox1
			// 
			this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.checkedListBox1.FormattingEnabled = true;
			this.checkedListBox1.Location = new System.Drawing.Point(9, 29);
			this.checkedListBox1.Name = "checkedListBox1";
			this.checkedListBox1.Size = new System.Drawing.Size(200, 488);
			this.checkedListBox1.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(215, 29);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(95, 30);
			this.button1.TabIndex = 2;
			this.button1.Text = "Add";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(215, 65);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(95, 30);
			this.button2.TabIndex = 3;
			this.button2.Text = "Remove";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.Location = new System.Drawing.Point(215, 101);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(95, 30);
			this.button3.TabIndex = 4;
			this.button3.Text = "Edit";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// EditScene
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.filtersGroup);
			this.Name = "EditScene";
			this.Padding = new System.Windows.Forms.Padding(15);
			this.Size = new System.Drawing.Size(1011, 576);
			this.filtersGroup.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox filtersGroup;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckedListBox checkedListBox1;
	}
}
