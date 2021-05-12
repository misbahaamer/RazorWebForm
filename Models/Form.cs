using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace RazorWebApp.Models
{
    public class Form
    {

        public string FirstName { get; set; }

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
