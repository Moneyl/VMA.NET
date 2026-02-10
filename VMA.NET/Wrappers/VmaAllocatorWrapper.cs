using Silk.NET.Vulkan;
using VMA.NET.Enums;
using VMA.NET.Handles;
using VMA.NET.Interop;
using VMA.NET.Structs;

namespace VMA.NET.Wrappers;

public unsafe class VmaAllocatorWrapper : IDisposable
{
    public VmaAllocator Handle { get; }
    private bool _disposed;

    private VmaAllocatorWrapper(VmaAllocator handle)
    {
        Handle = handle;
    }

    public static VmaAllocatorWrapper Create(
        Vk vk,
        Instance instance,
        PhysicalDevice physicalDevice,
        Device device,
        VmaAllocatorCreateFlagBits flags = VmaAllocatorCreateFlagBits.None,
        uint vulkanApiVersion = 0,
        ulong preferredLargeHeapBlockSize = 0)
    {
        var getInstanceProcAddr = vk.Context.GetProcAddress("vkGetInstanceProcAddr");
        var getDeviceProcAddr = vk.Context.GetProcAddress("vkGetDeviceProcAddr");

        var vulkanFunctions = new VmaVulkanFunctions
        {
            VkGetInstanceProcAddr = (nint)getInstanceProcAddr,
            VkGetDeviceProcAddr = (nint)getDeviceProcAddr,
        };

        var createInfo = new VmaAllocatorCreateInfo
        {
            Flags = flags,
            PhysicalDevice = physicalDevice,
            Device = device,
            PreferredLargeHeapBlockSize = preferredLargeHeapBlockSize,
            PVulkanFunctions = &vulkanFunctions,
            Instance = instance,
            VulkanApiVersion = vulkanApiVersion,
        };

        VmaAllocator allocator;
        VmaException.ThrowOnFailure(Vma.CreateAllocator(&createInfo, &allocator));

        return new VmaAllocatorWrapper(allocator);
    }

    public VmaAllocatorInfo GetAllocatorInfo()
    {
        VmaAllocatorInfo info;
        Vma.GetAllocatorInfo(Handle, &info);
        return info;
    }

    public void SetCurrentFrameIndex(uint frameIndex)
    {
        Vma.SetCurrentFrameIndex(Handle, frameIndex);
    }

    public VmaTotalStatistics CalculateStatistics()
    {
        VmaTotalStatistics stats;
        Vma.CalculateStatistics(Handle, &stats);
        return stats;
    }

    public void GetHeapBudgets(Span<VmaBudget> budgets)
    {
        fixed (VmaBudget* pBudgets = budgets)
        {
            Vma.GetHeapBudgets(Handle, pBudgets);
        }
    }

    public uint FindMemoryTypeIndex(uint memoryTypeBits, VmaAllocationCreateInfo* pAllocationCreateInfo)
    {
        uint memoryTypeIndex;
        VmaException.ThrowOnFailure(Vma.FindMemoryTypeIndex(Handle, memoryTypeBits, pAllocationCreateInfo, &memoryTypeIndex));
        return memoryTypeIndex;
    }

    public VmaPool CreatePool(VmaPoolCreateInfo* pCreateInfo)
    {
        VmaPool pool;
        VmaException.ThrowOnFailure(Vma.CreatePool(Handle, pCreateInfo, &pool));
        return pool;
    }

    public void DestroyPool(VmaPool pool)
    {
        Vma.DestroyPool(Handle, pool);
    }

    public (Silk.NET.Vulkan.Buffer Buffer, VmaAllocation Allocation, VmaAllocationInfo AllocationInfo) CreateBuffer(
        BufferCreateInfo* pBufferCreateInfo,
        VmaAllocationCreateInfo* pAllocationCreateInfo)
    {
        Silk.NET.Vulkan.Buffer buffer;
        VmaAllocation allocation;
        VmaAllocationInfo allocationInfo;
        VmaException.ThrowOnFailure(Vma.CreateBuffer(Handle, pBufferCreateInfo, pAllocationCreateInfo, &buffer, &allocation, &allocationInfo));
        return (buffer, allocation, allocationInfo);
    }

    public void DestroyBuffer(Silk.NET.Vulkan.Buffer buffer, VmaAllocation allocation)
    {
        Vma.DestroyBuffer(Handle, buffer, allocation);
    }

    public (Image Image, VmaAllocation Allocation, VmaAllocationInfo AllocationInfo) CreateImage(
        ImageCreateInfo* pImageCreateInfo,
        VmaAllocationCreateInfo* pAllocationCreateInfo)
    {
        Image image;
        VmaAllocation allocation;
        VmaAllocationInfo allocationInfo;
        VmaException.ThrowOnFailure(Vma.CreateImage(Handle, pImageCreateInfo, pAllocationCreateInfo, &image, &allocation, &allocationInfo));
        return (image, allocation, allocationInfo);
    }

    public void DestroyImage(Image image, VmaAllocation allocation)
    {
        Vma.DestroyImage(Handle, image, allocation);
    }

    public (VmaAllocation Allocation, VmaAllocationInfo AllocationInfo) AllocateMemory(
        MemoryRequirements* pMemoryRequirements,
        VmaAllocationCreateInfo* pAllocationCreateInfo)
    {
        VmaAllocation allocation;
        VmaAllocationInfo allocationInfo;
        VmaException.ThrowOnFailure(Vma.AllocateMemory(Handle, pMemoryRequirements, pAllocationCreateInfo, &allocation, &allocationInfo));
        return (allocation, allocationInfo);
    }

    public void FreeMemory(VmaAllocation allocation)
    {
        Vma.FreeMemory(Handle, allocation);
    }

    public VmaAllocationInfo GetAllocationInfo(VmaAllocation allocation)
    {
        VmaAllocationInfo info;
        Vma.GetAllocationInfo(Handle, allocation, &info);
        return info;
    }

    public void* MapMemory(VmaAllocation allocation)
    {
        void* pData;
        VmaException.ThrowOnFailure(Vma.MapMemory(Handle, allocation, &pData));
        return pData;
    }

    public void UnmapMemory(VmaAllocation allocation)
    {
        Vma.UnmapMemory(Handle, allocation);
    }

    public void FlushAllocation(VmaAllocation allocation, ulong offset, ulong size)
    {
        VmaException.ThrowOnFailure(Vma.FlushAllocation(Handle, allocation, offset, size));
    }

    public void InvalidateAllocation(VmaAllocation allocation, ulong offset, ulong size)
    {
        VmaException.ThrowOnFailure(Vma.InvalidateAllocation(Handle, allocation, offset, size));
    }

    public void BindBufferMemory(VmaAllocation allocation, Silk.NET.Vulkan.Buffer buffer)
    {
        VmaException.ThrowOnFailure(Vma.BindBufferMemory(Handle, allocation, buffer));
    }

    public void BindImageMemory(VmaAllocation allocation, Image image)
    {
        VmaException.ThrowOnFailure(Vma.BindImageMemory(Handle, allocation, image));
    }

    public VmaDefragmentationContext BeginDefragmentation(VmaDefragmentationInfo* pInfo)
    {
        VmaDefragmentationContext context;
        VmaException.ThrowOnFailure(Vma.BeginDefragmentation(Handle, pInfo, &context));
        return context;
    }

    public VmaDefragmentationStats EndDefragmentation(VmaDefragmentationContext context)
    {
        VmaDefragmentationStats stats;
        Vma.EndDefragmentation(Handle, context, &stats);
        return stats;
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            Vma.DestroyAllocator(Handle);
            _disposed = true;
        }

        GC.SuppressFinalize(this);
    }

    ~VmaAllocatorWrapper()
    {
        if (!_disposed)
        {
            Vma.DestroyAllocator(Handle);
            _disposed = true;
        }
    }
}
