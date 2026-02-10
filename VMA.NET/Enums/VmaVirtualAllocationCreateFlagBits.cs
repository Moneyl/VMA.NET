namespace VMA.NET.Enums;

[Flags]
public enum VmaVirtualAllocationCreateFlagBits : uint
{
    None = 0,
    UpperAddressBit = 0x00000040,
    StrategyMinMemoryBit = 0x00010000,
    StrategyMinTimeBit = 0x00020000,
    StrategyMinOffsetBit = 0x00040000,
    StrategyMask = StrategyMinMemoryBit | StrategyMinTimeBit | StrategyMinOffsetBit,
}
