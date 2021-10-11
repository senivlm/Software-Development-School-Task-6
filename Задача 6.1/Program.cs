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

            Console.WriteLine(polynomial1);
            Console.WriteLine(polynomial2 + "\n");

            Polynomial polynomial3 = polynomial1 + polynomial2;
            Polynomial polynomial4 = polynomial1 - polynomial2;
            Polynomial polynomial5 = polynomial1 * polynomial2;

            Console.WriteLine(polynomial3);
            Console.WriteLine(polynomial4);
            Console.WriteLine(polynomial5);

            double x = 5.2;
            Polynomial polynomial6 = x;
            Console.WriteLine("\n" + polynomial6);

            Console.ReadKey();
        }
    }
}