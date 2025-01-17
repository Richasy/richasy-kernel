// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.DependencyInjection;

namespace RichasyKernel;

/// <summary>
/// 内核.
/// </summary>
public sealed class Kernel(IServiceProvider services)
{
    /// <summary>
    /// 服务供应商.
    /// </summary>
    public IServiceProvider Services { get; } = services;

    /// <summary>
    /// 创建内核构建器.
    /// </summary>
    /// <returns><see cref="IKernelBuilder"/>.</returns>
    public static IKernelBuilder CreateBuilder() => new KernelBuilder();

    /// <summary>
    /// 获取服务.
    /// </summary>
    /// <typeparam name="T">服务类型.</typeparam>
    /// <param name="serviceKey">键.</param>
    /// <returns>服务.</returns>
    /// <exception cref="KernelException">服务未发现.</exception>
    public T GetRequiredService<T>(object? serviceKey = null) where T : class
    {
        T? service = default;

        if (serviceKey is not null)
        {
            if (Services is IKeyedServiceProvider)
            {
                service = Services.GetKeyedService<T>(serviceKey);
            }
        }
        else
        {
            service = Services.GetService<T>();
        }

        if (service is null)
        {
            var msg = serviceKey is null
                ? $"Service of type {typeof(T)} not registered."
                : Services is not IKeyedServiceProvider
                    ? $"Key '{serviceKey}' specified but service provider '{Services}' is not a {nameof(IKeyedServiceProvider)}."
                    : $"Service of type {typeof(T)} with key '{serviceKey}' not registered.";
            throw new KernelException(msg);
        }

        return service;
    }
}
