using System.Runtime.InteropServices;
using Silk.NET.Vulkan;
using VMA.NET.Enums;

namespace VMA.NET.Structs;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct VmaVirtualBlockCreateInfo
{
    public ulong Size;
    public VmaVirtualBlockCreateFlagBits Flags;
    public AllocationCallbacks* PAllocationCallbacks;
}
