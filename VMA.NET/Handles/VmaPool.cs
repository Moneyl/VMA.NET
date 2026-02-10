using System.Runtime.InteropServices;

namespace VMA.NET.Handles;

[StructLayout(LayoutKind.Sequential)]
public readonly struct VmaPool : IEquatable<VmaPool>
{
    public readonly nint Handle;

    public VmaPool(nint handle) => Handle = handle;

    public bool IsNull => Handle == 0;
    public static VmaPool Null => default;

    public bool Equals(VmaPool other) => Handle == other.Handle;
    public override bool Equals(object? obj) => obj is VmaPool other && Equals(other);
    public override int GetHashCode() => Handle.GetHashCode();

    public static bool operator ==(VmaPool left, VmaPool right) => left.Handle == right.Handle;
    public static bool operator !=(VmaPool left, VmaPool right) => left.Handle != right.Handle;

    public override string ToString() => $"VmaPool(0x{Handle:X})";
}
