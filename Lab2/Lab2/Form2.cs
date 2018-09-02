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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kayit = textBox1.Text;
            string kayitDosya = kayit + ".txt";           

            FileStream fs;
            if (!File.Exists(kayitDosya))
            {
                listBox1.Items.Add(kayit);
                fs = File.Create(kayitDosya);
                fs.Close();
            }
            else
            {
                MessageBox.Show(kayit+" daha önce oluşturulmuş");
            }
        }
    }
}
