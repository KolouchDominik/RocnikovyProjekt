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
        //****************************************************************
        public KvadratickaFunkce()
        {

        }
        //*****************************************************************

        


        public void NastavRozA(double rozA)
        {
            this.rozA = rozA;
        }
        public void NastavRozB(double rozB)
        {
            this.rozB = rozB;
        }
        public void Vykresli()
        {
            graf.Series["Kvadraticka funkce"].Points.Clear();
            

            for (double x = rozA; x <= rozB; x=x+0.5)
            {
                double y = a * (x * x) + b * x + c;
                graf.Series["Kvadraticka funkce"].Points.AddXY(x, y);
            }
            
            
        }
        //************************************************************************
        public double Koreny(out double x2, out bool ResVR)
        {
            x2 = 0;

            D = b * b - 4 * a * c;
            if (D == 0)
            {
                x1 = -b / (2 * a);
                x2 = x1;
                ResVR = true;
            }
            else if (D > 0)
            {
                x1 = (-b + Math.Sqrt(D)) / (2 * a);
                x2 = (-b - Math.Sqrt(D)) / (2 * a);
                ResVR = true;
            }
            else ResVR = false;
            
            return x1;
        }
        //**************************************************************************
        public string VrcholXY()
        {
            double VrcholX = 0;
            double VrcholY = 0;
            if (a > 0)
            {
                VrcholX = -b /(2*a);
                VrcholY = -((b * b) / (4 * a)) + c;
                return "[" + VrcholX + ";" + VrcholY + "]";
            }

            else
            {
                VrcholX = -b / (2 * a);
                VrcholY = -((b * b) / (4 * a)) + c;
                return "[" + VrcholX + ";" + VrcholY + "]";
            }
        }
        //*****************************************************************************
        public string Definicni_obor()
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
        public string MaxMin()
        {
            if (a > 0)
            {
                return "V bodě x = " + (-(b / 2 / a) + " má funkce minimum \nFunkce nemá maximum");
            }
            else return "V bodě x = " + (-(b / 2 / a) + " má funkce maximum \nFunkce nemá minimum");
        }
    }
}
