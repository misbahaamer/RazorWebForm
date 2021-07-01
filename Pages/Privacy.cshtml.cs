using DinkToPdf;
using DinkToPdf.Contracts;
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
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RazorWebAPp.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        private readonly IUserService _userService;
        private IConverter _converter;
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
        public string Output { get; set; }
        [BindProperty]
        public List<SelectListItem> Columns { get; set; }

        public PrivacyModel(ILogger<PrivacyModel> logger, IUserService userService, IConverter converter)
        {
            _logger = logger;
            _userService = userService;
            _converter = converter; ;
        }
        
    


        public void OnGet()
        {
            LoadData();
            Output = JsonConvert.SerializeObject(UserDataList.Data);
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
        public IActionResult OnPostViewPDF()
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report"
            };
            var sheet = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "lib", "bootstrap", "dist", "css", "bootstrap.css");
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = GetHTMLString(),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "lib", "bootstrap", "dist", "css", "bootstrap.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            var file = _converter.Convert(pdf);
            return File(file, "application/pdf");

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
            var data1 = _userService.GetUserList().Result;
            var data2 = _userService.GetUserList().Result;
            UserDataList dataList = new UserDataList();
            dataList.Data = new List<User>();
            dataList.Data.AddRange(data1.Data);
            foreach (var item in data2.Data)
            {
                item.Id = item.Id + 10;
                item.First_Name = item.First_Name + "data2";
                item.Last_Name = item.Last_Name + "data2";
            }
            dataList.Data.AddRange(data2.Data);
            UserDataList = dataList;



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
        public  string GetHTMLString()
        {
            UserDataList = _userService.GetUserList().Result;
            List<User> Users = UserDataList.Data.ToList();
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <table class='table table-sm'>
                                <thead>
                                    <tr>
                                        <th scope='col'>Id</th>
                                        <th scope='col'>First Name</th>
                                        <th scope='col'>Last Name</th>
                                        <th scope='col'>Email</th>
                                        <th scope='col'>Avatar</th>
                                    </tr></thead>");
            foreach (var item in Users)
            {
                sb.AppendFormat(@"<tbody><tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                  </tr></tbody>", item.Id, item.First_Name, item.Last_Name, item.Email, item.Avatar);
            }
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
            return sb.ToString();
        }
    }
}
