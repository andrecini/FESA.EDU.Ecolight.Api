using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treinamento.REST.Tests.Mocks.Data
{
    public static class EncryptorData
    {
        public static string GetPassword()
        {
            return "SenhaEncryptografada";
        }

        public static string GetEncryptedPassword() 
        {
            return "SenhaEncryptografada";
        }
    }
}
