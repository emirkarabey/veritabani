using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Proje2
{
    public partial class Ödemeler : Form
    {
        public Ödemeler()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Başarıyla Ödendi...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);



            baglanti.Open();
            NpgsqlCommand komut20 = new NpgsqlCommand("insert into odemeler (odemeno,odeyenid,odemeturu,tutar) values (@p1,@p2,@p3,@p4)", baglanti);
            komut20.Parameters.AddWithValue("@p1", int.Parse(textBox3.Text));
            komut20.Parameters.AddWithValue("@p2", int.Parse(textBox2.Text));
            komut20.Parameters.AddWithValue("@p3", comboBox1.Text);
            komut20.Parameters.AddWithValue("@p4", decimal.Parse(textBox1.Text));

            komut20.ExecuteNonQuery();

            baglanti.Close();

            string sorgu = "select * from odemelistele()";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            baglanti.Open();
            NpgsqlCommand komut21 = new NpgsqlCommand("update musteri_bakiye set bakiye=bakiye-@p2 where musteri_id=@p1", baglanti);
            komut21.Parameters.AddWithValue("@p1", int.Parse(textBox2.Text));
            komut21.Parameters.AddWithValue("@p2", decimal.Parse(textBox1.Text));
            komut21.ExecuteNonQuery();

            baglanti.Close();
            baglanti.Open();

            NpgsqlCommand komut22 = new NpgsqlCommand("update musteri set bakiye=bakiye-@p2 where kayitid=@p1", baglanti);
            komut22.Parameters.AddWithValue("@p1", int.Parse(textBox2.Text));
            komut22.Parameters.AddWithValue("@p2", decimal.Parse(textBox1.Text));
            komut22.ExecuteNonQuery();

            baglanti.Close();





        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=MobilBanka2; user ID=postgres; password=heroesboq12");

        private void Ödemeler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut23 = new NpgsqlCommand("select odemeturu from odemeturu", baglanti);
            NpgsqlDataReader dr = komut23.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());

            }
            baglanti.Close();
            string sorgu = "select * from odemeler order by odemeno";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
