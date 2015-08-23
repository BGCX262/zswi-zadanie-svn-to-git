namespace Recepcia
{
    partial class PridajHosta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PridajHosta));
            this.meno_lbl = new System.Windows.Forms.Label();
            this.priezvisko_lbl = new System.Windows.Forms.Label();
            this.meno_tb = new System.Windows.Forms.TextBox();
            this.priezvisko_tb = new System.Windows.Forms.TextBox();
            this.pohlavie_lbl = new System.Windows.Forms.Label();
            this.muz_rb = new System.Windows.Forms.RadioButton();
            this.zena_rb = new System.Windows.Forms.RadioButton();
            this.adresa_lbl = new System.Windows.Forms.Label();
            this.adresa_tb = new System.Windows.Forms.TextBox();
            this.cisloOP_lbl = new System.Windows.Forms.Label();
            this.datumNarodenia_lbl = new System.Windows.Forms.Label();
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.cisloOP_tb = new System.Windows.Forms.TextBox();
            this.pridajHosta_btn = new System.Windows.Forms.Button();
            this.zrus_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // meno_lbl
            // 
            this.meno_lbl.AutoSize = true;
            this.meno_lbl.Location = new System.Drawing.Point(33, 29);
            this.meno_lbl.Name = "meno_lbl";
            this.meno_lbl.Size = new System.Drawing.Size(47, 17);
            this.meno_lbl.TabIndex = 0;
            this.meno_lbl.Text = "Meno:";
            // 
            // priezvisko_lbl
            // 
            this.priezvisko_lbl.AutoSize = true;
            this.priezvisko_lbl.Location = new System.Drawing.Point(33, 70);
            this.priezvisko_lbl.Name = "priezvisko_lbl";
            this.priezvisko_lbl.Size = new System.Drawing.Size(76, 17);
            this.priezvisko_lbl.TabIndex = 1;
            this.priezvisko_lbl.Text = "Priezvisko:";
            // 
            // meno_tb
            // 
            this.meno_tb.Location = new System.Drawing.Point(173, 26);
            this.meno_tb.Name = "meno_tb";
            this.meno_tb.Size = new System.Drawing.Size(192, 22);
            this.meno_tb.TabIndex = 2;
            // 
            // priezvisko_tb
            // 
            this.priezvisko_tb.Location = new System.Drawing.Point(173, 65);
            this.priezvisko_tb.Name = "priezvisko_tb";
            this.priezvisko_tb.Size = new System.Drawing.Size(192, 22);
            this.priezvisko_tb.TabIndex = 3;
            // 
            // pohlavie_lbl
            // 
            this.pohlavie_lbl.AutoSize = true;
            this.pohlavie_lbl.Location = new System.Drawing.Point(33, 111);
            this.pohlavie_lbl.Name = "pohlavie_lbl";
            this.pohlavie_lbl.Size = new System.Drawing.Size(66, 17);
            this.pohlavie_lbl.TabIndex = 4;
            this.pohlavie_lbl.Text = "Pohlavie:";
            // 
            // muz_rb
            // 
            this.muz_rb.AutoSize = true;
            this.muz_rb.Location = new System.Drawing.Point(182, 107);
            this.muz_rb.Name = "muz_rb";
            this.muz_rb.Size = new System.Drawing.Size(55, 21);
            this.muz_rb.TabIndex = 5;
            this.muz_rb.TabStop = true;
            this.muz_rb.Text = "Muž";
            this.muz_rb.UseVisualStyleBackColor = true;
            // 
            // zena_rb
            // 
            this.zena_rb.AutoSize = true;
            this.zena_rb.Location = new System.Drawing.Point(279, 107);
            this.zena_rb.Name = "zena_rb";
            this.zena_rb.Size = new System.Drawing.Size(62, 21);
            this.zena_rb.TabIndex = 6;
            this.zena_rb.TabStop = true;
            this.zena_rb.Text = "Žena";
            this.zena_rb.UseVisualStyleBackColor = true;
            // 
            // adresa_lbl
            // 
            this.adresa_lbl.AutoSize = true;
            this.adresa_lbl.Location = new System.Drawing.Point(33, 147);
            this.adresa_lbl.Name = "adresa_lbl";
            this.adresa_lbl.Size = new System.Drawing.Size(57, 17);
            this.adresa_lbl.TabIndex = 7;
            this.adresa_lbl.Text = "Adresa:";
            // 
            // adresa_tb
            // 
            this.adresa_tb.Location = new System.Drawing.Point(173, 147);
            this.adresa_tb.Name = "adresa_tb";
            this.adresa_tb.Size = new System.Drawing.Size(192, 22);
            this.adresa_tb.TabIndex = 8;
            // 
            // cisloOP_lbl
            // 
            this.cisloOP_lbl.AutoSize = true;
            this.cisloOP_lbl.Location = new System.Drawing.Point(33, 193);
            this.cisloOP_lbl.Name = "cisloOP_lbl";
            this.cisloOP_lbl.Size = new System.Drawing.Size(66, 17);
            this.cisloOP_lbl.TabIndex = 9;
            this.cisloOP_lbl.Text = "Číslo OP:";
            // 
            // datumNarodenia_lbl
            // 
            this.datumNarodenia_lbl.AutoSize = true;
            this.datumNarodenia_lbl.Location = new System.Drawing.Point(33, 234);
            this.datumNarodenia_lbl.Name = "datumNarodenia_lbl";
            this.datumNarodenia_lbl.Size = new System.Drawing.Size(121, 17);
            this.datumNarodenia_lbl.TabIndex = 10;
            this.datumNarodenia_lbl.Text = "Dátum narodenia:";
            // 
            // calendar
            // 
            this.calendar.Location = new System.Drawing.Point(173, 234);
            this.calendar.Name = "calendar";
            this.calendar.TabIndex = 11;
            // 
            // cisloOP_tb
            // 
            this.cisloOP_tb.Location = new System.Drawing.Point(173, 188);
            this.cisloOP_tb.Name = "cisloOP_tb";
            this.cisloOP_tb.Size = new System.Drawing.Size(192, 22);
            this.cisloOP_tb.TabIndex = 12;
            // 
            // pridajHosta_btn
            // 
            this.pridajHosta_btn.BackColor = System.Drawing.Color.Lime;
            this.pridajHosta_btn.Location = new System.Drawing.Point(36, 473);
            this.pridajHosta_btn.Name = "pridajHosta_btn";
            this.pridajHosta_btn.Size = new System.Drawing.Size(138, 36);
            this.pridajHosta_btn.TabIndex = 13;
            this.pridajHosta_btn.Text = "Pridaj hosťa";
            this.pridajHosta_btn.UseVisualStyleBackColor = false;
            this.pridajHosta_btn.Click += new System.EventHandler(this.pridajHosta_btn_Click);
            // 
            // zrus_btn
            // 
            this.zrus_btn.BackColor = System.Drawing.Color.Red;
            this.zrus_btn.Location = new System.Drawing.Point(227, 473);
            this.zrus_btn.Name = "zrus_btn";
            this.zrus_btn.Size = new System.Drawing.Size(138, 36);
            this.zrus_btn.TabIndex = 14;
            this.zrus_btn.Text = "Zruš";
            this.zrus_btn.UseVisualStyleBackColor = false;
            this.zrus_btn.Click += new System.EventHandler(this.zrus_btn_Click);
            // 
            // PridajHosta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 537);
            this.Controls.Add(this.zrus_btn);
            this.Controls.Add(this.pridajHosta_btn);
            this.Controls.Add(this.cisloOP_tb);
            this.Controls.Add(this.calendar);
            this.Controls.Add(this.datumNarodenia_lbl);
            this.Controls.Add(this.cisloOP_lbl);
            this.Controls.Add(this.adresa_tb);
            this.Controls.Add(this.adresa_lbl);
            this.Controls.Add(this.zena_rb);
            this.Controls.Add(this.muz_rb);
            this.Controls.Add(this.pohlavie_lbl);
            this.Controls.Add(this.priezvisko_tb);
            this.Controls.Add(this.meno_tb);
            this.Controls.Add(this.priezvisko_lbl);
            this.Controls.Add(this.meno_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PridajHosta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pridávanie hosťa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label meno_lbl;
        private System.Windows.Forms.Label priezvisko_lbl;
        private System.Windows.Forms.TextBox meno_tb;
        private System.Windows.Forms.TextBox priezvisko_tb;
        private System.Windows.Forms.Label pohlavie_lbl;
        private System.Windows.Forms.RadioButton muz_rb;
        private System.Windows.Forms.RadioButton zena_rb;
        private System.Windows.Forms.Label adresa_lbl;
        private System.Windows.Forms.TextBox adresa_tb;
        private System.Windows.Forms.Label cisloOP_lbl;
        private System.Windows.Forms.Label datumNarodenia_lbl;
        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.TextBox cisloOP_tb;
        private System.Windows.Forms.Button pridajHosta_btn;
        private System.Windows.Forms.Button zrus_btn;
    }
}