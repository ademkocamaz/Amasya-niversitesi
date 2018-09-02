using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab
{
    public partial class Form1 : Form
    {
        Color renk = Color.White;
        int kalinlik = 1;
        string metin = "";
        int X1, Y1, X2, Y2;
        Font font;

        enum Sekil
        {
            Daire,
            Dortgen,
            Cizgi,
            Metin
        }
        Sekil sekil = Sekil.Cizgi;


        public Form1()
        {
            InitializeComponent();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            X1 = e.X;
            Y1 = e.Y;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            X2 = e.X;
            Y2 = e.Y;
            Ciz();
        }

        void Ciz()
        {
            Graphics grafik = panel2.CreateGraphics();
            Pen kalem = new Pen(renk, kalinlik);



            switch (sekil)
            {
                case Sekil.Cizgi:
                    grafik.DrawLine(kalem, X1, Y1, X2, Y2);
                    break;
                case Sekil.Daire:
                    grafik.DrawEllipse(kalem, X1, Y1, ((X2 - X1) < 0 ? (X1 - X2) : (X2 - X1)), ((Y2 - Y1) < 0 ? (Y1 - Y2) : (Y2 - Y1)));
                    break;
                case Sekil.Dortgen:
                    grafik.DrawRectangle(kalem, X1, Y1, ((X2 - X1) < 0 ? (X1 - X2) : (X2 - X1)), ((Y2 - Y1) < 0 ? (Y1 - Y2) : (Y2 - Y1)));
                    break;
                case Sekil.Metin:
                    //Font font = new Font("Helvetica", 15, FontStyle.Bold);

                    Brush firca = new SolidBrush(renk);
                    grafik.DrawString(metin, font, firca, X1, Y1);

                    break;

                default:

                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();

            font = fontDialog1.Font;

            metin = Interaction.InputBox("Çizilecek metni giriniz.");
            sekil = Sekil.Metin;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sekil = Sekil.Daire;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sekil = Sekil.Dortgen;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sekil = Sekil.Cizgi;
        }

        Color RenkSec()
        {
            colorDialog1.ShowDialog();
            return colorDialog1.Color;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            renk = RenkSec();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!Int32.TryParse(Interaction.InputBox("Çizgi kalınlığı giriniz."), out kalinlik))
                MessageBox.Show("Bir sayı giriniz.");
        }
    }
}
