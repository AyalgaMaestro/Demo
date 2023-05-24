using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace pannda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select count(id_auth),auth_role from auth where login = '" + logbox.Text + "'and pass = '" + passbox.Text + "';";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();

                if (rd.HasRows)
                {
                    rd.Read();
                    int Count = Convert.ToInt32(rd.GetInt32(0));
                    if (Count > 0)
                    {
                        if (rd.GetString(1) == "1")
                        {
                            Sklad2   Win = new Sklad2();
                            Win.Owner = this;
                            Win.Show();
                            this.Hide();
                        }
                        else if (rd.GetString(1) == "2")
                        {
                            Oper Win = new Oper();
                            Win.Owner = this;
                            Win.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка авторизации!");
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
