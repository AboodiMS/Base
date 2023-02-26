using Base.Modules.Users.Domain.DTO.User;
using Base.Shared.IServices;

namespace Base.Modules.Users.Domain.IServices
{
    public interface IUsersService: 
        ICRUDService<GetUserResponseDto,GetUserDetailsResponseDto,CreateUserRequestDto,UpdateUserRequestDto>

    {
        Task ChangePowers(ChangePowersRequestDto dto);
    }
}
