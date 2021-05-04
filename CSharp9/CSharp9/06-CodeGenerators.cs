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
