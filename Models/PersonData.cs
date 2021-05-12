using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorWebApp.Models
{
    public class PersonData
    {
        public Person person { get; set; }
        public List<Subscription> subList { get; set; }
    }
}
