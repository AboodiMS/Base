using AutoMapper;
using Base.Modules.Users.Domain.DTO.User;
using Base.Modules.Users.Domain.DTO.UserSettings;
using Base.Modules.Users.Domain.Entities;

namespace Base.Modules.Users.Domain.Mapping
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User,GetUserDetailsResponseDto>();
            CreateMap<User,GetUserResponseDto>();
            CreateMap<UpdateUserRequestDto, User>();
            CreateMap<CreateUserRequestDto, User>();
            CreateMap<ChangePasswordRequestDto, User>();
        }
    }
}
