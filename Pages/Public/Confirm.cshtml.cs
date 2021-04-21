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

        public Form formdata { get; set; }

        public void OnGet()
        {
            firstname = HttpContext.Session.GetString("firstname");
            lastname = SessionHelper.GetObjectFromJson<string>(HttpContext.Session, "lastname");
        }
       
    }
}
