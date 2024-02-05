using System.Collections.Immutable;
using User.Application;
using User.Domain;

namespace User.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private static IList<UserModel>? userModels = new List<UserModel>();
        public UserRepository()
        {
            userModels = new List<UserModel>() {
                new (){ Name = new Name("Jaya", "Kumar", "Vinayagam"), Address = "Chennai", Email = "jayakumarvinayagam@outlook.com", Id = 100, Phone = "9952366332"}
            };
        }

        public Task<bool> Delete(int id)
        {
            bool isUserExist = userModels!.Any(user => user.Id == id);
            if (isUserExist)
                userModels!.Remove(userModels.SingleOrDefault(user => user.Id == id));
            return Task.FromResult(isUserExist);
        }

        public async Task<IReadOnlyCollection<UserModel>> Get() => await Task.FromResult(userModels!.ToImmutableList());

        public async Task<UserModel> Save(UserModel model)
        {
            userModels!.Add(model);
            return await Task.FromResult(model);
        }

        public Task<UserModel> Update(int id, UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
