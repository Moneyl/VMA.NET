using System.Runtime.InteropServices;
using Silk.NET.Vulkan;

namespace VMA.NET.Structs;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct VmaAllocationInfo
{
    public uint MemoryType;
    public DeviceMemory DeviceMemory;
    public ulong Offset;
    public ulong Size;
    public void* PMappedData;
    public void* PUserData;
    public byte* PName;
}
