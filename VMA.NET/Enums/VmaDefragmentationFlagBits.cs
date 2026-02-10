namespace VMA.NET.Enums;

[Flags]
public enum VmaDefragmentationFlagBits : uint
{
    None = 0,
    AlgorithmFastBit = 0x1,
    AlgorithmBalancedBit = 0x2,
    AlgorithmFullBit = 0x4,
    AlgorithmExtensiveBit = 0x8,
    AlgorithmMask = AlgorithmFastBit | AlgorithmBalancedBit | AlgorithmFullBit | AlgorithmExtensiveBit,
}
