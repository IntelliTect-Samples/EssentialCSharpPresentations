namespace CSharp11;

#if CSHARP11
internal class ExpectedExceptionAttribute<T> : Attribute
{
    private string v;

    public ExpectedExceptionAttribute(string v)
    {
        this.v=v;
    }
}
#endif // CSHARP11