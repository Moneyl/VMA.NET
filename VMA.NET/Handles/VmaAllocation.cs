using System.Runtime.InteropServices;

namespace VMA.NET.Handles;

[StructLayout(LayoutKind.Sequential)]
public readonly struct VmaAllocation : IEquatable<VmaAllocation>
{
    public readonly nint Handle;

    public VmaAllocation(nint handle) => Handle = handle;

    public bool IsNull => Handle == 0;
    public static VmaAllocation Null => default;

    public bool Equals(VmaAllocation other) => Handle == other.Handle;
    public override bool Equals(object? obj) => obj is VmaAllocation other && Equals(other);
    public override int GetHashCode() => Handle.GetHashCode();

    public static bool operator ==(VmaAllocation left, VmaAllocation right) => left.Handle == right.Handle;
    public static bool operator !=(VmaAllocation left, VmaAllocation right) => left.Handle != right.Handle;

    public override string ToString() => $"VmaAllocation(0x{Handle:X})";
}
