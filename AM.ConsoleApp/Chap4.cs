using AM.ApplicationCore;
using AM.ApplicationCore.Domain;
using AM.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AM.ConsoleApp
{
    public class Chap4
    {
       
        public static void Test1()
        {
            Console.WriteLine("\n=== Chapitre 4 : Pattern Unit of Work ===\n");

            using (var unitOfWork = new UnitOfWork())
            {
                Console.WriteLine("?? Ajout de Boeing1 et Boeing2...");
                var planesRepository = unitOfWork.Repository<Plane>();

                var boeing1 = new Plane(PlaneType.Boeing, 200, new DateTime(2010, 1, 1));
                var boeing2 = new Plane(PlaneType.Boeing, 150, new DateTime(2015, 2, 3));

                planesRepository.Add(boeing1);
                planesRepository.Add(boeing2);

                unitOfWork.SaveChanges();
                Console.WriteLine("? Boeing1 et Boeing2 ajoutés avec succès !\n");

                Console.WriteLine("?? Ajout de Airbus...");
                var airbus = new Plane
                {
                    PlaneType = PlaneType.Airbus,
                    Capacity = 250,
                    ManufactureDate = new DateTime(2020, 11, 11)
                };
                planesRepository.Add(airbus);
                unitOfWork.SaveChanges();
                Console.WriteLine("? Airbus ajouté avec succès !\n");

                // Ajouter les vols
                Console.WriteLine("?? Ajout des vols...");
                var flightsRepository = unitOfWork.Repository<Flight>();

                var flights = new List<Flight>
                {
                    new Flight
                    {
                        FlightDate = new DateTime(2022, 1, 1, 15, 10, 0),
                        Destination = "Paris",
                        Departure = "Tunis",
                        EffectiveArrival = new DateTime(2022, 1, 1, 17, 10, 0),
                        EstimatedDuration = 2,
                        PlaneId = boeing1.PlaneId
                    },
                    new Flight
                    {
                        FlightDate = new DateTime(2022, 2, 1, 21, 10, 0),
                        Destination = "Paris",
                        Departure = "Tunis",
                        EffectiveArrival = new DateTime(2022, 2, 1, 23, 10, 0),
                        EstimatedDuration = 2,
                        PlaneId = boeing2.PlaneId
                    },
                    new Flight
                    {
                        FlightDate = new DateTime(2022, 3, 1, 08, 10, 0),
                        Destination = "London",
                        Departure = "Tunis",
                        EffectiveArrival = new DateTime(2022, 3, 1, 10, 10, 0),
                        EstimatedDuration = 2,
                        PlaneId = boeing1.PlaneId
                    },
                    new Flight
                    {
                        FlightDate = new DateTime(2022, 4, 1, 12, 10, 0),
                        Destination = "Berlin",
                        Departure = "Paris",
                        EffectiveArrival = new DateTime(2022, 4, 1, 14, 10, 0),
                        EstimatedDuration = 2,
                        PlaneId = airbus.PlaneId
                    }
                };

                flightsRepository.AddRange(flights);
                unitOfWork.SaveChanges();
                Console.WriteLine("? 4 vols ajoutés avec succès !\n");
            }

            Console.WriteLine("? Unit of Work disposé correctement !");
        }

       
        public static void VerifyDatabase()
        {
            Console.WriteLine("\n=== Vérification de la Base de Données ===\n");

            using (var unitOfWork = new UnitOfWork())
            {
                var planesRepository = unitOfWork.Repository<Plane>();
                var flightsRepository = unitOfWork.Repository<Flight>();

                var planes = planesRepository.GetAll().ToList();
                var flights = flightsRepository.GetAll().ToList();

                Console.WriteLine("?? Statistiques de la base de données:");
                Console.WriteLine($"   ? Nombre d'avions: {planes.Count}");
                foreach (var plane in planes)
                {
                    Console.WriteLine($"      - {plane.PlaneType} (ID: {plane.PlaneId}, Capacité: {plane.Capacity})");
                }

                Console.WriteLine($"\n   ? Nombre de vols: {flights.Count}");
                foreach (var flight in flights.Take(4))
                {
                    Console.WriteLine($"      - {flight.Departure} ? {flight.Destination} (Date: {flight.FlightDate:dd/MM/yyyy HH:mm})");
                }

                // Vérification spécifique
                Console.WriteLine($"\n? Vérifications:");
                var firstTwoPlanes = planesRepository.GetAll(p => p.PlaneId <= 2).ToList();
                Console.WriteLine($"   ? Avions avec ID <= 2: {firstTwoPlanes.Count} (attendu: 2)");

                var parisFlights = flightsRepository.GetAll(f => f.Destination == "Paris").ToList();
                Console.WriteLine($"   ? Vols vers Paris: {parisFlights.Count}");
            }
        }
    }
}
