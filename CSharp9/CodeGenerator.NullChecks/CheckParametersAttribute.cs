using System;

namespace CodeGenerator.NullChecks
{
    [AttributeUsage(AttributeTargets.Constructor)]
    public class CheckParametersAttribute : Attribute
    { }
}
