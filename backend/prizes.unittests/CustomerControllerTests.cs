using System;
using System.Diagnostics.CodeAnalysis;
using prizes.Controllers;
using Xunit;
using Autofac.Extras.Moq;
using prizes.Repository;

namespace prizes.unittests
{
    [ExcludeFromCodeCoverage]
    public class CustomerControllerTests
    {
        private ICustomerController GivenTheSystemUnderTest(AutoMock mock){
            
            var mRepostorty = mock.Create<ICustomerRepository>();
            return new CustomerController(mRepostorty);
        }
        [Fact]
        public void CustomerIsNotNull()
        {  
            Action<AutoMock, ICustomerController> action = (AutoMock m, ICustomerController system ) => {
                //AndWhenISetACustomer(m);
                var customer = system.Get();
                Assert.NotNull(customer);
            };
            this.Execute(action);
        }

        private void Execute(Action<AutoMock,ICustomerController> action){
            using (var mock = AutoMock.GetStrict())
            {
                var system = GivenTheSystemUnderTest(mock);
                //execute the action
                action(mock, system);
            }
        }
    }
}
