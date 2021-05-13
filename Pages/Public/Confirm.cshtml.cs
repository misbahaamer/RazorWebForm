using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RazorWebApp.Helper;
using RazorWebApp.Models;

namespace RazorWebApp.Pages.Public
{
    public class ConfirmModel : PageModel
    {
        public string firstname { get; set; }
        public PersonList PersonsData { get; set; }

        [BindProperty]
        public PersonList persons { get; set; }
        [BindProperty]
        public List<Subscriptions> AllSubscriptions { get; set; }
        [BindProperty]
        public List<string> AreChecked { get; set; }




        public void OnGet()
        {
            //firstname = HttpContext.Session.GetString("firstname");
            //lastname = SessionHelper.GetObjectFromJson<string>(HttpContext.Session, "lastname");
            PersonList ps = new PersonList();

            persons = ps;
            AllSubscriptions = persons.plist.OrderByDescending(x => x.subscriptions.Count()).First().subscriptions;


        }

        //private List<Subscriptions> LoadSubscription()
        //{
        //    SubscriptionsList subscriptionsList = new SubscriptionsList();
                
        //    return subscriptionsList.slist;
        //}
        public void OnPostSaveChanges()
        {
            //List<Persons> persons = new List<Persons>();
            //List<Subscriptions> subscriptions = new List<Subscriptions>();
            //var sorted = AreChecked.OrderBy(x => x);
            //foreach (var item in sorted)
            //{
            //    var index = item.Split(':')[0];
            //    var subscription = item.Split(':')[1];
            //    Persons person = new Persons();
            //    Subscriptions subs = new Subscriptions();
            //    person.PersonId = Convert.ToInt32(index);
            //    subs.SubcriptionId = Convert.ToInt32(subscription);
            //    subscriptions.Add(new Subscriptions() { SubcriptionId = subs.SubcriptionId});

            //}
            PersonList pl = new PersonList();
            PersonsData = pl;
            var data = JsonConvert.SerializeObject(pl.plist);
            HttpContext.Session.SetString("pdata", data);
            //SessionHelper.SetObjectAsJson(HttpContext.Session, "personData", data);

            var total = persons;
        }
    }
}
