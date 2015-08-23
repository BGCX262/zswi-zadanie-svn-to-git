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
    public partial class Kalendar : Form
    {
        public Kalendar()
        {
            InitializeComponent();
            napln_kalendar();
            napln_guestlist();
            nastavFarbu();
        }

        public void napln_kalendar()
        {
            DataTable vysl = new DataTable();
            vysl.Columns.Add("Dátum");
            foreach (Object o in Database.getInstance.getRooms())
            {
                vysl.Columns.Add(o.ToString());
            }

            ArrayList days = new ArrayList();
            DateTime tmp = DateTime.Now;
            for (int i = 0; i < 60; i++)
            {
                days.Add(tmp.Year.ToString() + "-" + tmp.Month.ToString() + "-" + (tmp.Day.ToString().Length < 2 ? "0" + tmp.Day.ToString() : tmp.Day.ToString()));
                tmp = tmp.AddDays(1);
            }

            foreach (Object o in Database.getInstance.getCalendarLines(days))
            {
                vysl.Rows.Add((Object[])o);
            }

            kalendar_grid.DataSource = vysl;
        }

        private void napln_guestlist()
        {
            lb_guestList.DataSource = Database.getInstance.getGuestlist(filter_tb.Text);
        }

        private void btn_novaRezervacia_Click(object sender, EventArgs e)
        {
            Database.getInstance.setButtonOff(btn_novaRezervacia, this);

            for (int i = 0; kalendar_grid.SelectedCells.Count > i; i++)
            {
                if (kalendar_grid.SelectedCells[i].Value.ToString() != "")
                {
                    MessageBox.Show("Musíte zvoliť len prázdne izby!");
                    Database.getInstance.setButtonOn(btn_novaRezervacia, this);
                    return;
                }
            }

            if (lb_guestList.SelectedItem == null)
            {
                MessageBox.Show("Musíte zvoliť hosťa zo zoznamu!");
                Database.getInstance.setButtonOn(btn_novaRezervacia, this);
                return;
            }

            ArrayList spracovaneStlpce = new ArrayList();
            string spracovavanyStlpec = "1";
            while (!spracovavanyStlpec.Equals(""))
            {
                spracovavanyStlpec = "";
                DateTime min = DateTime.Now.AddDays(62);
                DateTime max = DateTime.Now.AddDays(-1);
                for (int i = 0; kalendar_grid.SelectedCells.Count > i; i++)
                {
                    string stlpec = kalendar_grid.Columns[kalendar_grid.SelectedCells[i].ColumnIndex].Name;
                    DateTime riadok = DateTime.Parse(kalendar_grid.Rows[kalendar_grid.SelectedCells[i].RowIndex].Cells[0].Value.ToString());
                    if ((!spracovaneStlpce.Contains(stlpec)) && spracovavanyStlpec.Equals(""))
                    {
                        spracovaneStlpce.Add(stlpec);
                        spracovavanyStlpec = stlpec;
                    }
                    if (stlpec.Equals(spracovavanyStlpec))
                    {
                        if (DateTime.Compare(riadok, min) <= 0) min = riadok;
                        if (DateTime.Compare(max, riadok) <= 0) max = riadok;
                    }
                }

                string priezvisko = lb_guestList.SelectedItem.ToString().Split(',')[0].Trim();
                string meno = lb_guestList.SelectedItem.ToString().Split(',')[1].Trim();

                if (!spracovavanyStlpec.Equals("") && !Database.getInstance.insertReservation(priezvisko, meno, spracovavanyStlpec, min, max))
                    MessageBox.Show("Rezerváciu pre izbu " + spracovavanyStlpec + " nebolo možné spracovať.");
            }
            napln_kalendar();

            Database.getInstance.setButtonOn(btn_novaRezervacia, this);
        }

        private void btn_pridajHosta_Click(object sender, EventArgs e)
        {
            Database.getInstance.setButtonOff(btn_pridajHosta, this);

            PridajHosta dialog = new PridajHosta();
            dialog.ShowDialog();
            if (dialog.DialogResult == DialogResult.OK)
            {
                napln_guestlist();
            }

            Database.getInstance.setButtonOn(btn_pridajHosta, this);
        }

        private void btn_zmazRezervaciu_Click(object sender, EventArgs e)
        {
            Database.getInstance.setButtonOff(btn_zmazRezervaciu, this);

            if (kalendar_grid.SelectedCells.Count != 1)
            {
                MessageBox.Show("Musíte označiť práve jednu bunku.");
                Database.getInstance.setButtonOn(btn_zmazRezervaciu, this);
                return;
            }
            string stlpec = kalendar_grid.Columns[kalendar_grid.SelectedCells[0].ColumnIndex].Name;
            if (stlpec.Equals("Dátum"))
            {
                MessageBox.Show("Musíte označiť bunku v stĺpeci s izbami.");
                Database.getInstance.setButtonOn(btn_zmazRezervaciu, this);
                return;
            }
            DateTime riadok = DateTime.Parse(kalendar_grid.Rows[kalendar_grid.SelectedCells[0].RowIndex].Cells[0].Value.ToString());

            if (!Database.getInstance.deleteReservation(stlpec, riadok))
                MessageBox.Show("Rezerváciu pre izbu " + stlpec + " nebolo možné zmazať.");
            napln_kalendar();

            Database.getInstance.setButtonOn(btn_zmazRezervaciu, this);
        }

        private void filter_tb_TextChanged(object sender, EventArgs e)
        {
            if (filter_tb.Text.Length > 0)
            {
                ArrayList zoznamStringov = new ArrayList();
                zoznamStringov.Add(filter_tb.Text);
                if (!Database.getInstance.validString(zoznamStringov))
                {
                    MessageBox.Show("Vyhľadávať je možné len alfanumerické znaky.");
                    filter_tb.Text = "";
                }
            }
            napln_guestlist();
        }

        private void btn_upravHosta_Click(object sender, EventArgs e)
        {
            Database.getInstance.setButtonOff(btn_upravHosta, this);

            if (lb_guestList.SelectedItem == null)
            {
                MessageBox.Show("Musíte zvoliť hosťa zo zoznamu!");
                return;
            }

            string priezvisko = lb_guestList.SelectedItem.ToString().Split(',')[0].Trim();
            string meno = lb_guestList.SelectedItem.ToString().Split(',')[1].Trim();

            PridajHosta dialog = new PridajHosta();
            dialog.setEditMode(Database.getInstance.getGuestID(priezvisko, meno));
            dialog.ShowDialog();
            if (dialog.DialogResult == DialogResult.OK)
            {
                napln_guestlist();
                napln_kalendar();
            }

            Database.getInstance.setButtonOn(btn_upravHosta, this);
        }

        private void btn_odhlasit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public void setLoggedUsername(string meno)
        {
            lbl_prihlasenyPouzivatel.Text += meno;
        }

        private void nastavFarbu()
        {
            kalendar_grid.BackgroundColor = Database.getInstance.getColor();
            this.BackColor = Database.getInstance.getColor();
        }

        private void cb_farby_SelectedValueChanged(object sender, EventArgs e)
        {
            Database.getInstance.setColor(cb_farby.SelectedItem.ToString().Trim());
            nastavFarbu();
        }
    }
}
