using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFstudii
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //AddToDB();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void AddToDB()
        {
            using (var m = new Model1())
            {
                SelfReference s1 = new SelfReference() { Name = "Alex" };
                SelfReference s2 = new SelfReference() { Name = "Andrei" };
                SelfReference s3 = new SelfReference() { Name = "Bogdan" };
                SelfReference s4 = new SelfReference() { Name = "Cezar" };
                SelfReference s5 = new SelfReference() { Name = "Darius" };
                SelfReference s6 = new SelfReference() { Name = "Eugen" };
                SelfReference s7 = new SelfReference() { Name = "Florin" };

                m.SelfReferences.Add(s1);
                m.SelfReferences.Add(s2);
                m.SelfReferences.Add(s3);
                m.SelfReferences.Add(s4);
                m.SelfReferences.Add(s5);
                m.SelfReferences.Add(s6);
                m.SelfReferences.Add(s7);

                m.SaveChanges();

                s1.SelfReference2 = s7;
                s2.SelfReference2 = s7;
                s3.SelfReference2 = s6;
                s4.SelfReference2 = s6;
                s5.SelfReference2 = s2;
                s6.SelfReference2 = s2;
                s7.SelfReference2 = s1;

                m.SaveChanges();
            }
        }
    }
}
