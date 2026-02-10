using System.Runtime.InteropServices;

namespace VMA.NET.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct VmaDetailedStatistics
{
    public VmaStatistics Statistics;
    public uint UnusedRangeCount;
    public ulong AllocationSizeMin;
    public ulong AllocationSizeMax;
    public ulong UnusedRangeSizeMin;
    public ulong UnusedRangeSizeMax;
}
