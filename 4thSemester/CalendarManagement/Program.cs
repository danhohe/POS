#nullable disable


using Microsoft.VisualBasic;

namespace CalendarManagement
{
    class Program
    {
        static void Main(string[] args)
        {

            CalendarEvent[] calendarEvents = ReadFromCsv("CalendarDates.csv");
            SortCalendar(ref calendarEvents);
            PrintCalendar(calendarEvents);
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }

        private static void PrintCalendar(CalendarEvent[] calendarEvents)
        {
            Console.Clear();
            for (int i = 0; i < calendarEvents.Length; i++)
            {
                Console.WriteLine($"{calendarEvents[i].FullDate}: {calendarEvents[i].Desc}");
            }
        }

        private static void SortCalendar(ref CalendarEvent[] calendarEvents)
        {
            for (int i = 0; i < calendarEvents.Length - 1; i++)
            {
                int j = GetIndexOfMinimum(calendarEvents, i);
                int n = CompareTo(calendarEvents[i], calendarEvents[j]);
                if (n == -1)
                {
                    Swap(ref calendarEvents[j], ref calendarEvents[i]);
                }
                else if (n == 1)
                {
                    Swap(ref calendarEvents[i], ref calendarEvents[j]);
                }
            }
        }

        private static int GetIndexOfMinimum(CalendarEvent[] calendarEvents, int startIndex)
        {
            int result = 0;
            bool isFound = false;
            for (result = startIndex + 1; result < calendarEvents.Length && !isFound; result++)
            {
                if(calendarEvents[startIndex].Year > calendarEvents[result].Year)
                {
                    if (calendarEvents[startIndex].Month > calendarEvents[result].Month)
                    {
                        
                    }
                }
                isFound = (calendarEvents[startIndex].Day > calendarEvents[result].Day) || (calendarEvents[startIndex].Month > calendarEvents[result].Month) || (calendarEvents[startIndex].Year > calendarEvents[result].Year);
            }
            if (isFound)
            {
                result -= 1;
            }
            else if (!isFound)
            {
                result = startIndex;
            }
            return result;
        }

        private static void Swap(ref CalendarEvent event1, ref CalendarEvent event2)
        {
            CalendarEvent temp = event1;
            event1 = event2;
            event2 = temp;
        }

        private static int CompareTo(CalendarEvent event1, CalendarEvent event2)
        {
            int result = 0;
            if ((event1.Day < event2.Day) || (event1.Month < event2.Month) || (event1.Year < event2.Year))
            {
                result = -1;
            }
            else if ((event1.Day > event2.Day) || (event1.Month < event2.Month) || (event1.Year < event2.Year))
            {
                result = 1;
            }
            else
            {
                result = 0;
            }
            return result;
        }

        private static CalendarEvent[] ReadFromCsv(string csv)
        {
            string[] text = File.ReadAllLines(csv);
            CalendarEvent[] result = new CalendarEvent[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                result[i] = CalendarEvent.CreateNewEvent(text[i]);
            }
            return result;
        }
    }
}
