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
    public partial class Sklad : Form
    {
        public Sklad()
        {
            InitializeComponent();
            getInfo("select product.id_product as 'Артикул', ttype.name_type as 'Тип', producer.name_producer as 'Производитель', product.name_product as 'Название', product.price as 'Цена', product.guarantee as 'Гарантия', product.stock as 'Кол-во' from product join ttype on product.id_type = ttype.id_type join producer on product.id_producer = producer.id_producer;");

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
                MySqlCommand cmd = new MySqlCommand("insert into product(id_type, id_producer, name_product, price, guarantee, stock) value('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "');", conn);
                conn.Open();
                cmd.ExecuteReader();
                conn.Close();
                getInfo("select product.id_product as 'Артикул', ttype.name_type as 'Тип', producer.name_producer as 'Производитель', product.name_product as 'Название', product.price as 'Цена', product.guarantee as 'Гарантия', product.stock as 'Кол-во' from product join ttype on product.id_type = ttype.id_type join producer on product.id_producer = producer.id_producer;");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sklad2 Win = new Sklad2();
            Win.Owner = this;
            Win.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены что хотите обновить товар?", "Подтвердите свои действия", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {

                try
                {
                    MySqlConnection conn = new MySqlConnection("Server=localhost; DataBase=pan_da; User=root; Password=root;");
                    MySqlCommand cmd = new MySqlCommand("update product set id_type = '" + textBox1.Text + "', id_producer = '" + textBox2.Text + "', name_product = '" + textBox3.Text + "', price = '" + textBox4.Text + "', guarantee = '" + textBox5.Text + "', stock = '" + textBox6.Text + "' where id_product = " + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + ";", conn);
                    conn.Open();
                    cmd.ExecuteReader();
                    conn.Close();
                    getInfo("select product.id_product as 'Артикул', ttype.name_type as 'Тип', producer.name_producer as 'Производитель', product.name_product as 'Название', product.price as 'Цена', product.guarantee as 'Гарантия', product.stock as 'Кол-во' from product join ttype on product.id_type = ttype.id_type join producer on product.id_producer = producer.id_producer;");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
                    MySqlCommand cmd = new MySqlCommand("delete from product where id_product =" + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + ";", conn);
                    conn.Open();
                    cmd.ExecuteReader();
                    conn.Close();
                    getInfo("select product.id_product as 'Артикул', ttype.name_type as 'Тип', producer.name_producer as 'Производитель', product.name_product as 'Название', product.price as 'Цена', product.guarantee as 'Гарантия', product.stock as 'Кол-во' from product join ttype on product.id_type = ttype.id_type join producer on product.id_producer = producer.id_producer;");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox2.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox3.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox4.Text = dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox5.Text = dataGridView1[5, dataGridView1.CurrentRow.Index].Value.ToString();
                textBox6.Text = dataGridView1[6, dataGridView1.CurrentRow.Index].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
