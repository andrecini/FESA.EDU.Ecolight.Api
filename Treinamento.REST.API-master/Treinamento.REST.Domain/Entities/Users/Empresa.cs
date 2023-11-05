using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treinamento.REST.Domain.Entities.Users
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }
    }
}
