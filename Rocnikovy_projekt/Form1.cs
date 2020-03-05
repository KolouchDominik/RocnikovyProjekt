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
using System.Drawing.Drawing2D;

namespace Rocnikovy_projekt
{

    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            
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
                KvaButtonClick = true;
                KvaFun = new KvadratickaFunkce(KvaA, KvaB, KvaC, chart1, KvaRozA, KvaRozB);

                KvaFun.Vykresli();
                Kvalabel1.Text = KvaFun.Vlastnosti();
            }
            else MessageBox.Show("Špantě zadané hodnoty, musí být obsaženy pouze čísla!\nVšechny textové pole musí obsahovat hodnotu!");
            
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
                    Explabel3.Text = ExpFun.Vlastnosti_ExpFun();
                }
                else MessageBox.Show("Základ \"a\" musí být větší než 0 "); //viditelné úvozovky
            }
            else MessageBox.Show("Špantě zadané hodnoty, musí být obsaženy pouze čísla!\nVšechny textové pole musí obsahovat hodnotu!");
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
                GoniometrickeFunkce gonFun = new GoniometrickeFunkce(stranaA, stranaB, stranaC, Gonchart1);
                Gonlabel1.Text = gonFun.Vykresli();

            }
            else MessageBox.Show("Špantě zadané hodnoty, musí být obsaženy pouze čísla!\nVšechny textové pole musí obsahovat hodnotu!");
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
                LogLabel3.Text = LogFun.Vlastnosti();
            }
            else MessageBox.Show("Špantě zadané hodnoty, musí být obsaženy pouze čísla!\nVšechny textové pole musí obsahovat hodnotu!");
        }
      
        private void LogtextBox2_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(logtextBox2.Text, out double rozA) && LogButtonClick)
            {
                if (rozA > 0)
                {
                    //konzultace -> program spadne, když číslo začne 0 (0.1,0.2...) logaritmická funkce nemá nikdy na ose X číslo 0
                    LogFun.NastavRozA(rozA);
                    LogFun.Vykresly();
                }
            }
        }
        private void LogtextBox3_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(logtextBox3.Text, out double rozB) && LogButtonClick)
            {
                if (rozB > 0)
                {
                    //stejný problém, například pro interval (0.1,0.8)
                    LogFun.NastavRozB(rozB);
                    LogFun.Vykresly();
                }
            }
        }

        #endregion
    }

}