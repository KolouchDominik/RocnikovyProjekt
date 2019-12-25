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
        private Chart graf;
        private double vyska;
        double pom;


        public GoniometrickeFunkce(double a, double b, double c, Chart graf)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.graf = graf;
        }


        private bool kontrola()
        {
            double[] strany = { a, b, c };
            if (strany.Sum() - strany.Max() > strany.Max()) return true;
            else return false;
        }

            

        public string vypocet()
        {
            if (kontrola())
            {

                double alpha = Math.Acos((b * b + c * c - a * a) / (2 * b * c)) * (180 / Math.PI);
                double beta = Math.Acos((a * a + c * c - b * b) / (2 * a * c)) * (180 / Math.PI);
                double gamma = 180 - alpha - beta;

                 
                


                return "Alpha: " + alpha + "°\nBeta: " + beta + "°\nGamma: " + gamma + "°";

            }


            else return "součet dvou kratších stran \nmusí být větší než strana nejdelší";
        }

        
    }
}
