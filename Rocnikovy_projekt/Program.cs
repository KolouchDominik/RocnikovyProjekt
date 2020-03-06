using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rocnikovy_projekt
{
    static class Program
    {
        /// <summary>
        /// Hlavní vstupní bod aplikace.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(ReseniChyb);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


           
        }
        private static void ReseniChyb(object sender, ThreadExceptionEventArgs t)
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch
            { 
                MessageBox.Show("Chybička se vloudila!\nRozsah osy X má příliš mnoho bodů k vykreslení!\nZmenšete rozsah osy X");
                Application.Restart();
            }
        }

    }
}
