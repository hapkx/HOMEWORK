using System;

namespace work1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Order order1 = new Order("001", "Mary");
                OrderDetails milk = new OrderDetails("1111", "milk", 2.1, 3);
                OrderDetails egg = new OrderDetails("1112", "eggs", 3.2, 4);
                OrderDetails bread = new OrderDetails("1113", "bread", 1, 3.1);
                order1.AddDetails(milk);
                order1.AddDetails(bread);
                Order order2 = new Order("002", "Jack");
                OrderDetails sugar = new OrderDetails("2222", "sugar", 3.3, 1);
                order2.AddDetails(sugar);
                order2.AddDetails(bread);

                OrderService orderService1 = new OrderService();
                orderService1.Add(order1);
                orderService1.Add(order2);

                Console.WriteLine(order1);
                Console.WriteLine(order2);

                orderService1.Display();

                Console.WriteLine("\n search orderID 001");
                foreach (Order o in orderService1.SearchByID("001"))
                    Console.WriteLine(o.ToString());
                Console.WriteLine("\n search client mary");
                foreach (Order o in orderService1.SearchByClient("Mary"))
                    Console.WriteLine(o.ToString());

                Console.WriteLine("delete 001");
                orderService1.Delete("001");
                Console.WriteLine("\n search orderID 001");
                foreach (Order o in orderService1.SearchByID("001"))
                    Console.WriteLine(o.ToString());
                orderService1.Sort((odr1, odr2) => (int)(odr1.sumPrice - odr2.sumPrice));

                Console.Write("按任意键退出...");
                Console.ReadKey(true);

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
