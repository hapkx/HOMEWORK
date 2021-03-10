using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace work1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个正整数：");
            string s = Console.ReadLine();
            int a = int.Parse(s);
            while (a <= 0)
            {
                Console.WriteLine("输入不合法，重新输入：");
                s = Console.ReadLine();
                a = int.Parse(s);
            }
            int i = 2;
            while (i <= a)
            {
                if (a % i == 0)
                {
                    Console.WriteLine($"{i}");
                    a = a / i;
                }
                else i++;
            }
            Console.Write("按任意键退出...");
            Console.ReadKey(true);
        }
    }
}
