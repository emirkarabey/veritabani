using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Proje2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=MobilBanka2; user ID=postgres; password=heroesboq12");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Çalışanlar ff = new Çalışanlar();
            ff.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Müşteriler ff = new Müşteriler();
            ff.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Şubeler ff = new Şubeler();
            ff.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Müşteriler ff = new Müşteriler();
            ff.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ParaCekYatir ff = new ParaCekYatir();
            ff.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ParaCekYatir ff = new ParaCekYatir();
            ff.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            string sorgu = "select * from musteri where kayitid='"+textBox1.Text+"'"+"  order by kayitid";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kartlar ff = new Kartlar();
            ff.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            HavaleEft ff = new HavaleEft();
            ff.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Ödemeler ff = new Ödemeler();
            ff.Show();
        }
    }
}
