using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RazorWebApp.Helper;
using RazorWebApp.Models;
using RazorWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
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
        [BindProperty]
        public string SelectOption { get; set; }
        [BindProperty]
        public string Input { get; set; }
        public PersonList PrivacyPersonsData { get; set; }

        [BindProperty]
        public List<SelectListItem> Columns { get; set; }

        public PrivacyModel(ILogger<PrivacyModel> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }



        public void OnGet()
        {
            LoadData();
            //if (PrivacyPersonsData == null)
            //{
            //    var data = HttpContext.Session.GetString("pdata");
            //    var converted = JsonConvert.DeserializeObject<List<Persons>>(data);
            //    //PrivacyPersonsData = SessionHelper.GetObjectFromJson<PersonList>(HttpContext.Session, "personData");
            //}
            LoadColumns();
            
        }

        private void LoadColumns()
        {
            User user = new User();


            Type TheType = user.GetType();
            var columns = TheType.GetProperties();

            Columns = new List<SelectListItem>();
            Columns.Add(new SelectListItem { Value = "", Text = "----Select----" });

            int i = 0;
            foreach (var item in columns)
            {
                Columns.Add(new SelectListItem { Value = columns[i].Name.ToString(), Text = columns[i].Name.ToString() }) ;
                i++;
            }


        }

        public async Task OnPostDelete()
        {
            var data = AreChecked;
            LoadData();

     
        }
        public void OnPostSearchForData()
        {
            var data = AreChecked;

            SessionHelper.SetObjectAsJson(HttpContext.Session, "CheckedRows", AreChecked);

            var checkedRows = SessionHelper.GetObjectFromJson<List<string>>(HttpContext.Session, "CheckedRows");

            LoadData(SelectOption, Input);
            LoadColumns();

        }
        public void OnPostClearData()
        {
            
            if (AreChecked.Count == 0)
            {
                var checkedRows = SessionHelper.GetObjectFromJson<List<string>>(HttpContext.Session, "CheckedRows");
                AreChecked = checkedRows;

            }
            LoadData();

            LoadColumns();

        }
        

        public void LoadData()
        {
            UserData = _userService.GetUserData().Result;
            UserDataList = _userService.GetUserList().Result;
            
            

        }

        public void LoadData(string select, string value )
        {
            UserData = _userService.GetUserData().Result;
            UserDataList = _userService.GetUserList().Result;


            switch (select)
            {
                case "Id":
                    UserDataList.Data = UserDataList.Data.Where(x => x.Id == Convert.ToInt32(value)).ToList();
                    break;
                case "First_Name":
                    UserDataList.Data = UserDataList.Data.Where(x => x.First_Name == value).ToList();
                    break;
                case "Email":
                    UserDataList.Data = UserDataList.Data.Where(x => x.Email == value).ToList();
                    break;
                case "Avatar":
                    UserDataList.Data = UserDataList.Data.Where(x => x.Avatar == value).ToList();
                    break;
                case "Last_Name":
                    UserDataList.Data = UserDataList.Data.Where(x => x.Last_Name == value).ToList();
                    break;

                default:
                    UserDataList.Data = UserDataList.Data.ToList();
                    break;
            }

            
        }
    }
}
