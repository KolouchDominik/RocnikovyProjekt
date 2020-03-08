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
        /// <summary>
        /// Konstruktor pro sinus a cosinus
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="rozA"></param>
        /// <param name="rozB"></param>
        /// <param name="pom"></param>
        /// <param name="graf"></param>
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
        /// <summary>
        /// Konstruktor pro tangens
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="rozA"></param>
        /// <param name="rozB"></param>
        /// <param name="pom"></param>
        /// <param name="graf"></param>
        public GoniometrickeFunkce(double a, double b, double rozA, double rozB, string pom, Chart graf)
        {
            this.a = a;
            this.b = b;
            this.rozA = rozA;
            this.rozB = rozB;
            this.pom = pom;
            this.graf = graf;
        }
        /// <summary>
        /// Konstruktor pro aktualizaci osy X
        /// </summary>
        public GoniometrickeFunkce()
        {

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
        /// Dle zadaných hodnot v konstruktoru vykreslí graf
        /// </summary>
        public void Vykresly()
        {



            if (pom == "sin")
            {
                graf.Series.Clear();
                graf.Series.Add("Goniometricka funkce");
                graf.Series["Goniometricka funkce"].ChartType = SeriesChartType.Line;

                for (double x = rozA; x < rozB; x += 0.1)
                {

                    graf.Series["Goniometricka funkce"].Points.AddXY(x, a * (Math.Sin(x * b)) + c);

                }
            }
            else if (pom == "cos")
            {
                graf.Series.Clear();
                graf.Series.Add("Goniometricka funkce");
                graf.Series["Goniometricka funkce"].ChartType = SeriesChartType.Line;

                for (double x = rozA; x < rozB; x += 0.1)
                {
                    graf.Series["Goniometricka funkce"].Points.AddXY(x, a * (Math.Cos(x * b)) + c);
                }
            }
            else    //Nutnost vytvořit nové serie bodů, kvůli chybám zarovnání osy x a spojování v bodech, které nejsou definované pro tangens
            {
                graf.Series.Clear();
                graf.Series.Add("Goniometricka funkce");
                graf.ChartAreas[0].AxisY.Minimum = -10;
                graf.ChartAreas[0].AxisY.Maximum = 10;
                string serie = "Gon";
                graf.Series.Add(serie);
                graf.Series[serie].ChartType = SeriesChartType.Line;
                int y = 2;

                for (double x = rozA; x < rozB; x = x + 0.1)
                {

                    graf.Series[serie].Points.AddXY(x, a * Math.Tan(x) + b);

                    if (Math.Tan(x + 0.1) < Math.Tan(x))
                    {
                        graf.Series.Add("Series" + y);
                        serie = "Series" + y;
                        graf.Series[serie].ChartType = SeriesChartType.Line;

                        ++y;
                    }
                }
            }
        }
        /// <summary>
        /// Dle zadaných hodnot v konstruktoru vypíše vlastnosti vybrané goniometrické funkce
        /// </summary>
        /// <returns></returns>
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
                string pomocny = "Definiční obor:\nvšechna reálná čísla / {π/2 + kπ} kde k je celé číslo\nObor hodnot: všechna reálná čísla" +
                    "\nRostoucí v každém intervalu:\n(-π/2+kπ; π/2+kπ) kde k je celé číslo\nNemá maximum ani minimum\nFunkce je lichá a neomezená";
                return pomocny;
            }
        }
    }
}
