using System;

namespace AsyncExtensions;

public class CapturedAsyncException : Exception
{
    public CapturedAsyncException(string message) : base(message) { }
    
    public CapturedAsyncException(string message, Exception innerException) : base(message, innerException) { }
}