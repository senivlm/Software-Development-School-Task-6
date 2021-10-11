using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Задача_6._2
{
    public class WeeklyAttendanceStatictics
    {
        private List<Record> records;
        private List<Record> uniqueRecords;

        public WeeklyAttendanceStatictics(string filePath)
        {
            records = new List<Record>();
            ReadFromFile(filePath);

            uniqueRecords = records.GroupBy(record => record.Ip).Select(x => x.First()).ToList();
        }

        public string GetEachIpWeaklyAttendance()
        {
            string result = "\nКількість відвідувань на тиждень для кожного ip:\n";

            foreach(Record record in uniqueRecords)
            {
                result += record.Ip + " - " + GetIpWeaklyAttendance(record.Ip) + "\n";
            }

            return result;
        }

        public string GetEachIpMostPopularWeekday()
        {
            string result = "\nНайбільш популярний день тижня для кожного ip:\n";

            foreach (Record record in uniqueRecords)
            {
                result += record.Ip + " - " + GetIpMostPopularWeekday(record.Ip) + "\n";
            }

            return result;
        }

        private string GetIpMostPopularWeekday(string ip)
        {
            return records.Where(x => x.Ip == ip).ToList()
                            .GroupBy(x => x.Day)
                            .OrderByDescending(i => i.Count())
                            .First().Key;
        }

        private int GetIpWeaklyAttendance(string ip)
        {
            int count = 0;

            foreach (Record record in records)
                if (record.Ip == ip)
                    count++;

            return count;
        }

        private void ReadFromFile(string filePath)
        {
            try
            {
                using (StreamReader inputFile = new StreamReader(filePath))
                {
                    string line;
                    while((line = inputFile.ReadLine()) != null)
                    {
                        string[] recordText = line.Split();

                        string ip = recordText[0];
                        DateTime dateTime = DateTime.ParseExact(recordText[1], "HH:mm:ss", CultureInfo.InvariantCulture);
                        string day = recordText[2];

                        records.Add(new Record(ip, dateTime, day));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Помилка відкриття файлу. Перевірте правильність введеного шляху і назви файлу.");
                Console.WriteLine(e.Message);
            }
        }
    }
}
