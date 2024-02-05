using User.Domain;

namespace User.Application
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommand(IUserRepository userRepository) => _userRepository = userRepository;
        public async Task<UserModel> Create(UserModel userModel)
        {
            var user = await _userRepository.Save(userModel);
            return user;
        }
    }
}
