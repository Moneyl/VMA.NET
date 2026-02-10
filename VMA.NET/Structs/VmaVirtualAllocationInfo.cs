using System.Runtime.InteropServices;

namespace VMA.NET.Structs;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct VmaVirtualAllocationInfo
{
    public ulong Offset;
    public ulong Size;
    public void* PUserData;
}
