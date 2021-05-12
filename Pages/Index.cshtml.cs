using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorWebApp.Helper;
using RazorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorWebAPp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public List<PersonData> personData { get; set; }

        [BindProperty]
        public List<string> subscriptionDetails { get; set; } = new List<string>() { "Amazon", "Jio", "HotStar" };
        public void OnGet()
        {
            personData = GetData();
        }

        public List<PersonData> GetData()
        {
            List<PersonData> data = new List<PersonData>()
            {
                new PersonData()
                {
                    person = new Person(){ PersonId = 1, PersonName="Ravi Makwana" },
                    subList = new List<Subscription>()
                    {
                        new Subscription()
                        {
                            SubId = 1,
                            SubName = "Amazon"
                        },
                        new Subscription()
                        {
                            SubId = 2,
                            SubName = "Jio"
                        },
                        new Subscription()
                        {
                            SubId = 3,
                            SubName = "HotStar"
                        }
                    }
                },
                new PersonData()
                {
                    person = new Person(){ PersonId = 2, PersonName="Anjan Sinha" },
                    subList = new List<Subscription>()
                    {
                        new Subscription()
                        {
                            SubId = 1,
                            SubName = "Amazon"
                        },
                        new Subscription()
                        {
                            SubId = 2,
                            SubName = "Jio"
                        },
                        new Subscription()
                        {
                            SubId = 3,
                            SubName = "HotStar"
                        }
                    }
                },
                new PersonData()
                {
                    person = new Person(){ PersonId = 3, PersonName="Harsh Dodiya" },
                    subList = new List<Subscription>()
                    {
                        new Subscription()
                        {
                            SubId = 1,
                            SubName = "Amazon"
                        },
                        new Subscription()
                        {
                            SubId = 2,
                            SubName = "Jio"
                        },
                        new Subscription()
                        {
                            SubId = 3,
                            SubName = "HotStar"
                        }
                    }
                },
            };
            return data;
        }

        public ActionResult OnPostSubmitData(List<PersonData> personData)
        {
            return new RedirectToPageResult("/Public/Confirm");
        }
    }
}
