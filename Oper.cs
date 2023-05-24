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
    public partial class Oper : Form
    {
        public Oper()
        {
            InitializeComponent();
            getInfo("select id_clients as 'Номер', name_client as 'Имя', dob as 'Датарождения', tel as 'Телефон', id_passport as 'Нпаспорта' from clients;");
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
                MySqlCommand cmd = new MySqlCommand("insert into clients(name_client,dob,tel,id_passport) value('" + textBox1.Text + "', '"+ textBox2.Text +"', '"+ textBox3.Text +"', '"+ textBox4.Text +"');", conn);
                conn.Open();
                cmd.ExecuteReader();
                conn.Close();
                getInfo("select id_clients as 'Номер', name_client as 'Имя', dob as 'Датарождения', tel as 'Телефон', id_passport as 'Нпаспорта' from clients;");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены что хотите удалить товар?", "Подтвердите свои действия", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection("Server=localhost; DataBase=pan_da; User=root; Password=root;");
                    MySqlCommand cmd = new MySqlCommand("delete from clients where id_clients =" + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + ";", conn);
                    conn.Open();
                    cmd.ExecuteReader();
                    conn.Close();
                    getInfo("select id_clients as 'Номер', name_client as 'Имя', dob as 'Датарождения', tel as 'Телефон', id_passport as 'Нпаспорта' from clients;");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
