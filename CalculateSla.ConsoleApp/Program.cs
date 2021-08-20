using System;
using System.Collections.Generic;

namespace CalculateSla.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {




            List<DayOfWeek> BworkingDays = new List<DayOfWeek>();
            BworkingDays.Add(DayOfWeek.Monday);
            BworkingDays.Add(DayOfWeek.Tuesday);
            BworkingDays.Add(DayOfWeek.Wednesday);
            BworkingDays.Add(DayOfWeek.Thursday);
            BworkingDays.Add(DayOfWeek.Friday);
            //BworkingDays.Add(DayOfWeek.Saturday);
            //BworkingDays.Add(DayOfWeek.Sunday);

            var BSlaStartAt = new DateTime(2021, 08, 13, 0,0, 0);
            var Bhours = 5 ;
            var BWorkingTimeStart = new TimeSpan(0, 0, 0);
            var BWorkingTimeEnd = new TimeSpan(0, 0, 0);

            var BOnDutyTimeStart = new TimeSpan(19, 0, 0);
            var BOnDutyTimeEnd = new TimeSpan(3, 0, 0);

            CalculateSlaService.CalculateSla(BSlaStartAt, BworkingDays, Bhours, BWorkingTimeStart, BWorkingTimeEnd, BOnDutyTimeStart, BOnDutyTimeEnd, null);

        }





    }
}
