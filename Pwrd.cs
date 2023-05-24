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

namespace PPPanda
{
    public partial class Pwrd : Form
    {
        public Pwrd()
        {
            InitializeComponent();
            this.FormClosing += Pwrd_FormClosing;
        }

        private void Pwrd_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string query = "update auth set pass = '" + textBox2.Text + "' where login = '" + textBox1.Text + "';";
            try
            {
                MySqlConnection conn = new MySqlConnection("Server = localhost; database = ppanda; user = root; password = root;");
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteReader();
                conn.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
