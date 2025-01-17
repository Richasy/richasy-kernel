// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.DependencyInjection;

namespace RichasyKernel;

/// <summary>
/// 内核构建器.
/// </summary>
internal sealed class KernelBuilder : IKernelBuilder
{
    public KernelBuilder() => Services = new ServiceCollection();

    public IServiceCollection Services { get; }
}
