using AutoMapper;
using RazorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorWebApp.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Form, FormDTO>();
            CreateMap<Address, AddressDTO>();
        }
    }
}
