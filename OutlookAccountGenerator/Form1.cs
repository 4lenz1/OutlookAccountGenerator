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

namespace OutlookAccountGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            datePicker.Value = DateTime.Now;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //string filename = "Azure_Pass_Account" +/* datePicker.ToString() + */inputApplicant.Text;
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Excel.Workbook wb = excel.Workbooks.Add(1);
            Excel.Worksheet sh = wb.Sheets.Add();
            datePicker.Format = DateTimePickerFormat.Custom;
            datePicker.CustomFormat = "yyyyMMdd";
          
            sh.Name = "Azure Account";

            sh.Cells[1, "A"].Value2 = "Index";
            sh.Cells[1, "B"].Value2 = "Account";
            sh.Cells[1, "C"].Value2 = "Password";
            sh.Cells[1, "D"].Value2 = "Applicant";


            for(int index = 1; index <= Int32.Parse( inputAmount.Text); index   ++)
            {
                sh.Cells[index + 1 ,"A"].Value2 = index;
                sh.Cells[index + 1, "B"].Value2 = "MS" + datePicker.Text + index.ToString("00") + "@outlook.com";
                sh.Cells[index + 1, "C"].Value2 = "MS" + datePicker.Text;
                sh.Cells[index + 1, "D"].Value2 = inputApplicant.Text;
            }

            txtFileName.Text = "Azure_Pass_Account_" + datePicker.Text + "_" + inputApplicant.Text + "auto_generate";

            wb.Close(true);
            excel.Quit();

        }

        private void datePicker_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
