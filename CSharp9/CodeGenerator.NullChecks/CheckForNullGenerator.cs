using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGenerator.NullChecks
{
    [Generator]
    public class CheckForNullGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var sourceBuilder = new StringBuilder(@"
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
");
            var visitor = new Visitor(sourceBuilder);
            foreach(var symbol in context.Compilation.GetSymbolsWithName(_ => true))
            {
                visitor.Visit(symbol);
            }
            sourceBuilder.AppendLine(@"
    }
}
");
            context.AddSource("NullCheckTests.cs", sourceBuilder.ToString());
        }

        public void Initialize(GeneratorInitializationContext context)
        {

        }
    }

    public class Visitor : SymbolVisitor
    {
        private StringBuilder _SourceBuilder;
        private readonly HashSet<string> _CreatedMethods = new HashSet<string>();

        public Visitor(StringBuilder sourceBuilder)
        {
            _SourceBuilder = sourceBuilder;
        }

        public override void VisitNamedType(INamedTypeSymbol symbol)
        {
            foreach (var child in symbol.GetMembers())
            {
                child.Accept(this);
            }
            base.VisitNamedType(symbol);
        }

        public override void VisitMethod(IMethodSymbol symbol)
        {
            if (symbol.MethodKind == MethodKind.Constructor &&
                symbol.GetAttributes() is { } attributes &&
                attributes.Any(x => x.AttributeClass.Name == nameof(CheckParametersAttribute)))
            {
                foreach (var parameter in symbol.Parameters)
                {
                    string methodName = $"{symbol.ContainingType.Name}Constructor_{parameter.Name}IsNull_ThrowsException";
                    if (!_CreatedMethods.Add(methodName)) continue;
                    _SourceBuilder.AppendLine($@"
        [Fact]
        public void {methodName}()
        {{");
                    _SourceBuilder.Append($"            var ex = Assert.Throws<ArgumentNullException>(() => new {symbol.ContainingType.ToDisplayString()}(");

                    _SourceBuilder.Append(string.Join(", ",
                        symbol.Parameters.Select(p =>
                        {
                            if (p.Name == parameter.Name)
                            {
                                return "null!";
                            }
                            return $"Mock.Of<{p.Type.ToDisplayString()}>()";
                        })));

                    _SourceBuilder.AppendLine("));");
                    _SourceBuilder.AppendLine($"            Assert.Equal(\"{parameter.Name}\", ex.ParamName);");
                    _SourceBuilder.AppendLine(@"        }");
                }
            }
            base.VisitMethod(symbol);
        }
    }
}
