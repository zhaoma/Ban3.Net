// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

namespace Ban3.Infrastructures.Common.Extensions;

/// <summary>
/// 位操作
/// </summary>
public static partial class Helper
{
    /// <summary>
    /// Gets the bit.获取取第index是否为1,index从0开始
    /// </summary>
    /// <param name="b">The b.</param>
    /// <param name="index">The index.</param>
    /// <returns></returns>
    public static bool GetBit(this byte b, int index)
    {
        return (b & (1 << index)) > 0;
    }

    /// <summary>
    /// Sets the bit.将第index位设为1
    /// </summary>
    /// <param name="b">The b.</param>
    /// <param name="index">The index.</param>
    /// <returns></returns>
    public static byte SetBit(this byte b, int index)
    {
        b |= (byte)(1 << index);
        return b;
    }

    /// <summary>
    /// 将第index位设为0
    /// Clears the bit.
    /// </summary>
    /// <param name="b">The b.</param>
    /// <param name="index">The index.</param>
    /// <returns></returns>
    public static byte ClearBit(this byte b, int index)
    {
        b &= (byte)((1 << 8) - 1 - (1 << index));
        return b;
    }

    /// <summary>
    /// Reverses the bit.
    /// 将第index位取反
    /// </summary>
    /// <param name="b">The b.</param>
    /// <param name="index">The index.</param>
    /// <returns></returns>
    public static byte ReverseBit(this byte b, int index)
    {
        b ^= (byte)(1 << index);
        return b;
    }

    /// <summary>
    /// String to Binary
    /// </summary>
    /// <param name="str">String</param>
    /// <returns>Binary</returns>
    public static string StringToBinary(string str)
    {
        string converted = string.Empty;
        byte[] byteArray = str.StringToBytes();

        for (int i = 0; i < byteArray.Length; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                converted += (byteArray[i] & 0x80) > 0 ? "1" : "0";
                byteArray[i] <<= 1;
            }
        }

        return converted;
    }
}