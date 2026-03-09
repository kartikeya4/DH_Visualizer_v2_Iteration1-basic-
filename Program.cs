using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DH_Visualizer_v2.View;
using DH_Visualizer_v2.Modal;
using DH_Visualizer_v2.Controller;

namespace DH_Visualizer_v2
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
            
            var View = new Form1();
            var Modal = new Modal.RobotModal();
            var Controller = new RobotController(View, Modal);

            Controller.Initialize();
            
            Application.Run(View);
        }
    }
}
