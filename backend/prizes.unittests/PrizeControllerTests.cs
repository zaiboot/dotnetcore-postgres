using System;
using System.Diagnostics.CodeAnalysis;
using Prizes.Controllers;
using Xunit;
using Autofac.Extras.Moq;
using Prizes.Repository;
using Moq;
using Prizes.Repository.DTO;
using Prizes.Models;
using System.Linq;

namespace Prizes.unittests
{
    [ExcludeFromCodeCoverage]
    public class PrizeControllerTests : BaseTest<PrizeController> 
    {

        [Fact]
        public void CustomerIsNotNull()
        {
            Action<AutoMock, PrizeController> action = (AutoMock m, PrizeController system) =>
            {
                var customer = system.Get();
                Assert.NotNull(customer);
            };
            Execute(action);
        }

        [Fact]
        public void CustomerIsValid()
        {
            Action<AutoMock, PrizeController> action = (AutoMock m, PrizeController system) =>
            {
                var r = system.Get();
                Assert.NotNull(r);
                Assert.NotNull(r.Value);
                var prizes = r.Value;
                Assert.True(prizes.Any());
                
            };
            this.Execute(action);
        }

       
    }
}
