using AM.ApplicationCore;
using AM.Infrastructure;
using System;

namespace AM.ConsoleApp
{
    public class Chap3
    {
        public static void Test1()
        {
            using (var context = new AMContext())
            {
                Console.WriteLine("Insertion des données...");

                context.Planes.AddRange(InMemorySource.Boeing1, InMemorySource.Boeing2, InMemorySource.Airbus);

                context.Flights.AddRange(InMemorySource.Flights);

                context.Staffs.AddRange(InMemorySource.Staffs);

                context.Travellers.AddRange(InMemorySource.Travellers);

                context.SaveChanges();

                Console.WriteLine("✓ Données insérées avec succès !");
            }
        }
    }
}