using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

namespace Recepcia
{
    public partial class Login : Form
    {
        private bool dbReady = false;

        public Login()
        {
            InitializeComponent();
            Thread t = new Thread(()=>
            {
                while (!Database.getInstance.databaseReady())
                    Thread.Sleep(100);
                dbReady = true;
            });
            t.Start();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            ArrayList zoznamStringov = new ArrayList();
            zoznamStringov.Add(tb_login.Text);
            zoznamStringov.Add(tb_password.Text);
            if (!Database.getInstance.validString(zoznamStringov))
            {
                MessageBox.Show("Vsetky polia musia obsahovať len alfanumerické ASCII znaky.");
                return;
            }
            if (tb_login.Text.Length < 1 || tb_password.Text.Length < 1)
            {
                MessageBox.Show("Nezadali ste meno alebo heslo.");
                return;
            }
            skusLogin();
        }

        private void tb_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && btn_login.Enabled == true)
            {
                skusLogin();
            }
        }

        private void skusLogin()
        {
            Database.getInstance.setButtonOff(btn_login, this);

            if (Database.getInstance.login(tb_login.Text, tb_password.Text) > -1)
            {
                Kalendar dialog = new Kalendar();
                this.Hide();
                dialog.setLoggedUsername(tb_login.Text);
                dialog.ShowDialog();
                if (dialog.DialogResult == DialogResult.OK)
                {
                    tb_login.Text = "";
                    tb_password.Text = "";
                    btn_login.Text = "Prihlás";
                    this.Show();
                }
                else
                {
                    this.Close();
                    Database.getInstance.closeConnection();
                }
            }
            else
            {
                MessageBox.Show("Zlé meno alebo heslo.");
            }

            Database.getInstance.setButtonOn(btn_login, this);
        }

        private void tb_login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && btn_login.Enabled == true)
            {
                skusLogin();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (dbReady)
            {
                timer.Enabled = false;
                btn_login.Enabled = true;
                btn_login.Text = "Prihlás";
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Database.getInstance.closeConnection();
        }
    }
}
