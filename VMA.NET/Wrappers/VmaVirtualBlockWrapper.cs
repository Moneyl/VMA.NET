using VMA.NET.Handles;
using VMA.NET.Interop;
using VMA.NET.Structs;

namespace VMA.NET.Wrappers;

public unsafe class VmaVirtualBlockWrapper : IDisposable
{
    public VmaVirtualBlock Handle { get; }
    private bool _disposed;

    private VmaVirtualBlockWrapper(VmaVirtualBlock handle)
    {
        Handle = handle;
    }

    public static VmaVirtualBlockWrapper Create(VmaVirtualBlockCreateInfo* pCreateInfo)
    {
        VmaVirtualBlock block;
        VmaException.ThrowOnFailure(Vma.CreateVirtualBlock(pCreateInfo, &block));
        return new VmaVirtualBlockWrapper(block);
    }

    public bool IsEmpty => Vma.IsVirtualBlockEmpty(Handle) != 0;

    public (VmaVirtualAllocation Allocation, ulong Offset) Allocate(VmaVirtualAllocationCreateInfo* pCreateInfo)
    {
        VmaVirtualAllocation allocation;
        ulong offset;
        VmaException.ThrowOnFailure(Vma.VirtualAllocate(Handle, pCreateInfo, &allocation, &offset));
        return (allocation, offset);
    }

    public void Free(VmaVirtualAllocation allocation)
    {
        Vma.VirtualFree(Handle, allocation);
    }

    public void Clear()
    {
        Vma.ClearVirtualBlock(Handle);
    }

    public VmaVirtualAllocationInfo GetAllocationInfo(VmaVirtualAllocation allocation)
    {
        VmaVirtualAllocationInfo info;
        Vma.GetVirtualAllocationInfo(Handle, allocation, &info);
        return info;
    }

    public VmaStatistics GetStatistics()
    {
        VmaStatistics stats;
        Vma.GetVirtualBlockStatistics(Handle, &stats);
        return stats;
    }

    public VmaDetailedStatistics CalculateStatistics()
    {
        VmaDetailedStatistics stats;
        Vma.CalculateVirtualBlockStatistics(Handle, &stats);
        return stats;
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            Vma.DestroyVirtualBlock(Handle);
            _disposed = true;
        }

        GC.SuppressFinalize(this);
    }

    ~VmaVirtualBlockWrapper()
    {
        if (!_disposed)
        {
            Vma.DestroyVirtualBlock(Handle);
            _disposed = true;
        }
    }
}
