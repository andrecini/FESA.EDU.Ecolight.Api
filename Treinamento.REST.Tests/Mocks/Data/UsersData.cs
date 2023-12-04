using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using Treinamento.REST.Domain.Entities.Auth;
using Treinamento.REST.Domain.Entities.Devices;
using Treinamento.REST.Domain.Entities.EndpointsModel;
using Treinamento.REST.Domain.Entities.Users;
using Treinamento.REST.Domain.Enums;

namespace Treinamento.REST.Tests.Mocks.Data
{
    public static class UsersData
    {
        public static Dictionary<string, User> GetSample()
        {
            var devices = new Dictionary<string, User>();

            devices.Add("Simples", new User
            {
                Id = 1,
                EmpresaId = 1,
                Username = "Usuário Teste",
                Uf = States.SaoPaulo,
                Celular = "11981724993",
                Cpf = "51332459803",
                Email = "teste@email.com",
                Password = "SenhaEncryptografada",
                Active = UserStatus.Active,
                Role = Roles.Administrator
            });

            devices.Add("Editado", new User
            {
                Id = 1,
                EmpresaId = 1,
                Username = "Usuário Teste - Editado",
                Uf = States.SaoPaulo,
                Celular = "11981724993",
                Cpf = "51332459803",
                Email = "teste@email.com",
                Password = "SenhaEncryptografada",
                Active = UserStatus.Active,
                Role = Roles.Administrator


            });

            return devices;

        }

        public static Dictionary<string, UserInput> GetUserInput()
        {
            var devices = new Dictionary<string, UserInput>();

            devices.Add("Simples", new UserInput
            {
               Username = "Usuario Teste",
               Email = "teste@email.com",
               Password = "SenhaEncryptografada",
               Celular = "11981724993",
               Cpf = "51332459803",
               Uf = States.SaoPaulo,
               Role = Roles.Administrator,
               Active = UserStatus.Active,
               EmpresaId = 1
            });

            devices.Add("Editado", new UserInput
            {
                Username = "Usuário Teste - Editado",
                Email = "teste@email.com",
                Password = "SenhaEncryptografada",
                Celular = "11981724993",
                Cpf = "51332459803",
                Uf = States.SaoPaulo,
                Role = Roles.Administrator,
                Active = UserStatus.Active,
                EmpresaId = 1
            });

            return devices;
        }

        public static Dictionary<string, Authentication> VerifyUser()
        {
            var devices = new Dictionary<string, Authentication>();

            devices.Add("Simples", new Authentication
            {
                Id = 1,
                EmpresaId = 1,
                Token = new TokenModel
                {
                    Token = "Token",
                    ValidTo = DateTime.Now.AddHours(5)
                },
                UserName = "Usuário Teste",
                Role = Roles.Administrator
            });

            return devices;
        }

        public static List<User> GetList(int amount)
        {
            var devices = new List<User>();

            for (int i = 1; i <= amount; i++)
            {
                devices.Add(new User
                {
                    Id = i,
                    EmpresaId = 1,
                    Username = $"Usuário Teste - {i}",
                    Uf = States.SaoPaulo,
                    Celular = "11981724993",
                    Cpf = "51332459803",
                    Email = "teste@email.com",
                    Password = "SenhaEncryptografada",
                    Active = UserStatus.Active,
                    Role = Roles.Administrator
                });
            }

            return devices;
        }
    }
}
