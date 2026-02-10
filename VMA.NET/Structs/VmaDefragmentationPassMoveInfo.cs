using System.Runtime.InteropServices;

namespace VMA.NET.Structs;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct VmaDefragmentationPassMoveInfo
{
    public uint MoveCount;
    public VmaDefragmentationMove* PMoves;
}
