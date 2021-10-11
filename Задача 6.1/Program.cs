using System;
using System.Text;

namespace Задача_6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Polynomial polynomial1 = new Polynomial("5x^0+-2x^2");
            Polynomial polynomial2 = new Polynomial("10x^2+1x^3+-3x^4");

            polynomial2[2] = 0;

            Console.WriteLine(polynomial1.ToString());
            Console.WriteLine(polynomial2.ToString());

            Console.WriteLine();
            polynomial1.Add(polynomial2);
            Console.WriteLine(polynomial1.ToString());

            Console.ReadKey();
        }
    }
}