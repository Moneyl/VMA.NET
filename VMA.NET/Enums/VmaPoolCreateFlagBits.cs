namespace VMA.NET.Enums;

[Flags]
public enum VmaPoolCreateFlagBits : uint
{
    None = 0,
    IgnoreBufferImageGranularityBit = 0x00000002,
    LinearAlgorithmBit = 0x00000004,
    AlgorithmMask = LinearAlgorithmBit,
}
