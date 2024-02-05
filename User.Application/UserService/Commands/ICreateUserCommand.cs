using User.Domain;

namespace User.Application
{
    public interface ICreateUserCommand
    {
        Task<UserModel> Create(UserModel userModel);
    }
}
