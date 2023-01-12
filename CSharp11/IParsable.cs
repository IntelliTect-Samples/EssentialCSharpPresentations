namespace CSharp11;

public interface IParsable<T>
{
    static abstract T Parse(string text);

}
