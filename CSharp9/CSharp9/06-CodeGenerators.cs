using CodeGenerator.NullChecks;
using System;

namespace CSharp9
{
    public class CodeGenerators
    {
        public class Controller
        {
            [CheckParameters]
            public Controller(IService service, IService2 service2)
            {
                Service = service ?? throw new ArgumentNullException(nameof(service));
                Service2 = service2 ?? throw new ArgumentNullException(nameof(service2));
            }

            public IService Service { get; }
            public IService2 Service2 { get; }
        }

        public interface IService
        { }

        public interface IService2
        { }
    }
}
/*
 *** GENERATED OUTPUT ***

using System;
using Moq;
using Xunit.Abstractions;
using Xunit;
namespace Generated_Tests
{
    public class Generated
    {
        private readonly ITestOutputHelper _Output;

        public Generated(ITestOutputHelper output)
        {
            _Output = output;
        }

        [Fact]
        public void ControllerConstructor_serviceIsNull_ThrowsException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new CSharp9.CodeGenerators.Controller(null!, Mock.Of<CSharp9.CodeGenerators.IService2>()));
            Assert.Equal("service", ex.ParamName);
        }

        [Fact]
        public void ControllerConstructor_service2IsNull_ThrowsException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new CSharp9.CodeGenerators.Controller(Mock.Of<CSharp9.CodeGenerators.IService>(), null!));
            Assert.Equal("service2", ex.ParamName);
        }

    }
}
 */
