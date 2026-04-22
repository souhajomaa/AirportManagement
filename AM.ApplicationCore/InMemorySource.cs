using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AM.ApplicationCore
{
    public static class InMemorySource
    {
        public static Plane Boeing1 { get; private set; }

        public static readonly Plane Boeing2;
        public static readonly Plane Airbus;

        public static readonly IList<Staff> Staffs;
        public static readonly IList<Traveller> Travellers;
        public static readonly IList<Flight> Flights;

        static InMemorySource()
        {
            Boeing1 = CreateBoeing1();

            Boeing2 = new Plane(PlaneType.Boeing, 150, new DateTime(2015, 2, 3))
            {
                PlaneId = 2
            };

            Airbus = new Plane
            {
                PlaneId = 3,
                PlaneType = PlaneType.Airbus,
                Capacity = 250,
                ManufactureDate = new DateTime(2020, 11, 11)
            };

            Staffs = new List<Staff>
            {
                new Staff
                {
                    PassportNumber = "S001",
                    //changer par fullname
                    FullName = new FullName { FirstName = "captain", LastName = "Captain" },

                    EmailAddress = "captain@gmail.com",
                    BirthDate = new DateTime(1965, 1, 1),
                    TelNumber = "12345678",
                    EmployementDate = new DateTime(1999, 1, 1),
                    Salary = 10000
                },
                new Staff
                {
                    PassportNumber = "S002",
                     FullName = new FullName { FirstName = "hostess1", LastName = "Hostess1" },
                    EmailAddress = "hostess1@gmail.com",
                    BirthDate = new DateTime(1995, 1, 1),
                    TelNumber = "23456789",
                    EmployementDate = new DateTime(2020, 1, 1),
                    Salary = 5000
                },
                new Staff
                {
                    PassportNumber = "S003",
                     FullName = new FullName { FirstName = "hostess2", LastName = "Hostess2" },
                    EmailAddress = "hostess2@gmail.com",
                    BirthDate = new DateTime(1996, 1, 1),
                    TelNumber = "34567890",
                    EmployementDate = new DateTime(2021, 1, 1),
                    Salary = 6100
                }
            };

            Travellers = new List<Traveller>
            {
                new Traveller
                {
                    PassportNumber = "T001",
                    FullName = new FullName { FirstName = "traveller1", LastName = "Traveller1" },

                    BirthDate = new DateTime(1980, 1, 1),
                    TelNumber = "45678901",
                    EmailAddress = "traveller1@gmail.com",
                    HealthInformation = "No troubles",
                    Nationality = "American"
                },
                new Traveller
                {
                    PassportNumber = "T002",
                      FullName = new FullName { FirstName = "traveller2", LastName = "Traveller2" },

                    BirthDate = new DateTime(1981, 1, 1),
                    TelNumber = "56789012",
                    EmailAddress = "traveller2@gmail.com",
                    HealthInformation = "Some troubles",
                    Nationality = "French"
                },
                new Traveller
                {
                    PassportNumber = "T003",
                    FullName = new FullName { FirstName = "traveller3", LastName = "Traveller3" },

                    BirthDate = new DateTime(1982, 1, 1),
                    TelNumber = "67890123",
                    EmailAddress = "traveller3@gmail.com",
                    HealthInformation = "No troubles",
                    Nationality = "Tunisian"
                },
                new Traveller
                {
                    PassportNumber = "T004",
        FullName = new FullName { FirstName = "traveller4", LastName = "Traveller4" },

                    BirthDate = new DateTime(1983, 1, 1),
                    TelNumber = "78901234",
                    EmailAddress = "traveller4@gmail.com",
                    HealthInformation = "Some troubles",
                    Nationality = "American"
                },
                new Traveller
                {
                    PassportNumber = "T005",
                    FullName = new FullName { FirstName = "traveller5", LastName = "Traveller5" },

                    BirthDate = new DateTime(1984, 1, 1),
                    TelNumber = "89012345",
                    EmailAddress = "traveller5@gmail.com",
                    HealthInformation = "Some troubles",
                    Nationality = "Spanish"
                }
            };

          
            Flights = new List<Flight>
            {
                new Flight
                {
                    FlightDate = new DateTime(2022, 1, 1, 15, 10, 0),
                    Destination = "Paris",
                    Departure = "Tunis",
                    EffectiveArrival = new DateTime(2022, 1, 1, 17, 10, 0),
                    EstimatedDuration = 2
                },
                new Flight
                {
                    FlightDate = new DateTime(2022, 2, 1, 21, 10, 0),
                    Destination = "Paris",
                    Departure = "Tunis",
                    EffectiveArrival = new DateTime(2022, 2, 1, 23, 10, 0),
                    EstimatedDuration = 2
                },
                new Flight
                {
                    FlightDate = new DateTime(2022, 3, 1, 5, 10, 0),
                    Destination = "Paris",
                    Departure = "Tunis",
                    EffectiveArrival = new DateTime(2022, 3, 1, 7, 10, 0),
                    EstimatedDuration = 2
                },
                new Flight
                {
                    FlightDate = new DateTime(2022, 4, 1, 6, 10, 0),
                    Destination = "Madrid",
                    Departure = "Tunis",
                    EffectiveArrival = new DateTime(2022, 4, 1, 8, 40, 0),
                    EstimatedDuration = 2.5
                },
                new Flight
                {
                    FlightDate = new DateTime(2022, 5, 1, 17, 10, 0),
                    Destination = "Madrid",
                    Departure = "Tunis",
                    EffectiveArrival = new DateTime(2022, 5, 1, 19, 40, 0),
                    EstimatedDuration = 2.5
                },
                new Flight
                {
                    FlightDate = new DateTime(2022, 6, 1, 20, 10, 0),
                    Destination = "Lisbonne",
                    Departure = "Tunis",
                    EffectiveArrival = new DateTime(2022, 6, 1, 23, 10, 0),
                    EstimatedDuration = 3
                }
            };

            Flights[0].Plane = Boeing1;
            Flights[1].Plane = Boeing1;
            Flights[2].Plane = Boeing2;
            Flights[3].Plane = Boeing2;
            Flights[4].Plane = Airbus;
            Flights[5].Plane = Airbus;

            foreach (var staff in Staffs)
            {
                Flights[0].Passengers.Add(staff);
            }

            foreach (var traveller in Travellers)
            {
                Flights[1].Passengers.Add(traveller);
            }

            var allPassengers = Staffs.Cast<Passenger>().Concat(Travellers).ToList();
            foreach (var passenger in allPassengers)
            {
                Flights[2].Passengers.Add(passenger);
            }
        }

        private static Plane CreateBoeing1()
        {
            var p = new Plane();
            p.PlaneType = PlaneType.Boeing;
            p.Capacity = 200;
            p.ManufactureDate = new DateTime(2018, 12, 31);
            return p;
        }
    }
}