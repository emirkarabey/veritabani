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
    public partial class Kartlar : Form
    {
        public Kartlar()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=MobilBanka2; user ID=postgres; password=heroesboq12");

        private void Kartlar_Load(object sender, EventArgs e)
        {
            string sorgu = "select * from kredikarti order by musteriid";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];

            string sorgu2 = "select * from bankakarti order by musteriid";
            NpgsqlDataAdapter da1 = new NpgsqlDataAdapter(sorgu2, baglanti);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];

        }
    }
}
