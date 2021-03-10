using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work2
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建数组
            Console.WriteLine("输入数组长度：");
            string s = Console.ReadLine();
            int length = int.Parse(s);
            Console.WriteLine($"数组长度为：{length}");
            int[] num = new int[length];
            for(int i = 0; i < length; i++)
            {
                Console.Write($"输入第{i + 1}个数：");
                s = Console.ReadLine();
                num[i] = int.Parse(s);
            }
            //输出数组
            for (int i = 0; i < length; i++)
            {
                Console.Write($"{num[i]}  ");
            }
            Console.Write("\n");
            //最大值
            Console.WriteLine($"最大值：{num.Max()}");
            //最小值
            Console.WriteLine($"最小值：{num.Min()}");
            //平均值
            int sum = 0;
            for(int i = 0; i < length; i++)
            {
                sum += num[i];
            }
            double average = (double)sum / length;
            Console.WriteLine($"平均值：{average}");
            //和
            Console.WriteLine($"和：{sum}");

            Console.Write("按任意键退出...");
            Console.ReadKey(true);
        }
        
    }
}
