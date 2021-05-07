using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorWebApp.Helper;
using RazorWebApp.Models;

namespace RazorWebApp.Pages.Public
{
    public class ConfirmModel : PageModel
    {
        public string firstname { get; set; }
        public string lastname { get; set; }

        [BindProperty]
        public PersonSubs personSubs { get; set; }
        [BindProperty]
        public List<Subscriptions> subsList { get; set; }
        [BindProperty]
        public List<string> Amazon { get; set; }
        [BindProperty]
        public List<string> Netflix { get; set; }
        [BindProperty]
        public List<string> Hulu { get; set; }
        [BindProperty]
        public List<string> Peacock { get; set; }
        [BindProperty]
        public List<string> Disney { get; set; }


        public void OnGet()
        {
            //firstname = HttpContext.Session.GetString("firstname");
            //lastname = SessionHelper.GetObjectFromJson<string>(HttpContext.Session, "lastname");
            PersonSubs ps = new PersonSubs();
            
            personSubs = ps;
            var slist = LoadSubscription();
            subsList = slist;
        }

        private List<Subscriptions> LoadSubscription()
        {
            var SubscriptionList = new List<Subscriptions>()
                { new Subscriptions()
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
                    }};
            return SubscriptionList;
        }
        public void OnPostSaveChanges(PersonSubs personSubs)
        {
            var amazon = Amazon    ;
            var netflix = Netflix   ;
            var hulu = Hulu      ;
            var peacock = Peacock   ;
            var  disney =    Disney;
    }
    }
}
