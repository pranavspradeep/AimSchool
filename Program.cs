using SecureApp;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SchoolManagement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           // Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string path = @"Aimsoft\pranav\Protection";
            Secure scr = new Secure();
            bool logic = scr.Algorithm("Aimsoft@2018", path);
            if (logic == true)
                // Application.Run(new Otherfees());
                Application.Run(new Login());
            //Application.Run(new Student());
          //  Application.Run(new Smstoparents());
            //Application.Run(new AllFeecollectedrpt());
            //Application.Run(new Student_Promotion());            
        }
    }
}