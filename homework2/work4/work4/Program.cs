using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work4
{
    class Program
    {
        static void Main(string[] args)
        {
            string s;
            int a, b;
            //创建矩阵
            Console.WriteLine("请输入一个二维矩阵：");
            Console.Write("请输入行数：");
            s = Console.ReadLine();
            a = int.Parse(s);
            Console.Write("请输入列数：");
            s = Console.ReadLine();
            b = int.Parse(s);
            int[,] matrix = new int[a, b];
            for(int i = 0; i < a; i++)
            {
                Console.WriteLine($"输入第{i + 1}行：");
                for(int j = 0; j < b; j++)
                {
                    s = Console.ReadLine();
                    matrix[i, j] = int.Parse(s);
                }
            }
            //输出矩阵
            Console.WriteLine("矩阵为：");
            for(int i = 0; i < a; i++)
            {
                for(int j = 0; j < b; j++)
                {
                    Console.Write($"{matrix[i, j]}  ");
                }
                Console.Write("\n");
            }

            bool flag = true;
            //判断
            for (int i = 1; i < a; i++)
            {                
                for(int j = 1; j < b; j++)
                {
                    if (matrix[i, j] != matrix[i - 1, j - 1])
                    {
                        flag = false;
                        break;
                    }
                }
                if (!flag)
                {
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("是托普利茨矩阵");
            }
            else
            {
                Console.WriteLine("不是托普利茨矩阵");
            }

            Console.Write("按任意键退出...");
            Console.ReadKey(true);
        }
    }
}
