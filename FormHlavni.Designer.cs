namespace Dochazka
{
    partial class FormHlavni
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHlavni));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelZamestnanci = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuSoubor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNovy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOdstranit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuKonec = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNovyDochazka = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditDochazky = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOdstranitDochazka = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSkupiny = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTisk = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNastaveni = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSvatky = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsCombRok = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tsCombMesic = new System.Windows.Forms.ToolStripComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvZamestnanci = new System.Windows.Forms.ListView();
            this.clmPrijmeni = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmJmeno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmRFID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmAktivni = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvDochazka = new System.Windows.Forms.ListView();
            this.clmDen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCas = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTypOdchodu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDoba = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.lbSumaHodin = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbSvatky = new System.Windows.Forms.Label();
            this.lbVikend = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbLekar = new System.Windows.Forms.Label();
            this.lbOCR = new System.Windows.Forms.Label();
            this.lbNemoc = new System.Windows.Forms.Label();
            this.lbDovolena = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelZamestnanci});
            this.statusStrip1.Location = new System.Drawing.Point(0, 475);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(753, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelZamestnanci
            // 
            this.toolStripStatusLabelZamestnanci.Name = "toolStripStatusLabelZamestnanci";
            this.toolStripStatusLabelZamestnanci.Size = new System.Drawing.Size(107, 17);
            this.toolStripStatusLabelZamestnanci.Text = "Počet zaměstnanců: ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSoubor,
            this.toolStripMenuItem1,
            this.mnuSkupiny,
            this.mnuTisk,
            this.toolStripMenuItem2,
            this.mnuAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(753, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuSoubor
            // 
            this.mnuSoubor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNovy,
            this.mnuEdit,
            this.mnuOdstranit,
            this.toolStripSeparator1,
            this.mnuKonec});
            this.mnuSoubor.ForeColor = System.Drawing.Color.Black;
            this.mnuSoubor.Name = "mnuSoubor";
            this.mnuSoubor.Size = new System.Drawing.Size(79, 20);
            this.mnuSoubor.Text = "Zaměstnanci";
            // 
            // mnuNovy
            // 
            this.mnuNovy.ForeColor = System.Drawing.Color.Black;
            this.mnuNovy.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.mnuNovy.Name = "mnuNovy";
            this.mnuNovy.Size = new System.Drawing.Size(130, 22);
            this.mnuNovy.Text = "Nový ";
            this.mnuNovy.Click += new System.EventHandler(this.mnuNovy_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.ForeColor = System.Drawing.Color.Black;
            this.mnuEdit.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(130, 22);
            this.mnuEdit.Text = "Editace";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // mnuOdstranit
            // 
            this.mnuOdstranit.ForeColor = System.Drawing.Color.Black;
            this.mnuOdstranit.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.mnuOdstranit.Name = "mnuOdstranit";
            this.mnuOdstranit.Size = new System.Drawing.Size(130, 22);
            this.mnuOdstranit.Text = "Odstranit";
            this.mnuOdstranit.Click += new System.EventHandler(this.mnuOdstranit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(127, 6);
            // 
            // mnuKonec
            // 
            this.mnuKonec.ForeColor = System.Drawing.Color.Black;
            this.mnuKonec.Name = "mnuKonec";
            this.mnuKonec.Size = new System.Drawing.Size(130, 22);
            this.mnuKonec.Text = "Konec";
            this.mnuKonec.Click += new System.EventHandler(this.mnuKonec_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNovyDochazka,
            this.mnuEditDochazky,
            this.mnuOdstranitDochazka});
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(65, 20);
            this.toolStripMenuItem1.Text = "Docházka";
            // 
            // mnuNovyDochazka
            // 
            this.mnuNovyDochazka.ForeColor = System.Drawing.Color.Black;
            this.mnuNovyDochazka.Name = "mnuNovyDochazka";
            this.mnuNovyDochazka.Size = new System.Drawing.Size(169, 22);
            this.mnuNovyDochazka.Text = "Nový záznam";
            this.mnuNovyDochazka.Click += new System.EventHandler(this.mnuNovyDochazka_Click);
            // 
            // mnuEditDochazky
            // 
            this.mnuEditDochazky.ForeColor = System.Drawing.Color.Black;
            this.mnuEditDochazky.Name = "mnuEditDochazky";
            this.mnuEditDochazky.Size = new System.Drawing.Size(169, 22);
            this.mnuEditDochazky.Text = "Editace docházky";
            this.mnuEditDochazky.Click += new System.EventHandler(this.mnuEditDochazky_Click);
            // 
            // mnuOdstranitDochazka
            // 
            this.mnuOdstranitDochazka.ForeColor = System.Drawing.Color.Black;
            this.mnuOdstranitDochazka.Name = "mnuOdstranitDochazka";
            this.mnuOdstranitDochazka.Size = new System.Drawing.Size(169, 22);
            this.mnuOdstranitDochazka.Text = "Odstranit záznam";
            this.mnuOdstranitDochazka.Click += new System.EventHandler(this.mnuOdstranitDochazka_Click);
            // 
            // mnuSkupiny
            // 
            this.mnuSkupiny.ForeColor = System.Drawing.Color.Black;
            this.mnuSkupiny.Name = "mnuSkupiny";
            this.mnuSkupiny.Size = new System.Drawing.Size(56, 20);
            this.mnuSkupiny.Text = "Skupiny";
            this.mnuSkupiny.Click += new System.EventHandler(this.mnuSkupiny_Click);
            // 
            // mnuTisk
            // 
            this.mnuTisk.ForeColor = System.Drawing.Color.Black;
            this.mnuTisk.Name = "mnuTisk";
            this.mnuTisk.Size = new System.Drawing.Size(78, 20);
            this.mnuTisk.Text = "Tisk sestavy";
            this.mnuTisk.Click += new System.EventHandler(this.mnuTisk_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNastaveni,
            this.mnuSvatky});
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.Black;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(60, 20);
            this.toolStripMenuItem2.Text = "Nástroje";
            // 
            // mnuNastaveni
            // 
            this.mnuNastaveni.ForeColor = System.Drawing.Color.Black;
            this.mnuNastaveni.Name = "mnuNastaveni";
            this.mnuNastaveni.Size = new System.Drawing.Size(133, 22);
            this.mnuNastaveni.Text = "Nastavení";
            this.mnuNastaveni.Click += new System.EventHandler(this.mnuNastaveni_Click);
            // 
            // mnuSvatky
            // 
            this.mnuSvatky.Name = "mnuSvatky";
            this.mnuSvatky.Size = new System.Drawing.Size(133, 22);
            this.mnuSvatky.Text = "Svátky";
            this.mnuSvatky.Click += new System.EventHandler(this.mnuSvatky_Click);
            // 
            // mnuAbout
            // 
            this.mnuAbout.ForeColor = System.Drawing.Color.Black;
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(64, 20);
            this.mnuAbout.Text = "O aplikaci";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tsCombRok,
            this.toolStripLabel2,
            this.tsCombMesic});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(753, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(32, 22);
            this.toolStripLabel1.Text = "Rok: ";
            // 
            // tsCombRok
            // 
            this.tsCombRok.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsCombRok.Name = "tsCombRok";
            this.tsCombRok.Size = new System.Drawing.Size(121, 25);
            this.tsCombRok.SelectedIndexChanged += new System.EventHandler(this.tsCombRok_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(40, 22);
            this.toolStripLabel2.Text = "Měsíc: ";
            // 
            // tsCombMesic
            // 
            this.tsCombMesic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsCombMesic.Name = "tsCombMesic";
            this.tsCombMesic.Size = new System.Drawing.Size(121, 25);
            this.tsCombMesic.SelectedIndexChanged += new System.EventHandler(this.tsCombMesic_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvZamestnanci);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvDochazka);
            this.splitContainer1.Size = new System.Drawing.Size(639, 426);
            this.splitContainer1.SplitterDistance = 307;
            this.splitContainer1.TabIndex = 4;
            // 
            // lvZamestnanci
            // 
            this.lvZamestnanci.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmPrijmeni,
            this.clmJmeno,
            this.clmRFID,
            this.clmAktivni,
            this.clmGroup});
            this.lvZamestnanci.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvZamestnanci.FullRowSelect = true;
            this.lvZamestnanci.GridLines = true;
            this.lvZamestnanci.HideSelection = false;
            this.lvZamestnanci.Location = new System.Drawing.Point(0, 0);
            this.lvZamestnanci.MultiSelect = false;
            this.lvZamestnanci.Name = "lvZamestnanci";
            this.lvZamestnanci.ShowGroups = false;
            this.lvZamestnanci.Size = new System.Drawing.Size(307, 426);
            this.lvZamestnanci.TabIndex = 0;
            this.lvZamestnanci.UseCompatibleStateImageBehavior = false;
            this.lvZamestnanci.View = System.Windows.Forms.View.Details;
            this.lvZamestnanci.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvZamestnanci_ItemSelectionChanged);
            this.lvZamestnanci.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvZamestnanci_KeyDown);
            this.lvZamestnanci.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvZamestnanci_KeyPress);
            this.lvZamestnanci.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvZamestnanci_MouseDoubleClick);
            // 
            // clmPrijmeni
            // 
            this.clmPrijmeni.Text = "Příjmení";
            this.clmPrijmeni.Width = 81;
            // 
            // clmJmeno
            // 
            this.clmJmeno.Text = "Jméno";
            this.clmJmeno.Width = 72;
            // 
            // clmRFID
            // 
            this.clmRFID.Text = "RFID karta";
            this.clmRFID.Width = 64;
            // 
            // clmAktivni
            // 
            this.clmAktivni.Text = "Aktivní";
            this.clmAktivni.Width = 48;
            // 
            // clmGroup
            // 
            this.clmGroup.Text = "Skupina";
            // 
            // lvDochazka
            // 
            this.lvDochazka.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmDen,
            this.clmCas,
            this.clmTypOdchodu,
            this.clmDoba});
            this.lvDochazka.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDochazka.FullRowSelect = true;
            this.lvDochazka.GridLines = true;
            this.lvDochazka.HideSelection = false;
            this.lvDochazka.Location = new System.Drawing.Point(0, 0);
            this.lvDochazka.MultiSelect = false;
            this.lvDochazka.Name = "lvDochazka";
            this.lvDochazka.Size = new System.Drawing.Size(328, 426);
            this.lvDochazka.TabIndex = 1;
            this.lvDochazka.UseCompatibleStateImageBehavior = false;
            this.lvDochazka.View = System.Windows.Forms.View.Details;
            this.lvDochazka.SelectedIndexChanged += new System.EventHandler(this.lvDochazka_SelectedIndexChanged);
            this.lvDochazka.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvDochazka_KeyDown);
            this.lvDochazka.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvDochazka_KeyPress);
            this.lvDochazka.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvDochazka_MouseDoubleClick);
            // 
            // clmDen
            // 
            this.clmDen.Text = "Den";
            this.clmDen.Width = 56;
            // 
            // clmCas
            // 
            this.clmCas.Text = "Čas";
            // 
            // clmTypOdchodu
            // 
            this.clmTypOdchodu.Text = "Důvod";
            this.clmTypOdchodu.Width = 75;
            // 
            // clmDoba
            // 
            this.clmDoba.Text = "Doba";
            this.clmDoba.Width = 72;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Odpracováno:";
            // 
            // lbSumaHodin
            // 
            this.lbSumaHodin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSumaHodin.AutoSize = true;
            this.lbSumaHodin.Location = new System.Drawing.Point(11, 50);
            this.lbSumaHodin.Name = "lbSumaHodin";
            this.lbSumaHodin.Size = new System.Drawing.Size(55, 13);
            this.lbSumaHodin.TabIndex = 6;
            this.lbSumaHodin.Text = "                ";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbSvatky);
            this.panel1.Controls.Add(this.lbVikend);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.lbLekar);
            this.panel1.Controls.Add(this.lbOCR);
            this.panel1.Controls.Add(this.lbNemoc);
            this.panel1.Controls.Add(this.lbDovolena);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbSumaHodin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(645, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(108, 426);
            this.panel1.TabIndex = 7;
            // 
            // lbSvatky
            // 
            this.lbSvatky.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSvatky.AutoSize = true;
            this.lbSvatky.Location = new System.Drawing.Point(12, 282);
            this.lbSvatky.Name = "lbSvatky";
            this.lbSvatky.Size = new System.Drawing.Size(55, 13);
            this.lbSvatky.TabIndex = 19;
            this.lbSvatky.Text = "                ";
            // 
            // lbVikend
            // 
            this.lbVikend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbVikend.AutoSize = true;
            this.lbVikend.Location = new System.Drawing.Point(12, 243);
            this.lbVikend.Name = "lbVikend";
            this.lbVikend.Size = new System.Drawing.Size(55, 13);
            this.lbVikend.TabIndex = 18;
            this.lbVikend.Text = "                ";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 269);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Svátky";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 230);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Víkendy";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(9, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Měsíční přehled";
            // 
            // lbLekar
            // 
            this.lbLekar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLekar.AutoSize = true;
            this.lbLekar.Location = new System.Drawing.Point(12, 200);
            this.lbLekar.Name = "lbLekar";
            this.lbLekar.Size = new System.Drawing.Size(55, 13);
            this.lbLekar.TabIndex = 14;
            this.lbLekar.Text = "                ";
            // 
            // lbOCR
            // 
            this.lbOCR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbOCR.AutoSize = true;
            this.lbOCR.Location = new System.Drawing.Point(12, 161);
            this.lbOCR.Name = "lbOCR";
            this.lbOCR.Size = new System.Drawing.Size(55, 13);
            this.lbOCR.TabIndex = 13;
            this.lbOCR.Text = "                ";
            // 
            // lbNemoc
            // 
            this.lbNemoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNemoc.AutoSize = true;
            this.lbNemoc.Location = new System.Drawing.Point(12, 125);
            this.lbNemoc.Name = "lbNemoc";
            this.lbNemoc.Size = new System.Drawing.Size(55, 13);
            this.lbNemoc.TabIndex = 12;
            this.lbNemoc.Text = "                ";
            // 
            // lbDovolena
            // 
            this.lbDovolena.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDovolena.AutoSize = true;
            this.lbDovolena.Location = new System.Drawing.Point(12, 87);
            this.lbDovolena.Name = "lbDovolena";
            this.lbDovolena.Size = new System.Drawing.Size(55, 13);
            this.lbDovolena.TabIndex = 11;
            this.lbDovolena.Text = "                ";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Lékař:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "OČR:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nemoc:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Dovolená:";
            // 
            // FormHlavni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 497);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormHlavni";
            this.Text = "Dochazka";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormHlavni_FormClosing);
            this.Load += new System.EventHandler(this.FormHlavni_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuSoubor;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tsCombRok;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox tsCombMesic;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lvZamestnanci;
        private System.Windows.Forms.ColumnHeader clmPrijmeni;
        private System.Windows.Forms.ColumnHeader clmJmeno;
        private System.Windows.Forms.ColumnHeader clmAktivni;
        private System.Windows.Forms.ColumnHeader clmRFID;
        private System.Windows.Forms.ColumnHeader clmDen;
        private System.Windows.Forms.ColumnHeader clmCas;
        private System.Windows.Forms.ToolStripMenuItem mnuKonec;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuNovy;
        private System.Windows.Forms.ToolStripMenuItem mnuOdstranit;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelZamestnanci;
        private System.Windows.Forms.ColumnHeader clmTypOdchodu;
        private System.Windows.Forms.ColumnHeader clmDoba;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuEditDochazky;
        private System.Windows.Forms.ToolStripMenuItem mnuNovyDochazka;
        private System.Windows.Forms.ToolStripMenuItem mnuOdstranitDochazka;
        private System.Windows.Forms.ToolStripMenuItem mnuSkupiny;
        private System.Windows.Forms.ColumnHeader clmGroup;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuNastaveni;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ListView lvDochazka;
        public System.Windows.Forms.Label lbSumaHodin;
        private System.Windows.Forms.ToolStripMenuItem mnuTisk;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label lbLekar;
        public System.Windows.Forms.Label lbOCR;
        public System.Windows.Forms.Label lbNemoc;
        public System.Windows.Forms.Label lbDovolena;
        public System.Windows.Forms.Label lbSvatky;
        public System.Windows.Forms.Label lbVikend;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripMenuItem mnuSvatky;
    }
}

