using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace RazorWebApp.Models
{
    public class FormDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Collection<AddressDTO> Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }
    }
    public class AddressDTO
    {
        public string HomeAddress { get; set; }
        public string WorkAddress { get; set; }
        public string OtherAddress { get; set; }
    }
}
