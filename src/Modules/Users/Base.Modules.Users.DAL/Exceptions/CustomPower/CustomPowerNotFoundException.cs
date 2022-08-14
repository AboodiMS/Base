using Base.Shared.Exceptions;

namespace Base.Modules.Users.DAL.Exceptions.CustomPower
{
    internal class CustomPowerNotFoundException : BaseException
    {
        public Guid Id { get; }

        public CustomPowerNotFoundException(Guid id) : base($"CustomPower with ID: '{id}' was not found.")
        {
            Id = id;
        }
    }
}
