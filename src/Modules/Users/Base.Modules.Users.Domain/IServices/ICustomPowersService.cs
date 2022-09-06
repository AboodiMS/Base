using Base.Modules.Users.Domain.DTO.CustomPower;
using Base.Shared.IServices;

namespace Base.Modules.Users.Domain.IServices
{
    public interface ICustomPowersService<GetResponse, GeDetailsResponse, AddRequest, UpdateRequest> :
        ICRUDService<GetResponse, GeDetailsResponse, AddRequest, UpdateRequest>
    {
    }
}
