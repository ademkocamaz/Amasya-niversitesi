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

namespace Lab4
{
    public partial class Form1 : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Rehber.accdb");
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;

        public Form1()
        {
            InitializeComponent();
        }

        void KayitlariListele()
        {

            da = new OleDbDataAdapter("Select * from REHBER", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "REHBER");
            dataGridView1.DataSource = ds.Tables["REHBER"];
            con.Close();
            Temizle();
        }

        void Temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        void SehirleriEkle()
        {
            da = new OleDbDataAdapter("Select * from SEHIRLER", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "SEHIR");
            comboBox1.DataSource = ds.Tables["SEHIR"];
            comboBox1.DisplayMember = "SEHIR";
            comboBox1.ValueMember = "SEHIR";
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KayitlariListele();
            SehirleriEkle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into REHBER (ADI,SOYADI,TELEFON,GSM,ADRES,SEHIR) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox1.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            KayitlariListele();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dataGridView1.Rows.Count.ToString());
            if (dataGridView1.Rows.Count > 1)
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "delete from REHBER where Kimlik=" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
                cmd.ExecuteNonQuery();
                con.Close();
                KayitlariListele();
            }
            else
            {
                MessageBox.Show("Silinecek kayıt bulunamadı.");
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update REHBER set ADI='" + textBox1.Text + "',SOYADI='" + textBox2.Text + "',TELEFON='" + textBox3.Text + "',GSM='" + textBox4.Text + "',ADRES='" + textBox5.Text + "',SEHIR='" + comboBox1.Text + "' where Kimlik=" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "";
                cmd.ExecuteNonQuery();
                con.Close();
                
                KayitlariListele();

            }
            else
            {
                MessageBox.Show("Güncellenecek kayıt bulunamadı.");
            }
        }
    }
}
