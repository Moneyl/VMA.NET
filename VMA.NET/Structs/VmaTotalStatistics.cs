using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace VMA.NET.Structs;

[InlineArray(32)]
public struct VmaDetailedStatisticsArray32
{
    private VmaDetailedStatistics _element;
}

[InlineArray(16)]
public struct VmaDetailedStatisticsArray16
{
    private VmaDetailedStatistics _element;
}

[StructLayout(LayoutKind.Sequential)]
public struct VmaTotalStatistics
{
    public VmaDetailedStatisticsArray32 MemoryType;
    public VmaDetailedStatisticsArray16 MemoryHeap;
    public VmaDetailedStatistics Total;
}
