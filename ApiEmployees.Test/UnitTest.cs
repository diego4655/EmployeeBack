using ApiEmployees.Entities;
using ApiEmployees.Repository;
using ApiEmployees.Services;
using Moq;
using Xunit;
using Assert = Xunit.Assert;

namespace ApiEmployees.Test
{
    public class Tests
    {
        private readonly Mock<IDataAccess<ServiceResponse>> _dataAccess;
        private readonly EmployeesInformationService _EmployeesInformation;

        public Tests()
        {
            _dataAccess = new Mock<IDataAccess<ServiceResponse>>();
            _EmployeesInformation = new EmployeesInformationService(_dataAccess.Object);
        }

        [Fact]
        public async Task BussinesLayerTest()
        {
            List<string> possibleStates = new() { "success", "Failed" };
            var information = await _EmployeesInformation.GetEmployeeInformation(1);
            Assert.IsType<ServiceResponse>(information);
        }
    }
}