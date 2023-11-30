#define PI
#define DEBUG
#define VC_V10

namespace PreprocessorDirectives
{
    /// <summary>
    /// C# 预处理器指令
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
#if PI
            Console.WriteLine("PI 已定义");
#endif

#if (DEBUG && VC_V10)
            Console.WriteLine("DEBUG && VC_V10 已定义");
#endif
        }
    }
}