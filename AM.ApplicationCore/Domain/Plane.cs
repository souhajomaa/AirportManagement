using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AM.ApplicationCore.Domain
{
    public class Plane
    {
        public int PlaneId { get; set; }
        public PlaneType PlaneType { get; set; }

        [Range(50, 500)]
        public int Capacity { get; set; }

        [Column(TypeName = "date")]
        public DateTime ManufactureDate { get; set; }

        public IList<Flight> Flights { get; set; } = new List<Flight>();

        public Plane() { }

        public Plane(PlaneType planeType, int capacity, DateTime manufactureDate)
        {
            PlaneType = planeType;
            Capacity = capacity;
            ManufactureDate = manufactureDate;
        }

        public override string ToString()
        {
            return $"Plane {PlaneId} - {PlaneType} - Capacity: {Capacity} - Manufactured: {ManufactureDate:dd/MM/yyyy}";
        }
    }
}