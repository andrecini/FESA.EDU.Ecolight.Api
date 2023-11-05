using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.REST.Domain.Enums;

namespace Treinamento.REST.Domain.Entities.EndpointsModel
{
    [DisplayName("Users")]
    public class UserInput
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Celular { get; set; }
        public string Cpf { get; set; }
        public States Uf { get; set; }
        public Roles Role { get; set; }
        public UserStatus Active { get; set; }
        public int EmpresaId { get; set; }
    }
}
