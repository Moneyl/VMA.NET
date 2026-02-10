using System.Runtime.InteropServices;

namespace VMA.NET.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct VmaDeviceMemoryCallbacks
{
    public nint PfnAllocate;
    public nint PfnFree;
    public nint PUserData;
}
