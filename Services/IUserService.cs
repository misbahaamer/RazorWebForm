using RazorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorWebApp.Services
{
    public interface IUserService
    {
        Task<UserData> GetUserData();
        Task<UserDataList> GetUserList();
    }
}
