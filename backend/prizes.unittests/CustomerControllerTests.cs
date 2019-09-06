using System;
using System.Diagnostics.CodeAnalysis;
using prizes.Controllers;
using Xunit;
using Autofac.Extras.Moq;
using prizes.Repository;
using Prizes.Api.Mapping;
using Microsoft.Extensions.Logging;
using Moq;
using prizes.Repository.DTO;
using Prizes.Models;

namespace prizes.unittests
{
    [ExcludeFromCodeCoverage]
    public class CustomerControllerTests  //where TSystemUnderTest:ICustomerController
    {
        protected void AndISetupInfoLogger(AutoMock mock)
        {   
            AndISetUpLog(mock, LogLevel.Information);
        }
        private void AndISetUpLog(AutoMock mock, LogLevel logLevel)
        {
            //Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter);
            // ILogger.Log<Object>(Information, 0, [[0, 1], [{OriginalFormat}, Getting information for customer {0}]], null, System.Func`3[System.Object,System.Exception,
            mock.Mock<ILogger<ICustomerController>>().Setup(l => l.Log(
                It.Is<LogLevel>(ll => ll == logLevel),
                It.IsAny<EventId>(),
                It.IsAny<object>(),
                It.IsAny<Exception>(),
                It.IsAny<Func<object, Exception, string>>()
            ))
            ;
        }

        protected void AndISetupAMapping<TFrom, TDestiny>(AutoMock mock, TDestiny result) where TDestiny : new()
        {
            mock.Mock<IMappingEngine>().Setup(m =>
                m.Map<TFrom, TDestiny>(
                        It.IsAny<TFrom>()
                        )
            ).Returns(result);
        }
        private ICustomerController GivenTheSystemUnderTest(AutoMock mock)
        {
            AndISetupInfoLogger(mock);
            AndISetupAMapping<CustomerInformation, Customer>(mock, GivenTheCustomer());
            return mock.Create<CustomerController>();
        }

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

        private void Execute(Action<AutoMock, ICustomerController> action)
        {
            using (var mock = AutoMock.GetStrict())
            {
                AndWhenISetACustomer(mock);
                var system = GivenTheSystemUnderTest(mock);
                //execute the action
                action(mock, system);
            }
        }
    }
}
