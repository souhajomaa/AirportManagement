using System;
using System.ComponentModel.DataAnnotations;

namespace AM.ApplicationCore.Domain
{
    public class Traveller : Passenger
    {
        [DataType(DataType.MultilineText)]//multiligne
        public string HealthInformation { get; set; }
        public string Nationality { get; set; }

        public override string PassengerType => "Traveller passenger type";

        public override string ToString()
        {
            return base.ToString() + $", Traveller - {Nationality} - Health: {HealthInformation}";
        }
    }
}