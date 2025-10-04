using System.Threading.Tasks;

namespace Common.AsyncExtensions;

public static class TaskExtensions
{
    /// <summary>
    /// Wait for the task to finish (synchronously).
    /// </summary>
    /// <param name="self">The task to be awaited.</param>
    public static void WaitFor(this Task self) => self.AwaitTask();

    /// <summary>
    /// Wait for the task to finish (synchronously) and return the result.
    /// </summary>
    /// <param name="self">The task to be awaited.</param>
    /// <typeparam name="T">The type of the result.</typeparam>
    /// <returns>The result of the awaited task.</returns>
    public static T WaitFor<T>(this Task<T> self)
    {
        self.AwaitTask();
        return self.Result;
    }

    private static void AwaitTask(this Task self)
    {
        if (self.Status == TaskStatus.Created)
        {
            self.RunSynchronously();
            return;
        }

        self.Wait();
    }
}