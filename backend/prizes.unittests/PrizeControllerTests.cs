using System;
using System.Diagnostics.CodeAnalysis;
using Prizes.Controllers;
using Xunit;
using Autofac.Extras.Moq;
using Prizes.Repository;
using System.Linq;
using System.Collections.Generic;
using Prizes.DTO;
using Moq;
using System.Threading.Tasks;

namespace Prizes.UnitTests
{
    [ExcludeFromCodeCoverage]
    public class PrizeControllerTests : BaseTest<PrizeController>
    {

        [Fact]
        public void LoadsPrizesIsNotNull()
        {
            Action<AutoMock, PrizeController> action = async (AutoMock m, PrizeController system) =>
            {
                const int PRIZES_COUNT = 10;
                AndWhenISetUpPrizes(PRIZES_COUNT, m, 1);
                AndISetupAMapping<IEnumerable<Prize>, List<Models.Prize>>(m, GivenAListOfModelPrize(PRIZES_COUNT));
                AndWhenIMarkOneAsAvailable(m);
                var r = await system.GetAsync(1);
                Assert.NotNull(r);
                Assert.NotNull(r.Value);
                var prizes = r.Value;
                Assert.True(prizes.Any());
            };
            Execute(action);
        }
        private void AndWhenIMarkOneAsAvailable(AutoMock m)
        {
            m.Mock<IPrizeRepository>()
                .Setup(s => s.MarkOneAsAvailable(It.IsAny<Prize>()))
                    .Returns(Task.CompletedTask);


        }
        private void AndWhenISetUpPrizes(int count, AutoMock m, int customerId)
        {
            var prizes = new List<Prize>();
            for (int i = 0; i < count; i++)
            {
                var p = GivenASinglePrize(i);
                prizes.Add(p);
            }
            m.Mock<IPrizeRepository>().Setup(s => s.GetPrizes(customerId)).Returns(prizes);

        }
        private List<Models.Prize> GivenAListOfModelPrize(int count)
        {

            var list = new List<Models.Prize>();

            for (int i = 0; i < count; i++)
            {
                list.Add(
                    new Models.Prize
                    {
                        Id = i,
                        Description = $"{i} - Name",
                        Amount = i * 100
                    }

                );
            }

            return list;
        }
        private Prize GivenASinglePrize(int i)
        {
            return new Prize
            {
                Id = i,
                Name = $"{i} - Name",
                Amount = i * 100
            };
        }

        [Fact]
        public void CustomerIsValid()
        {
            Action<AutoMock, PrizeController> action = async (m, system) =>
            {
                const int PRIZES_COUNT = 10;
                AndWhenISetUpPrizes(PRIZES_COUNT, m, 1);
                AndISetupAMapping<IEnumerable<Prize>, List<Models.Prize>>(m, GivenAListOfModelPrize(PRIZES_COUNT));
                AndWhenIMarkOneAsAvailable(m);
                var r = await system.GetAsync(1);
                Assert.NotNull(r);
                Assert.NotNull(r.Value);
                var prizes = r.Value;
                Assert.True(prizes.Any());

            };
            this.Execute(action);
        }


    }
}
