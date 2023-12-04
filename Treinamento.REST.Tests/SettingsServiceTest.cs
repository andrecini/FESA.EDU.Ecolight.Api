using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.REST.Domain.Enums;
using Treinamento.REST.Services.Services;
using Treinamento.REST.Tests.Mocks.Data;
using Treinamento.REST.Tests.Mocks.Repository;

namespace Treinamento.REST.Tests
{
    public class SettingsServiceTest
    {
        [Fact]
        public void GetSettings()
        {
            var service = new SettingsService(SettingsRepositoryMock.Get());

            var configuracoes = service.GetSettings(1);

            Assert.Equivalent(SettingsData.GetList(20), configuracoes);
        }
        
        [Fact]
        public void GetSettingsById()
        {
            var service = new SettingsService(SettingsRepositoryMock.Get());

            var configuracoes = service.GetSettingsById(1);

            Assert.Equivalent(SettingsData.GetSample()["Simples"], configuracoes);
        }

        [Fact]
        public void GetTotalAmountOfSettings()
        {
            var service = new SettingsService(SettingsRepositoryMock.Get());

            var configuracoes = service.GetTotalAmountOfSettings(1);

            Assert.Equivalent(10, configuracoes);
        }

        [Fact]
        public void GetActiveSettings()
        {
            var service = new SettingsService(SettingsRepositoryMock.Get());

            var configuracoes = service.GetActiveSettings(1);

            Assert.Equivalent(SettingsData.GetList(10).Where(x => x.Enable), configuracoes);
        }

        [Fact]
        public void GetInactiveSettings()
        {
            var service = new SettingsService(SettingsRepositoryMock.Get());

            var configuracoes = service.GetInactiveSettings(1);

            Assert.Equivalent(SettingsData.GetList(10).Where(x => !x.Enable), configuracoes);
        }

        [Fact]
        public void AddSettings()
        {
            var service = new SettingsService(SettingsRepositoryMock.Get());

            var configuracoes = service.AddSettings(SettingsData.GetDeviceInput()["Simples"]);

            Assert.Equivalent(SettingsData.GetSample()["Simples"], configuracoes);
        }

        [Fact]
        public void UpdateSettings()
        {
            var service = new SettingsService(SettingsRepositoryMock.Get());

            var configuracoes = service.UpdateSettings(1, SettingsData.GetDeviceInput()["Simples"]);

            Assert.Equivalent(SettingsData.GetSample()["Editado"], configuracoes);
        }

        [Fact]
        public void UpdateSettingsStatus()
        {
            var service = new SettingsService(SettingsRepositoryMock.Get());

            var configuracoes = service.UpdateSettingsStatus(1, SettingsStatus.Active);

            Assert.Equivalent(SettingsData.GetSample()["Editado"], configuracoes);
        } 
    }
}
