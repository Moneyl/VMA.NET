using System.Runtime.InteropServices;

namespace VMA.NET.Handles;

[StructLayout(LayoutKind.Sequential)]
public readonly struct VmaAllocator : IEquatable<VmaAllocator>
{
    public readonly nint Handle;

    public VmaAllocator(nint handle) => Handle = handle;

    public bool IsNull => Handle == 0;
    public static VmaAllocator Null => default;

    public bool Equals(VmaAllocator other) => Handle == other.Handle;
    public override bool Equals(object? obj) => obj is VmaAllocator other && Equals(other);
    public override int GetHashCode() => Handle.GetHashCode();

    public static bool operator ==(VmaAllocator left, VmaAllocator right) => left.Handle == right.Handle;
    public static bool operator !=(VmaAllocator left, VmaAllocator right) => left.Handle != right.Handle;

    public override string ToString() => $"VmaAllocator(0x{Handle:X})";
}
