using System;

namespace Common.AsyncExtensions;

public class CapturedAsyncException(string message, Exception innerException) : 
    Exception(message, innerException);