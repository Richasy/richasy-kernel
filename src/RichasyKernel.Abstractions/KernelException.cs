// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

namespace RichasyKernel;

/// <summary>
/// 内核错误类型.
/// </summary>
public class KernelException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="KernelException"/> class.
    /// </summary>
    public KernelException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="KernelException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public KernelException(string? message) : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="KernelException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
    public KernelException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
