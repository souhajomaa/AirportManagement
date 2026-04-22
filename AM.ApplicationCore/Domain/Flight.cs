using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public int FlightId { get; set; }
        public DateTime FlightDate { get; set; }

        [Required(ErrorMessage = "La destination est obligatoire")]
        public string Destination { get; set; }

        [Required(ErrorMessage = "Le départ est obligatoire")]
        public string Departure { get; set; }

        public DateTime EffectiveArrival { get; set; }
        public double EstimatedDuration { get; set; }

        public Plane Plane { get; set; }

        [ForeignKey(nameof(Plane))]
        public int? PlaneId { get; set; }

        public IList<Passenger> Passengers { get; set; } = new List<Passenger>();

        public override string ToString()
        {
            return $"Flight {FlightId} → {Destination} | {FlightDate:dd/MM/yyyy HH:mm}";
        }
    }
}