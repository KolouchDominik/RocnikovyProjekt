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

namespace Rocnikovy_projekt
{

    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        KvadratickaFunkce KvaFun;
        ExponencialniFunkce ExpFun;
        bool KvaButtonclick = false;

        // Kvadratická funkce ***********************************************************************************************************************************
        #region Kvadratická funkce
        private void KvaButton1_Click(object sender, EventArgs e)
        { 
            double x1, x2 = 0;
            if (double.TryParse(KvaTextBox1.Text, out double cislo1)
                && double.TryParse(KvaTextBox2.Text, out double cislo2)
                && double.TryParse(KvaTextBox3.Text, out double cislo3)
                && double.TryParse(KvaTextBox4.Text, out double cislo4)
                && double.TryParse(KvaTextBox5.Text, out double cislo5))
            {
                KvaFun = new KvadratickaFunkce(cislo1, cislo2, cislo3, chart1, cislo4, cislo5);

                KvaFun.Vykresli();
                x1 = KvaFun.Koreny(out x2, out bool ReseniVR);
                if (ReseniVR)
                {
                    if (x1 != x2)
                    {
                        Kvalabel1.Text = "Kořen x1 = " + x1;
                        Kvalabel2.Text = "Kořen x2 = " + x2;
                    }
                    else Kvalabel1.Text = "Kořen x1 a x2 = " + x1;
                }
                else Kvalabel1.Text = "Nemá řešení v oboru reálných čísel";
                Kvalabel3.Text = "Vrchol v bodě: " + KvaFun.VrcholXY();
                Kvalabel4.Text = "Definiční obor: " + KvaFun.Definicni_obor();
                Kvalabel5.Text = KvaFun.MaxMin();

                KvaButtonclick = true;
            }

            else MessageBox.Show("špantě zadané parametry, musí být obsaženy pouze čísla!");
            
        }

        private void KvaTextBox1_TextChanged(object sender, EventArgs e)
        {
            Kvalabel1.Text = "";
            Kvalabel2.Text = "";
            Kvalabel3.Text = "";
            Kvalabel4.Text = "";
            Kvalabel5.Text = "";
        }

        private void KvaTextBox4_TextChanged(object sender, EventArgs e)
        {
            
            bool spravne = double.TryParse(KvaTextBox4.Text, out double cislo);

            if (spravne&&KvaButtonclick)
            {
                KvaFun.RozA = cislo;
                KvaFun.Vykresli();
            }
        }

        private void KvaTextBox5_TextChanged(object sender, EventArgs e)
        {
            bool spravne = double.TryParse(KvaTextBox5.Text, out double cislo);

            if(spravne&&KvaButtonclick)
            {
                KvaFun.RozB = cislo;
                KvaFun.Vykresli();
            }
        }


        #endregion
        // Kvadratická funkce konec *****************************************************************************************************************************

        private void Button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(ExptextBox1.Text, out double zaklad))
            {
                ExpFun = new ExponencialniFunkce(zaklad,-4,-6,chart2);
                ExpFun.Vykresli();
            }
        }

    }

}
