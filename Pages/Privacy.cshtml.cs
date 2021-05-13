using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RazorWebApp.Helper;
using RazorWebApp.Models;
using RazorWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RazorWebAPp.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        private readonly IUserService _userService;
        [BindProperty]
        public UserData UserData { get; set; }
        [BindProperty]
        public UserDataList UserDataList { get; set; }
        [BindProperty]
        public List<string> AreChecked { get; set; }

        public PersonList PrivacyPersonsData { get; set; }

        public PrivacyModel(ILogger<PrivacyModel> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }



        public void OnGet()
        {
            LoadData();
            if (PrivacyPersonsData == null)
            {
                var data = HttpContext.Session.GetString("pdata");
                var converted = JsonConvert.DeserializeObject<List<Persons>>(data);
                //PrivacyPersonsData = SessionHelper.GetObjectFromJson<PersonList>(HttpContext.Session, "personData");
            }
            
        }

        public async Task OnPostDelete()
        {
            var data = AreChecked;
            LoadData();

     
        }

        public void LoadData()
        {
            UserData = _userService.GetUserData().Result;
            UserDataList = _userService.GetUserList().Result;
        }
    }
}
