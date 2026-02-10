using System.Runtime.InteropServices;

namespace VMA.NET.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct VmaStatistics
{
    public uint BlockCount;
    public uint AllocationCount;
    public ulong BlockBytes;
    public ulong AllocationBytes;
}
