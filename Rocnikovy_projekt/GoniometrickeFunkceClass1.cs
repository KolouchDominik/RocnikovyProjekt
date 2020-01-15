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
        private double alpha;
        private double beta;
        private double gamma;
        private Chart graf;
        private double vyska;
        private double prepona;
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
            prepona = strany.Max();
            if (strany.Sum() - strany.Max() > strany.Max()) return true;
            else return false;
        }

            
        
        public string vypocet()
        {
            if (kontrola())
            {

                alpha = Math.Acos((b * b + c * c - a * a) / (2 * b * c)) * (180 / Math.PI);
                beta = Math.Acos((a * a + c * c - b * b) / (2 * a * c)) * (180 / Math.PI);
                gamma = 180 - alpha - beta;
                double SouVysky = SouVysky_delka(out vyska);

                
                graf.Series["Goniometricka funkce"].Points.Clear();
                graf.Series["Goniometricka funkce"].Points.AddXY(0, 0);
                graf.Series["Goniometricka funkce"].Points.AddXY(c, 0);
                graf.Series["Goniometricka funkce"].Points.AddXY(SouVysky,vyska);
                graf.Series["Goniometricka funkce"].Points.AddXY(0, 0);

                

                    
                graf.ChartAreas["ChartArea1"].AxisY.Maximum =c+1;
                graf.ChartAreas["ChartArea1"].AxisY.Minimum = -1;
                graf.ChartAreas["ChartArea1"].AxisY.Interval = 1;
                graf.ChartAreas["ChartArea1"].AxisX.Maximum = c+1;
                graf.ChartAreas["ChartArea1"].AxisX.Minimum = -1;
                graf.ChartAreas["ChartArea1"].AxisX.Interval = 1;

                return "Alpha: " + alpha + "°\nBeta: " + beta + "°\nGamma: " + gamma + "°";
            }
            else return "součet dvou kratších stran \n  musí být větší než strana nejdelší";
        }

        private double SouVysky_delka(out double vyska)
        {
            double p = (a + b + c) / 2; //poloviční obvod
            vyska = (2 / a) * Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            double SouXVysky = Math.Sqrt((b * b) - (vyska * vyska));
            return SouXVysky;
        }
    }
}
