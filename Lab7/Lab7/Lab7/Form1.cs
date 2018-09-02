using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics grafik;

        void UcgenCiz(int kenar, int x, int y)
        {
            grafik = panel2.CreateGraphics();
            Pen kalem = new Pen(Color.Black, 5);
            Point[] noktalar = { new Point(x, y), new Point(x + kenar / 2, y + kenar), new Point(x - kenar / 2, y + kenar) };

            grafik.DrawString("(" + x + "," + y + ")", Font, Brushes.Black, x, y - 20);
            grafik.DrawString("(" + (x + kenar / 2) + "," + (y + kenar) + ")", Font, Brushes.Black, x + kenar / 2, y + kenar + 10);
            grafik.DrawString("(" + (x - kenar / 2) + "," + (y + kenar) + ")", Font, Brushes.Black, x - kenar / 2 - 10, y + kenar + 10);


            grafik.DrawPolygon(kalem, noktalar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kenar, x, y;
            if (!Int32.TryParse(textBox1.Text, out kenar))
            {
                MessageBox.Show("Lütfen sayı giriniz.");
                return;
            }
            if (!Int32.TryParse(textBox2.Text, out x))
            {
                MessageBox.Show("Lütfen sayı giriniz.");
                return;
            }
            if (!Int32.TryParse(textBox3.Text, out y))
            {
                MessageBox.Show("Lütfen sayı giriniz.");
                return;
            }
            UcgenCiz(kenar, x, y);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (grafik != null) grafik.Clear(panel1.BackColor);
        }
    }
}
