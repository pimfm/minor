using System;
using System.Threading;

namespace DockerHelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            for (int i = 1; i <= int.Parse(args[0]); i++)
            {
                Console.WriteLine($"Hello, World {i}");
                Thread.Sleep(500);
            }
        }
    }
}
