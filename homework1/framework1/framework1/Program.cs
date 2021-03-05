using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace framework1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            char op;
            double d1, d2, ans = 0.0;
            char flag = 'y';
            Console.WriteLine("计算器");
            while (flag == 'y')
            {
                Console.Write("输入第一个数：");
                s = Console.ReadLine();
                d1 = Double.Parse(s);
                Console.Write("输入第二个数：");
                s = Console.ReadLine();
                d2 = Double.Parse(s);
                Console.Write("输入运算符：");
                s = Console.ReadLine();
                op = Char.Parse(s);
                while (op != '+' && op != '-' && op != '*' && op != '/')
                {
                    Console.WriteLine("重新输入运算符：");
                    s = Console.ReadLine();
                    op = Char.Parse(s);
                }
                switch (op)
                {
                    case '+':
                        ans = d1 + d2;
                        break;
                    case '-':
                        ans = d1 - d2;
                        break;
                    case '*':
                        ans = d1 * d2;
                        break;
                    case '/':
                        ans = d1 / d2;
                        break;
                    default:
                        break;
                }
                Console.WriteLine($"{d1} {op} {d2} = {ans}");
                Console.Write("是否继续？（y/n）：");
                s = Console.ReadLine();
                flag = Char.Parse(s);
            }
        }        
    }
}
