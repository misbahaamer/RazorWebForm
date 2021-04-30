using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
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

        public PrivacyModel(ILogger<PrivacyModel> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }



        public void OnGet()
        {
             UserData = _userService.GetUserData().Result;
             UserDataList = _userService.GetUserList().Result;

        }
    }
}
