using System;
using System.Collections.Generic;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class BasicFlightService : IBasicFlightService
    {
        private IEnumerable<Flight> flights;
        private ShowLine showLine;

        public BasicFlightService(IEnumerable<Flight> source, ShowLine showLineDelegate)
        {
            flights = source;
            showLine = showLineDelegate;
        }

        public void ShowFlights(string filterType, string filterValue)
        {
            showLine($"Filter Type: {filterType}, Filter Value: {filterValue}");

            switch (filterType.ToLower())
            {
                case "destination":
                    foreach (Flight flight in flights)
                    {
                        if (flight.Destination == filterValue)
                        {
                            showLine($"FlightId: {flight.FlightId}, Destination: {flight.Destination}, FlightDate: {flight.FlightDate}");
                        }
                    }
                    break;

                case "flightdate":
                    DateTime searchDate = DateTime.Parse(filterValue);
                    foreach (Flight flight in flights)
                    {
                        if (flight.FlightDate.Date == searchDate.Date)
                        {
                            showLine($"FlightId: {flight.FlightId}, Destination: {flight.Destination}, FlightDate: {flight.FlightDate}");
                        }
                    }
                    break;

                case "flightid":
                    int searchId = int.Parse(filterValue);
                    foreach (Flight flight in flights)
                    {
                        if (flight.FlightId == searchId)
                        {
                            showLine($"FlightId: {flight.FlightId}, Destination: {flight.Destination}, FlightDate: {flight.FlightDate}");
                            break;
                        }
                    }
                    break;

                default:
                    throw new ArgumentException("Unknown filter");
            }
        }
    }
}