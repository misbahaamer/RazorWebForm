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
        public PersonList persons { get; set; }
        [BindProperty]
        public List<Subscriptions> AllSubscriptions { get; set; }



        public void OnGet()
        {
            //firstname = HttpContext.Session.GetString("firstname");
            //lastname = SessionHelper.GetObjectFromJson<string>(HttpContext.Session, "lastname");
            PersonList ps = new PersonList();

            //var slist = LoadSubscription();
            persons = ps;
            AllSubscriptions = persons.plist.OrderByDescending(x => x.subscriptions.Count()).First().subscriptions;

        }

        //private List<Subscriptions> LoadSubscription()
        //{
        //    SubscriptionsList subscriptionsList = new SubscriptionsList();
                
        //    return subscriptionsList.slist;
        //}
        public void OnPostSaveChanges(PersonList personSubs)
        {
            //var amazon = Amazon    ;
            //var netflix = Netflix   ;
            //var hulu = Hulu      ;
            //var peacock = Peacock   ;
            //var  disney =    Disney;
    }
    }
}
