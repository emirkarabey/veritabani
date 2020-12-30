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
    
    public partial class HavaleEft : Form
    {
        
        public HavaleEft()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Başarıyla Havale Edildi...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            baglanti.Open();
            NpgsqlCommand komut15 = new NpgsqlCommand("insert into havale (havaleid,gonderenid,alanid,tutar) values (@p1,@p2,@p3,@p4)", baglanti);
            komut15.Parameters.AddWithValue("@p1", int.Parse(textBox5.Text));
            komut15.Parameters.AddWithValue("@p2", int.Parse(textBox7.Text));
            komut15.Parameters.AddWithValue("@p3", int.Parse(textBox12.Text));
            komut15.Parameters.AddWithValue("@p4", decimal.Parse(textBox1.Text));
            komut15.ExecuteNonQuery();

            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand komut16 = new NpgsqlCommand("update musteri_bakiye set bakiye=bakiye-@p2 where musteri_id=@p1", baglanti);
            komut16.Parameters.AddWithValue("@p1", int.Parse(textBox7.Text));
            komut16.Parameters.AddWithValue("@p2", decimal.Parse(textBox1.Text));
            komut16.ExecuteNonQuery();

            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand komut17 = new NpgsqlCommand("update musteri set bakiye=bakiye-@p2 where kayitid=@p1", baglanti);
            komut17.Parameters.AddWithValue("@p1", int.Parse(textBox7.Text));
            komut17.Parameters.AddWithValue("@p2", decimal.Parse(textBox1.Text));
            komut17.ExecuteNonQuery();

            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand komut18 = new NpgsqlCommand("update musteri_bakiye set bakiye=bakiye+@p2 where musteri_id=@p1", baglanti);
            komut18.Parameters.AddWithValue("@p1", int.Parse(textBox12.Text));
            komut18.Parameters.AddWithValue("@p2", decimal.Parse(textBox1.Text));
            komut18.ExecuteNonQuery();

            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand komut19 = new NpgsqlCommand("update musteri set bakiye=bakiye+@p2 where kayitid=@p1", baglanti);
            komut19.Parameters.AddWithValue("@p1", int.Parse(textBox12.Text));
            komut19.Parameters.AddWithValue("@p2", decimal.Parse(textBox1.Text));
            komut19.ExecuteNonQuery();

            baglanti.Close();





            string sorgu = "select * from havalelistele()";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];

            string sorgu2 = "select * from musteri order by kayitid";
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sorgu2, baglanti);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGridView1.DataSource = ds2.Tables[0];
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=MobilBanka2; user ID=postgres; password=heroesboq12");

        private void HavaleEft_Load(object sender, EventArgs e)
        {
            string sorgu = "select * from musteri order by kayitid";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            string sorgu2 = "select * from havalelistele()";
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sorgu2, baglanti);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];

            string sorgu3 = "select * from eftlistele()";
            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter(sorgu3, baglanti);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            dataGridView3.DataSource = ds3.Tables[0];


        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Başarıyla EFT Yapıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            baglanti.Open();
            NpgsqlCommand komut15 = new NpgsqlCommand("insert into eft (eftid,gonderenid,alanid,tutar) values (@p1,@p2,@p3,@p4)", baglanti);
            komut15.Parameters.AddWithValue("@p1", int.Parse(textBox6.Text));
            komut15.Parameters.AddWithValue("@p2", int.Parse(textBox4.Text));
            komut15.Parameters.AddWithValue("@p3", int.Parse(textBox3.Text));
            komut15.Parameters.AddWithValue("@p4", decimal.Parse(textBox2.Text));
            komut15.ExecuteNonQuery();

            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand komut16 = new NpgsqlCommand("update musteri_bakiye set bakiye=bakiye-@p2 where musteri_id=@p1", baglanti);
            komut16.Parameters.AddWithValue("@p1", int.Parse(textBox4.Text));
            komut16.Parameters.AddWithValue("@p2", decimal.Parse(textBox2.Text));
            komut16.ExecuteNonQuery();

            baglanti.Close();
            baglanti.Open();

            NpgsqlCommand komut17 = new NpgsqlCommand("update musteri set bakiye=bakiye-@p2 where kayitid=@p1", baglanti);
            komut17.Parameters.AddWithValue("@p1", int.Parse(textBox4.Text));
            komut17.Parameters.AddWithValue("@p2", decimal.Parse(textBox2.Text));
            komut17.ExecuteNonQuery();

            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand komut18 = new NpgsqlCommand("update musteri_bakiye set bakiye=bakiye+@p2 where musteri_id=@p1", baglanti);
            komut18.Parameters.AddWithValue("@p1", int.Parse(textBox3.Text));
            komut18.Parameters.AddWithValue("@p2", decimal.Parse(textBox2.Text));
            komut18.ExecuteNonQuery();

            baglanti.Close();
            baglanti.Open();

            NpgsqlCommand komut19 = new NpgsqlCommand("update musteri set bakiye=bakiye+@p2 where kayitid=@p1", baglanti);
            komut19.Parameters.AddWithValue("@p1", int.Parse(textBox3.Text));
            komut19.Parameters.AddWithValue("@p2", decimal.Parse(textBox2.Text));
            komut19.ExecuteNonQuery();

            baglanti.Close();


            string sorgu2 = "select * from musteri order by kayitid";
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sorgu2, baglanti);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGridView1.DataSource = ds2.Tables[0];

            string sorgu3 = "select * from eftlistele()";
            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter(sorgu3, baglanti);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            dataGridView3.DataSource = ds3.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Havale Başarıyla silindi...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            baglanti.Open();
            NpgsqlCommand komut14 = new NpgsqlCommand("delete from havale where havaleid=@p1", baglanti);
            komut14.Parameters.AddWithValue("@p1", int.Parse(textBox8.Text));
            komut14.ExecuteNonQuery();
            baglanti.Close();


            string sorgu2 = "select * from havalelistele()";
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sorgu2, baglanti);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];

            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("EFT Başarıyla silindi...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            baglanti.Open();
            NpgsqlCommand komut14 = new NpgsqlCommand("delete from eft where eftid=@p1", baglanti);
            komut14.Parameters.AddWithValue("@p1", int.Parse(textBox9.Text));
            komut14.ExecuteNonQuery();
            baglanti.Close();

            string sorgu3 = "select * from eftlistele()";
            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter(sorgu3, baglanti);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            dataGridView3.DataSource = ds3.Tables[0];

        }
    }
}
