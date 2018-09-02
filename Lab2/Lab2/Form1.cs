using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void kayitlariListele()
        {
            listBox1.Items.Clear();
            textBox1.Text = "";
            textBox2.Text = "";

            string[] kayitlar = Directory.GetFiles(konum, "*.txt");
            foreach (string herbir in kayitlar)
            {
                listBox1.Items.Add(Path.GetFileNameWithoutExtension(herbir));
            }
        }

        string konum = System.IO.Directory.GetCurrentDirectory();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
            frm2.Dispose();
            this.Show();
            kayitlariListele();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string kayit = listBox1.Items[listBox1.SelectedIndex].ToString();

                textBox1.Text = File.ReadAllText(kayit + ".txt");

                textBox2.Text = File.GetLastWriteTime(kayit + ".txt").ToString();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            kayitlariListele();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string kayit = listBox1.Items[listBox1.SelectedIndex].ToString();
                File.WriteAllText(kayit + ".txt", textBox1.Text);
                File.SetLastWriteTime(kayit + ".txt", Convert.ToDateTime(textBox2.Text));
                kayitlariListele();
            }

        }
    }
}
