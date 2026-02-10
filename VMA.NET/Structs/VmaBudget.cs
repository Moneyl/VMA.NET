using System.Runtime.InteropServices;

namespace VMA.NET.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct VmaBudget
{
    public VmaStatistics Statistics;
    public ulong Usage;
    public ulong Budget;
}
