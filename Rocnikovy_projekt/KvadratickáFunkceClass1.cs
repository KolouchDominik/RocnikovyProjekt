using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Rocnikovy_projekt
{
    class KvadratickáFunkce
    {
        private double a;
        private double b;
        private double c;
        private Chart graf;
        public double RozA;
        public double RozB;

        private double D, x1, x2;
        private ChartArea CA;
        
        
        public KvadratickáFunkce(double a, double b, double c, Chart graf,double RozA, double RozB)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.graf = graf;
            this.RozA = RozA;
            this.RozB = RozB;
        }
        //****************************************************************
        public KvadratickáFunkce()
        {

        }
        //*****************************************************************

        
        public void Vykresli()
        {

            double PrvniY=RozA, PosledniY = 0;
            graf.Series["Kvadraticka funkce"].Points.Clear();

            if (a > 0)
            {

                for (double x = RozA; x <= RozB; ++x)
                {
                    double y = a * (x * x) + b * x + c;
                    graf.Series["Kvadraticka funkce"].Points.AddXY(x, y);
                    if(x==RozB)
                    {
                        PosledniY = x;
                    }
                }
            }
            else
            {


                for (double x = RozA; x <= RozB; ++x)
                {
                    double y = a * (x * x) + b * x + c;
                    graf.Series["Kvadraticka funkce"].Points.AddXY(x, y);
                    if (x == RozB)
                    {
                        PosledniY = x;
                    }
                }
            }

            CA = graf.ChartAreas[0];
            CA.CursorY.IsUserSelectionEnabled = true;
            CA.AxisY.ScaleView.Zoom(PrvniY,PosledniY);
            CA.AxisY.ScaleView.SizeType = DateTimeIntervalType.Number;
            CA.AxisY.ScaleView.Zoomable = true;
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
