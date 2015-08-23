using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Data;
using System.Text.RegularExpressions;

namespace Recepcia
{
    class Database
    {
        private static Database instance;
        static MySqlConnection conn;
        private int user;
        private Color farba;
        private bool dbReady = false;

        private Database()
        {
            string connectionStringIn = "SERVER=1.1.1.1;DATABASE=recepcia;UID=recepcia;PASSWORD=recepcia;";
            string connectionStringOut = "SERVER=88.212.46.144;DATABASE=recepcia;UID=recepcia;PASSWORD=recepcia;";
            Boolean outside = false;
            conn = new MySqlConnection(connectionStringOut);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                outside = true;
            }

            if (outside)
            {
                conn = new MySqlConnection(connectionStringIn);
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nedá sa pripojit k databázovému systému, skontroloujte pripojenie na internet.");
                    Application.Exit();
                }
            }
            dbReady = true;
        }

        public static Database getInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Database();
                }
                return instance;
            }
        }

        public bool databaseReady()
        {
            return dbReady;
        }

        public void closeConnection()
        {
            conn.Close();
        }

        string originalText = "";
        public void setButtonOff(Button btn, Form frm)
        {
            foreach (Control c in frm.Controls)
            {
                c.Enabled = false;
            }
            originalText = btn.Text;
            btn.Text = "Čakajte...";
            btn.Refresh();
            Cursor.Current = Cursors.WaitCursor;
        }

        public void setButtonOn(Button btn, Form frm)
        {
            foreach (Control c in frm.Controls)
            {
                c.Enabled = true;
            }
            btn.Text = originalText;
            originalText = "";
            btn.Refresh();
            Cursor.Current = Cursors.Default; ;
        }

        public int login(string meno, string heslo)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT pouzivatel_id FROM pouzivatel WHERE meno = @meno AND heslo = @heslo");
            cmd.Connection = conn;
            MySqlParameter prm1 = new MySqlParameter("meno", meno);
            cmd.Parameters.Add(prm1);
            MySqlParameter prm2 = new MySqlParameter("heslo", heslo);
            cmd.Parameters.Add(prm2);

            MySqlDataReader reader = cmd.ExecuteReader();
            int value = -1;
            while (reader.Read())
            {
                value = Int32.Parse(reader.GetValue(0).ToString());
            }
            reader.Close();

            if (value > -1)
            {
                user = value;
                cmd = new MySqlCommand("SELECT farba FROM pouzivatel WHERE pouzivatel_id = @pouzivatel_id");
                cmd.Connection = conn;
                prm1 = new MySqlParameter("pouzivatel_id", value);
                cmd.Parameters.Add(prm1);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    farba = Color.FromName(reader.GetValue(0).ToString());
                }
                reader.Close();
            }
            return value;
        }

        public Color getColor()
        {
            return farba;
        }

        public void setColor(String color)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE pouzivatel SET farba = @farba WHERE pouzivatel_id = @pouzivatel_id");
                
                cmd.Connection = conn;
                MySqlParameter prm1 = new MySqlParameter("pouzivatel_id", user);
                MySqlParameter prm2 = new MySqlParameter("farba", color);
                cmd.Parameters.Add(prm1);
                cmd.Parameters.Add(prm2);
                cmd.ExecuteNonQuery();

                ColorConverter conv = new ColorConverter();
                farba = (Color)conv.ConvertFromString(color);
            }
            catch (Exception ex)
            {
            }
        }

        public ArrayList getRooms()
        {
            ArrayList vysledok = new ArrayList();
            MySqlCommand cmd = new MySqlCommand("SELECT oznacenie FROM izba");
            cmd.Connection = conn;

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                vysledok.Add(reader.GetValue(0).ToString());
            }
            reader.Close();

            return vysledok;
        }

        public bool insertGuest(string meno, string priezvisko, string pohlavie, string adresa, DateTime datumNarodenia, string cisloOP)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO host (meno, priezvisko, pohlavie, adresa, datum_narodenia, cislo_OP_pasu) VALUES (@meno, @priezvisko, @pohlavie, @adresa, @datum_narodenia, @cislo_OP_pasu)");
                cmd.Connection = conn;
                MySqlParameter prm1 = new MySqlParameter("meno", meno);
                MySqlParameter prm2 = new MySqlParameter("priezvisko", priezvisko);
                MySqlParameter prm3 = new MySqlParameter("pohlavie", pohlavie);
                MySqlParameter prm4 = new MySqlParameter("adresa", adresa);
                MySqlParameter prm5 = new MySqlParameter("datum_narodenia", datumNarodenia);
                MySqlParameter prm6 = new MySqlParameter("cislo_OP_pasu", (object)cisloOP ?? DBNull.Value);
                cmd.Parameters.Add(prm1);
                cmd.Parameters.Add(prm2);
                cmd.Parameters.Add(prm3);
                cmd.Parameters.Add(prm4);
                cmd.Parameters.Add(prm5);
                cmd.Parameters.Add(prm6);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool updateGuest(string meno, string priezvisko, string pohlavie, string adresa, DateTime datumNarodenia, string cisloOP, int guestID)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE host set meno = @meno, priezvisko = @priezvisko, pohlavie = @pohlavie, adresa = @adresa, datum_narodenia = @datum_narodenia, cislo_OP_pasu = @cislo_OP_pasu WHERE host_id = @host_id");
                cmd.Connection = conn;
                MySqlParameter prm1 = new MySqlParameter("meno", meno);
                MySqlParameter prm2 = new MySqlParameter("priezvisko", priezvisko);
                MySqlParameter prm3 = new MySqlParameter("pohlavie", pohlavie);
                MySqlParameter prm4 = new MySqlParameter("adresa", adresa);
                MySqlParameter prm5 = new MySqlParameter("datum_narodenia", datumNarodenia);
                MySqlParameter prm6 = new MySqlParameter("cislo_OP_pasu", (object)cisloOP ?? DBNull.Value);
                MySqlParameter prm7 = new MySqlParameter("host_id", guestID);
                cmd.Parameters.Add(prm1);
                cmd.Parameters.Add(prm2);
                cmd.Parameters.Add(prm3);
                cmd.Parameters.Add(prm4);
                cmd.Parameters.Add(prm5);
                cmd.Parameters.Add(prm6);
                cmd.Parameters.Add(prm7);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public ArrayList getRoomsIDs()
        {
            ArrayList vysledok = new ArrayList();
            MySqlCommand cmd = new MySqlCommand("SELECT izba_id FROM izba");
            cmd.Connection = conn;

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                vysledok.Add(reader.GetValue(0).ToString());
            }
            reader.Close();
            return vysledok;
        }

        public ArrayList getCalendarLines(ArrayList days)
        {
            ArrayList vysl = new ArrayList();
            ArrayList izby = getRoomsIDs();

            foreach (Object den in days)
            {
                ArrayList riadok = new ArrayList();
                riadok.Add(den);
                foreach (Object izba in izby)
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT CONCAT(meno, ' ', priezvisko) FROM host WHERE host_id = (SELECT host_id FROM rezervacia WHERE ubytovanie_od <= @datum AND ubytovanie_do>= @datum AND izba_id = @izba)");
                    cmd.Connection = conn;
                    MySqlParameter prm1 = new MySqlParameter("datum", den);
                    cmd.Parameters.Add(prm1);
                    MySqlParameter prm2 = new MySqlParameter("izba", izba);
                    cmd.Parameters.Add(prm2);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    String host = "";
                    while (reader.Read())
                    {
                        if (reader.IsDBNull(0)) host = "";
                        else host = reader.GetValue(0).ToString();
                    }
                    riadok.Add(host);
                    reader.Close();
                }
                vysl.Add(riadok.ToArray());
            }
            return vysl;
        }

        public string getGuestFirstName(int guestID)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT meno FROM host WHERE host_id = @host_id");
            cmd.Connection = conn;
            MySqlParameter prm1 = new MySqlParameter("host_id", guestID);
            cmd.Parameters.Add(prm1);

            MySqlDataReader reader = cmd.ExecuteReader();
            string value = "";
            while (reader.Read())
            {
                value = reader.GetValue(0).ToString();
            }
            reader.Close();
            return value;
        }

        public string getGuestLastName(int guestID)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT priezvisko FROM host WHERE host_id = @host_id");
            cmd.Connection = conn;
            MySqlParameter prm1 = new MySqlParameter("host_id", guestID);
            cmd.Parameters.Add(prm1);

            MySqlDataReader reader = cmd.ExecuteReader();
            string value = "";
            while (reader.Read())
            {
                value = reader.GetValue(0).ToString();
            }
            reader.Close();
            return value;
        }

        public string getGuestGender(int guestID)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT pohlavie FROM host WHERE host_id = @host_id");
            cmd.Connection = conn;
            MySqlParameter prm1 = new MySqlParameter("host_id", guestID);
            cmd.Parameters.Add(prm1);

            MySqlDataReader reader = cmd.ExecuteReader();
            string value = "";
            while (reader.Read())
            {
                value = reader.GetValue(0).ToString();
            }
            reader.Close();
            return value;
        }

        public string getGuestOP(int guestID)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT cislo_OP_pasu FROM host WHERE host_id = @host_id");
            cmd.Connection = conn;
            MySqlParameter prm1 = new MySqlParameter("host_id", guestID);
            cmd.Parameters.Add(prm1);

            MySqlDataReader reader = cmd.ExecuteReader();
            string value = "";
            while (reader.Read())
            {
                value = reader.GetValue(0).ToString();
            }
            reader.Close();
            return value;
        }

        public string getGuestAddress(int guestID)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT adresa FROM host WHERE host_id = @host_id");
            cmd.Connection = conn;
            MySqlParameter prm1 = new MySqlParameter("host_id", guestID);
            cmd.Parameters.Add(prm1);

            MySqlDataReader reader = cmd.ExecuteReader();
            string value = "";
            while (reader.Read())
            {
                value = reader.GetValue(0).ToString();
            }
            reader.Close();
            return value;
        }

        public DateTime getGuestDOB(int guestID)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT datum_narodenia FROM host WHERE host_id = @host_id");
            cmd.Connection = conn;
            MySqlParameter prm1 = new MySqlParameter("host_id", guestID);
            cmd.Parameters.Add(prm1);

            MySqlDataReader reader = cmd.ExecuteReader();
            string value = "";
            while (reader.Read())
            {
                value = reader.GetValue(0).ToString();
            }
            reader.Close();
            return DateTime.Parse(value);
        }

        public int getGuestID(string priezvisko, string meno)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT host_id FROM host WHERE priezvisko = @priezvisko AND meno = @meno");
            cmd.Connection = conn;
            MySqlParameter prm1 = new MySqlParameter("meno", meno);
            MySqlParameter prm2 = new MySqlParameter("priezvisko", priezvisko);
            cmd.Parameters.Add(prm1);
            cmd.Parameters.Add(prm2);

            MySqlDataReader reader = cmd.ExecuteReader();
            string value = "";
            while (reader.Read())
            {
                value = reader.GetValue(0).ToString();
            }
            reader.Close();
            int vysledok = 0;
            Int32.TryParse(value, out vysledok);
            return vysledok;
        }

        public bool insertReservation(string priezvisko, string meno, string nazov_izby, DateTime datum_od, DateTime datum_do)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO rezervacia (host_id, pouzivatel_id, izba_id, ubytovanie_od, ubytovanie_do) VALUES ((SELECT host_id FROM host WHERE meno = @meno AND priezvisko = @priezvisko), @pouzivatel_id, (SELECT izba_id FROM izba WHERE oznacenie = @nazov_izby), @datum_od, @datum_do)");
                cmd.Connection = conn;
                MySqlParameter prm1 = new MySqlParameter("meno", meno);
                MySqlParameter prm2 = new MySqlParameter("priezvisko", priezvisko);
                MySqlParameter prm3 = new MySqlParameter("pouzivatel_id", user);
                MySqlParameter prm4 = new MySqlParameter("nazov_izby", nazov_izby);
                MySqlParameter prm5 = new MySqlParameter("datum_od", datum_od);
                MySqlParameter prm6 = new MySqlParameter("datum_do", datum_do);
                cmd.Parameters.Add(prm1);
                cmd.Parameters.Add(prm2);
                cmd.Parameters.Add(prm3);
                cmd.Parameters.Add(prm4);
                cmd.Parameters.Add(prm5);
                cmd.Parameters.Add(prm6);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool deleteReservation(string nazov_izby, DateTime datum)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("DELETE FROM rezervacia WHERE (SELECT izba_id FROM izba WHERE oznacenie = @nazov_izby) = izba_id AND ubytovanie_od <= @datum AND ubytovanie_do >= @datum");
                cmd.Connection = conn;
                MySqlParameter prm1 = new MySqlParameter("nazov_izby", nazov_izby);
                MySqlParameter prm2 = new MySqlParameter("datum", datum);
                cmd.Parameters.Add(prm1);
                cmd.Parameters.Add(prm2);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public ArrayList getGuestlist(string searchString)
        {
            ArrayList vysledok = new ArrayList();
            MySqlCommand cmd = new MySqlCommand("SELECT CONCAT(priezvisko, ', ', meno) FROM host WHERE meno LIKE '%" + searchString + "%' OR priezvisko LIKE '%" + searchString + "%'");
            cmd.Connection = conn;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                vysledok.Add(reader.GetValue(0).ToString());
            }
            reader.Close();
            return vysledok;
        }

        public bool validString (ArrayList zoznam)
        {
            foreach (Object o in zoznam)
            {
                if (!Regex.IsMatch((String)o, @"^[a-zA-Z0-9 ]+$")) return false;
            }
            return true;
        }
    }
}
