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
                int j = 0;
                for (double x = rozA; x < rozB; x += 0.1)
                {
                    graf.Series["Goniometricka funkce"].Points.AddXY(x, a *(Math.Sin(x * b)) + c);
                    
                }
            }
            else if(pom == "cos")
            {
                for (double x = rozA; x < rozB; x += 0.1)
                {
                    graf.Series["Goniometricka funkce"].Points.AddXY(x, a * (Math.Cos(x * b)) + c);
                }
            }
            else
            {
                string serie = "Goniometricka funkce";
                int y = 2;

                for (double x = 0; x <3; x = x + 0.1)
                {
                    graf.Series[serie].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    graf.ChartAreas[0].AxisY.Minimum = -10;
                    graf.ChartAreas[0].AxisY.Maximum = 10;
                    graf.Series[serie].Points.AddXY(x, Math.Tan(x));

                    if (Math.Tan(x + 0.1) < Math.Tan(x))
                    {
                        graf.Series.Add("Series" + y);
                        serie = "Series" + y;
                        ++y;
                    }

                    // draw graph for all those x with lower < x < upper

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
            else if (pom == "cos")
            {
                string pomocny = "Definiční obor: všechna reálná čísla\nObor hodnot je interval: <"
                    + a + ";" + (-a) + ">\nMaximum v bodě: 2kπ kde k je celé číslo\n" +
                    "Minimum v bodě: π+2kπ kde k je celé číslo \nFunkce je sudá a omezená";
                return pomocny;
            }
            else
            {
                string pomocny = "Definiční obor: všechna reálná čísla / {π/2 + kπ} kde k je celé číslo\nObor hodnot je interval: všechna reálná čísla" +
                    "\nRostoucí v každém intervalu(-π/2+kπ; π/2+kπ) kde k je celé číslo\nNemá maximum ani minimum\nFunkce je lichá a neomezená";
                return pomocny;
            }

        }
    }
}
