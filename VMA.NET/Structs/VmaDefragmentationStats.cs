using System.Runtime.InteropServices;

namespace VMA.NET.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct VmaDefragmentationStats
{
    public ulong BytesMoved;
    public ulong BytesFreed;
    public uint AllocationsMoved;
    public uint DeviceMemoryBlocksFreed;
}
