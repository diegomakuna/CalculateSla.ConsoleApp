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

            Console.WriteLine("Normal = " + OnDutyTimeStart + " as " + OnDutyTimeEnd);

            var delivery = new DateTime(date.Ticks);

            Console.WriteLine("Start = " + date);

            Console.WriteLine("------------------------------------------------\n");



            Console.WriteLine("TOTAL de HORAS " + totalDays);


            delivery = CalcTime(date, new TimeSpan(1, 0, 0), totalDays, delivery, startHour, endHour, OnDutyTimeStart, OnDutyTimeEnd, workingDays);

            #region old Code
            //var OneHour = new TimeSpan(1, 0, 0);

            //var timeLeft = TimeSpan.Zero;
            //while (timeLeft != totalDays)
            //{

            //    var endOndute = new DateTime(delivery.Year, delivery.Month, delivery.Day, OnDutyTimeStart.Hours, OnDutyTimeStart.Minutes, 0).AddHours((day.Subtract(OnDutyTimeStart) + OnDutyTimeEnd).Hours);
            //    if(calRange(delivery, startHour, endHour, OnDutyTimeStart, OnDutyTimeEnd))
            //    {

            //        timeLeft = timeLeft.Add(OneHour);
            //        delivery = delivery.Add(OneHour);

            //        if (timeLeft < OneHour)
            //        {
            //            timeLeft = timeLeft.Add(timeLeft);
            //            delivery = delivery.Add(timeLeft);
            //        }
            //    }
            //    else
            //    {


            //        delivery = delivery.Add(OneHour);
            //        if (!workingDays.Contains(delivery.DayOfWeek))
            //        {
            //            delivery = delivery.AddDays(1);
            //        }
            //    }



            //}

            #endregion

            Console.WriteLine("START = " + date);
            Console.WriteLine("ENTREGA = " + delivery);
            Console.WriteLine("ENTREGA= " + delivery.Subtract(date).Hours);

            Console.WriteLine("------------------------------------------------\n");
        }

        private static bool calRange(DateTime slaStart, DateTime delivery, TimeSpan startHour, TimeSpan endHour, TimeSpan OnDutyTimeStart, TimeSpan OnDutyTimeEnd)
        {
            var day = new TimeSpan(24, 0, 0);
            
            var endOndute = new DateTime(slaStart.Year, slaStart.Month, slaStart.Day, OnDutyTimeStart.Hours, OnDutyTimeStart.Minutes, 0).AddHours((day.Subtract(OnDutyTimeStart) + OnDutyTimeEnd).Hours);
            var StartOndute = new DateTime(slaStart.Year, slaStart.Month, slaStart.Day, OnDutyTimeStart.Hours, OnDutyTimeStart.Minutes, 0);

            return (delivery.TimeOfDay >= startHour && delivery.TimeOfDay < endHour) || (delivery >= StartOndute && delivery <= endOndute);
        }

        private static DateTime CalcTime(DateTime slaStart,TimeSpan time, TimeSpan totalDays, DateTime delivery, TimeSpan startHour, TimeSpan endHour, TimeSpan OnDutyTimeStart, TimeSpan OnDutyTimeEnd, List<DayOfWeek> workingDays, bool blocked = false)
        {
            var timeLeft = TimeSpan.Zero;
            while (timeLeft < totalDays)
            {

                if (calRange(slaStart, delivery, startHour, endHour, OnDutyTimeStart, OnDutyTimeEnd))
                {

                    if (timeLeft.Add(time) >= totalDays && !blocked)
                    {

                        delivery = CalcTime(slaStart , new TimeSpan(0, 1, 0), time, delivery, startHour, endHour, OnDutyTimeStart, OnDutyTimeEnd, workingDays, true);

                    }
                    else {

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

        public static bool InclusiveBetween(this IComparable a, IComparable b, IComparable c)
        {
            return a.CompareTo(b) >= 0 && a.CompareTo(c) <= 0;
        }

        public static bool ExclusiveBetween(this IComparable a, IComparable b, IComparable c)
        {
            return a.CompareTo(b) > 0 && a.CompareTo(c) < 0;
        }

        public static bool Between(this IComparable a, IComparable b, IComparable c)
        {
            return a.InclusiveBetween(b, c);
        }
    }
}
