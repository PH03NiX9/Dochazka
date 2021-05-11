namespace Dochazka
{
    partial class FormGroup
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
            this.lvGroup = new System.Windows.Forms.ListView();
            this.clmPopis = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuNova = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOdstranit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvGroup
            // 
            this.lvGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmPopis});
            this.lvGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvGroup.FullRowSelect = true;
            this.lvGroup.GridLines = true;
            this.lvGroup.HideSelection = false;
            this.lvGroup.Location = new System.Drawing.Point(0, 24);
            this.lvGroup.MultiSelect = false;
            this.lvGroup.Name = "lvGroup";
            this.lvGroup.ShowGroups = false;
            this.lvGroup.Size = new System.Drawing.Size(334, 344);
            this.lvGroup.TabIndex = 0;
            this.lvGroup.UseCompatibleStateImageBehavior = false;
            this.lvGroup.View = System.Windows.Forms.View.Details;
            this.lvGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvGroup_KeyDown);
            this.lvGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvGroup_KeyPress);
            this.lvGroup.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvGroup_MouseDoubleClick);
            // 
            // clmPopis
            // 
            this.clmPopis.Text = "Název";
            this.clmPopis.Width = 136;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNova,
            this.mnuEdit,
            this.mnuOdstranit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(334, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuNova
            // 
            this.mnuNova.Name = "mnuNova";
            this.mnuNova.Size = new System.Drawing.Size(83, 20);
            this.mnuNova.Text = "Nová skupina";
            this.mnuNova.Click += new System.EventHandler(this.mnuNova_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(98, 20);
            this.mnuEdit.Text = "Editovat skupinu";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // mnuOdstranit
            // 
            this.mnuOdstranit.Name = "mnuOdstranit";
            this.mnuOdstranit.Size = new System.Drawing.Size(103, 20);
            this.mnuOdstranit.Text = "Odstranit skupinu";
            this.mnuOdstranit.Click += new System.EventHandler(this.mnuOdstranit_Click);
            // 
            // FormGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 368);
            this.Controls.Add(this.lvGroup);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormGroup";
            this.Text = "Skupiny";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGroup_FormClosing);
            this.Load += new System.EventHandler(this.FormGroup_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvGroup;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuNova;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuOdstranit;
        private System.Windows.Forms.ColumnHeader clmPopis;
    }
}