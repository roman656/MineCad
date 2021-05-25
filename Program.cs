using System;
using System.Runtime.ExceptionServices;
using System.Windows.Forms;

namespace MineCad
{
    static class Program
    {
        [STAThread]
        [HandleProcessCorruptedStateExceptions]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
