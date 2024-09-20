using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookShop_CNPM.GUI;
using BookShop_CNPM.GUI.Importer;
using BookShop_CNPM.GUI.Manager;
using BookShop_CNPM.GUI.Modal;

namespace BookShop_CNPM
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

			Application.Run(LoginGUI.Instance);
        }
	}
}
