using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Publisher
    {
        public Action Event { get; set; }

        public void Raise()
        {
            if (Event != null)
            {
                Event();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Publisher p = new Publisher();

            //p.Event += () => Console.WriteLine("Notify 1");
            //p.Event += () => Console.WriteLine("Notify 2");

            //p.Raise();

            //Console.ReadKey();
            Prime.Compare(156423514);
        }
    }
    class Prime
    {
        bool isPrime(int n)
        {
            int m = n / 2;
            for (int i = 2; i <= m; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        int sPrime1(int n)
        {
            for (int i = n - 1; i >= 2; i--)
            {
                if (isPrime(i))
                {
                    return i;
                }
            }
            return 1;
        }

        private bool[] MakeSieve(int max)
        {
            bool[] is_prime = new bool[max + 1];
            for (int i = 2; i <= max; i++) is_prime[i] = true;

            for (int i = 2; i <= max; i++)
            {
                if (is_prime[i])
                {
                    for (int j = i * 2; j <= max; j += i)
                        is_prime[j] = false;
                }
            }
            return is_prime;
        }

        int sPrime2(int n)
        {
            bool[] sieve = MakeSieve(n);
            for(int i = n - 1; i >= 2; i--)
            {
                if (sieve[i] == true)
                    return i;
            }
            return 1;
        }

        public static void Compare(int n)
        {
            Prime p = new Prime();
            Thread t1 = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Console.WriteLine("Start fir: " + Thread.CurrentThread.Name + " " + DateTime.Now.ToString("hh:mm:s:ms") + " Numar natural dat = " + n);
                int result = p.sPrime1(n);
                Console.WriteLine("End fir: " + Thread.CurrentThread.Name + " " + DateTime.Now.ToString("hh:mm:s:ms") + " Numar prim = " +result);
            });
            t1.Name = "method 1";
            Thread t2 = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Console.WriteLine("Start fir: " + Thread.CurrentThread.Name + " " + DateTime.Now.ToString("hh:mm:s:ms") + " Numar natural dat = " + n);
                int result = p.sPrime2(n);
                Console.WriteLine("End fir: " + Thread.CurrentThread.Name + " " + DateTime.Now.ToString("hh:mm:s:ms") + " Numar prim = " + result);
            });
            t2.Name = "method 2";

            t1.Start();
            t2.Start();

            Console.ReadKey();

        }
    }

}
