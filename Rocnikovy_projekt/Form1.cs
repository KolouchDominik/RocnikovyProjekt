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
        GoniometrickeFunkce GonFun;

        bool KvaButtonClick = false;
        bool ExpButtonClick = false;
        bool LogButtonClick = false;
        bool GonButtonClick = false;


        #region Kvadratická funkce
        private void KvaButton1_Click(object sender, EventArgs e)
        { 
            if (double.TryParse(KvaTextBoxA.Text, out double KvaA)
                && double.TryParse(KvaTextBoxB.Text, out double KvaB)
                && double.TryParse(KvaTextBoxC.Text, out double KvaC)
                && double.TryParse(KvaTextBoxRozA.Text, out double KvaRozA)
                && double.TryParse(KvaTextBoxRozB.Text, out double KvaRozB))
            {
                if (KvaA != 0)
                {
                    KvaButtonClick = true;
                    KvaFun = new KvadratickaFunkce(KvaA, KvaB, KvaC, KvaChart, KvaRozA, KvaRozB);

                    KvaFun.Vykresli();
                    KvalabelVlastnosti.Text = KvaFun.Vlastnosti();
                }
                else
                {
                    MessageBox.Show("Kvadratický člen \"a\" musí být různý od 0)");
                    KvaTextBoxA.Focus();
                    KvaTextBoxA.SelectAll();
                }
            }
            else MessageBox.Show("Špantě zadané hodnoty, musí být obsaženy pouze čísla!\nVšechny textové pole musí obsahovat hodnotu!");
            
        }
        private void KvaTextBoxRozA_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(KvaTextBoxRozA.Text, out double RozA) && KvaButtonClick)
            {
                KvaFun.NastavRozA(RozA);
                KvaFun.Vykresli();
            }
        }
        private void KvaTextBoxRozB_TextChanged(object sender, EventArgs e)
        {
            if(double.TryParse(KvaTextBoxRozB.Text, out double RozB) && KvaButtonClick)
            {
                KvaFun.NastavRozB(RozB);
                KvaFun.Vykresli();
            }
        }


        #endregion

        #region Exponencialni funkce

        private void Expbutton1_Click(object sender, EventArgs e)
        {
            
            if (double.TryParse(ExptextBoxA.Text, out double ExpA)
                && double.TryParse(ExptextBoxB.Text, out double ExpB)
                && double.TryParse(ExptextBoxC.Text, out double ExpC)
                && double.TryParse(ExptextBoxRozA.Text, out double ExpRozA)
                && double.TryParse(ExptextBoxRozB.Text, out double ExpRozB))
            {
                if (ExpA > 0)
                {
                    ExpFun = new ExponencialniFunkce(ExpA, ExpB, ExpC, ExpChart, ExpRozA, ExpRozB);
                    ExpFun.Vykresli();
                    ExpButtonClick = true;
                    Explabel3.Text = ExpFun.Vlastnosti_ExpFun();
                }
                else MessageBox.Show("Základ \"a\" musí být větší než 0 "); //viditelné úvozovky
            }
            else MessageBox.Show("Špantě zadané hodnoty, musí být obsaženy pouze čísla!\nVšechny textové pole musí obsahovat hodnotu!");
        }


        private void ExptextBoxRozA_TextChanged(object sender, EventArgs e)
        {
            if(double.TryParse(ExptextBoxRozA.Text, out double RozA)&&ExpButtonClick)
            {
                ExpFun.NastavRozA(RozA);
                ExpFun.Vykresli();
            }
        }

       

        private void ExptextBoxRozB_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(ExptextBoxRozB.Text, out double RozB) && ExpButtonClick)
            {
                ExpFun.NastavRozB(RozB);
                ExpFun.Vykresli();  
            }
        }

        





        #endregion

        #region Goniometricke funkce

        private void Gonbutton1_Click(object sender, EventArgs e)
        {
            if (SinradioButton1.Checked)
            {
                if (double.TryParse(GontextBox1.Text, out double a)
                    && double.TryParse(GontextBox2.Text, out double b)
                    && double.TryParse(GontextBox3.Text, out double c)
                    && double.TryParse(GontextBoxRozA.Text, out double rozA)
                    && double.TryParse(GontextBoxRozB.Text, out double rozB))
                {
                    GonButtonClick = true;
                    GonFun = new GoniometrickeFunkce(a, b, c, rozA, rozB, "sin", GonChart);
                    GonFun.Vykresly();
                    Gonlabel1.Text = GonFun.Vlastnosit();
                }
                else { MessageBox.Show("Chybně zadané vstupy!"); }
            }
            else if (CosradioButton1.Checked)
            {
                if (double.TryParse(GontextBox1.Text, out double a)
                    && double.TryParse(GontextBox2.Text, out double b)
                    && double.TryParse(GontextBox3.Text, out double c)
                    && double.TryParse(GontextBoxRozA.Text, out double rozA)
                    && double.TryParse(GontextBoxRozB.Text, out double rozB))
                {
                    GonButtonClick = true;
                    GonFun = new GoniometrickeFunkce(a, b, c, rozA, rozB, "cos", GonChart); ;
                    GonFun.Vykresly();
                    Gonlabel1.Text = GonFun.Vlastnosit();
                }
                else { MessageBox.Show("Chybně zadané vstupy!"); }
            }
            else if(TanradioButton1.Checked)
            {
                if (double.TryParse(GontextBox1.Text, out double a)
                    && double.TryParse(GontextBox2.Text, out double b)
                    && double.TryParse(GontextBoxRozA.Text, out double rozA)
                    && double.TryParse(GontextBoxRozB.Text, out double rozB))
                {
                    GonButtonClick = true;
                    GonFun = new GoniometrickeFunkce(a, b, rozA, rozB, "tan", GonChart); ;
                    GonFun.Vykresly();
                    Gonlabel1.Text = GonFun.Vlastnosit();
                }
                else { MessageBox.Show("Chybně zadané vstupy!"); }
            }
            
            else
            {
                MessageBox.Show("Není vybrána funkce!");
            }

        }

        // **************** Lepší přístup k uživateli ******************
        private void SinradioButton1_CheckedChanged(object sender, EventArgs e)
        {
            GonLabelSinCos.Text = "Rovnice ve tvaru: a*sin(x*b)+c";
            GontextBox3.Enabled = true;
        }
        private void CosradioButton1_CheckedChanged(object sender, EventArgs e)
        {
            GonLabelSinCos.Text = "Rovnice ve tvaru: a*cos(x*b)+c";
            GontextBox3.Enabled = true;
        }
        private void TanradioButton1_CheckedChanged(object sender, EventArgs e)
        {
            GonLabelSinCos.Text = "Rovnice ve tvaru: a*tg(x)+b";
            GontextBox3.Enabled=false;
        }
        // **************** Lepší přístup k uživateli ******************

        private void GontextBoxRozA_TextChanged(object sender, EventArgs e)
        {
            if(double.TryParse(GontextBoxRozA.Text, out double rozA)&&GonButtonClick)
            {
                GonFun.NastavRozA(rozA);
                GonFun.Vykresly();
            }
        }

        private void GontextBoxRozB_TextChanged(object sender, EventArgs e)
        {
            if(double.TryParse(GontextBoxRozB.Text, out double rozB)&&GonButtonClick)
            {
                GonFun.NastavRozB(rozB);
                GonFun.Vykresly();
            }
        }

        #endregion

        #region Logaritmicka funkce
        private void Logbutton1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(logtextBoxA.Text, out double a)
                && double.TryParse(logtextBoxRozA.Text, out double rozA)
                && double.TryParse(logtextBoxRozB.Text, out double rozB))
            {
                if (a > 0)
                {
                    if (rozA > 0)
                    {
                        LogFun = new LogaritmickaFunkce(a, rozA, rozB, LogChart);
                        LogFun.Vykresly();
                        LogButtonClick = true;
                        LogLabel3.Text = LogFun.Vlastnosti();
                    }
                    else MessageBox.Show("Počátek intervalu musí být větší než 0");
                }
                else
                {
                    MessageBox.Show("\"a\" musí být z intervalu (0;1)∪(1;∞)");
                    logtextBoxA.Focus();
                    logtextBoxA.SelectAll();
                }
            }
            else MessageBox.Show("Špantě zadané hodnoty, musí být obsaženy pouze čísla!\nVšechny textové pole musí obsahovat hodnotu!");
        }
      
        private void LogtextBoxRozA_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(logtextBoxRozA.Text, out double rozA) && LogButtonClick)
            {
                if (rozA > 0)
                {
                    LogFun.NastavRozA(rozA);
                    LogFun.Vykresly();
                }
            }
        }
        private void LogtextBoxRozB_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(logtextBoxRozB.Text, out double rozB) && LogButtonClick)
            {
                if (rozB > 0)
                {
                    LogFun.NastavRozB(rozB);
                    LogFun.Vykresly();
                }
            }
        }







        #endregion
    }

}