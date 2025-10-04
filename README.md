# AsyncExtensions

Extensions for common async use cases.  
Have you ever had the need to do something like?
```csharp
var x = (await dbContext.Table.Where(...)).ToList();
```

What if you could just do this?
```chsharp
var x = await dbContext.Table.Where(...).ToListAsync();
```

Or have you ever needed the result of a task but felt /icky/ doing this?
```csharp
var x = myMethodAsync()?.Result;
```

What if you could just do this?
```csharp
var x = myMethodAsync().WaitFor();
```

This simple library attempts to add extensions for tasks for these use cases.
The following methods are included:
- `WaitFor`
- `ToListAsync`
- `ToArrayAsync`
- `AsEnumerableAsync`

This hand-dandy little library also includes some extensions for timing methods.
This comes in the form of `Time` and `TimeAsync` methods on the `Stopwatch` class in the System.Diagnostics namespace.
These work as follows:  
```csharp
var watch = new Stopwatch();
var res = watch.Time(() => MyMethod());
```

This will return you a `StopwatchResult` which contains the duration, elapsed milliseconds, as well as the signature of the method executed (if it can be determined).
If the method returned a result, that will also be included with a `Result` property.
