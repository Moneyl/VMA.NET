using System.Runtime.InteropServices;
using Silk.NET.Vulkan;
using VMA.NET.Enums;
using VMA.NET.Handles;

namespace VMA.NET.Structs;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct VmaAllocationCreateInfo
{
    public VmaAllocationCreateFlagBits Flags;
    public VmaMemoryUsage Usage;
    public MemoryPropertyFlags RequiredFlags;
    public MemoryPropertyFlags PreferredFlags;
    public uint MemoryTypeBits;
    public VmaPool Pool;
    public void* PUserData;
    public float Priority;
}
