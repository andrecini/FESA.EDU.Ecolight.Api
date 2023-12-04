using Treinamento.REST.Domain.Entities.Devices;
using Treinamento.REST.Domain.Enums;
using Treinamento.REST.Services.Services;
using Treinamento.REST.Tests.Mocks.Data;
using Treinamento.REST.Tests.Mocks.Repository;
using Treinamento.REST.Tests.Mocks.Services;

namespace Treinamento.REST.Tests
{
    public class DeviceServiceTest
    {
        [Fact]
        public void GetDevices()
        {
            var service = new DeviceService(DeviceRepositoryMock.Get(), HistoricServiceMock.Get());

            var devices = service.GetDevices(1);

            Assert.Equivalent(DeviceData.GetList(10), devices);
        }

        [Fact]
        public void GetDevicesById()
        {
            var service = new DeviceService(DeviceRepositoryMock.Get(), HistoricServiceMock.Get());

            var device = service.GetDeviceById(1);

            Assert.Equivalent(DeviceData.GetSample()["Simples"], device);
        }

        [Fact]
        public void GetActiveDevices()
        {
            var service = new DeviceService(DeviceRepositoryMock.Get(), HistoricServiceMock.Get());

            var devices = service.GetActiveDevices(1);

            Assert.Equivalent(DeviceData.GetList(10), devices);
        }

        [Fact]
        public void GetInactiveDevices()
        {
            var service = new DeviceService(DeviceRepositoryMock.Get(), HistoricServiceMock.Get());

            var devices = service.GetInactiveDevices(1);

            Assert.Equivalent(new List<Device>(), devices);
        }

        [Fact]
        public void GetTotalAmountOfDevices()
        {
            var service = new DeviceService(DeviceRepositoryMock.Get(), HistoricServiceMock.Get());

            var amount = service.GetTotalAmountOfDevices(1);

            Assert.Equivalent(10, amount);
        }

        [Fact]
        public void UpdateDevice()
        {
            var service = new DeviceService(DeviceRepositoryMock.Get(), HistoricServiceMock.Get());

            var device = service.UpdateDevice(100, DeviceData.GetDeviceInput()["Simples"]);

            Assert.Equivalent(DeviceData.GetSample()["Editado"], device);
        }

        [Fact]
        public void UpdateDeviceStatus()
        {
            var service = new DeviceService(DeviceRepositoryMock.Get(), HistoricServiceMock.Get());

            var device = service.UpdateDeviceStatus(1, SettingsStatus.Active);

            Assert.Equivalent(DeviceData.GetSample()["Editado"], device);
        }

        [Fact]
        public void AddDevice()
        {
            var service = new DeviceService(DeviceRepositoryMock.Get(), HistoricServiceMock.Get());

            var device = service.AddDevice(DeviceData.GetDeviceInput()["Simples"]);

            Assert.Equivalent(DeviceData.GetSample()["Simples"], device);
        }

        [Fact]
        public void GetDeviceReport()
        {
            var service = new DeviceService(DeviceRepositoryMock.Get(), HistoricServiceMock.Get());

            var report = service.GetDeviceReport(1);

            Assert.Equivalent(ReportData.GetSample()["Simples"].DevicesExpenses, report.DevicesExpenses);
            Assert.Equivalent(ReportData.GetSample()["Simples"].CarbonEmission, report.CarbonEmission);
            Assert.Equivalent(ReportData.GetSample()["Simples"].MonthlyKwhSavings, report.MonthlyKwhSavings);
            Assert.Equivalent(ReportData.GetSample()["Simples"].MonthlyDevicesExpenseSavings, report.MonthlyDevicesExpenseSavings);
            Assert.Equivalent(ReportData.GetSample()["Simples"].AllDevices, report.AllDevices);
            Assert.Equivalent(ReportData.GetSample()["Simples"].CriticalDevices, report.CriticalDevices);
        }

        [Fact]
        public void GetDashboard()
        {
            var service = new DeviceService(DeviceRepositoryMock.Get(), HistoricServiceMock.Get());

            var dashboard = service.GetDashboard(1);

            Assert.Equivalent(DashboardData.GetSample()["Simples"].Inactive, dashboard.Inactive);
            Assert.Equivalent(DashboardData.GetSample()["Simples"].Active, dashboard.Active);
            Assert.Equivalent(DashboardData.GetSample()["Simples"].Total, dashboard.Total);
            Assert.Equivalent(DashboardData.GetSample()["Simples"].MonthlyDeviceExpenses, dashboard.MonthlyDeviceExpenses);
            Assert.Equivalent(DashboardData.GetSample()["Simples"].MonthlyKwhUsage, dashboard.MonthlyKwhUsage);
        }
    }
}