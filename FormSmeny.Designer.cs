﻿namespace Dochazka
{
    partial class FormSmeny
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvSmeny = new System.Windows.Forms.ListView();
            this.btOK = new System.Windows.Forms.Button();
            this.btStorno = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvSmeny);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btStorno);
            this.splitContainer1.Panel2.Controls.Add(this.btOK);
            this.splitContainer1.Size = new System.Drawing.Size(392, 273);
            this.splitContainer1.SplitterDistance = 196;
            this.splitContainer1.TabIndex = 0;
            // 
            // lvSmeny
            // 
            this.lvSmeny.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSmeny.Location = new System.Drawing.Point(0, 0);
            this.lvSmeny.MultiSelect = false;
            this.lvSmeny.Name = "lvSmeny";
            this.lvSmeny.Size = new System.Drawing.Size(196, 273);
            this.lvSmeny.TabIndex = 0;
            this.lvSmeny.UseCompatibleStateImageBehavior = false;
            this.lvSmeny.View = System.Windows.Forms.View.List;
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.Location = new System.Drawing.Point(44, 238);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(65, 22);
            this.btOK.TabIndex = 0;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            // 
            // btStorno
            // 
            this.btStorno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStorno.Location = new System.Drawing.Point(115, 238);
            this.btStorno.Name = "btStorno";
            this.btStorno.Size = new System.Drawing.Size(65, 23);
            this.btStorno.TabIndex = 1;
            this.btStorno.Text = "Storno";
            this.btStorno.UseVisualStyleBackColor = true;
            // 
            // FormSmeny
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 273);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "FormSmeny";
            this.Text = "Směny";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lvSmeny;
        private System.Windows.Forms.Button btStorno;
        private System.Windows.Forms.Button btOK;
    }
}