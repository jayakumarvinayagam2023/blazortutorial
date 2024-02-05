using User.Domain;

namespace User.Application
{
    public class UserQueryService : IUserQueryService
    {
        private readonly IUserRepository _userRepository;

        public UserQueryService(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<IReadOnlyCollection<UserModel>> Get() => await _userRepository.Get();
    }
}
