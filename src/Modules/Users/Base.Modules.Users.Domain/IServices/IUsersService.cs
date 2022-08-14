using Base.Modules.Users.Domain.DTO.User;
using Base.Shared.IServices;

namespace Base.Modules.Users.Domain.IServices
{
    public interface IUsersService<GetResponse, GeDetailsResponse, AddRequest, UpdateRequest> :
        IDeletableService<GetResponse, GeDetailsResponse, AddRequest, UpdateRequest>

    {
        Task ChangePowers(ChangePowersRequestDto dto);
    }
}
