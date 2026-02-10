using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Silk.NET.Vulkan;
using VMA.NET.Handles;
using VMA.NET.Structs;

[assembly: DisableRuntimeMarshalling]

namespace VMA.NET.Interop;

public static unsafe partial class Vma
{
    static Vma()
    {
        NativeLibraryLoader.Register();
    }

    // ── Allocator lifecycle ──────────────────────────────────────────────

    [LibraryImport("vma", EntryPoint = "vmaCreateAllocator")]
    public static partial Result CreateAllocator(VmaAllocatorCreateInfo* pCreateInfo, VmaAllocator* pAllocator);

    [LibraryImport("vma", EntryPoint = "vmaDestroyAllocator")]
    public static partial void DestroyAllocator(VmaAllocator allocator);

    [LibraryImport("vma", EntryPoint = "vmaGetAllocatorInfo")]
    public static partial void GetAllocatorInfo(VmaAllocator allocator, VmaAllocatorInfo* pAllocatorInfo);

    // ── Device properties ────────────────────────────────────────────────

    [LibraryImport("vma", EntryPoint = "vmaGetPhysicalDeviceProperties")]
    public static partial void GetPhysicalDeviceProperties(VmaAllocator allocator, PhysicalDeviceProperties** ppPhysicalDeviceProperties);

    [LibraryImport("vma", EntryPoint = "vmaGetMemoryProperties")]
    public static partial void GetMemoryProperties(VmaAllocator allocator, PhysicalDeviceMemoryProperties** ppPhysicalDeviceMemoryProperties);

    [LibraryImport("vma", EntryPoint = "vmaGetMemoryTypeProperties")]
    public static partial void GetMemoryTypeProperties(VmaAllocator allocator, uint memoryTypeIndex, MemoryPropertyFlags* pFlags);

    [LibraryImport("vma", EntryPoint = "vmaSetCurrentFrameIndex")]
    public static partial void SetCurrentFrameIndex(VmaAllocator allocator, uint frameIndex);

    // ── Statistics ───────────────────────────────────────────────────────

    [LibraryImport("vma", EntryPoint = "vmaCalculateStatistics")]
    public static partial void CalculateStatistics(VmaAllocator allocator, VmaTotalStatistics* pStats);

    [LibraryImport("vma", EntryPoint = "vmaGetHeapBudgets")]
    public static partial void GetHeapBudgets(VmaAllocator allocator, VmaBudget* pBudgets);

    [LibraryImport("vma", EntryPoint = "vmaBuildStatsString")]
    public static partial void BuildStatsString(VmaAllocator allocator, byte** ppStatsString, uint detailedMap);

    [LibraryImport("vma", EntryPoint = "vmaFreeStatsString")]
    public static partial void FreeStatsString(VmaAllocator allocator, byte* pStatsString);

    // ── Memory type finding ──────────────────────────────────────────────

    [LibraryImport("vma", EntryPoint = "vmaFindMemoryTypeIndex")]
    public static partial Result FindMemoryTypeIndex(VmaAllocator allocator, uint memoryTypeBits, VmaAllocationCreateInfo* pAllocationCreateInfo, uint* pMemoryTypeIndex);

    [LibraryImport("vma", EntryPoint = "vmaFindMemoryTypeIndexForBufferInfo")]
    public static partial Result FindMemoryTypeIndexForBufferInfo(VmaAllocator allocator, BufferCreateInfo* pBufferCreateInfo, VmaAllocationCreateInfo* pAllocationCreateInfo, uint* pMemoryTypeIndex);

    [LibraryImport("vma", EntryPoint = "vmaFindMemoryTypeIndexForImageInfo")]
    public static partial Result FindMemoryTypeIndexForImageInfo(VmaAllocator allocator, ImageCreateInfo* pImageCreateInfo, VmaAllocationCreateInfo* pAllocationCreateInfo, uint* pMemoryTypeIndex);

    // ── Pool management ──────────────────────────────────────────────────

    [LibraryImport("vma", EntryPoint = "vmaCreatePool")]
    public static partial Result CreatePool(VmaAllocator allocator, VmaPoolCreateInfo* pCreateInfo, VmaPool* pPool);

    [LibraryImport("vma", EntryPoint = "vmaDestroyPool")]
    public static partial void DestroyPool(VmaAllocator allocator, VmaPool pool);

    [LibraryImport("vma", EntryPoint = "vmaGetPoolStatistics")]
    public static partial void GetPoolStatistics(VmaAllocator allocator, VmaPool pool, VmaStatistics* pPoolStats);

    [LibraryImport("vma", EntryPoint = "vmaCalculatePoolStatistics")]
    public static partial void CalculatePoolStatistics(VmaAllocator allocator, VmaPool pool, VmaDetailedStatistics* pPoolStats);

    [LibraryImport("vma", EntryPoint = "vmaCheckPoolCorruption")]
    public static partial Result CheckPoolCorruption(VmaAllocator allocator, VmaPool pool);

    [LibraryImport("vma", EntryPoint = "vmaGetPoolName")]
    public static partial void GetPoolName(VmaAllocator allocator, VmaPool pool, byte** ppName);

    [LibraryImport("vma", EntryPoint = "vmaSetPoolName")]
    public static partial void SetPoolName(VmaAllocator allocator, VmaPool pool, byte* pName);

    // ── Memory allocation ────────────────────────────────────────────────

    [LibraryImport("vma", EntryPoint = "vmaAllocateMemory")]
    public static partial Result AllocateMemory(VmaAllocator allocator, MemoryRequirements* pVkMemoryRequirements, VmaAllocationCreateInfo* pCreateInfo, VmaAllocation* pAllocation, VmaAllocationInfo* pAllocationInfo);

    [LibraryImport("vma", EntryPoint = "vmaAllocateDedicatedMemory")]
    public static partial Result AllocateDedicatedMemory(VmaAllocator allocator, MemoryRequirements* pVkMemoryRequirements, VmaAllocationCreateInfo* pCreateInfo, void* pMemoryAllocateNext, VmaAllocation* pAllocation, VmaAllocationInfo* pAllocationInfo);

    [LibraryImport("vma", EntryPoint = "vmaAllocateMemoryPages")]
    public static partial Result AllocateMemoryPages(VmaAllocator allocator, MemoryRequirements* pVkMemoryRequirements, VmaAllocationCreateInfo* pCreateInfo, nuint allocationCount, VmaAllocation* pAllocations, VmaAllocationInfo* pAllocationInfo);

    [LibraryImport("vma", EntryPoint = "vmaAllocateMemoryForBuffer")]
    public static partial Result AllocateMemoryForBuffer(VmaAllocator allocator, Silk.NET.Vulkan.Buffer buffer, VmaAllocationCreateInfo* pCreateInfo, VmaAllocation* pAllocation, VmaAllocationInfo* pAllocationInfo);

    [LibraryImport("vma", EntryPoint = "vmaAllocateMemoryForImage")]
    public static partial Result AllocateMemoryForImage(VmaAllocator allocator, Image image, VmaAllocationCreateInfo* pCreateInfo, VmaAllocation* pAllocation, VmaAllocationInfo* pAllocationInfo);

    [LibraryImport("vma", EntryPoint = "vmaFreeMemory")]
    public static partial void FreeMemory(VmaAllocator allocator, VmaAllocation allocation);

    [LibraryImport("vma", EntryPoint = "vmaFreeMemoryPages")]
    public static partial void FreeMemoryPages(VmaAllocator allocator, nuint allocationCount, VmaAllocation* pAllocations);

    // ── Allocation info ──────────────────────────────────────────────────

    [LibraryImport("vma", EntryPoint = "vmaGetAllocationInfo")]
    public static partial void GetAllocationInfo(VmaAllocator allocator, VmaAllocation allocation, VmaAllocationInfo* pAllocationInfo);

    [LibraryImport("vma", EntryPoint = "vmaGetAllocationInfo2")]
    public static partial void GetAllocationInfo2(VmaAllocator allocator, VmaAllocation allocation, VmaAllocationInfo2* pAllocationInfo);

    [LibraryImport("vma", EntryPoint = "vmaSetAllocationUserData")]
    public static partial void SetAllocationUserData(VmaAllocator allocator, VmaAllocation allocation, void* pUserData);

    [LibraryImport("vma", EntryPoint = "vmaSetAllocationName")]
    public static partial void SetAllocationName(VmaAllocator allocator, VmaAllocation allocation, byte* pName);

    [LibraryImport("vma", EntryPoint = "vmaGetAllocationMemoryProperties")]
    public static partial void GetAllocationMemoryProperties(VmaAllocator allocator, VmaAllocation allocation, MemoryPropertyFlags* pFlags);

    // ── Memory mapping ───────────────────────────────────────────────────

    [LibraryImport("vma", EntryPoint = "vmaMapMemory")]
    public static partial Result MapMemory(VmaAllocator allocator, VmaAllocation allocation, void** ppData);

    [LibraryImport("vma", EntryPoint = "vmaUnmapMemory")]
    public static partial void UnmapMemory(VmaAllocator allocator, VmaAllocation allocation);

    // ── Cache control ────────────────────────────────────────────────────

    [LibraryImport("vma", EntryPoint = "vmaFlushAllocation")]
    public static partial Result FlushAllocation(VmaAllocator allocator, VmaAllocation allocation, ulong offset, ulong size);

    [LibraryImport("vma", EntryPoint = "vmaInvalidateAllocation")]
    public static partial Result InvalidateAllocation(VmaAllocator allocator, VmaAllocation allocation, ulong offset, ulong size);

    [LibraryImport("vma", EntryPoint = "vmaFlushAllocations")]
    public static partial Result FlushAllocations(VmaAllocator allocator, uint allocationCount, VmaAllocation* allocations, ulong* offsets, ulong* sizes);

    [LibraryImport("vma", EntryPoint = "vmaInvalidateAllocations")]
    public static partial Result InvalidateAllocations(VmaAllocator allocator, uint allocationCount, VmaAllocation* allocations, ulong* offsets, ulong* sizes);

    // ── Memory copy ──────────────────────────────────────────────────────

    [LibraryImport("vma", EntryPoint = "vmaCopyMemoryToAllocation")]
    public static partial Result CopyMemoryToAllocation(VmaAllocator allocator, void* pSrcHostPointer, VmaAllocation dstAllocation, ulong dstAllocationLocalOffset, ulong size);

    [LibraryImport("vma", EntryPoint = "vmaCopyAllocationToMemory")]
    public static partial Result CopyAllocationToMemory(VmaAllocator allocator, VmaAllocation srcAllocation, ulong srcAllocationLocalOffset, void* pDstHostPointer, ulong size);

    // ── Corruption detection ─────────────────────────────────────────────

    [LibraryImport("vma", EntryPoint = "vmaCheckCorruption")]
    public static partial Result CheckCorruption(VmaAllocator allocator, uint memoryTypeBits);

    // ── Defragmentation ──────────────────────────────────────────────────

    [LibraryImport("vma", EntryPoint = "vmaBeginDefragmentation")]
    public static partial Result BeginDefragmentation(VmaAllocator allocator, VmaDefragmentationInfo* pInfo, VmaDefragmentationContext* pContext);

    [LibraryImport("vma", EntryPoint = "vmaEndDefragmentation")]
    public static partial void EndDefragmentation(VmaAllocator allocator, VmaDefragmentationContext context, VmaDefragmentationStats* pStats);

    [LibraryImport("vma", EntryPoint = "vmaBeginDefragmentationPass")]
    public static partial Result BeginDefragmentationPass(VmaAllocator allocator, VmaDefragmentationContext context, VmaDefragmentationPassMoveInfo* pPassInfo);

    [LibraryImport("vma", EntryPoint = "vmaEndDefragmentationPass")]
    public static partial Result EndDefragmentationPass(VmaAllocator allocator, VmaDefragmentationContext context, VmaDefragmentationPassMoveInfo* pPassInfo);

    // ── Buffer/image binding ─────────────────────────────────────────────

    [LibraryImport("vma", EntryPoint = "vmaBindBufferMemory")]
    public static partial Result BindBufferMemory(VmaAllocator allocator, VmaAllocation allocation, Silk.NET.Vulkan.Buffer buffer);

    [LibraryImport("vma", EntryPoint = "vmaBindBufferMemory2")]
    public static partial Result BindBufferMemory2(VmaAllocator allocator, VmaAllocation allocation, ulong allocationLocalOffset, Silk.NET.Vulkan.Buffer buffer, void* pNext);

    [LibraryImport("vma", EntryPoint = "vmaBindImageMemory")]
    public static partial Result BindImageMemory(VmaAllocator allocator, VmaAllocation allocation, Image image);

    [LibraryImport("vma", EntryPoint = "vmaBindImageMemory2")]
    public static partial Result BindImageMemory2(VmaAllocator allocator, VmaAllocation allocation, ulong allocationLocalOffset, Image image, void* pNext);

    // ── Buffer create/destroy ────────────────────────────────────────────

    [LibraryImport("vma", EntryPoint = "vmaCreateBuffer")]
    public static partial Result CreateBuffer(VmaAllocator allocator, BufferCreateInfo* pBufferCreateInfo, VmaAllocationCreateInfo* pAllocationCreateInfo, Silk.NET.Vulkan.Buffer* pBuffer, VmaAllocation* pAllocation, VmaAllocationInfo* pAllocationInfo);

    [LibraryImport("vma", EntryPoint = "vmaCreateBufferWithAlignment")]
    public static partial Result CreateBufferWithAlignment(VmaAllocator allocator, BufferCreateInfo* pBufferCreateInfo, VmaAllocationCreateInfo* pAllocationCreateInfo, ulong minAlignment, Silk.NET.Vulkan.Buffer* pBuffer, VmaAllocation* pAllocation, VmaAllocationInfo* pAllocationInfo);

    [LibraryImport("vma", EntryPoint = "vmaCreateDedicatedBuffer")]
    public static partial Result CreateDedicatedBuffer(VmaAllocator allocator, BufferCreateInfo* pBufferCreateInfo, VmaAllocationCreateInfo* pAllocationCreateInfo, void* pMemoryAllocateNext, Silk.NET.Vulkan.Buffer* pBuffer, VmaAllocation* pAllocation, VmaAllocationInfo* pAllocationInfo);

    [LibraryImport("vma", EntryPoint = "vmaCreateAliasingBuffer")]
    public static partial Result CreateAliasingBuffer(VmaAllocator allocator, VmaAllocation allocation, BufferCreateInfo* pBufferCreateInfo, Silk.NET.Vulkan.Buffer* pBuffer);

    [LibraryImport("vma", EntryPoint = "vmaCreateAliasingBuffer2")]
    public static partial Result CreateAliasingBuffer2(VmaAllocator allocator, VmaAllocation allocation, ulong allocationLocalOffset, BufferCreateInfo* pBufferCreateInfo, Silk.NET.Vulkan.Buffer* pBuffer);

    [LibraryImport("vma", EntryPoint = "vmaDestroyBuffer")]
    public static partial void DestroyBuffer(VmaAllocator allocator, Silk.NET.Vulkan.Buffer buffer, VmaAllocation allocation);

    // ── Image create/destroy ─────────────────────────────────────────────

    [LibraryImport("vma", EntryPoint = "vmaCreateImage")]
    public static partial Result CreateImage(VmaAllocator allocator, ImageCreateInfo* pImageCreateInfo, VmaAllocationCreateInfo* pAllocationCreateInfo, Image* pImage, VmaAllocation* pAllocation, VmaAllocationInfo* pAllocationInfo);

    [LibraryImport("vma", EntryPoint = "vmaCreateDedicatedImage")]
    public static partial Result CreateDedicatedImage(VmaAllocator allocator, ImageCreateInfo* pImageCreateInfo, VmaAllocationCreateInfo* pAllocationCreateInfo, void* pMemoryAllocateNext, Image* pImage, VmaAllocation* pAllocation, VmaAllocationInfo* pAllocationInfo);

    [LibraryImport("vma", EntryPoint = "vmaCreateAliasingImage")]
    public static partial Result CreateAliasingImage(VmaAllocator allocator, VmaAllocation allocation, ImageCreateInfo* pImageCreateInfo, Image* pImage);

    [LibraryImport("vma", EntryPoint = "vmaCreateAliasingImage2")]
    public static partial Result CreateAliasingImage2(VmaAllocator allocator, VmaAllocation allocation, ulong allocationLocalOffset, ImageCreateInfo* pImageCreateInfo, Image* pImage);

    [LibraryImport("vma", EntryPoint = "vmaDestroyImage")]
    public static partial void DestroyImage(VmaAllocator allocator, Image image, VmaAllocation allocation);

    // ── Virtual block ────────────────────────────────────────────────────

    [LibraryImport("vma", EntryPoint = "vmaCreateVirtualBlock")]
    public static partial Result CreateVirtualBlock(VmaVirtualBlockCreateInfo* pCreateInfo, VmaVirtualBlock* pVirtualBlock);

    [LibraryImport("vma", EntryPoint = "vmaDestroyVirtualBlock")]
    public static partial void DestroyVirtualBlock(VmaVirtualBlock virtualBlock);

    [LibraryImport("vma", EntryPoint = "vmaIsVirtualBlockEmpty")]
    public static partial uint IsVirtualBlockEmpty(VmaVirtualBlock virtualBlock);

    [LibraryImport("vma", EntryPoint = "vmaGetVirtualAllocationInfo")]
    public static partial void GetVirtualAllocationInfo(VmaVirtualBlock virtualBlock, VmaVirtualAllocation allocation, VmaVirtualAllocationInfo* pVirtualAllocInfo);

    [LibraryImport("vma", EntryPoint = "vmaVirtualAllocate")]
    public static partial Result VirtualAllocate(VmaVirtualBlock virtualBlock, VmaVirtualAllocationCreateInfo* pCreateInfo, VmaVirtualAllocation* pAllocation, ulong* pOffset);

    [LibraryImport("vma", EntryPoint = "vmaVirtualFree")]
    public static partial void VirtualFree(VmaVirtualBlock virtualBlock, VmaVirtualAllocation allocation);

    [LibraryImport("vma", EntryPoint = "vmaClearVirtualBlock")]
    public static partial void ClearVirtualBlock(VmaVirtualBlock virtualBlock);

    [LibraryImport("vma", EntryPoint = "vmaSetVirtualAllocationUserData")]
    public static partial void SetVirtualAllocationUserData(VmaVirtualBlock virtualBlock, VmaVirtualAllocation allocation, void* pUserData);

    [LibraryImport("vma", EntryPoint = "vmaGetVirtualBlockStatistics")]
    public static partial void GetVirtualBlockStatistics(VmaVirtualBlock virtualBlock, VmaStatistics* pStats);

    [LibraryImport("vma", EntryPoint = "vmaCalculateVirtualBlockStatistics")]
    public static partial void CalculateVirtualBlockStatistics(VmaVirtualBlock virtualBlock, VmaDetailedStatistics* pStats);

    [LibraryImport("vma", EntryPoint = "vmaBuildVirtualBlockStatsString")]
    public static partial void BuildVirtualBlockStatsString(VmaVirtualBlock virtualBlock, byte** ppStatsString, uint detailedMap);

    [LibraryImport("vma", EntryPoint = "vmaFreeVirtualBlockStatsString")]
    public static partial void FreeVirtualBlockStatsString(VmaVirtualBlock virtualBlock, byte* pStatsString);
}
