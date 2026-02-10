using System.Runtime.InteropServices;

namespace VMA.NET.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct VmaAllocationInfo2
{
    public VmaAllocationInfo AllocationInfo;
    public ulong BlockSize;
    public uint DedicatedMemory;
}
