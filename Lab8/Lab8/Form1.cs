using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace Lab8
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Word.Application word = new Word.Application();
            Word.Document wordBelge = word.Documents.Add();
            //wordUygulama.Visible = true;
            //wordUygulama.Selection.TypeText(textBox1.Text);
            wordBelge.Range().Text = textBox1.Text;
            wordBelge.SaveAs(Application.StartupPath + "\\" + textBox2.Text == "" ? "belge" : textBox2.Text + ".docx");

            wordBelge.PrintOut();

            wordBelge.Close();
            word.Quit();
            wordBelge = null;
            word = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Object misValue = System.Reflection.Missing.Value;
            Excel.Application excel = new Excel.Application();
            Excel.Workbook excelKitap = excel.Workbooks.Add(misValue);
            Excel.Worksheet excelSayfa = excelKitap.ActiveSheet;

            //Excel.Range excelRange = excelSayfa.Cells[1, 1];
            //excelRange.Value = "Test";

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                Excel.Range excelRange = excelSayfa.Cells[1, i + 1];
                excelRange.Value = listBox1.Items[i].ToString();
            }

            excel.Visible = true;
            excelKitap.SaveAs(Application.StartupPath + "\\" + textBox2.Text == "" ? "belge" : textBox2.Text + ".xlsx", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlNoChange, misValue, misValue, misValue, misValue, misValue);


            excelKitap.Close(true,misValue,misValue);
            excel.Quit();

            excelSayfa = null;
            excelKitap = null;
            excel = null;


        }
    }
}
