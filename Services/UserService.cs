using Newtonsoft.Json;
using RazorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RazorWebApp.Services
{
    public class UserService : IUserService
    {

        private readonly HttpClient httpClient;

        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<UserData> GetUserData()
        {
            var response =  await httpClient.GetAsync("api/users/2");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<UserData>(responseBody);
            return data;
        }

        public async Task<UserDataList> GetUserList()
        {
            var response = await httpClient.GetAsync("api/users");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserDataList>(responseBody);
        }
    
    }
}
