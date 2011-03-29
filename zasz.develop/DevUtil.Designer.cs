﻿namespace zasz.develop
{
    partial class DevUtil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DevUtil));
            this.ImportPosts = new System.Windows.Forms.Button();
            this.ClearDB = new System.Windows.Forms.Button();
            this.DevConsole = new System.Windows.Forms.TextBox();
            this.ClearConsole = new System.Windows.Forms.Button();
            this.UtilChooseFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // ImportPosts
            // 
            this.ImportPosts.Location = new System.Drawing.Point(28, 18);
            this.ImportPosts.Name = "ImportPosts";
            this.ImportPosts.Size = new System.Drawing.Size(140, 30);
            this.ImportPosts.TabIndex = 0;
            this.ImportPosts.Text = "Import Posts (BE.NET)";
            this.ImportPosts.UseVisualStyleBackColor = true;
            this.ImportPosts.Click += new System.EventHandler(this.ImportPostsClick);
            // 
            // ClearDB
            // 
            this.ClearDB.Location = new System.Drawing.Point(28, 72);
            this.ClearDB.Name = "ClearDB";
            this.ClearDB.Size = new System.Drawing.Size(140, 30);
            this.ClearDB.TabIndex = 1;
            this.ClearDB.Text = "Clear RavenDB";
            this.ClearDB.UseVisualStyleBackColor = true;
            this.ClearDB.Click += new System.EventHandler(this.ClearDB_Click);
            // 
            // DevConsole
            // 
            this.DevConsole.Location = new System.Drawing.Point(585, 18);
            this.DevConsole.Multiline = true;
            this.DevConsole.Name = "DevConsole";
            this.DevConsole.ReadOnly = true;
            this.DevConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DevConsole.Size = new System.Drawing.Size(588, 507);
            this.DevConsole.TabIndex = 2;
            // 
            // ClearConsole
            // 
            this.ClearConsole.Location = new System.Drawing.Point(421, 18);
            this.ClearConsole.Name = "ClearConsole";
            this.ClearConsole.Size = new System.Drawing.Size(140, 30);
            this.ClearConsole.TabIndex = 3;
            this.ClearConsole.Text = "Clear Console";
            this.ClearConsole.UseVisualStyleBackColor = true;
            this.ClearConsole.Click += new System.EventHandler(this.ClearConsoleClick);
            // 
            // UtilChooseFolder
            // 
            this.UtilChooseFolder.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.UtilChooseFolder.SelectedPath = "C:\\Documents and Settings\\thiagac\\My Documents\\Visual Studio 2010\\Projects\\Posts";
            this.UtilChooseFolder.ShowNewFolderButton = false;
            // 
            // DevUtil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 550);
            this.Controls.Add(this.ClearConsole);
            this.Controls.Add(this.DevConsole);
            this.Controls.Add(this.ClearDB);
            this.Controls.Add(this.ImportPosts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DevUtil";
            this.Text = "Developer Utilities";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ImportPosts;
        private System.Windows.Forms.Button ClearDB;
        private System.Windows.Forms.TextBox DevConsole;
        private System.Windows.Forms.Button ClearConsole;
        private System.Windows.Forms.FolderBrowserDialog UtilChooseFolder;
    }
}

