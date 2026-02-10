namespace VMA.NET.Enums;

[Flags]
public enum VmaVirtualBlockCreateFlagBits : uint
{
    None = 0,
    LinearAlgorithmBit = 0x00000001,
    AlgorithmMask = LinearAlgorithmBit,
}
