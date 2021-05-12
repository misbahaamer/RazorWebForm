using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorWebApp.Models
{
    public class Subscription
    {
        public int SubId { get; set; }
        public string SubName { get; set; }
        public bool IsChecked { get; set; }
    }
}
