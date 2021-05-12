using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorWebApp.Models
{
    public class UserData
    {
        public User Data { get; set; }
        public Support Support { get; set; }
    }
    public class UserDataList
    {
        public int Page { get; set; }
        public int Per_Page { get; set; }
        public int Total_Pages { get; set; }
        public int Total { get; set; }
        public IEnumerable<User> Data { get; set; }
        public Support Support { get; set; }
    }
}
