using DesignFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test Model Designer First");
            TestMedia();
            Console.ReadKey();
        }
        static void TestMedia()
        {
            using (Model1Container context = new Model1Container())
            {
                Media m = new Media();
                m.Path = "PATH1";
                context.Media.Add(m);
                context.SaveChanges();
                var items = context.Media;
                foreach (var x in items)
                {
                    Console.WriteLine("{0} {1}", x.Id, x.Path);
                }
            }
        }
    }
}
