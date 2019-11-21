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
        private double zaklad;
        private double rozA;
        private double rozB;
        private double y;
        private Chart graf;

        public ExponencialniFunkce()
        {

        }

        public ExponencialniFunkce(double zaklad, double rozA, double rozB, Chart graf)
        {
            this.zaklad = zaklad;
            this.rozA = rozA;
            this.rozB = rozB;
            this.graf = graf;
        }

        public void Vykresli()
        {
            graf.Series["Exponenciální"].Points.Clear();
            for(double x = rozA;x <rozB;++x)
            {
                y = Math.Pow(zaklad, x);
                graf.Series["Exponenciální"].Points.AddXY(x, y);
            }
        }

    }
}
