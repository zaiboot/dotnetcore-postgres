using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;
using Autofac.Extras.Moq;
using Moq;
using Customers.Controllers;
using Customers.Models;
using Customers.Repository;
using Customers.Repository.DTO;

namespace Customers.UnitTests
{
    [ExcludeFromCodeCoverage]
    public class CustomerControllerTests : BaseTest<CustomerController>
    {
        private Customer GivenTheCustomer()
        {
            return new Customer
            {
                Name = "Test 01",
                ClaimedAmount = 10
            };
        }

        private void AndWhenISetACustomer(AutoMock m)
        {
            var ci = GivenTheDefautlCustomerInformation();
            m.Mock<ICustomerRepository>().Setup(s => s.GetCustomerInformation(
               It.IsAny<int>()
           )).Returns(ci);

        }

        private CustomerInformation GivenTheDefautlCustomerInformation()
        {
            return new CustomerInformation
            {
                Id = 1,
                CustomerName = "Test 01",
                ClaimedAmount = 10
            };
        }

        [Fact]
        public void CustomerIsNotNull()
        {
            Action<AutoMock, ICustomerController> action = (AutoMock m, ICustomerController system) =>
            {
                AndWhenISetACustomer(m);
                AndISetupAMapping<CustomerInformation, Customer>(m, GivenTheCustomer());
                var customer = system.Get();
                Assert.NotNull(customer);
            };
            this.Execute(action);
        }

        [Fact]
        public void CustomerIsValid()
        {
            Action<AutoMock, ICustomerController> action = (AutoMock m, ICustomerController system) =>
            {
                AndISetupAMapping<CustomerInformation, Customer>(m, GivenTheCustomer());
                AndWhenISetACustomer(m);
                var expected = GivenTheDefautlCustomerInformation();
                var customer = system.Get();
                Assert.NotNull(customer);
                Assert.NotNull(customer.Value);
                var actual = customer.Value;

                Assert.Equal(actual.Name, expected.CustomerName);
                Assert.Equal(actual.ClaimedAmount, expected.ClaimedAmount);

            };
            this.Execute(action);
        }
    }
}
