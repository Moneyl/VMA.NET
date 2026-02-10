using System.Runtime.InteropServices;

namespace VMA.NET.Handles;

[StructLayout(LayoutKind.Sequential)]
public readonly struct VmaVirtualAllocation : IEquatable<VmaVirtualAllocation>
{
    public readonly nint Handle;

    public VmaVirtualAllocation(nint handle) => Handle = handle;

    public bool IsNull => Handle == 0;
    public static VmaVirtualAllocation Null => default;

    public bool Equals(VmaVirtualAllocation other) => Handle == other.Handle;
    public override bool Equals(object? obj) => obj is VmaVirtualAllocation other && Equals(other);
    public override int GetHashCode() => Handle.GetHashCode();

    public static bool operator ==(VmaVirtualAllocation left, VmaVirtualAllocation right) => left.Handle == right.Handle;
    public static bool operator !=(VmaVirtualAllocation left, VmaVirtualAllocation right) => left.Handle != right.Handle;

    public override string ToString() => $"VmaVirtualAllocation(0x{Handle:X})";
}
