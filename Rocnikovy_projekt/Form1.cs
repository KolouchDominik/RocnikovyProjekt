using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.WinForms;
using LiveCharts.Wpf;

namespace Rocnikovy_projekt
{

    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        
    


        private void KvaButton1_Click(object sender, EventArgs e)
        {
            bool ReseniVR;
            double x1, x2 = 0;
            KvadratickáFunkce KvaFun = new KvadratickáFunkce(double.Parse(KvaTextBox1.Text), double.Parse(KvaTextBox2.Text), double.Parse(KvaTextBox3.Text),
                chart1,double.Parse(KvaTextBox4.Text),double.Parse(KvaTextBox5.Text));
            KvaFun.Vykresli();
            x1 = KvaFun.Koreny(out x2, out ReseniVR);
            if (ReseniVR)
            {
                if (x1 != x2)
                {
                    label1.Text = "Kořen x1 = " + x1;
                    label2.Text = "Kořen x2 = " + x2;
                }
                else label1.Text = "Kořen x1 a x2 = " + x1;
            }
            else label1.Text = "Nemá řešení v oboru reálných čísel";
            label3.Text = "Vrchol v bodě: " +  KvaFun.VrcholXY();
            label4.Text = "Definiční obor: " + KvaFun.Definicni_obor();
            label5.Text = KvaFun.MaxMin();
            
            
            
        }

        private void KvaTextBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
        }
    }

}
