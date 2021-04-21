using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using RazorWebApp.Helper;
using RazorWebApp.Models;

namespace RazorWebApp.Pages.Public
{
    public class FormModel : PageModel
    {

        [BindProperty]
        public Form formdata { get; set; }

        public List<SelectListItem> States = new List<SelectListItem>();


        public void OnGet()
        {
            var tempStates = new List<SelectListItem>();
            tempStates.Add(new SelectListItem { Value = "VA", Text = "Virginia" });
            tempStates.Add(new SelectListItem { Value = "WA", Text = "Washington" });
            tempStates.Add(new SelectListItem { Value = "TX", Text = "Texas" });
            tempStates.Add(new SelectListItem { Value = "KA", Text = "Kansas" });
            tempStates.Add(new SelectListItem { Value = "OR", Text = "Oregon" });
            tempStates.Add(new SelectListItem { Value = "CO", Text = "Colorado" });

            States = tempStates;
        

            //ViewData["states"] = dropdown;
        }
    

        public ActionResult OnPostNavigateToConfirm(Form form)
        {
            HttpContext.Session.SetString("firstname", form.FirstName);

            SessionHelper.SetObjectAsJson(HttpContext.Session, "lastname", form.LastName);

            return new RedirectToPageResult("/Public/Confirm");
        }
    }
}
