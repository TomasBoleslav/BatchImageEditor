
namespace BatchImageEditor
{
	partial class SceneTabs
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
			this.tabsPanel = new System.Windows.Forms.Panel();
			this._processTabButton = new System.Windows.Forms.Button();
			this._editTabButton = new System.Windows.Forms.Button();
			this._loadTabButton = new System.Windows.Forms.Button();
			this.tabsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabsPanel
			// 
			this.tabsPanel.Controls.Add(this._processTabButton);
			this.tabsPanel.Controls.Add(this._editTabButton);
			this.tabsPanel.Controls.Add(this._loadTabButton);
			this.tabsPanel.Location = new System.Drawing.Point(0, 0);
			this.tabsPanel.Name = "tabsPanel";
			this.tabsPanel.Size = new System.Drawing.Size(300, 50);
			this.tabsPanel.TabIndex = 0;
			// 
			// processTabButton
			// 
			this._processTabButton.FlatAppearance.BorderSize = 0;
			this._processTabButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this._processTabButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
			this._processTabButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._processTabButton.ForeColor = System.Drawing.SystemColors.Window;
			this._processTabButton.Location = new System.Drawing.Point(200, 0);
			this._processTabButton.Margin = new System.Windows.Forms.Padding(0);
			this._processTabButton.Name = "processTabButton";
			this._processTabButton.Size = new System.Drawing.Size(100, 50);
			this._processTabButton.TabIndex = 2;
			this._processTabButton.Text = "PROCESS";
			this._processTabButton.UseVisualStyleBackColor = true;
			this._processTabButton.Click += new System.EventHandler(this.ProcessTabButton_Click);
			// 
			// editTabButton
			// 
			this._editTabButton.FlatAppearance.BorderSize = 0;
			this._editTabButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this._editTabButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
			this._editTabButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._editTabButton.ForeColor = System.Drawing.SystemColors.Window;
			this._editTabButton.Location = new System.Drawing.Point(100, 0);
			this._editTabButton.Margin = new System.Windows.Forms.Padding(0);
			this._editTabButton.Name = "editTabButton";
			this._editTabButton.Size = new System.Drawing.Size(100, 50);
			this._editTabButton.TabIndex = 1;
			this._editTabButton.Text = "EDIT";
			this._editTabButton.UseVisualStyleBackColor = false;
			this._editTabButton.Click += new System.EventHandler(this.EditTabButton_Click);
			// 
			// loadTabButton
			// 
			this._loadTabButton.BackColor = System.Drawing.SystemColors.Control;
			this._loadTabButton.FlatAppearance.BorderSize = 0;
			this._loadTabButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
			this._loadTabButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
			this._loadTabButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._loadTabButton.Location = new System.Drawing.Point(0, 0);
			this._loadTabButton.Margin = new System.Windows.Forms.Padding(0);
			this._loadTabButton.Name = "loadTabButton";
			this._loadTabButton.Size = new System.Drawing.Size(100, 50);
			this._loadTabButton.TabIndex = 0;
			this._loadTabButton.Text = "LOAD";
			this._loadTabButton.UseVisualStyleBackColor = false;
			this._loadTabButton.Click += new System.EventHandler(this.LoadTabButton_Click);
			// 
			// SceneTabs
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.Controls.Add(this.tabsPanel);
			this.Name = "SceneTabs";
			this.Size = new System.Drawing.Size(511, 50);
			this.Load += new System.EventHandler(this.SceneTabs_Load);
			this.Resize += new System.EventHandler(this.SceneTabs_Resize);
			this.tabsPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel tabsPanel;
		private System.Windows.Forms.Button _processTabButton;
		private System.Windows.Forms.Button _editTabButton;
		private System.Windows.Forms.Button _loadTabButton;
	}
}
