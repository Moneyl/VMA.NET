using System.Runtime.InteropServices;
using VMA.NET.Enums;

namespace VMA.NET.Structs;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct VmaPoolCreateInfo
{
    public uint MemoryTypeIndex;
    public VmaPoolCreateFlagBits Flags;
    public ulong BlockSize;
    public nuint MinBlockCount;
    public nuint MaxBlockCount;
    public float Priority;
    public ulong MinAllocationAlignment;
    public void* PMemoryAllocateNext;
}
