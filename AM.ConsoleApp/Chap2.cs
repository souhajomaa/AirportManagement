using AM.ApplicationCore;
using AM.ApplicationCore.Services;
using System;

namespace AM.UI.Console
{
    public class Chap2
    {
        public static ShowLine showLine = System.Console.WriteLine;

        public static void Test1()
        {
            var service = new BasicFlightService(InMemorySource.Flights, showLine);

            service.ShowFlights("Destination", "Paris");
            service.ShowFlights("Destination", "Madrid");
            service.ShowFlights("FlightId", "3");
        }
    }
}