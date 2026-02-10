using VMA.NET.Handles;
using VMA.NET.Interop;
using VMA.NET.Structs;

namespace VMA.NET.Wrappers;

public unsafe class VmaPoolWrapper : IDisposable
{
    public VmaPool Handle { get; }
    public VmaAllocator Allocator { get; }
    private bool _disposed;

    public VmaPoolWrapper(VmaAllocator allocator, VmaPool pool)
    {
        Allocator = allocator;
        Handle = pool;
    }

    public VmaStatistics GetStatistics()
    {
        VmaStatistics stats;
        Vma.GetPoolStatistics(Allocator, Handle, &stats);
        return stats;
    }

    public VmaDetailedStatistics CalculateStatistics()
    {
        VmaDetailedStatistics stats;
        Vma.CalculatePoolStatistics(Allocator, Handle, &stats);
        return stats;
    }

    public void CheckCorruption()
    {
        VmaException.ThrowOnFailure(Vma.CheckPoolCorruption(Allocator, Handle));
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            Vma.DestroyPool(Allocator, Handle);
            _disposed = true;
        }

        GC.SuppressFinalize(this);
    }

    ~VmaPoolWrapper()
    {
        if (!_disposed)
        {
            Vma.DestroyPool(Allocator, Handle);
            _disposed = true;
        }
    }
}
