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


        KvadratickáFunkce KvaFun;
        bool buttonclick = false;

        private void KvaButton1_Click(object sender, EventArgs e)
        { //ahojda
            bool ReseniVR;
            double x1, x2 = 0;
            if (double.TryParse(KvaTextBox1.Text, out double cislo1) && double.TryParse(KvaTextBox2.Text, out double cislo2) && double.TryParse(KvaTextBox3.Text, out double cislo3)
                && double.TryParse(KvaTextBox4.Text, out double cislo4) && double.TryParse(KvaTextBox5.Text, out double cislo5))
            {
                KvaFun = new KvadratickáFunkce(cislo1, cislo2, cislo3, chart1, cislo4, cislo5);

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
                label3.Text = "Vrchol v bodě: " + KvaFun.VrcholXY();
                label4.Text = "Definiční obor: " + KvaFun.Definicni_obor();
                label5.Text = KvaFun.MaxMin();

                buttonclick = true;
            }

            else MessageBox.Show("špantě zadané parametry, musí být obsaženy pouze čísla!");
            
        }

        private void KvaTextBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
        }

        private void KvaTextBox4_TextChanged(object sender, EventArgs e)
        {
            
            bool spravne = double.TryParse(KvaTextBox4.Text, out double cislo);

            if (spravne&&buttonclick)
            {
                KvaFun.RozA = cislo;
                KvaFun.Vykresli();
            }
        }

        private void KvaTextBox5_TextChanged(object sender, EventArgs e)
        {
            bool spravne = double.TryParse(KvaTextBox5.Text, out double cislo);

            if(spravne&&buttonclick)
            {
                KvaFun.RozB = cislo;
                KvaFun.Vykresli();
            }
        }
    }

}
