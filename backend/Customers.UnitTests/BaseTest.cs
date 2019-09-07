using System;
using System.Diagnostics.CodeAnalysis;
using Autofac.Extras.Moq;
using Customers.Api.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Customers.UnitTests
{
    //this is a good candidate for a nuget package.
    [ExcludeFromCodeCoverage]
    public abstract class BaseTest<TController> where TController : ControllerBase
    {

        protected void Execute(Action<AutoMock, TController> action)
        {
            using (var mock = AutoMock.GetStrict())
            {
                var system = GivenTheSystemUnderTest(mock);
                //execute the action
                action(mock, system);
            }
        }
        protected TController GivenTheSystemUnderTest(AutoMock mock)
        {
            AndISetupInfoLogger(mock);
            return mock.Create<TController>();
        }
        protected void AndISetupInfoLogger(AutoMock mock)
        {
            AndISetUpLog(mock, LogLevel.Information);
        }
        private void AndISetUpLog(AutoMock mock, LogLevel logLevel)
        {
            mock.Mock<ILogger<TController>>().Setup(l => l.Log(
                It.Is<LogLevel>(ll => ll == logLevel),
                It.IsAny<EventId>(),
                It.IsAny<object>(),
                It.IsAny<Exception>(),
                It.IsAny<Func<object, Exception, string>>()
            ))
            ;
        }

        protected void AndISetupAMapping<TFrom, TDestiny>(AutoMock mock, TDestiny result)
        {
            mock.Mock<IMappingEngine>().Setup(m =>
                m.Map<TFrom, TDestiny>(
                        It.IsAny<TFrom>()
                        )
            ).Returns(result);
        }
    }
}