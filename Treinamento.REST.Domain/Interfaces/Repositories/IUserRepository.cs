using Treinamento.REST.Domain.Entities.Auth;
using Treinamento.REST.Domain.Entities.Users;
using Treinamento.REST.Domain.Enums;

namespace Treinamento.REST.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers(int skip, int pageSize);

        User GetUserById(int id);

        int GetTotalAmountOfUsers();

        User AddUser(User user);

        User UpdateUser(User user);

        bool DeleteUserById(int userId);

        User UpdateUserRole(int userId, Roles role);

        User UpdateUserStatus(int Id, UserStatus status);     

        Authentication VerifyUser(string username);
    }
}
