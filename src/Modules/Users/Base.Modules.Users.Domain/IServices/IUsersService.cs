using Base.Modules.Users.Domain.DTO.User;
using Base.Shared.IServices;

namespace Base.Modules.Users.Domain.IServices
{
    public interface IUsersService<GetResponse, GetDetailsResponse, AddRequest, UpdateRequest> :
        ICRUDService<GetResponse, GetDetailsResponse, AddRequest, UpdateRequest>

    {
        Task ChangePowers(ChangePowersRequestDto dto);
    }
}
