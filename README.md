![.NET](https://img.shields.io/badge/.NET-9.0%2C%20standard2.0-512BD4)
[![language](https://img.shields.io/badge/language-C%23-239120)](https://learn.microsoft.com/dotnet/csharp/tour-of-csharp/overview)
![OS](https://img.shields.io/badge/OS-windows-0078D4)
[![RichasyKernel.Abstractions](https://img.shields.io/nuget/v/RichasyKernel.Abstractions?label=RichasyKernel.Abstractions
)](https://www.nuget.org/packages/RichasyKernel.Abstractions)
[![RichasyKernel.Core](https://img.shields.io/nuget/v/RichasyKernel.Core?label=RichasyKernel.Core
)](https://www.nuget.org/packages/RichasyKernel.Core)

## 🚀 关于

**RichasyKernel** 是一个简单的依赖注入包装，它基于 [Microsoft.Extensions.DependencyInjection.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection.Abstractions)。

我通过这个项目在多个应用中共享依赖注入代码。

## 📝 如何使用

**RichasyKernel.Abstractions** 提供一个 `IKernelBuilder` 接口，用于注册服务，你可以像这样使用：

```csharp
var kernelBuilder = Kernel.CreateBuilder();
kernelBuilder.Services.AddSingleton<IFoo, Foo>();
```

调用 `Kernel.CreateBuilder()` 会返回一个库自带的简单实现：`KernelBuilder`，如果你有自定义需求，可以自行扩展 `IKernelBuilder` 接口。

当完成依赖注入后，你可以调用 `kernelBuilder.Services.BuildServiceProvider()` 来获取 `IServiceProvider`，或者你也可以创建一个 Kernel 对象：

```csharp
var kernel = new Kernel(kernelBuilder.Services.BuildServiceProvider());
```

一般情况下，我更推荐你在引入 **RichasyKernel.Core** 后使用下面的写法：

```csharp
// Extensions.cs
// 先将依赖写为静态扩展方法.
private static IKernelBuilder AddFoo(this IKernelBuilder builder)
{
    builder.Services.AddSingleton<IFoo, Foo>();
    return builder;
}

private static IKernelBuilder AddBar(this IKernelBuilder builder)
{
    builder.Services.AddSingleton<IBar, Bar>();
    return builder;
}

// Program.cs
// 然后在注入时链式调用，最终使用 Build 方法构建一个 Kernel 对象.
var kernel = Kernel
    .CreateBuilder()
    .AddFoo()
    .AddBar()
    .Build();

var foo = kernel.GetRequiredService<IFoo>();
```