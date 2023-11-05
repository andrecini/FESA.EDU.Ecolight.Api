using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.REST.Domain.Entities.EndpointsModel;
using Treinamento.REST.Domain.Enums;

namespace Treinamento.REST.Domain.Entities.Users
{
    [DisplayName("Users")]
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Celular { get; set; }
        public string Cpf { get; set; }
        public States Uf { get; set; }
        public Roles Role { get; set; }
        public UserStatus Active { get; set; }
        public int EmpresaId { get; set; }

        public static User Map(UserInput user)
        {
            return new User()
            {
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                Celular= user.Celular,
                Cpf= user.Cpf,
                Uf= user.Uf,
                Role= user.Role,
                Active= user.Active,
                EmpresaId= user.EmpresaId
            };
        }

        public static User Map(int id, UserInput user)
        {
            return new User()
            {
                Id = id,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                Celular = user.Celular,
                Cpf = user.Cpf,
                Uf = user.Uf,
                Role = user.Role,
                Active = user.Active,
                EmpresaId = user.EmpresaId
            };
        }

    }
}
