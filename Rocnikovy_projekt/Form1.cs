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
        LogaritmickaFunkce LogFun;

        bool KvaButtonClick = false;
        bool ExpButtonClick = false;
        bool LogButtonClick = false;


        #region Kvadratická funkce
        private void KvaButton1_Click(object sender, EventArgs e)
        { 
            double x1, x2 = 0;
            if (double.TryParse(KvaTextBox1.Text, out double KvaA)
                && double.TryParse(KvaTextBox2.Text, out double KvaB)
                && double.TryParse(KvaTextBox3.Text, out double KvaC)
                && double.TryParse(KvaTextBox4.Text, out double KvaRozA)
                && double.TryParse(KvaTextBox5.Text, out double KvaRozB))
            {
                KvaFun = new KvadratickaFunkce(KvaA, KvaB, KvaC, chart1, KvaRozA, KvaRozB);

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
                else Kvalabel3.Text = "Nemá řešení v oboru reálných čísel\n" +
                "Vrchol v bodě: " + KvaFun.VrcholXY() +
                "\nDefiniční obor: " + KvaFun.Definicni_obor() +"\n"+
               KvaFun.MaxMin();

                KvaButtonClick = true;
            }

            else MessageBox.Show("špantě zadané parametry, musí být obsaženy pouze čísla!");
            
        }

      

        private void KvaTextBox4_TextChanged(object sender, EventArgs e)
        {
            
            bool spravne = double.TryParse(KvaTextBox4.Text, out double RozA);

            if (spravne&&KvaButtonClick)
            {
                KvaFun.NastavRozA(RozA);
                KvaFun.Vykresli();
            }
        }

        private void KvaTextBox5_TextChanged(object sender, EventArgs e)
        {
            bool spravne = double.TryParse(KvaTextBox5.Text, out double RozB);

            if(spravne&&KvaButtonClick)
            {
                KvaFun.NastavRozB(RozB);
                KvaFun.Vykresli();
            }
        }


        #endregion

        #region Exponencialni funkce

        private void Expbutton1_Click(object sender, EventArgs e)
        {
            
            if (double.TryParse(ExptextBox1.Text, out double ExpA)
                && double.TryParse(ExptextBox2.Text, out double ExpB)
                && double.TryParse(ExptextBox3.Text, out double ExpC)
                && double.TryParse(ExptextBox4.Text, out double ExpRozA)
                && double.TryParse(ExptextBox5.Text, out double ExpRozB))
            {
                if (ExpA > 0)
                {
                    ExpFun = new ExponencialniFunkce(ExpA, ExpB, ExpC, chart2, ExpRozA, ExpRozB);
                    ExpFun.Vykresli();
                    ExpButtonClick = true;
                }
                else MessageBox.Show("Základ \"a\" musí být větší než 0 "); //viditelné úvozovky
            }
        }


        private void ExptextBox4_TextChanged(object sender, EventArgs e)
        {
            if(double.TryParse(ExptextBox4.Text, out double RozA)&&ExpButtonClick)
            {
                ExpFun.NastavRozA(RozA);
                ExpFun.Vykresli();
            }
        }

       

        private void ExptextBox5_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(ExptextBox5.Text, out double RozB) && ExpButtonClick)
            {
                ExpFun.NastavRozB(RozB);
                ExpFun.Vykresli();
            }
        }

        





        #endregion

        #region Goniometricke funkce

        private void Gonbutton1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(GontextBox1.Text, out double stranaA) 
            && double.TryParse(GontextBox2.Text, out double stranaB) 
            && double.TryParse(GontextBox3.Text, out double stranaC))
            {
                GoniometrickeFunkce gonFun = new GoniometrickeFunkce(stranaA, stranaB, stranaC,Gonchart1);
                Gonlabel1.Text = gonFun.vypocet();

            }
        }

       
        #endregion

        #region Logaritmicka funkce
        private void Logbutton1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(logtextBox1.Text, out double a)
                && double.TryParse(logtextBox2.Text, out double rozA) && rozA > 0
                && double.TryParse(logtextBox3.Text, out double rozB))
            {
                LogFun = new LogaritmickaFunkce(a, rozA, rozB, Logchart1);
                LogFun.Vykresly();
                LogButtonClick = true;
            }
            else MessageBox.Show("Špatně zadané parametry!");
        }
      
        private void LogtextBox2_TextChanged(object sender, EventArgs e)
        {
            if(double.TryParse(logtextBox2.Text,out double rozA)&&LogButtonClick)
            {
                LogFun.NastavRozA(rozA);
                LogFun.Vykresly();
            }
        }
        private void LogtextBox3_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(logtextBox3.Text, out double rozB) && LogButtonClick)
            {
                LogFun.NastavRozB(rozB);
                LogFun.Vykresly();
            }
        }

        #endregion
    }

}