using System.Runtime.InteropServices;

namespace VMA.NET.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct VmaVulkanFunctions
{
    public nint VkGetInstanceProcAddr;
    public nint VkGetDeviceProcAddr;
    public nint VkGetPhysicalDeviceProperties;
    public nint VkGetPhysicalDeviceMemoryProperties;
    public nint VkAllocateMemory;
    public nint VkFreeMemory;
    public nint VkMapMemory;
    public nint VkUnmapMemory;
    public nint VkFlushMappedMemoryRanges;
    public nint VkInvalidateMappedMemoryRanges;
    public nint VkBindBufferMemory;
    public nint VkBindImageMemory;
    public nint VkGetBufferMemoryRequirements;
    public nint VkGetImageMemoryRequirements;
    public nint VkCreateBuffer;
    public nint VkDestroyBuffer;
    public nint VkCreateImage;
    public nint VkDestroyImage;
    public nint VkCmdCopyBuffer;
    public nint VkGetBufferMemoryRequirements2KHR;
    public nint VkGetImageMemoryRequirements2KHR;
    public nint VkBindBufferMemory2KHR;
    public nint VkBindImageMemory2KHR;
    public nint VkGetPhysicalDeviceMemoryProperties2KHR;
    public nint VkGetDeviceBufferMemoryRequirements;
    public nint VkGetDeviceImageMemoryRequirements;
    public nint VkGetMemoryWin32HandleKHR;
}
