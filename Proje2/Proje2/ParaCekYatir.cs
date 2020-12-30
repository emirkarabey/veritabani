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
    public partial class ParaCekYatir : Form
    {
        public ParaCekYatir()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=MobilBanka2; user ID=postgres; password=heroesboq12");

        private void ParaCekYatir_Load(object sender, EventArgs e)
        {
            string sorgu = "select * from musteri_bakiye order by musteri_id";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            //
            string sorgu2 = "select * from paracek order by cekilenid";
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sorgu2, baglanti);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];

            string sorgu3 = "select * from parayatir order by yatirilanid";
            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter(sorgu3, baglanti);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            dataGridView3.DataSource = ds3.Tables[0];

            

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para Başarıyla Çekildi...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            baglanti.Open();
            NpgsqlCommand komut6 = new NpgsqlCommand("update musteri_bakiye set bakiye=bakiye-@p2 where musteri_id=@p1", baglanti);
           
            komut6.Parameters.AddWithValue("@p1", int.Parse(textBox6.Text));
            komut6.Parameters.AddWithValue("@p2", decimal.Parse(textBox4.Text));
           
            komut6.ExecuteNonQuery();

            baglanti.Close();
            string sorgu = "select * from musteri_bakiye order by musteri_id";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            // Müşteri bakiye ile müşteri tablosunu bağla
            baglanti.Open();
            NpgsqlCommand komut8 = new NpgsqlCommand("update musteri set bakiye=bakiye-@p2 where kayitid=@p1", baglanti);

            komut8.Parameters.AddWithValue("@p1", int.Parse(textBox6.Text));
            komut8.Parameters.AddWithValue("@p2", decimal.Parse(textBox4.Text));

            komut8.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into paracek (cekilenid,tutar) values (@p1,@p2)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox6.Text));
            komut.Parameters.AddWithValue("@p2", decimal.Parse(textBox4.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();

            string sorgu2 = "select * from paracek order by cekilenid";
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sorgu2, baglanti);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para Başarıyla Yatırıldı...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            baglanti.Open();
            NpgsqlCommand komut7 = new NpgsqlCommand("update musteri_bakiye set bakiye=bakiye+@p2 where musteri_id=@p1", baglanti);

            komut7.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut7.Parameters.AddWithValue("@p2", decimal.Parse(textBox3.Text));

            komut7.ExecuteNonQuery();

            baglanti.Close();
            string sorgu = "select * from musteri_bakiye order by musteri_id";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];


            baglanti.Open();
            NpgsqlCommand komut9 = new NpgsqlCommand("update musteri set bakiye=bakiye+@p2 where kayitid=@p1", baglanti);

            komut9.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut9.Parameters.AddWithValue("@p2", decimal.Parse(textBox3.Text));

            komut9.ExecuteNonQuery();

            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into parayatir (yatirilanid,tutar) values (@p1,@p2)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut.Parameters.AddWithValue("@p2", decimal.Parse(textBox3.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();

            string sorgu2 = "select * from parayatir order by yatirilanid";
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sorgu2, baglanti);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGridView3.DataSource = ds2.Tables[0];

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
