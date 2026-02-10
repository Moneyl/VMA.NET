using System.Runtime.InteropServices;

namespace VMA.NET.Handles;

[StructLayout(LayoutKind.Sequential)]
public readonly struct VmaDefragmentationContext : IEquatable<VmaDefragmentationContext>
{
    public readonly nint Handle;

    public VmaDefragmentationContext(nint handle) => Handle = handle;

    public bool IsNull => Handle == 0;
    public static VmaDefragmentationContext Null => default;

    public bool Equals(VmaDefragmentationContext other) => Handle == other.Handle;
    public override bool Equals(object? obj) => obj is VmaDefragmentationContext other && Equals(other);
    public override int GetHashCode() => Handle.GetHashCode();

    public static bool operator ==(VmaDefragmentationContext left, VmaDefragmentationContext right) => left.Handle == right.Handle;
    public static bool operator !=(VmaDefragmentationContext left, VmaDefragmentationContext right) => left.Handle != right.Handle;

    public override string ToString() => $"VmaDefragmentationContext(0x{Handle:X})";
}
