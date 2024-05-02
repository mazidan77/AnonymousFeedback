using AnonymousFeedback.Application.Dtos.UserDto;
using AnonymousFeedback.Domian.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousFeedback.Application.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserPutDto>().ReverseMap();
            CreateMap<User, UserGetDto>().ReverseMap();
        }
    }
}
