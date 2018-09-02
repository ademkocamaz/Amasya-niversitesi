using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string yol = "";
        string secilenKlasor = "";

        void klasorListele()
        {
            secilenKlasor = "";
            listBox1.Items.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            if (yol != "")
            {
                string[] klasorler = Directory.GetDirectories(yol);
                foreach (string klasor in klasorler)
                {
                    listBox1.Items.Add(klasor);
                }
            }
            else
            {
                MessageBox.Show("bir klasör seçiniz");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            yol = folderBrowserDialog1.SelectedPath;
            label3.Text = yol;

            klasorListele();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                secilenKlasor = listBox1.Items[listBox1.SelectedIndex].ToString();
                //textBox1.Text = Directory.GetCreationTime(secilenKlasor).ToString();
                textBox2.Text = Directory.GetLastWriteTime(secilenKlasor).ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1 || secilenKlasor != "")
            {
                try
                {
                    Directory.Delete(secilenKlasor);
                    klasorListele();
                    MessageBox.Show(secilenKlasor + " silindi.");
                    secilenKlasor = "";

                }
                catch (Exception hata)
                {
                    MessageBox.Show("Hata oluştu. " + hata);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && secilenKlasor!="")
            {
                try
                {
                    Directory.CreateDirectory(secilenKlasor + "\\" + textBox3.Text);
                    klasorListele();
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Hata oluştu. " + hata);
                }
            }
            else
            {
                MessageBox.Show("Bir klasör seçiniz.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (secilenKlasor != "")
            {
                textBox1.Text = Directory.GetCreationTime(secilenKlasor).ToString();
            }
            else
            {
                MessageBox.Show("Bir klasör seçiniz.");
            }
            
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(textBox2.Text!="" && secilenKlasor != "")
            {
                try
                {
                    Directory.SetLastWriteTime(secilenKlasor, Convert.ToDateTime(textBox2.Text));
                    klasorListele();
                }catch(Exception hata)
                {
                    MessageBox.Show("Hata oluştu. " + hata);
                }

            }else
            {
                MessageBox.Show("Bir klasör seçiniz.");
            }
        }
    }
}
