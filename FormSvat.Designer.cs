namespace Dochazka
{
    partial class FormSvat
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuNovySv = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditSv = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSmazatSv = new System.Windows.Forms.ToolStripMenuItem();
            this.lvSvatky = new System.Windows.Forms.ListView();
            this.clmDatum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmNazev = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmOpak = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNovySv,
            this.mnuEditSv,
            this.mnuSmazatSv});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(414, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuNovySv
            // 
            this.mnuNovySv.Name = "mnuNovySv";
            this.mnuNovySv.Size = new System.Drawing.Size(79, 20);
            this.mnuNovySv.Text = "Nový svátek";
            this.mnuNovySv.Click += new System.EventHandler(this.mnuNovySv_Click_1);
            // 
            // mnuEditSv
            // 
            this.mnuEditSv.Name = "mnuEditSv";
            this.mnuEditSv.Size = new System.Drawing.Size(59, 20);
            this.mnuEditSv.Text = "Editovat";
            this.mnuEditSv.Click += new System.EventHandler(this.mnuEditSv_Click_1);
            // 
            // mnuSmazatSv
            // 
            this.mnuSmazatSv.Name = "mnuSmazatSv";
            this.mnuSmazatSv.Size = new System.Drawing.Size(54, 20);
            this.mnuSmazatSv.Text = "Smazat";
            this.mnuSmazatSv.Click += new System.EventHandler(this.mnuSmazatSv_Click);
            // 
            // lvSvatky
            // 
            this.lvSvatky.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmDatum,
            this.clmNazev,
            this.clmOpak});
            this.lvSvatky.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSvatky.FullRowSelect = true;
            this.lvSvatky.GridLines = true;
            this.lvSvatky.HideSelection = false;
            this.lvSvatky.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lvSvatky.Location = new System.Drawing.Point(0, 24);
            this.lvSvatky.MultiSelect = false;
            this.lvSvatky.Name = "lvSvatky";
            this.lvSvatky.ShowGroups = false;
            this.lvSvatky.Size = new System.Drawing.Size(414, 359);
            this.lvSvatky.TabIndex = 0;
            this.lvSvatky.UseCompatibleStateImageBehavior = false;
            this.lvSvatky.View = System.Windows.Forms.View.Details;
            // 
            // clmDatum
            // 
            this.clmDatum.Text = "Datum";
            // 
            // clmNazev
            // 
            this.clmNazev.Text = "Název";
            // 
            // clmOpak
            // 
            this.clmOpak.Text = "Opakování";
            this.clmOpak.Width = 104;
            // 
            // FormSvat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 383);
            this.Controls.Add(this.lvSvatky);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormSvat";
            this.Text = "Svátky";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSvat_FormClosed);
            this.Load += new System.EventHandler(this.FormSvat_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuNovySv;
        private System.Windows.Forms.ToolStripMenuItem mnuEditSv;
        private System.Windows.Forms.ToolStripMenuItem mnuSmazatSv;
        private System.Windows.Forms.ListView lvSvatky;
        private System.Windows.Forms.ColumnHeader clmDatum;
        private System.Windows.Forms.ColumnHeader clmNazev;
        private System.Windows.Forms.ColumnHeader clmOpak;


        public System.EventHandler lvSvatky_SelectedIndexChanged { get; set; }
    }
}