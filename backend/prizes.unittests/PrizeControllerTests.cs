using System;
using System.Diagnostics.CodeAnalysis;
using Prizes.Controllers;
using Xunit;
using Autofac.Extras.Moq;
using Prizes.Repository;
using Moq;
using System.Linq;

namespace Prizes.unittests
{
    [ExcludeFromCodeCoverage]
    public class PrizeControllerTests : BaseTest<PrizeController>
    {

        [Fact]
        public void LoadsPrizesIsNotNull()
        {
            Action<AutoMock, PrizeController> action = (AutoMock m, PrizeController system) =>
            {
                const int PRIZES_COUNT = 10;
                AndWhenISetUpPrizes(PRIZES_COUNT, m);
                var r = system.Get();
                Assert.NotNull(r);
                Assert.NotNull(r.Value);
                var prizes = r.Value;
                Assert.True(prizes.Any());
            };
            Execute(action);
        }

        private void AndWhenISetUpPrizes(int count, AutoMock m)
        {
            
            for (int i = 0; i < count; i++)
            {

            }
        //     m.Mock<IPrizeRepository>().Setup(s => s.
        //       It.IsAny<int>()
        //   )).Returns(ci);

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
