
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
			this._processScene = new BatchImageEditor.ProcessScene();
			this.SuspendLayout();
			// 
			// _sceneTabs
			// 
			this._sceneTabs.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this._sceneTabs.Dock = System.Windows.Forms.DockStyle.Top;
			this._sceneTabs.Location = new System.Drawing.Point(0, 0);
			this._sceneTabs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._sceneTabs.Name = "_sceneTabs";
			this._sceneTabs.Size = new System.Drawing.Size(774, 38);
			this._sceneTabs.TabIndex = 0;
			this._sceneTabs.LoadTabSelected += new System.EventHandler(this.SceneTabs_LoadTabSelected);
			this._sceneTabs.EditTabSelected += new System.EventHandler(this.SceneTabs_EditTabSelected);
			this._sceneTabs.ProcessTabSelected += new System.EventHandler(this.SceneTabs_ProcessTabSelected);
			// 
			// _loadScene
			// 
			this._loadScene.Dock = System.Windows.Forms.DockStyle.Fill;
			this._loadScene.Location = new System.Drawing.Point(0, 38);
			this._loadScene.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._loadScene.Name = "_loadScene";
			this._loadScene.Padding = new System.Windows.Forms.Padding(18, 15, 18, 15);
			this._loadScene.Size = new System.Drawing.Size(774, 458);
			this._loadScene.TabIndex = 1;
			this._loadScene.FileSetChanged += new System.EventHandler(this.LoadScene_FileSetChanged);
			// 
			// _editScene
			// 
			this._editScene.Dock = System.Windows.Forms.DockStyle.Fill;
			this._editScene.Location = new System.Drawing.Point(0, 38);
			this._editScene.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._editScene.Name = "_editScene";
			this._editScene.Padding = new System.Windows.Forms.Padding(13, 11, 13, 11);
			this._editScene.Size = new System.Drawing.Size(774, 458);
			this._editScene.TabIndex = 2;
			this._editScene.FilterListChanged += new System.EventHandler(this.EditScene_FilterListChanged);
			// 
			// _processScene
			// 
			this._processScene.Dock = System.Windows.Forms.DockStyle.Fill;
			this._processScene.Location = new System.Drawing.Point(0, 0);
			this._processScene.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this._processScene.Name = "_processScene";
			this._processScene.Padding = new System.Windows.Forms.Padding(13, 11, 13, 11);
			this._processScene.Size = new System.Drawing.Size(774, 496);
			this._processScene.TabIndex = 3;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(774, 496);
			this.Controls.Add(this._loadScene);
			this.Controls.Add(this._editScene);
			this.Controls.Add(this._sceneTabs);
			this.Controls.Add(this._processScene);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MinimumSize = new System.Drawing.Size(790, 535);
			this.Name = "MainForm";
			this.Text = "BatchImageEditor";
			this.ResumeLayout(false);

		}

		#endregion

		private SceneTabs _sceneTabs;
		private LoadScene _loadScene;
		private EditScene _editScene;
		private ProcessScene _processScene;
	}
}