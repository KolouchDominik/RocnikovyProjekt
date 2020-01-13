using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Rocnikovy_projekt
{
    class LogaritmickaFunkce
    {
        private double a;
        private double n;
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

        public void Vykresly()
        {
            if (Kontrola())
            {
                for (double x = rozA; x < rozB; x=x+0.1)
                {
                    double y = Math.Log(x, a);
                    graf.Series["Logaritmicka funkce"].Points.AddXY(x, y);
                }
            }
        }

        public void NastavRozA(double rozA)
        {
            this.rozA = rozA;
        }

        public void NastavRozB(double rozB)
        {
            this.rozB = rozB;   
        }

        public string Vlastnosti()
        {
            string pom = "";
            string rostKles = "";
            string oborH = "Oborem hodnot logaritmické funkce jsou všechna reálná čísla";
            string defO = "Definiční obor: (0;∞)";  
            if (a > 1) rostKles = "Funkce je rostoucí";
            else rostKles = "Funkce je klesající";
            pom = oborH + "\n" + defO + "\n" + rostKles;
            return pom;
        }
    }
}
