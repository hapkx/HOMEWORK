using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace work1
{
    class Program
    {
        class Shape
        {
            virtual public double area { get; }
            public bool validity;
                     
        }
        class Rectangle : Shape
        {
            double height;
            double width;
            public Rectangle(double height, double width)
            {
                this.height = height;
                this.width = width;
            }
            override public double area
            {
                get
                {
                    return height * width;
                }                
            }
            public bool Validity()
            {                
                if (height > 0 && width > 0)
                    {
                        validity = true;
                    }
                    else
                    {
                        validity = false;
                    }                               
                return validity;

            }            
        }
        class Triangle : Shape
        {
            double a, b, c;
            public Triangle(double a, double b, double c)
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }
            override public double area
            {
                get
                {
                    double s = (a + b + c) / 2;                    
                    return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
                }                
            }
            public bool Validity()
            {
                if (a > 0 && b > 0 && c > 0 && a + b > c && a + c > b && b + c > a)
                    {
                        validity = true;
                    }
                    else
                    {
                        validity = false;
                    }
                
                return validity;
            }
        }
        class Square : Shape
        {
            double a;
            public Square(double a)
            {
                this.a = a;
            }
            override public double area
            {
                get
                { 
                    return a * a;
                }
            }
            public bool Validity()
            {
               if (a > 0)
                    {
                        validity = true;
                    }
                    else
                    {
                        validity = false;
                    }              
               return validity;
                
            }            
        }
        class Industry
        {
            public Shape getShape(String shapeType,params double[] num)
            {
                switch (shapeType)
                {
                    case "Rectangle":
                        return new Rectangle(num[0], num[1]);
                        break;
                    case "Square":
                        return new Square(num[0]);
                        break;
                    case "Triangle":
                        return new Triangle(num[0], num[1], num[2]);
                        break;
                    default:
                        return null;
                }                               
            }
        static void Main(string[] args)
        {
            //工厂模式   List<Shape> shape = new List<Shape>();
            Rectangle rec1 = new Rectangle(3, 5);
            Console.WriteLine($"rec1's area:{rec1.area}");
            Rectangle rec2 = new Rectangle(2, 3);
            Square squ1 = new Square(3.4);
            Triangle tri1 = new Triangle(3, 4, 5);
            Square squ2 = new Square(3.6);
            Square squ3 = new Square(5);
            Rectangle rec3 = new Rectangle(3.2, 4);
            Triangle tri2 = new Triangle(1.1, 2.2, 3.2);
            Rectangle rec4 = new Rectangle(2, 3);
            Triangle tri3 = new Triangle(2, 3, 4);

            if (rec1.Validity() && rec2.Validity() && rec3.Validity() && rec4.Validity() && squ1.Validity() && squ2.Validity()
                && squ3.Validity() && tri1.Validity() && tri2.Validity() && tri3.Validity())
            {
                double areasum = rec1.area + rec2.area + rec3.area + rec4.area + squ1.area + squ2.area + squ3.area + tri1.area + tri2.area + tri3.area;
                Console.WriteLine($"sumarea: {areasum}");
            }
            else
            {
                Console.WriteLine("输入数值有误");
            }

            Console.Write("按任意键退出...");
            Console.ReadKey(true);
        }
    }
}
