// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.DependencyInjection;

namespace RichasyKernel;

/// <summary>
/// 定义内核构建器的接口.
/// </summary>
public interface IKernelBuilder
{
    /// <summary>
    /// 获取 <see cref="IServiceCollection"/> 实例.
    /// </summary>
    IServiceCollection Services { get; }
}
