# Heleonix.Guard

[![Release: .NET / NuGet](https://github.com/Heleonix/Heleonix.Guard/actions/workflows/release-net-nuget.yml/badge.svg)](https://github.com/Heleonix/Heleonix.Guard/actions/workflows/release-net-nuget.yml)

Provides performant guard functionality for methods to throw exceptions

## Install

https://www.nuget.org/packages/Heleonix.Guard

## Documentation

See [Heleonix.Guard](https://heleonix.github.io/docs/Heleonix.Guard)

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

## Contribution Guideline

1. [Create a fork](https://github.com/Heleonix/Heleonix.Guard/fork) from the main repository
2. Implement whatever is needed
3. [Create a Pull Request](https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/proposing-changes-to-your-work-with-pull-requests/creating-a-pull-request-from-a-fork).
   Make sure the assigned [Checks](https://github.com/Heleonix/Heleonix.Guard/actions/workflows/pr-net.yml) pass successfully.
4. [Request review](https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/proposing-changes-to-your-work-with-pull-requests/requesting-a-pull-request-review) from the code owner
5. Once approved, merge your Pull Request via [Squash and merge](https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/incorporating-changes-from-a-pull-request/about-pull-request-merges#squash-and-merge-your-commits)

   > **IMPORTANT**  
   > While merging, enter a [Conventional Commits](https://www.conventionalcommits.org/) commit message.
   > This commit message will be used in automatically generated [Github Release Notes](https://github.com/Heleonix/Heleonix.Guard/releases)
   > and [NuGet Release Notes](https://www.nuget.org/packages/Heleonix.Guard/#releasenotes-body-tab)

5. Monitor the [Release: .NET / NuGet](https://github.com/Heleonix/Heleonix.Guard/actions/workflows/release-net-nuget.yml)
   GitHub workflow to make sure your changes are delivered successfully
5. In case of any issues, please contact [heleonix.sln@gmail.com](mailto:heleonix.sln@gmail.com)
5. 