
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
			this.sceneTabs = new BatchImageEditor.SceneTabs();
			this.loadScene = new BatchImageEditor.LoadScene();
			this.SuspendLayout();
			// 
			// sceneTabs
			// 
			this.sceneTabs.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.sceneTabs.Dock = System.Windows.Forms.DockStyle.Top;
			this.sceneTabs.Location = new System.Drawing.Point(0, 0);
			this.sceneTabs.Name = "sceneTabs";
			this.sceneTabs.Size = new System.Drawing.Size(904, 50);
			this.sceneTabs.TabIndex = 0;
			this.sceneTabs.LoadTabSelected += new System.EventHandler(this.sceneTabs_LoadTabSelected);
			// 
			// loadScene
			// 
			this.loadScene.Dock = System.Windows.Forms.DockStyle.Fill;
			this.loadScene.Location = new System.Drawing.Point(0, 50);
			this.loadScene.Name = "loadScene";
			this.loadScene.Padding = new System.Windows.Forms.Padding(20);
			this.loadScene.Size = new System.Drawing.Size(904, 546);
			this.loadScene.TabIndex = 1;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(904, 596);
			this.Controls.Add(this.loadScene);
			this.Controls.Add(this.sceneTabs);
			this.Name = "MainForm";
			this.Text = "MainForm";
			this.ResumeLayout(false);

		}

		#endregion

		private SceneTabs sceneTabs;
		private LoadScene loadScene;
	}
}