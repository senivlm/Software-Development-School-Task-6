using System;

namespace Задача_6._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(3, 3);

            foreach (int numb in matrix)
            {
                Console.WriteLine(numb);
            }
        }
    }
}
