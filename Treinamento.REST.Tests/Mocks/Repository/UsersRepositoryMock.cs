using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.REST.Data.Repositories;
using Treinamento.REST.Domain.Entities.Devices;
using Treinamento.REST.Domain.Entities.EndpointsModel;
using Treinamento.REST.Domain.Entities.Users;
using Treinamento.REST.Domain.Enums;
using Treinamento.REST.Domain.Interfaces.Repositories;
using Treinamento.REST.Tests.Mocks.Data;

namespace Treinamento.REST.Tests.Mocks.Repository
{
    public static class UsersRepositoryMock
    {
        private static IUserRepository _repository;

        public static IUserRepository Get()
        {
            if (_repository == null) CreateInstance();

            return _repository;
        }

        private static void CreateInstance()
        {
            var mock = new Mock<IUserRepository>();

            mock.Setup(x => x.GetUsers(It.IsAny<int>(), It.IsAny<int>())).Returns(UsersData.GetList(10));
            mock.Setup(x => x.GetUserById(It.IsAny<int>())).Returns(UsersData.GetSample()["Simples"]);
            mock.Setup(x => x.GetTotalAmountOfUsers()).Returns(10);
            mock.Setup(x => x.AddUser(It.IsAny<User>())).Returns(UsersData.GetSample()["Simples"]);
            mock.Setup(x => x.UpdateUser(It.IsAny<User>())).Returns(UsersData.GetSample()["Editado"]);
            mock.Setup(x => x.UpdateUserRole(It.IsAny<int>(), It.IsAny<Roles>())).Returns(UsersData.GetSample()["Editado"]);
            mock.Setup(x => x.UpdateUserStatus(It.IsAny<int>(), It.IsAny<UserStatus>())).Returns(UsersData.GetSample()["Editado"]);
            mock.Setup(x => x.DeleteUserById(It.IsAny<int>())).Returns(true);
            mock.Setup(x => x.VerifyUser(It.IsAny<string>())).Returns();




            _repository = mock.Object;
        }
    }
}
