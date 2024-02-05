using User.Domain;

namespace User.Application
{
    public interface IUserQueryService
    {
        Task<IReadOnlyCollection<UserModel>> Get();
    }
}
