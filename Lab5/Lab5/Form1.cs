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
    public partial class Form1 : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kitap.accdb");

        public Form1()
        {
            InitializeComponent();
        }

        void KayitlariListele()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            OleDbDataAdapter adp = new OleDbDataAdapter("Select * From KITAPLAR", baglanti);
            DataSet ds = new DataSet();
            ds.Clear();
            adp.Fill(ds, "kitap");
            dataGridView1.DataSource = ds.Tables["kitap"];
            baglanti.Close();
        }

        void TurleriEkle()
        {
            if (baglanti.State == ConnectionState.Broken)
            {
                baglanti.Open();
            }
            OleDbDataAdapter adp = new OleDbDataAdapter("Select * From TURLER", baglanti);
            DataSet ds = new DataSet();
            adp.Fill(ds, "tur");
            comboBox1.DataSource = ds.Tables["tur"];
            comboBox1.DisplayMember = "TUR_ADI";
            comboBox1.ValueMember = "TUR_ADI";
        }
        void Temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            //comboBox1.Items.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            string sql = "INSERT INTO KITAPLAR (KITAP_ADI,YAZARI,TURU,BASIM_YERI) VALUES('" + textBox1.Text + "', '" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "')";
            OleDbCommand komut = new OleDbCommand(sql, baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Temizle();
            KayitlariListele();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KayitlariListele();
            TurleriEkle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
            frm2.Dispose();
            this.Show();            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 frm3 = new Form3();
            frm3.ShowDialog();
            frm3.Dispose();
            this.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 frm4 = new Form4();
            frm4.ShowDialog();
            frm4.Dispose();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            string sql = "DELETE FROM KITAPLAR WHERE Kimlik="+ dataGridView1.CurrentRow.Cells[0].Value.ToString();
            OleDbCommand komut = new OleDbCommand(sql, baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Temizle();
            KayitlariListele();
        }
    }
}
