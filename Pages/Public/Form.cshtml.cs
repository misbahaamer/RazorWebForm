using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AutoMapper;
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

        private readonly IMapper _mapper;

        public FormModel(IMapper mapper)
        {
            _mapper = mapper;
        }

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

            Form form = new Form();
            Address address = new Address();

            form.FirstName = "firstname";
            form.LastName = "lastname";
            form.City = "city";
            form.State = "state";
            form.Zip = "12345";
            //form.Address = new Collection<Address>();
            //address.HomeAddress = "home address";
            //address.WorkAddress = "work address";
            //address.OtherAddress = "other address";

            //form.Address.Add(address);

            var formDTO = _mapper.Map<FormDTO>(form);

        

            //ViewData["states"] = dropdown;
        }
    

        public ActionResult OnPostNavigateToConfirm(Form form)
        {
            HttpContext.Session.SetString("firstname", form.FirstName);

            SessionHelper.SetObjectAsJson(HttpContext.Session, "lastname", form.LastName);

            //SendEmail();
            var formDTO = _mapper.Map<FormDTO>(form);
            return new RedirectToPageResult("/Public/Confirm");
        }

        private void SendEmail()
        {
            MailMessage message= new MailMessage();
            message.From = new
               MailAddress("razortest1604@outlook.com");
            message.To.Add(new
               MailAddress("testmail@mailinator.com"));
            message.Subject = "Test Subject";
            message.Body = "Testing Office365 Email";
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential("razortest1604@outlook.com", "Rainman@1604");
            client.Port = 587;
            client.Host = "smtp.office365.com";
            client.EnableSsl = true;
            client.Send(message);
        }
    }
}
