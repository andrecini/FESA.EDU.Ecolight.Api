using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.REST.Domain.Interfaces.Services;
using Treinamento.REST.Tests.Mocks.Data;

namespace Treinamento.REST.Tests.Mocks.Services
{
    public static class EncryptorServiceMock
    {
        private static IEncryptorService _service;

        public static IEncryptorService Get()
        {
            if (_service == null) CreateInstance();

            return _service;
        }

        private static void CreateInstance()
        {
            var mock = new Mock<IEncryptorService>();

            mock.Setup(x => x.Decrypt(It.IsAny<string>())).Returns(EncryptorData.GetPassword());
            mock.Setup(x => x.Encrypt(It.IsAny<string>())).Returns(EncryptorData.GetEncryptedPassword());

            _service = mock.Object;
        }
    }
}
