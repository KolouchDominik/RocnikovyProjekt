using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Rocnikovy_projekt
{
    class KvadratickaFunkce
    {
        private double a;
        private double b;
        private double c;
        private Chart graf;
        private double rozA;
        private double rozB;

        private double D, x1, x2;
        
        
        public KvadratickaFunkce(double a, double b, double c, Chart graf,double rozA, double rozB)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.graf = graf;
            this.rozA = rozA;
            this.rozB = rozB;
        }
        /// <summary>
        /// Konstruktor pro nastavení osy X
        /// </summary>
        public KvadratickaFunkce()
        {

        }
        //*****************************************************************

        

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
        public void Vykresli()
        {
            graf.Series["Kvadraticka funkce"].Points.Clear();
            for (double x = rozA; x <= rozB; x=x+0.1)
            {
                double y = a * (x * x) + b * x + c;
                graf.Series["Kvadraticka funkce"].Points.AddXY(x, y);
            }
        }
        //************************************************************************
        private string Koreny()
        {
            x1 = 0;
            x2 = 0;
            string pom;

            D = b * b - 4 * a * c;
            if (D == 0)
            {
                x1 = -b / (2 * a);
                return pom = "Rovnice má 1 reálný kořen: " + x1;
            }
            else if (D > 0)
            {
                x1 = (-b + Math.Sqrt(D)) / (2 * a);
                x2 = (-b - Math.Sqrt(D)) / (2 * a);
                return pom = "Rovnice má 2 reálné kořeny: "+"\nX1: "
                        +Math.Round(x1,5) + "\nX2: " + Math.Round(x2,5);
            }
            else return pom = "Rovnice nemá reálný kořen";
        }

        /// <summary>
        /// Dle zadaných hodnot v konstruktoru vypíše vlastnosti kvadratické funkce;
        /// </summary>
        /// <returns></returns>
        public string Vlastnosti()
        {
            string pom;
            pom = Koreny() + "\nVrchol v bodě: " + VrcholXY() + "\nDefiniční obor: " + Definicni_obor()+"\n"+MaxMin();
            return pom;
        }



        //**************************************************************************
        private string VrcholXY()
        {
            double VrcholX = 0;
            double VrcholY = 0;
            string pom;
            VrcholX = -b / (2 * a);
            VrcholY = -((b * b) / (4 * a)) + c;
            return pom=  "[" + VrcholX + ";" + VrcholY + "]";
            
        }
        //*****************************************************************************
        private string Definicni_obor()
        {
            if(a>0)
            {
                return "<" + (c - ((b * b / (4 * a)))) + ";∞)";
            }
            else
            {
                return "(-∞;" + (c - ((b * b / (4 * a)))) + ">";
            } 
        }
        //****************************************************************************
        private string MaxMin()
        {
            if (a > 0)
            {
                return "V bodě x = " + (-(b / 2 / a) + " má funkce minimum \nFunkce nemá maximum");
            }
            else return "V bodě x = " + (-(b / 2 / a) + " má funkce maximum \nFunkce nemá minimum");

        }
    }
}
