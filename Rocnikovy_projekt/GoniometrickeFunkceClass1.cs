using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Rocnikovy_projekt
{
    class GoniometrickeFunkce
    {
        private double a;
        private double b;
        private double c;
        private double rozA;
        private double rozB;
        private string pom;
        private Chart graf;

        public GoniometrickeFunkce(double a, double b, double c, double rozA, double rozB, string pom, Chart graf)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.rozA = rozA;
            this.rozB = rozB;
            this.pom = pom;
            this.graf = graf;
        }

        public void Vykresly()
        {
            graf.Series["Goniometricka funkce"].Points.Clear();
            if (pom == "sin")
            {
                for (double x = rozA; x < rozB; x += 0.1)
                {
                    graf.Series["Goniometricka funkce"].Points.AddXY(x, a *(Math.Sin(x * b)) + c);
                }
            }
            else
            {
                for (double x = rozA; x < rozB; x += 0.1)
                {
                    graf.Series["Goniometricka funkce"].Points.AddXY(x, a * (Math.Cos(x * b)) + c);
                }
            }
        }

        public string Vlastnosit()
        {
            if (pom == "sin")
            {
                string pomocny = "Definiční obor: všechna reálná čísla\nObor hodnot je interval: <"
                    + a + ";" + (-a) + ">\nMaximum v bodě: π/2+2kπ kde k je celé číslo \n" +
                    "Minimum v bodě: -π/2+2kπ kde k je celé číslo\nFunkce je lichá a omezená";
                return pomocny;
            }
            else
            {
                string pomocny = "Definiční obor: všechna reálná čísla\nObor hodnot je interval: <"
                    + a + ";" + (-a) + ">\nMaximum v bodě: 2kπ kde k je celé číslo\n" +
                    "Minimum v bodě: π+2kπ kde k je celé číslo \nFunkce je sudá a omezená";
                return pomocny;
            }

        }
    }
}
