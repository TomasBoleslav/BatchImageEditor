
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
			this.processTabButton = new System.Windows.Forms.Button();
			this.editTabButton = new System.Windows.Forms.Button();
			this.loadTabButton = new System.Windows.Forms.Button();
			this.tabsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabsPanel
			// 
			this.tabsPanel.Controls.Add(this.processTabButton);
			this.tabsPanel.Controls.Add(this.editTabButton);
			this.tabsPanel.Controls.Add(this.loadTabButton);
			this.tabsPanel.Location = new System.Drawing.Point(0, 0);
			this.tabsPanel.Name = "tabsPanel";
			this.tabsPanel.Size = new System.Drawing.Size(300, 50);
			this.tabsPanel.TabIndex = 0;
			// 
			// processTabButton
			// 
			this.processTabButton.FlatAppearance.BorderSize = 0;
			this.processTabButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.processTabButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
			this.processTabButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.processTabButton.ForeColor = System.Drawing.SystemColors.Window;
			this.processTabButton.Location = new System.Drawing.Point(200, 0);
			this.processTabButton.Margin = new System.Windows.Forms.Padding(0);
			this.processTabButton.Name = "processTabButton";
			this.processTabButton.Size = new System.Drawing.Size(100, 50);
			this.processTabButton.TabIndex = 2;
			this.processTabButton.Text = "PROCESS";
			this.processTabButton.UseVisualStyleBackColor = true;
			this.processTabButton.Click += new System.EventHandler(this.ProcessTabButton_Click);
			// 
			// editTabButton
			// 
			this.editTabButton.FlatAppearance.BorderSize = 0;
			this.editTabButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.editTabButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
			this.editTabButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.editTabButton.ForeColor = System.Drawing.SystemColors.Window;
			this.editTabButton.Location = new System.Drawing.Point(100, 0);
			this.editTabButton.Margin = new System.Windows.Forms.Padding(0);
			this.editTabButton.Name = "editTabButton";
			this.editTabButton.Size = new System.Drawing.Size(100, 50);
			this.editTabButton.TabIndex = 1;
			this.editTabButton.Text = "EDIT";
			this.editTabButton.UseVisualStyleBackColor = false;
			this.editTabButton.Click += new System.EventHandler(this.EditTabButton_Click);
			// 
			// loadTabButton
			// 
			this.loadTabButton.BackColor = System.Drawing.SystemColors.Control;
			this.loadTabButton.FlatAppearance.BorderSize = 0;
			this.loadTabButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
			this.loadTabButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
			this.loadTabButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.loadTabButton.Location = new System.Drawing.Point(0, 0);
			this.loadTabButton.Margin = new System.Windows.Forms.Padding(0);
			this.loadTabButton.Name = "loadTabButton";
			this.loadTabButton.Size = new System.Drawing.Size(100, 50);
			this.loadTabButton.TabIndex = 0;
			this.loadTabButton.Text = "LOAD";
			this.loadTabButton.UseVisualStyleBackColor = false;
			this.loadTabButton.Click += new System.EventHandler(this.LoadTabButton_Click);
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
		private System.Windows.Forms.Button processTabButton;
		private System.Windows.Forms.Button editTabButton;
		private System.Windows.Forms.Button loadTabButton;
	}
}
