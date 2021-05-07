using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorWebApp.Models
{
    public class Persons
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
    }
    public class Subscriptions
    {
        public int SubcriptionId { get; set; }
        public string SubscriptionName { get; set; }
    }
    public class PerSubs
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public bool Amazon { get; set; }
        public bool Netflix { get; set; }
        public bool Hulu { get; set; }
        public bool Peacock { get; set; }
        public bool Disney { get; set; }
    }
    public class PersonSubs
    {

        public List<PerSubs> plist = new List<PerSubs>()
        { 
            new PerSubs()
            {
                PersonId = 1,
                PersonName = "Person1",
                Amazon = false,
                Netflix = false,
                Hulu = false,
                Peacock = false,
                Disney = false
                
            },
            new PerSubs()
            {
                PersonId = 2,
                PersonName = "Person2",
                Amazon = false,
                Netflix = false,
                Hulu = false,
                Peacock = false,
                Disney = false

            },
            new PerSubs()
            {
                PersonId = 3,
                PersonName = "Person3",
                Amazon = false,
                Netflix = false,
                Hulu = false,
                Peacock = false,
                Disney = false
            },
            new PerSubs()
            {
                PersonId = 4,
                PersonName = "Person4",
                Amazon = false,
                Netflix = false,
                Hulu = false,
                Peacock = false,
                Disney = false
            },
            new PerSubs()
            {
                PersonId = 5,
                PersonName = "Person5",
                Amazon = false,
                Netflix = false,
                Hulu = false,
                Peacock = false,
                Disney = false
            }
        };
       

    }

}
