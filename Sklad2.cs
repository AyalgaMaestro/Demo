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
    public partial class Sklad2 : Form
    {
        public string Cond = "";
        public Sklad2()
        {
            InitializeComponent();
            try
            {
                MySqlConnection conn = new MySqlConnection("Server = localhost;Database = pan_da; User = root; Password = root;");
                getInfo("select product.id_product as 'Артикул', ttype.name_type as 'Тип', producer.name_producer as 'Производитель', product.name_product as 'Название', product.price as 'Цена', product.guarantee as 'Гарантия', product.stock as 'Кол-во' from product join ttype on product.id_type = ttype.id_type join producer on product.id_producer = producer.id_producer;", t1);
                getInfo("select charact.name_charact as 'Характеристика', addit_info.vvalue as 'Описание' from addit_info join charact on addit_info.id_charact = charact.id_charact;", t2);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void getInfo(string query, DataGridView table)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("Server = localhost;Database = pan_da; User = root; Password = root;");
                MySqlDataAdapter ada = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                conn.Open();
                ada.Fill(dt);
                table.DataSource = dt;
                table.ClearSelection();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void t1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            getInfo("select charact.name_charact as 'Характеристика', addit_info.vvalue as 'Опиание' from addit_info join charact on addit_info.id_charact = charact.id_charact where id_product = " + t1[0, t1.CurrentRow.Index].Value.ToString() + ";", t2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Charact Win = new Charact();
            Win.Owner = this;
            Win.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sklad Win = new Sklad();
            Win.Owner = this;
            Win.Show();
            this.Hide();
        }

        private void combo_search_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_search.SelectedIndex == -1) txt_search.Enabled = false;
            else txt_search.Enabled = true;
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (txt_search.Text == "")
            {
                Cond = "";
                getInfo($"select product.id_product as 'Номер', ttype.name_type as 'Тип', producer.name_producer as 'Производитель', product.name_product as 'Название', product.price as 'Цена', product.guarantee as 'Гарантия', product.stock as 'Кол-во' from product join ttype on product.id_type = ttype.id_type join producer on product.id_producer = producer.id_producer{Cond};", t1);
            }
            else
            {
                switch (combo_search.SelectedIndex)
                {
                    case 0:
                        Cond = $" where product.id_product = {txt_search.Text}";
                        getInfo($"select product.id_product as 'Номер', ttype.name_type as 'Тип', producer.name_producer as 'Производитель', product.name_product as 'Название', product.price as 'Цена', product.guarantee as 'Гарантия', product.stock as 'Кол-во' from product join ttype on product.id_type = ttype.id_type join producer on product.id_producer = producer.id_producer{Cond};", t1);
                        break;
                    case 1:
                        Cond = $" where producer.name_producer like '%{txt_search.Text}%'";
                        getInfo($"select product.id_product as 'Номер', ttype.name_type as 'Тип', producer.name_producer as 'Производитель', product.name_product as 'Название', product.price as 'Цена', product.guarantee as 'Гарантия', product.stock as 'Кол-во' from product join ttype on product.id_type = ttype.id_type join producer on product.id_producer = producer.id_producer{Cond};", t1);
                        break;
                    case 2:
                        Cond = $" where product.name_product like '%{txt_search.Text}%'";
                        getInfo($"select product.id_product as 'Номер', ttype.name_type as 'Тип', producer.name_producer as 'Производитель', product.name_product as 'Название', product.price as 'Цена', product.guarantee as 'Гарантия', product.stock as 'Кол-во' from product join ttype on product.id_type = ttype.id_type join producer on product.id_producer = producer.id_producer{Cond};", t1);
                        break;
                    default:
                        break;
                }
            }
        }

        private void fill_maingrid(DataGridView dgv)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            string query = $"select p.id_product, t.name_type, producer.name_producer, p.name_product, p.price, p.stock, p.guarantee from product p join ttype t on p.id_type = t.id_type join producer on p.id_producer = producer.id_producer{Cond};";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            try
            {
                MySqlDataReader rdr = cmd.ExecuteReader();

                dgv.Rows.Clear();

                while (rdr.Read())
                {
                    dgv.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6]);
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
            }
        }
    }
}
