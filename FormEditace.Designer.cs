namespace Dochazka
{
    partial class FormEditace
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbPrijmeni = new System.Windows.Forms.TextBox();
            this.tbJmeno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbHeslo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxAktivni = new System.Windows.Forms.CheckBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmbOpravneni = new System.Windows.Forms.ComboBox();
            this.cmdRFID = new System.Windows.Forms.Button();
            this.tbRFID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lvSkupiny = new System.Windows.Forms.ListView();
            this.clmPopis = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbRezim = new System.Windows.Forms.ComboBox();
            this.numUpDownDovolena = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownDovolena)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Příjmení";
            // 
            // tbPrijmeni
            // 
            this.tbPrijmeni.Location = new System.Drawing.Point(24, 36);
            this.tbPrijmeni.Name = "tbPrijmeni";
            this.tbPrijmeni.Size = new System.Drawing.Size(215, 20);
            this.tbPrijmeni.TabIndex = 1;
            this.tbPrijmeni.Tag = "Příjmení";
            this.tbPrijmeni.Validating += new System.ComponentModel.CancelEventHandler(this.KontrolaPolozek);
            // 
            // tbJmeno
            // 
            this.tbJmeno.Location = new System.Drawing.Point(24, 84);
            this.tbJmeno.Name = "tbJmeno";
            this.tbJmeno.Size = new System.Drawing.Size(215, 20);
            this.tbJmeno.TabIndex = 3;
            this.tbJmeno.Tag = "Jméno";
            this.tbJmeno.Validating += new System.ComponentModel.CancelEventHandler(this.KontrolaPolozek);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Jméno";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(24, 133);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(215, 20);
            this.tbLogin.TabIndex = 5;
            this.tbLogin.Tag = "Login";
            this.tbLogin.Validating += new System.ComponentModel.CancelEventHandler(this.KontrolaPolozek);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Login";
            // 
            // tbHeslo
            // 
            this.tbHeslo.Location = new System.Drawing.Point(24, 182);
            this.tbHeslo.Name = "tbHeslo";
            this.tbHeslo.Size = new System.Drawing.Size(215, 20);
            this.tbHeslo.TabIndex = 7;
            this.tbHeslo.Tag = "Heslo";
            this.tbHeslo.Validating += new System.ComponentModel.CancelEventHandler(this.KontrolaPolozek);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Heslo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Oprávnění";
            // 
            // cbxAktivni
            // 
            this.cbxAktivni.AutoSize = true;
            this.cbxAktivni.Checked = true;
            this.cbxAktivni.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxAktivni.Location = new System.Drawing.Point(61, 410);
            this.cbxAktivni.Name = "cbxAktivni";
            this.cbxAktivni.Size = new System.Drawing.Size(60, 17);
            this.cbxAktivni.TabIndex = 10;
            this.cbxAktivni.Text = "Aktivní";
            this.cbxAktivni.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.CausesValidation = false;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(139, 471);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(101, 25);
            this.cmdCancel.TabIndex = 12;
            this.cmdCancel.Text = "Storno";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(22, 470);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(99, 26);
            this.cmdOK.TabIndex = 11;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmbOpravneni
            // 
            this.cmbOpravneni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOpravneni.FormattingEnabled = true;
            this.cmbOpravneni.Location = new System.Drawing.Point(24, 277);
            this.cmbOpravneni.Name = "cmbOpravneni";
            this.cmbOpravneni.Size = new System.Drawing.Size(215, 21);
            this.cmbOpravneni.TabIndex = 17;
            // 
            // cmdRFID
            // 
            this.cmdRFID.CausesValidation = false;
            this.cmdRFID.Location = new System.Drawing.Point(139, 397);
            this.cmdRFID.Name = "cmdRFID";
            this.cmdRFID.Size = new System.Drawing.Size(100, 26);
            this.cmdRFID.TabIndex = 18;
            this.cmdRFID.Text = "Změna RFID katy";
            this.cmdRFID.UseVisualStyleBackColor = true;
            this.cmdRFID.Click += new System.EventHandler(this.cmdRFID_Click);
            // 
            // tbRFID
            // 
            this.tbRFID.Location = new System.Drawing.Point(23, 371);
            this.tbRFID.Name = "tbRFID";
            this.tbRFID.ReadOnly = true;
            this.tbRFID.Size = new System.Drawing.Size(215, 20);
            this.tbRFID.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 355);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "RFID Karta";
            // 
            // cmbGroup
            // 
            this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(24, 229);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(215, 21);
            this.cmbGroup.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Skupina";
            // 
            // lvSkupiny
            // 
            this.lvSkupiny.CheckBoxes = true;
            this.lvSkupiny.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmPopis});
            this.lvSkupiny.FullRowSelect = true;
            this.lvSkupiny.GridLines = true;
            this.lvSkupiny.HideSelection = false;
            this.lvSkupiny.Location = new System.Drawing.Point(259, 36);
            this.lvSkupiny.MultiSelect = false;
            this.lvSkupiny.Name = "lvSkupiny";
            this.lvSkupiny.ShowGroups = false;
            this.lvSkupiny.Size = new System.Drawing.Size(183, 429);
            this.lvSkupiny.TabIndex = 23;
            this.lvSkupiny.UseCompatibleStateImageBehavior = false;
            this.lvSkupiny.View = System.Windows.Forms.View.Details;
            // 
            // clmPopis
            // 
            this.clmPopis.Text = "Název";
            this.clmPopis.Width = 179;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(256, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Oprávnění skupin";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 309);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Pracovní režim";
            // 
            // cmbRezim
            // 
            this.cmbRezim.FormattingEnabled = true;
            this.cmbRezim.Location = new System.Drawing.Point(24, 326);
            this.cmbRezim.Name = "cmbRezim";
            this.cmbRezim.Size = new System.Drawing.Size(215, 21);
            this.cmbRezim.TabIndex = 26;
            // 
            // numUpDownDovolena
            // 
            this.numUpDownDovolena.Location = new System.Drawing.Point(139, 434);
            this.numUpDownDovolena.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numUpDownDovolena.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numUpDownDovolena.Name = "numUpDownDovolena";
            this.numUpDownDovolena.Size = new System.Drawing.Size(43, 20);
            this.numUpDownDovolena.TabIndex = 27;
            this.numUpDownDovolena.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 440);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Počet dní dovolené:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 410);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Status:";
            // 
            // FormEditace
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(464, 508);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.numUpDownDovolena);
            this.Controls.Add(this.cmbRezim);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lvSkupiny);
            this.Controls.Add(this.cmbGroup);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbRFID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmdRFID);
            this.Controls.Add(this.cmbOpravneni);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cbxAktivni);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbHeslo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbJmeno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPrijmeni);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditace";
            this.Text = "Editace";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditace_FormClosing);
            this.Load += new System.EventHandler(this.FormEditace_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownDovolena)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPrijmeni;
        private System.Windows.Forms.TextBox tbJmeno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbHeslo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbxAktivni;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.ComboBox cmbOpravneni;
        private System.Windows.Forms.Button cmdRFID;
        private System.Windows.Forms.TextBox tbRFID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView lvSkupiny;
        private System.Windows.Forms.ColumnHeader clmPopis;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbRezim;
        private System.Windows.Forms.NumericUpDown numUpDownDovolena;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}