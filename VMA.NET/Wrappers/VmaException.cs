using Silk.NET.Vulkan;

namespace VMA.NET.Wrappers;

public class VmaException : Exception
{
    public Result Result { get; }

    public VmaException(Result result)
        : base($"VMA operation failed with result: {result}")
    {
        Result = result;
    }

    public VmaException(Result result, string message)
        : base(message)
    {
        Result = result;
    }

    internal static void ThrowOnFailure(Result result)
    {
        if (result != Result.Success)
            throw new VmaException(result);
    }
}
