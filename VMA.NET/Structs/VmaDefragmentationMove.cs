using System.Runtime.InteropServices;
using VMA.NET.Enums;
using VMA.NET.Handles;

namespace VMA.NET.Structs;

[StructLayout(LayoutKind.Sequential)]
public struct VmaDefragmentationMove
{
    public VmaDefragmentationMoveOperation Operation;
    public VmaAllocation SrcAllocation;
    public VmaAllocation DstTmpAllocation;
}
