using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Rocnikovy_projekt
{
    class ExponencialniFunkce
    {
        private double a;
        private double b;
        private double c;
        private double rozA;
        private double rozB;
        private double y;
        private Chart graf;

        public ExponencialniFunkce()
        {

        }

        public ExponencialniFunkce(double a, double b,double c, Chart graf, double rozA,double rozB)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.rozA = rozA;
            this.rozB = rozB;
            this.graf = graf;
        }

        public void Vykresli()
        {
            graf.Series["Exponenciální"].Points.Clear();
            for(double x = rozA;x <rozB;++x)
            {
                y = Math.Pow(a, x-b)+c;
                graf.Series["Exponenciální"].Points.AddXY(x, y);
            }
        }

    }
}
