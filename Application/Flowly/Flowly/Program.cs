using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flowly
{
    /// <summary>
    /// This namespace contains all the classes that the Flowly Windows forms uses. 
    /// Inside there are brief descriptions of each class and their methods.
    /// </summary>
    public static class NamespaceDoc
    {
        //this is used for sandcastle
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
