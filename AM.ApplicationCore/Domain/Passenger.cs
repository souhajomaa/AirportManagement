using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        [Key]
        [StringLength(7)]
        public string PassportNumber { get; set; }
        //fullname
        [Required]
        public FullName FullName { get; set; }
        [Required]
        [MaxLength(300)]
        [StringLength(250, ErrorMessage = "Le prénom ne peut pas dépasser 250 caractères")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(300)]
        [StringLength(250, ErrorMessage = "Le nom ne peut pas dépasser 250 caractères")]
        public string LastName { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        public DateTime BirthDate { get; set; }

        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Le numéro de téléphone doit contenir exactement 8 chiffres")]
        public string TelNumber { get; set; }

        public IList<Flight> Flights { get; set; } = new List<Flight>();

        public virtual string PassengerType => "Unknown passenger type";

        public override string ToString()
        {
            return $"{FullName} - {EmailAddress}";
        }
    }
}