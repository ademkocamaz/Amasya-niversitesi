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
    public partial class Form2 : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kitap.accdb");
        public Form2()
        {
            InitializeComponent();
        }

        void KayitlariListele()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            OleDbDataAdapter adp = new OleDbDataAdapter("Select * From KITAPLAR WHERE TURU='Roman'", baglanti);
            DataSet ds = new DataSet();
            ds.Clear();
            adp.Fill(ds, "kitap");
            dataGridView1.DataSource = ds.Tables["kitap"];
            baglanti.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            KayitlariListele();
        }
    }
}
