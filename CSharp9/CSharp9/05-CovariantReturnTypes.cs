using Xunit;

namespace CSharp9
{
    public class CovariantReturnTypesTests
    {
        public class Base
        {
            public virtual Base Create() => new();
        }

        public class Derived : Base
        {
            public override Derived Create() => new();
        }

        [Fact]
        public void ReturnTypes()
        {
            Derived derived1 = new();
            Derived create1 = derived1.Create();

            Base derived2 = derived1;
            Base create2 = derived2.Create();
        }
    }
}
