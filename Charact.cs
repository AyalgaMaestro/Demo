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
    public partial class Charact : Form
    {
        public Charact()
        {
            InitializeComponent();
            getInfo("select id_type as 'Номер', name_type as 'Название' from ttype;");
        }


        public void getInfo(string query)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("Server=localhost; DataBase=pan_da; User=root; Password=root;");
                MySqlDataAdapter ada = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                conn.Open();
                ada.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("Server=localhost; DataBase=pan_da; User=root; Password=root;");
                MySqlCommand cmd = new MySqlCommand("insert into ttype(name_type) value('" + textBox1.Text + "');", conn);
                conn.Open();
                cmd.ExecuteReader();
                conn.Close();
                getInfo("select id_type as 'Номер', name_type as 'Название' from ttype;");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sklad2 Win = new Sklad2();
            Win.Owner = this;
            Win.Show();
            this.Hide();
        }
    }
}
