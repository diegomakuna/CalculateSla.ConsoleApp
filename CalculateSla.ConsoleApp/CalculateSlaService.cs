using System;
using System.Collections.Generic;
using System.Text;

namespace CalculateSla.ConsoleApp
{
    public static class CalculateSlaService
    {
        public static void Calculate(DateTime date, List<DayOfWeek> workingDays, int hours, TimeSpan startHour, TimeSpan endHour, TimeSpan OnDutyTimeStart, TimeSpan OnDutyTimeEnd, List<DateTime> holidays)
        {

            var day = new TimeSpan(24, 0, 0);
            var workHourPerDay = endHour.Subtract(startHour);
            var workOnDutyPerDays = OnDutyTimeEnd < OnDutyTimeStart ? ((day.Subtract(OnDutyTimeStart)) + OnDutyTimeEnd) : OnDutyTimeEnd.Subtract(OnDutyTimeStart);

            var totalworkperday = workHourPerDay + workOnDutyPerDays;

            var totalDays = TimeSpan.FromHours(hours);

            Console.WriteLine("Normal = " + startHour + " as " + endHour);

            Console.WriteLine("Plantao = " + OnDutyTimeStart + " as " + OnDutyTimeEnd);

            var delivery = new DateTime(date.Ticks);

            Console.WriteLine("------------------------------------------------\n");



            Console.WriteLine("TOTAL de HORAS " + totalDays);


            delivery = CalcTime(date, new TimeSpan(1, 0, 0), totalDays, delivery, startHour, endHour, OnDutyTimeStart, OnDutyTimeEnd, workingDays);

           
            Console.WriteLine("START = " + date);
            Console.WriteLine("ENTREGA = " + delivery);
            

            Console.WriteLine("------------------------------------------------\n");
        }

        private static bool calcRange(DateTime slaStart, DateTime delivery, TimeSpan startHour, TimeSpan endHour, TimeSpan OnDutyTimeStart, TimeSpan OnDutyTimeEnd)
        {

            var rangeStartHour = RangeDateStart(delivery, startHour, endHour);
            var rangeEndtHour = RangeDateEnd(delivery, startHour, endHour);

            var rangeStartDutyHour = RangeDateStart(delivery, OnDutyTimeStart, OnDutyTimeEnd);
            var rangeEndDutyHour = RangeDateEnd(delivery, OnDutyTimeStart, OnDutyTimeEnd);


            return (delivery >= rangeStartHour && delivery < rangeEndtHour) || (delivery >= rangeStartDutyHour && delivery < rangeEndDutyHour);
        }

        public static DateTime RangeDateStart(DateTime currentdate, TimeSpan start, TimeSpan end)
        {

            var day = new TimeSpan(24, 0, 0);

            var ch = (end - start);

            var h = ch < TimeSpan.Zero ? ch + day : ch;

            return currentdate.TimeOfDay > TimeSpan.FromHours(12) ? currentdate.AddHours(-(currentdate.TimeOfDay.Hours - start.Hours)) : currentdate.Add((end - currentdate.TimeOfDay)).AddHours(-h.Hours);

        }

        public static DateTime RangeDateEnd(DateTime currentdate, TimeSpan start, TimeSpan end)
        {

            var day = new TimeSpan(24, 0, 0);

            var ch = (end - start);

            var h = ch < TimeSpan.Zero ? ch + day : ch;

            var s = currentdate.TimeOfDay > TimeSpan.FromHours(12) ? currentdate.AddHours(-(currentdate.TimeOfDay.Hours - start.Hours)) : currentdate.Add((end - currentdate.TimeOfDay)).AddHours(-h.Hours);

            return s.AddHours(h.Hours);

        }

        private static DateTime CalcTime(DateTime slaStart, TimeSpan time, TimeSpan totalDays, DateTime delivery, TimeSpan startHour, TimeSpan endHour, TimeSpan OnDutyTimeStart, TimeSpan OnDutyTimeEnd, List<DayOfWeek> workingDays, bool blocked = false)
        {
            var timeLeft = TimeSpan.Zero;
            while (timeLeft < totalDays)
            {

                if (!workingDays.Contains(RangeDateStart(delivery, startHour, endHour).DayOfWeek) && !workingDays.Contains(RangeDateStart(delivery, OnDutyTimeStart, OnDutyTimeEnd).DayOfWeek))
                {
                    delivery = delivery.AddDays(1);
                    delivery = new DateTime(delivery.Year, delivery.Month, delivery.Day, startHour.Hours, endHour.Minutes, 0);
                    continue;
                }

                if (calcRange(slaStart, delivery, startHour, endHour, OnDutyTimeStart, OnDutyTimeEnd))

                {

                    if (timeLeft.Add(time) >= totalDays && !blocked)
                    {

                        delivery = CalcTime(slaStart, new TimeSpan(0, 1, 0), time, delivery, startHour, endHour, OnDutyTimeStart, OnDutyTimeEnd, workingDays, true);

                    }
                    else
                    {

                        delivery = delivery.Add(time);
                    }

                    timeLeft = timeLeft.Add(time);


                }
                else
                {

                    delivery = delivery.Add(new TimeSpan(1, 0, 0));
                    if (!workingDays.Contains(delivery.DayOfWeek))
                    {
                        delivery = delivery.AddDays(1);
                    }
                }



            }

            return delivery;
        }




    }
}
