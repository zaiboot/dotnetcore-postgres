using System;
using System.Diagnostics.CodeAnalysis;
using Autofac.Extras.Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Prizes.Api.Mapping;

namespace Prizes.unittests
{
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
            //Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter);
            // ILogger.Log<Object>(Information, 0, [[0, 1], [{OriginalFormat}, Getting information for customer {0}]], null, System.Func`3[System.Object,System.Exception,
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