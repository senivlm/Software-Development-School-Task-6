using System;

namespace Задача_6._2
{
    public class Record
    {
        public string Ip;
        public DateTime DateTime;
        public string Day;

        public Record(string ip, DateTime dateTime, string day)
        {
            Ip = ip ?? throw new ArgumentNullException(nameof(ip));
            DateTime = dateTime;
            Day = day ?? throw new ArgumentNullException(nameof(day));
        }
    }
}