using System.Runtime.InteropServices;
using Silk.NET.Vulkan;

namespace VMA.NET.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct VmaAllocatorInfo
{
    public Instance Instance;
    public PhysicalDevice PhysicalDevice;
    public Device Device;
}
