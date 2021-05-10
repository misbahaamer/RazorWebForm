using RazorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace RazorWebApp.Models
{
    public class Persons
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public List<Subscriptions> subscriptions { get; set; }
        public List<string> AreChecked { get; set; }
    }
    public class Subscriptions
    {
        public int SubcriptionId { get; set; }
        public string SubscriptionName { get; set; }
        public bool IsChecked { get; set; }
    }
    //public class PerSubs
    //{
    //    public int PersonId { get; set; }
    //    public string PersonName { get; set; }
    //    public bool Amazon { get; set; }
    //    public bool Netflix { get; set; }
    //    public bool Hulu { get; set; }
    //    public bool Peacock { get; set; }
    //    public bool Disney { get; set; }
    //}
    public class PersonList
    {

        public List<Persons> plist = new List<Persons>()
        {
            new Persons()
            {
                PersonId = 1,
                PersonName = "Person1",
                subscriptions = new List<Subscriptions>()
                {
                    new Subscriptions()
                    {
                        SubcriptionId = 1,
                        SubscriptionName = "Amazon",
                    },
                    new Subscriptions()
                    {
                        SubcriptionId = 2,
                        SubscriptionName = "Hulu"
                    },
                    new Subscriptions()
                    {
                        SubcriptionId = 3,
                        SubscriptionName = "Disney"
                    },
                    new Subscriptions()
                    {
                        SubcriptionId = 4,
                        SubscriptionName = "Peacock"
                    },
                    new Subscriptions()
                    {
                        SubcriptionId = 5,
                        SubscriptionName = "Netflix"
                    }
                }


            },
            new Persons()
            {
                PersonId = 2,
                PersonName = "Person2",
                subscriptions = new List<Subscriptions>()
                {
                    new Subscriptions()
                    {
                        SubcriptionId = 1,
                        SubscriptionName = "Amazon"
                    },
                    new Subscriptions()
                    {
                        SubcriptionId = 3,
                        SubscriptionName = "Disney"
                    },
                    new Subscriptions()
                    {
                        SubcriptionId = 4,
                        SubscriptionName = "Peacock"
                    },
                    new Subscriptions()
                    {
                        SubcriptionId = 5,
                        SubscriptionName = "Netflix"
                    }
                }



            },
            new Persons()
            {
                PersonId = 3,
                PersonName = "Person3",
                subscriptions = new List<Subscriptions>()
                {
                    new Subscriptions()
                    {
                        SubcriptionId = 1,
                        SubscriptionName = "Amazon"
                    },
                    new Subscriptions()
                    {
                        SubcriptionId = 2,
                        SubscriptionName = "Hulu"
                    },
                    new Subscriptions()
                    {
                        SubcriptionId = 3,
                        SubscriptionName = "Disney"
                    },
                    new Subscriptions()
                    {
                        SubcriptionId = 4,
                        SubscriptionName = "Peacock"
                    },
                }
            },
            new Persons()
            {
                PersonId = 4,
                PersonName = "Person4",
                subscriptions = new List<Subscriptions>()
                {
                    new Subscriptions()
                    {
                        SubcriptionId = 1,
                        SubscriptionName = "Amazon"
                    },
                    new Subscriptions()
                    {
                        SubcriptionId = 2,
                        SubscriptionName = "Hulu"
                    },
                    new Subscriptions()
                    {
                        SubcriptionId = 3,
                        SubscriptionName = "Disney"
                    },
                    new Subscriptions()
                    {
                        SubcriptionId = 4,
                        SubscriptionName = "Peacock"
                    },
                    new Subscriptions()
                    {
                        SubcriptionId = 5,
                        SubscriptionName = "Netflix"
                    }
                }


            },
            new Persons()
            {
                PersonId = 5,
                PersonName = "Person5",
                subscriptions = new List<Subscriptions>()
                {
                    new Subscriptions()
                    {
                        SubcriptionId = 2,
                        SubscriptionName = "Hulu"
                    },
                    new Subscriptions()
                    {
                        SubcriptionId = 3,
                        SubscriptionName = "Disney"
                    },
                    new Subscriptions()
                    {
                        SubcriptionId = 4,
                        SubscriptionName = "Peacock"
                    },
                    new Subscriptions()
                    {
                        SubcriptionId = 5,
                        SubscriptionName = "Netflix"
                    }
                }

            }
        };
    }
    //public  class SubscriptionsList
    //{

    //    public   List<Subscriptions> slist = new List<Subscriptions>()
    //    { new Subscriptions()
    //                {
    //                    SubcriptionId = 1,
    //                    SubscriptionName = "Amazon"
    //                },
    //                new Subscriptions()
    //                {
    //                    SubcriptionId = 2,
    //                    SubscriptionName = "Hulu"
    //                },
    //                new Subscriptions()
    //                {
    //                    SubcriptionId = 3,
    //                    SubscriptionName = "Disney"
    //                },
    //                new Subscriptions()
    //                {
    //                    SubcriptionId = 4,
    //                    SubscriptionName = "Peacock"
    //                },
    //                new Subscriptions()
    //                {
    //                    SubcriptionId = 5,
    //                    SubscriptionName = "Netflix"
    //                }
    //    };
    //}

}
