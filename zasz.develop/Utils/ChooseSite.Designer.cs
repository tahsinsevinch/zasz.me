﻿namespace zasz.develop.Utils
{
    partial class ChooseSite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseSite));
            this.Pro = new System.Windows.Forms.Button();
            this.Rest = new System.Windows.Forms.Button();
            this.Both = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Pro
            // 
            this.Pro.Location = new System.Drawing.Point(18, 85);
            this.Pro.Name = "Pro";
            this.Pro.Size = new System.Drawing.Size(70, 30);
            this.Pro.TabIndex = 0;
            this.Pro.Text = "Pro";
            this.Pro.UseVisualStyleBackColor = true;
            this.Pro.Click += new System.EventHandler(this.AnyClick);
            // 
            // Rest
            // 
            this.Rest.Location = new System.Drawing.Point(94, 85);
            this.Rest.Name = "Rest";
            this.Rest.Size = new System.Drawing.Size(70, 30);
            this.Rest.TabIndex = 1;
            this.Rest.Text = "Rest";
            this.Rest.UseVisualStyleBackColor = true;
            this.Rest.Click += new System.EventHandler(this.AnyClick);
            // 
            // Both
            // 
            this.Both.Location = new System.Drawing.Point(170, 85);
            this.Both.Name = "Both";
            this.Both.Size = new System.Drawing.Size(70, 30);
            this.Both.TabIndex = 2;
            this.Both.Text = "Both";
            this.Both.UseVisualStyleBackColor = true;
            this.Both.Click += new System.EventHandler(this.AnyClick);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Location = new System.Drawing.Point(26, 27);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(39, 13);
            this.Title.TabIndex = 3;
            this.Title.Text = "<Title>";
            // 
            // ChooseSite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 128);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.Both);
            this.Controls.Add(this.Rest);
            this.Controls.Add(this.Pro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseSite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChooseSite";
            this.Load += new System.EventHandler(this.ChooseSite_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Pro;
        private System.Windows.Forms.Button Rest;
        private System.Windows.Forms.Button Both;
        private System.Windows.Forms.Label Title;

    }
}