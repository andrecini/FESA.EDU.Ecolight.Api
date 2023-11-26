using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.REST.Services.Services;

namespace Treinamento.REST.Tests
{
    public class EncryptorServiceTest
    {
        [Theory]
        [InlineData("teste123")]
        [InlineData("senha123")]
        [InlineData("12345678")]
        public void EncryptAndDecrypt(string password)
        {
            var service = new EncryptorService();

            var encrypted = service.Encrypt(password);
            var decrypt = service.Decrypt(encrypted);

            Assert.NotNull(encrypted);
            Assert.NotNull(decrypt);
            Assert.Equal(password, decrypt);
        }
    }
}
