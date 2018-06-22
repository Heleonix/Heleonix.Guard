# Heleonix.Guard

Provides performant guard functionality for methods to throw exceptions

## Install

https://www.nuget.org/packages/Heleonix.Guard

## Example

```csharp
using Heleonix.Guard;
using Heleonix.Extensions;
using static Heleonix.Guard.Host;

public static class Test
{
    public static void Main()
    {
        MyMethod(null);
    }

    public static void MyMethod(string param)
    {
        // C# 7.2+: Non-Trailing named arguments
        Throw.ArgumentNullException(when: param.IsNull(), nameof(param));

        // OR

        // Prior to C# 7.2: You can use a helper method 'When'
        Throw.ArgumentNullException(When(param.IsNull()), nameof(param));

        // OR
        Throw.ArgumentNullException(param == null, nameof(param));

        // OR
        Throw.ArgumentNullException(When(param == null), nameof(param));
    }
}
```

The `Heleonix.Extensions` provides many useful predicative extensions to build assertions,
like `IsNull()`, `IsNullOrEmptyOrWhiteSpace()`, `IsLessThan()` etc.
**These extensions do not throw exceptions**, so they will not overlap an exception to be really thrown. See [Heleonix.Extensions](https://github.com/Heleonix/Heleonix.Extensions) for more details.

The `Host.Throw` property returns a singleton instance of the `Heleonix.Guard.ExceptionRaiser` class,
which provides methods to throw many existing exceptions, like `ArgumentNullException`, `FileLoadException` etc.
See more via VisualStudio intellisense.

The `ExceptionRaiser` returned by the `Host.Throw` is the singleton instance, so there is no creations of new objects every time,
as it is usually implemented in fluent interfaces. Besides, it also provides ability to implement custom exception raisers via extension methods:

```csharp
using Heleonix.Guard;

public static class ExceptionRaiserExtensions
{
#pragma warning disable CC0057 // Unused parameters
    public static void MyCustomException(this ExceptionRaiser raiser, bool when, int param1, string param2, object paramN, string message = null, Exception innerException = null)
    {
        if (when)
        {
            throw new MyCustomException(param1, param2, paramN, message, innerException);
        }
    }
#pragma warning restore CC0057 // Unused parameters
}
```

and then use it, for example, as below:

```csharp
Throw.MyCustomException(when: param1.IsZero() || param2.IsNullOrEmpty() || paramN.IsNull(), "some message");
```
