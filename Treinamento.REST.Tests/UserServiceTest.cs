using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.REST.Domain.Entities.Auth;
using Treinamento.REST.Domain.Entities.EndpointsModel;
using Treinamento.REST.Domain.Entities.Users;
using Treinamento.REST.Domain.Enums;
using Treinamento.REST.Domain.Settings;
using Treinamento.REST.Services.Services;
using Treinamento.REST.Tests.Mocks.Data;
using Treinamento.REST.Tests.Mocks.Repository;
using Treinamento.REST.Tests.Mocks.Services;

namespace Treinamento.REST.Tests
{
    public class UserServiceTest
    {
        [Fact]  
        public void GetUsers()
        { 

            var service = new UserService(UsersRepositoryMock.Get(), EncryptorServiceMock.Get());

            var usuarios = service.GetUsers(1, 1);

            Assert.Equivalent(UsersData.GetList(10), usuarios);
        }

        [Fact]
        public void GetTotalAmountOfUsers()
        {
            var service = new UserService(UsersRepositoryMock.Get(), EncryptorServiceMock.Get());

            var amount = service.GetTotalAmountOfUsers();

            Assert.Equivalent(10, amount);
        }

        [Fact]
        public void GetUserById()
        {
            var service = new UserService(UsersRepositoryMock.Get(), EncryptorServiceMock.Get());

            var usuario = service.GetUserById(1);

            Assert.Equivalent(UsersData.GetSample()["Simples"], usuario);
        }

        [Fact]
        public void AddUser()
        {
            var service = new UserService(UsersRepositoryMock.Get(), EncryptorServiceMock.Get());

            var usuario = service.AddUser(UsersData.GetUserInput()["Simples"]);

            Assert.Equivalent(UsersData.GetSample()["Simples"], usuario);
        }

        [Fact]
        public void UpdateUser()
        {
            var service = new UserService(UsersRepositoryMock.Get(), EncryptorServiceMock.Get());

            var usuario = service.UpdateUser(1, UsersData.GetUserInput()["Simples"]);

            Assert.Equivalent(UsersData.GetSample()["Editado"], usuario);
        }

        [Fact]
        public void DeleteUserById()
        {
            var service = new UserService(UsersRepositoryMock.Get(), EncryptorServiceMock.Get());

            var usuario = service.DeleteUserById(1);

            Assert.Equivalent(true, usuario);
        }

        [Fact]
        public void UpdateUserRole()
        {
            var service = new UserService(UsersRepositoryMock.Get(), EncryptorServiceMock.Get());

            var usuario = service.UpdateUserRole(1, Roles.Developer);

            Assert.Equivalent(UsersData.GetSample()["Editado"], usuario);
        }

        [Fact]
        public void UpdateUserStatus()
        {
            var service = new UserService(UsersRepositoryMock.Get(), EncryptorServiceMock.Get());

            var usuario = service.UpdateUserStatus(1, UserStatus.Active);

            Assert.Equivalent(UsersData.GetSample()["Editado"], usuario);
        }

    }
}
