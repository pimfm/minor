using System;
using System.Threading;

namespace Minor_Dag41
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Thread thread = new Thread(PrintHelloWorld);
            thread.Start();
        }

        public static void PrintHelloWorld()
        {
            Console.WriteLine("Hello, World");
        }
    }
}
