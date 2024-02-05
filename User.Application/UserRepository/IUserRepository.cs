using User.Domain;

namespace User.Application
{
    public interface IUserRepository
    {
        Task<IReadOnlyCollection<UserModel>> Get();
        Task<UserModel> Save(UserModel model);
        Task<bool> Delete(int id);
        Task<UserModel> Update(int id, UserModel model);
    }
}
