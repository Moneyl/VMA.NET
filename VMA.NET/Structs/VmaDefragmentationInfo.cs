using System.Runtime.InteropServices;
using VMA.NET.Enums;
using VMA.NET.Handles;

namespace VMA.NET.Structs;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct VmaDefragmentationInfo
{
    public VmaDefragmentationFlagBits Flags;
    public VmaPool Pool;
    public ulong MaxBytesPerPass;
    public uint MaxAllocationsPerPass;
    public nint PfnBreakCallback;
    public void* PBreakCallbackUserData;
}
