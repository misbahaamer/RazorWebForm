using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorWebApp.Models
{
    public class Form
    {

        [Required]
        [StringLength(10, ErrorMessage = "required firstname", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "required lastname", MinimumLength = 2)]
        public string LastName { get; set; }

        public Collection<Address> Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }
    }

    public class Address
    {
        public string HomeAddress { get; set; }
        public string WorkAddress { get; set; }
        public string OtherAddress { get; set; }
    }
}
