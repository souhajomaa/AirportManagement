using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace AM.ApplicationCore.Domain
{
    public class FullName
    {
        [MaxLength(300)]
        [StringLength(250, ErrorMessage = "Le prénom ne peut pas dépasser 250 caractères")]
        public string FirstName { get; set; }

        [MaxLength(300)]
        [StringLength(250, ErrorMessage = "Le nom ne peut pas dépasser 250 caractères")]
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}