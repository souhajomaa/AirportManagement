using System;
using System.ComponentModel.DataAnnotations;

namespace AM.ApplicationCore.Domain
{
    public class Staff : Passenger
    {
        public DateTime EmployementDate { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Le salaire doit être positif")]//salary positive

        public double Salary { get; set; }

        public override string PassengerType => "Staff passenger type";

        public override string ToString()
        {
            return base.ToString() + $", Staff - Salary: {Salary} - Employed: {EmployementDate:dd/MM/yyyy}";
        }
    }
}