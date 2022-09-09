using AutoMapper;
using Domain.Entities;
using Financio.Infrastructure.Models;

namespace Financio.Application.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, User>();
            CreateMap<User, UserEntity>();
        }
    }
}
