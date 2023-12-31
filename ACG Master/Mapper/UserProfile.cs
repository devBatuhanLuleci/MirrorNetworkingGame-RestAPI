﻿using ACG_Master.DataBase.Dtos;
using ACG_Master.DataBase.Entities;
using AutoMapper;

namespace ACG_Master.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }



}
