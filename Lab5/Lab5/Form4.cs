using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab
{
    public partial class Form4 : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kitap.accdb");

        public Form4()
        {
            InitializeComponent();
        }

        void KayitlariAra(string aranacak)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            OleDbDataAdapter adp = new OleDbDataAdapter("Select * From KITAPLAR WHERE "+aranacak, baglanti);
            DataSet ds = new DataSet();
            ds.Clear();
            adp.Fill(ds, "kitap");
            dataGridView1.DataSource = ds.Tables["kitap"];
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KayitlariAra("KITAP_ADI like '%" + textBox1.Text + "%'");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KayitlariAra("YAZARI like '%" + textBox2.Text + "%'");
        }
    }
}
