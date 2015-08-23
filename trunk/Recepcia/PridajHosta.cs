using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Recepcia
{
    public partial class PridajHosta : Form
    {
        private bool insertMode = true;
        private int guestID = -1;

        public PridajHosta()
        {
            InitializeComponent();
            this.BackColor = Database.getInstance.getColor();
        }

        public void setEditMode(int guestID)
        {
            insertMode = false;
            pridajHosta_btn.Text = "Uprav hosťa";
            this.Text = "Upravovanie hosťa";
            this.guestID = guestID;

            meno_tb.Text = Database.getInstance.getGuestFirstName(guestID);
            priezvisko_tb.Text = Database.getInstance.getGuestLastName(guestID);
            if (Database.getInstance.getGuestGender(guestID) == "m") muz_rb.Checked = true;
            else zena_rb.Checked = true;
            adresa_tb.Text = Database.getInstance.getGuestAddress(guestID);
            calendar.SelectionStart = Database.getInstance.getGuestDOB(guestID); ;
            calendar.SelectionEnd = calendar.SelectionStart;
            cisloOP_tb.Text = Database.getInstance.getGuestOP(guestID);
        }

        private void zrus_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pridajHosta_btn_Click(object sender, EventArgs e)
        {
            if (meno_tb.Text == "" || priezvisko_tb.Text == "" || (!muz_rb.Checked && !zena_rb.Checked))
            {
                MessageBox.Show("Musíte vyplniť všetky položky okrem čísla OP!");
                return;
            }

            ArrayList zoznamStringov = new ArrayList();
            zoznamStringov.Add(meno_tb.Text);
            zoznamStringov.Add(priezvisko_tb.Text);
            zoznamStringov.Add(adresa_tb.Text);
            if (cisloOP_tb.Text.Length>0) zoznamStringov.Add(cisloOP_tb.Text);
            if (!Database.getInstance.validString(zoznamStringov))
            {
                MessageBox.Show("Vsetky polia musia obsahovať len alfanumerické ASCII znaky.");
                return;
            }

            if (insertMode)
            {
                if (Database.getInstance.insertGuest(meno_tb.Text, priezvisko_tb.Text, muz_rb.Checked ? "m" : "z", adresa_tb.Text, calendar.SelectionStart, cisloOP_tb.Text == "" ? null : cisloOP_tb.Text))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hosť nebol pridaný.");
                }
            }
            else
            {
                if (Database.getInstance.updateGuest(meno_tb.Text, priezvisko_tb.Text, muz_rb.Checked ? "m" : "z", adresa_tb.Text, calendar.SelectionStart, cisloOP_tb.Text == "" ? null : cisloOP_tb.Text, guestID))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hosť nebol upravený.");
                }
            }
        }
    }
}
