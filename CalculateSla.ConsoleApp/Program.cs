using System;
using System.Collections.Generic;

namespace CalculateSla.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<DayOfWeek> workingDays = new List<DayOfWeek>();
            //workingDays.Add(DayOfWeek.Monday);
            //workingDays.Add(DayOfWeek.Tuesday);
            //workingDays.Add(DayOfWeek.Wednesday);
            //workingDays.Add(DayOfWeek.Thursday);
            //workingDays.Add(DayOfWeek.Friday);


            //var SlaStartAt = new DateTime(2021, 08, 13, 16, 50, 0);
            //var hours = 1;
            //var WorkingTimeStart = new TimeSpan(7, 0, 0);
            //var WorkingTimeEnd = new TimeSpan(17, 0, 0);

            //var OnDutyTimeStart = new TimeSpan(19, 0, 0);
            //var OnDutyTimeEnd = new TimeSpan(2, 0, 0);
            //CalculateSlaService.Calculate(SlaStartAt, workingDays, hours, WorkingTimeStart, WorkingTimeEnd, OnDutyTimeStart, OnDutyTimeEnd, null);

            //Console.WriteLine("---------------------------------------------------------------------------");
            //Console.WriteLine("---------------------------------------------------------------------------");
            //Console.WriteLine("---------------------------------------------------------------------------");
            //Console.WriteLine("---------------------------------------------------------------------------");


            //List<DayOfWeek> AworkingDays = new List<DayOfWeek>();
            //AworkingDays.Add(DayOfWeek.Monday);
            //AworkingDays.Add(DayOfWeek.Tuesday);
            //AworkingDays.Add(DayOfWeek.Wednesday);
            //AworkingDays.Add(DayOfWeek.Thursday);
            //AworkingDays.Add(DayOfWeek.Friday);

            //var ASlaStartAt = new DateTime(2021, 08, 13, 16, 50, 0);
            //var Ahours = 10;
            //var AWorkingTimeStart = new TimeSpan(7, 0, 0);
            //var AWorkingTimeEnd = new TimeSpan(17, 0, 0);

            //var AOnDutyTimeStart = new TimeSpan(19, 0, 0);
            //var AOnDutyTimeEnd = new TimeSpan(2, 0, 0);
            //CalculateSlaService.Calculate(ASlaStartAt, AworkingDays, Ahours, AWorkingTimeStart, AWorkingTimeEnd, AOnDutyTimeStart, AOnDutyTimeEnd, null);

            //Console.WriteLine("---------------------------------------------------------------------------");


            //Console.WriteLine("---------------------------------------------------------------------------");
            //Console.WriteLine("---------------------------------------------------------------------------");
            //Console.WriteLine("---------------------------------------------------------------------------");
            //Console.WriteLine("---------------------------------------------------------------------------");


            List<DayOfWeek> BworkingDays = new List<DayOfWeek>();
            BworkingDays.Add(DayOfWeek.Monday);
            //BworkingDays.Add(DayOfWeek.Tuesday);
           // BworkingDays.Add(DayOfWeek.Wednesday);
            BworkingDays.Add(DayOfWeek.Thursday);
            BworkingDays.Add(DayOfWeek.Friday);
            BworkingDays.Add(DayOfWeek.Saturday);
            BworkingDays.Add(DayOfWeek.Sunday);

            var BSlaStartAt = new DateTime(2021, 08, 9, 12, 59, 0);
            var Bhours = 19;
            var BWorkingTimeStart = new TimeSpan(7, 0, 0);
            var BWorkingTimeEnd = new TimeSpan(17, 0, 0);

            var BOnDutyTimeStart = new TimeSpan(20, 0, 0);
            var BOnDutyTimeEnd = new TimeSpan(0, 0, 0);
            CalculateSlaService.Calculate(BSlaStartAt, BworkingDays, Bhours, BWorkingTimeStart, BWorkingTimeEnd, BOnDutyTimeStart, BOnDutyTimeEnd, null);

            Console.WriteLine("---------------------------------------------------------------------------");
        }
    }
}
