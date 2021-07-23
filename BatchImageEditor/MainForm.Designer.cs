
namespace BatchImageEditor
{
	partial class MainForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sceneTabs1 = new BatchImageEditor.SceneTabs();
			this.loadScene1 = new BatchImageEditor.LoadScene();
			this.SuspendLayout();
			// 
			// sceneTabs1
			// 
			this.sceneTabs1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.sceneTabs1.Dock = System.Windows.Forms.DockStyle.Top;
			this.sceneTabs1.Location = new System.Drawing.Point(0, 0);
			this.sceneTabs1.Name = "sceneTabs1";
			this.sceneTabs1.Size = new System.Drawing.Size(904, 50);
			this.sceneTabs1.TabIndex = 0;
			// 
			// loadScene1
			// 
			this.loadScene1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.loadScene1.Location = new System.Drawing.Point(0, 50);
			this.loadScene1.Name = "loadScene1";
			this.loadScene1.Padding = new System.Windows.Forms.Padding(20);
			this.loadScene1.Size = new System.Drawing.Size(904, 546);
			this.loadScene1.TabIndex = 1;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(904, 596);
			this.Controls.Add(this.loadScene1);
			this.Controls.Add(this.sceneTabs1);
			this.Name = "MainForm";
			this.Text = "MainForm";
			this.ResumeLayout(false);

		}

		#endregion

		private SceneTabs sceneTabs1;
		private LoadScene loadScene1;
	}
}