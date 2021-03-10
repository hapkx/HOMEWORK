using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = new int[99];
            for(int i = 0; i < num.Length; i++)
            {
                num[i] = i + 2;
            }
            for(int i = 0; i < num.Length; i++)
            {
                for(int j = 2; j <= 10; j++)
                {
                    if (num[i] % j == 0 && num[i] / j != 1)
                    {
                        num[i] = 0;
                        break;
                    }
                }
            }
            for(int i = 0; i < num.Length; i++)
            {
                if (num[i] != 0)
                {
                    Console.Write($"{num[i]}  ");
                }
            }

            Console.Write("\n 按任意键退出...");
            Console.ReadKey(true);
        }
    }
}
