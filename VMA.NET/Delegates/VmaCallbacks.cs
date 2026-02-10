using System.Runtime.InteropServices;
using Silk.NET.Vulkan;
using VMA.NET.Handles;

namespace VMA.NET.Delegates;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void PfnVmaAllocateDeviceMemoryFunction(
    VmaAllocator allocator,
    uint memoryType,
    DeviceMemory memory,
    ulong size,
    void* pUserData);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void PfnVmaFreeDeviceMemoryFunction(
    VmaAllocator allocator,
    uint memoryType,
    DeviceMemory memory,
    ulong size,
    void* pUserData);

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate uint PfnVmaCheckDefragmentationBreakFunction(
    void* pUserData);
