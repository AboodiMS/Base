using Base.Modules.Users.Domain.DTO.User;
using Base.Shared.IServices;

namespace Base.Modules.Users.Domain.IServices
{
    public interface IUsersService<GetResponse, AddRequest, UpdateRequest> : IDeletableService<GetResponse, AddRequest, UpdateRequest>
        where GetResponse : GetUserResponseDto
        where AddRequest : AddUserRequestDto
        where UpdateRequest : UpdateUserRequestDto

    {
        Task ChangePowers();
    }
}
