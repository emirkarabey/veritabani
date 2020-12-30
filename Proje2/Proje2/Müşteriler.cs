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
    public partial class Müşteriler : Form
    {
        public Müşteriler()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=MobilBanka2; user ID=postgres; password=heroesboq12");
        private void Müşteriler_Load(object sender, EventArgs e)
        {
            string sorgu = "select * from musterilistele()";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            baglanti.Open();
            NpgsqlCommand komut11 = new NpgsqlCommand("select bankaadi from bankalar",baglanti);
            NpgsqlDataReader dr = komut11.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());

            }
            baglanti.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Müşteri eklendi...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            baglanti.Open();
            NpgsqlCommand komut12 = new NpgsqlCommand("insert into hesaplar (hesapno,bakiye) values (@p1,@p2)", baglanti);
            komut12.Parameters.AddWithValue("@p1", int.Parse(textBox11.Text));
            komut12.Parameters.AddWithValue("@p2", decimal.Parse(textBox8.Text));
            komut12.ExecuteNonQuery();

            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into musteri (kayitid,adsoyad,parola,tcno,bakiye,yas,bkartino,kkartino,bankaadi,hesapno) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)",baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut.Parameters.AddWithValue("@p2", textBox3.Text);
            komut.Parameters.AddWithValue("@p3", textBox10.Text);
            komut.Parameters.AddWithValue("@p4", textBox2.Text);
            komut.Parameters.AddWithValue("@p5", decimal.Parse(textBox8.Text));
            komut.Parameters.AddWithValue("@p6", int.Parse(textBox9.Text));
            komut.Parameters.AddWithValue("@p7", textBox5.Text);
            komut.Parameters.AddWithValue("@p8", textBox4.Text);
            komut.Parameters.AddWithValue("@p9", comboBox1.Text);
            komut.Parameters.AddWithValue("@p10", int.Parse(textBox11.Text));

            komut.ExecuteNonQuery();

            baglanti.Close();


            




            baglanti.Open();
            NpgsqlCommand komut9 = new NpgsqlCommand("insert into kredikarti (musteriid,adsoyad,cvc2,kartno,sonkullanmatarihi) values (@p1,@p2,@p3,@p4,@p5)", baglanti);
            komut9.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut9.Parameters.AddWithValue("@p2", textBox3.Text);
            komut9.Parameters.AddWithValue("@p3", int.Parse(textBox6.Text));
            komut9.Parameters.AddWithValue("@p4", textBox4.Text);
            komut9.Parameters.AddWithValue("@p5", maskedTextBox1.Text);
            komut9.ExecuteNonQuery();

            baglanti.Close();
            baglanti.Open();
            NpgsqlCommand komut10 = new NpgsqlCommand("insert into bankakarti (musteriid,adsoyad,cvc2,kartno,sonkullanmatarihi) values (@p1,@p2,@p3,@p4,@p5)", baglanti);
            komut10.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut10.Parameters.AddWithValue("@p2", textBox3.Text);
            komut10.Parameters.AddWithValue("@p3", int.Parse(textBox6.Text));
            komut10.Parameters.AddWithValue("@p4", textBox5.Text);
            komut10.Parameters.AddWithValue("@p5", maskedTextBox1.Text);
            komut10.ExecuteNonQuery();

            baglanti.Close();


            string sorgu = "select * from musteri order by kayitid";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            baglanti.Open();
            NpgsqlCommand komut3= new NpgsqlCommand("insert into musteri_bakiye (musteri_id,adsoyad,bakiye) values (@p1,@p2,@p3)", baglanti);
            komut3.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut3.Parameters.AddWithValue("@p2", textBox3.Text);
            komut3.Parameters.AddWithValue("@p3", decimal.Parse(textBox8.Text));
            komut3.ExecuteNonQuery();

            baglanti.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Müşteri güncellendi...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("update musteri set adsoyad=@p2,parola=@p3,tcno=@p4,bakiye=@p5,yas=@p6 where kayitid=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut.Parameters.AddWithValue("@p2", textBox3.Text);
            komut.Parameters.AddWithValue("@p3", int.Parse(textBox10.Text));
            komut.Parameters.AddWithValue("@p4", textBox2.Text);
            komut.Parameters.AddWithValue("@p5", decimal.Parse(textBox8.Text));
            komut.Parameters.AddWithValue("@p6", int.Parse(textBox9.Text));
            komut.ExecuteNonQuery();

            baglanti.Close();
            string sorgu = "select * from musteri order by kayitid";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            baglanti.Open();
            NpgsqlCommand komut4 = new NpgsqlCommand("update musteri_bakiye set adsoyad=@p2,bakiye=@p3 where musteri_id=@p1", baglanti);
            komut4.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut4.Parameters.AddWithValue("@p2", textBox3.Text);
            komut4.Parameters.AddWithValue("@p3", decimal.Parse(textBox8.Text));
            komut4.ExecuteNonQuery();

            baglanti.Close();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Müşteri silindi...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("delete from musteri where kayitid=@p1",baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(textBox7.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand komut14 = new NpgsqlCommand("delete from hesaplar where hesapno=@p1", baglanti);
            komut14.Parameters.AddWithValue("@p1", int.Parse(textBox12.Text));
            komut14.ExecuteNonQuery();
            baglanti.Close();





            string sorgu = "select * from musteri order by kayitid";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            baglanti.Open();
            NpgsqlCommand komut5 = new NpgsqlCommand("delete from musteri_bakiye where musteri_id=@p1", baglanti);
            komut5.Parameters.AddWithValue("@p1", int.Parse(textBox7.Text));
            komut5.ExecuteNonQuery();

            baglanti.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
