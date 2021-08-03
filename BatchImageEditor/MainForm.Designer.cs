
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
			this._sceneTabs = new BatchImageEditor.SceneTabs();
			this._loadScene = new BatchImageEditor.LoadScene();
			this._editScene = new BatchImageEditor.EditScene();
			this.SuspendLayout();
			// 
			// _sceneTabs
			// 
			this._sceneTabs.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this._sceneTabs.Dock = System.Windows.Forms.DockStyle.Top;
			this._sceneTabs.Location = new System.Drawing.Point(0, 0);
			this._sceneTabs.Name = "_sceneTabs";
			this._sceneTabs.Size = new System.Drawing.Size(904, 50);
			this._sceneTabs.TabIndex = 0;
			this._sceneTabs.LoadTabSelected += new System.EventHandler(this.SceneTabs_LoadTabSelected);
			this._sceneTabs.EditTabSelected += new System.EventHandler(this.SceneTabs_EditTabSelected);
			// 
			// _loadScene
			// 
			this._loadScene.Dock = System.Windows.Forms.DockStyle.Fill;
			this._loadScene.Location = new System.Drawing.Point(0, 50);
			this._loadScene.Name = "_loadScene";
			this._loadScene.Padding = new System.Windows.Forms.Padding(20);
			this._loadScene.Size = new System.Drawing.Size(904, 546);
			this._loadScene.TabIndex = 1;
			this._loadScene.FileSetChanged += new System.EventHandler(this.LoadScene_FileSetChanged);
			// 
			// _editScene
			// 
			this._editScene.Dock = System.Windows.Forms.DockStyle.Fill;
			this._editScene.Location = new System.Drawing.Point(0, 50);
			this._editScene.Name = "_editScene";
			this._editScene.Padding = new System.Windows.Forms.Padding(15);
			this._editScene.Size = new System.Drawing.Size(904, 546);
			this._editScene.TabIndex = 2;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(904, 596);
			this.Controls.Add(this._loadScene);
			this.Controls.Add(this._editScene);
			this.Controls.Add(this._sceneTabs);
			this.Name = "MainForm";
			this.Text = "MainForm";
			this.ResumeLayout(false);

		}

		#endregion

		private SceneTabs _sceneTabs;
		private LoadScene _loadScene;
		private EditScene _editScene;
	}
}