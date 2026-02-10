using System.Runtime.InteropServices;
using VMA.NET.Enums;

namespace VMA.NET.Structs;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct VmaVirtualAllocationCreateInfo
{
    public ulong Size;
    public ulong Alignment;
    public VmaVirtualAllocationCreateFlagBits Flags;
    public void* PUserData;
}
