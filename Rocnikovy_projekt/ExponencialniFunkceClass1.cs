﻿using System;
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

        public ExponencialniFunkce(double a, double b, double c, Chart graf, double rozA, double rozB)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.rozA = rozA;
            this.rozB = rozB;
            this.graf = graf;
        }

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

            graf.Series["Exponencialni funkce"].Points.Clear();

            for (   double x = rozA; x < rozB; x = x + 0.1) 
            {
                y = Math.Pow(a, x - b) + c;
                graf.Series["Exponencialni funkce"].Points.AddXY(x, y);
            }
        }

     

        public string Vlastnosti_ExpFun()
        {
            string pom;

            if (Rostouci()) pom = "roustoucí \nZdola omezená";
            else pom = "klesající \nZdola omezená";

            string vlastnosti = "Definiční obor: všechna reálná čísla" + "\nObor hodnot: "+ "("+ c +";∞)"+"\n"+pom + "\nNemá maximum ani minimum";
            return vlastnosti;
        }
        //**********************************************************
        private bool Rostouci()
        {
            if (a > 1) return true;
            else return false;
        }
        
        
    
    }
}
