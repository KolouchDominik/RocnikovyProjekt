using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;

namespace Rocnikovy_projekt
{
    class LogaritmickaFunkce
    {
        private double a;
        private double rozA;
        private double rozB;
        private Chart graf;

        public LogaritmickaFunkce(double a, double rozA, double rozB, Chart graf)
        {
            this.a = a;
            this.rozA = rozA;
            this.rozB = rozB;
            this.graf = graf;
        }

        /// <summary>
        /// Konstruktor pro aktualizaci osy X
        /// </summary>
        public LogaritmickaFunkce()
        {

        }
        
        private bool Kontrola()
        {
            if (a > 0 && a != 1)
            {
                return true;
            }
            else return false;
        }
        /// <summary>
        /// Dle zadaných hodnot v konstruktoru vykreslí graf
        /// </summary>
        public void Vykresly()
        {
            graf.Series["Logaritmicka funkce"].Points.Clear();
            if (Kontrola())
            {
                for (double x = rozA; x < rozB; x=x+0.1)
                {
                    double y = Math.Log(x, a);
                    graf.Series["Logaritmicka funkce"].Points.AddXY(x, y);
                }
            }
            else MessageBox.Show("Špatně zadaná hodnota, a>0, a!=1");
        }

        /// <summary>
        /// Nastaví začátek intervalu osy X
        /// </summary>
        /// <param name="rozA"></param>
        public void NastavRozA(double rozA)
        {
            this.rozA = rozA;
        }
        /// <summary>
        /// Nastaví konec intervalu osy X
        /// </summary>
        /// <param name="rozB"></param>
        public void NastavRozB(double rozB)
        {
            this.rozB = rozB;   
        }

        /// <summary>
        /// Dle zadaných hodnot v konstruktoru vypíše vlastnosti logaritmické funkce
        /// </summary>
        /// <returns></returns>
        public string Vlastnosti()
        {
            string pom;
            string rostKles;
            string oborH = "Oborem hodnot logaritmické funkce jsou všechna reálná čísla";
            string defO = "Definiční obor: (0;∞)";  
            if (a > 1) rostKles = "Funkce je rostoucí";
            else rostKles = "Funkce je klesající";
            pom = oborH + "\n" + defO + "\n" + rostKles;
            return pom;
        }
    }
}
