using System;

namespace Задача_6._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введіть шлях до файлу: ");
            string filePath = Console.ReadLine();

            WeeklyAttendanceStatictics statictics = new WeeklyAttendanceStatictics(filePath);
            Console.WriteLine(statictics.GetEachIpWeaklyAttendance());
            Console.WriteLine(statictics.GetEachIpMostPopularWeekday());
        }
    }
}
