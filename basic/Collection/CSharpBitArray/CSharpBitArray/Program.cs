using System.Collections;

namespace CSharpBitArray;

/// <summary>
/// C# BitArray（点阵列）：用来管理一个紧凑型的位值数组，数组中的值均为布尔类型，其中 true（1）表示此位为开启，false（0）表示此位为关闭。
/// <remarks>
/// 当需要存储位（英文名“bit”数据存储的最小单位，也可称为比特），但事先又不知道具体位数时，就可以使用点阵列。<br/>
/// 当需要访问点阵列中的元素时，可以使用整型索引从点阵列中访问指定元素，索引从零开始。
/// </remarks>
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        // 创建两个大小为 8 的点阵列
        var bitArray1 = new BitArray(8);
        var bitArray2 = new BitArray(8);
        // 存储数据
        byte[] a = { 60 };
        byte[] b = { 13 };
        bitArray1 = new BitArray(a);
        bitArray2 = new BitArray(b);
        // 打印点阵列信息
        Console.WriteLine("点阵列：bitArray1：60");
        PrintBitArray(bitArray1);
        Console.WriteLine("点阵列：bitArray2：13");
        PrintBitArray(bitArray2);

        // 点阵列位运算操作
        var bitArray3 = bitArray1.And(bitArray2);
        Console.WriteLine("执行按位与操作之后的点阵列bitArray3：");
        PrintBitArray(bitArray3);

        var bitArray4 = bitArray1.Or(bitArray2);
        Console.WriteLine("执行按位或操作之后的点阵列bitArray4：");
        PrintBitArray(bitArray4);

        var bitArray5 = bitArray1.Xor(bitArray2);
        Console.WriteLine("执行按位异或操作之后的点阵列bitArray5：");
        PrintBitArray(bitArray5);
    }

    /// <summary>
    /// 打印点阵列信息
    /// </summary>
    /// <param name="bitArray">点阵列</param>
    public static void PrintBitArray(BitArray bitArray)
    {
        for (var i = 0; i < bitArray.Count; i++)
        {
            Console.Write("{0, -6} ", bitArray[i]);
        }

        Console.WriteLine();
    }
}