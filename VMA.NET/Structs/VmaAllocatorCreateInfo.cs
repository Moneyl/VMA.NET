using System.Runtime.InteropServices;
using Silk.NET.Vulkan;
using VMA.NET.Enums;

namespace VMA.NET.Structs;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct VmaAllocatorCreateInfo
{
    public VmaAllocatorCreateFlagBits Flags;
    public PhysicalDevice PhysicalDevice;
    public Device Device;
    public ulong PreferredLargeHeapBlockSize;
    public AllocationCallbacks* PAllocationCallbacks;
    public VmaDeviceMemoryCallbacks* PDeviceMemoryCallbacks;
    public ulong* PHeapSizeLimit;
    public VmaVulkanFunctions* PVulkanFunctions;
    public Instance Instance;
    public uint VulkanApiVersion;
    public ExternalMemoryHandleTypeFlags* PTypeExternalMemoryHandleTypes;
}
