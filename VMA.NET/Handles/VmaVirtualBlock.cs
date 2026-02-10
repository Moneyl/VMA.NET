using System.Runtime.InteropServices;

namespace VMA.NET.Handles;

[StructLayout(LayoutKind.Sequential)]
public readonly struct VmaVirtualBlock : IEquatable<VmaVirtualBlock>
{
    public readonly nint Handle;

    public VmaVirtualBlock(nint handle) => Handle = handle;

    public bool IsNull => Handle == 0;
    public static VmaVirtualBlock Null => default;

    public bool Equals(VmaVirtualBlock other) => Handle == other.Handle;
    public override bool Equals(object? obj) => obj is VmaVirtualBlock other && Equals(other);
    public override int GetHashCode() => Handle.GetHashCode();

    public static bool operator ==(VmaVirtualBlock left, VmaVirtualBlock right) => left.Handle == right.Handle;
    public static bool operator !=(VmaVirtualBlock left, VmaVirtualBlock right) => left.Handle != right.Handle;

    public override string ToString() => $"VmaVirtualBlock(0x{Handle:X})";
}
