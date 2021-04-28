using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System;
using ordertest;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        private List<OrderDetail> list;
        private List<Order> orderlist;
        OrderService order = new OrderService();

        Goods apple = new Goods(1, "apple", 10.0f);
        Goods egg = new Goods(2, "egg", 1.2f);
        Goods milk = new Goods(3, "milk", 50f);
        Customer customer1 = new Customer(1, "Customer1");
        Customer customer2 = new Customer(2, "Customer2");

        [TestInitialize]
        public void TestInitialize()
        {
            Order order1 = new Order(1, customer1);
            order1.AddDetails(new OrderDetail(apple, 80));
            order1.AddDetails(new OrderDetail(egg, 200));
            order1.AddDetails(new OrderDetail(milk, 10));

            Order order2 = new Order(2, customer2);
            order2.AddDetails(new OrderDetail(egg, 200));
            order2.AddDetails(new OrderDetail(milk, 10));

            Order order3 = new Order(3, customer1);
            order3.AddDetails(new OrderDetail(apple, 80));
            order3.AddDetails(new OrderDetail(milk, 10));

            OrderService order = new OrderService();
            order.AddOrder(order1);
            order.AddOrder(order2);
            order.AddOrder(order3);
        }

        [TestMethod]
        public void TestAddOrder()
        {
            Order order4 = new Order(4, customer2);
            order4.AddDetails(new OrderDetail(milk, 10));
            order.AddOrder(order4);
            List<Order> orders = order.QueryAll();
            CollectionAssert.Contains(orders, order4);
        }
        [TestMethod]
        public void TestRemove()
        {
            order.RemoveOrder(1);
            Order order1 = new Order(1, customer1);
            order1.AddDetails(new OrderDetail(apple, 80));
            order1.AddDetails(new OrderDetail(egg, 200));
            order1.AddDetails(new OrderDetail(milk, 10));
            List<Order> ordertest = order.QueryAll();
            CollectionAssert.DoesNotContain(ordertest, order1);
        }
        
        [TestMethod]
        public void TestUpdate()
        {
            OrderService test = new OrderService();
            test.AddOrder(new Order(1, new Customer(1, "001")));
            test.AddOrder(new Order(2, new Customer(2, "002")));
            test.AddOrder(new Order(3, new Customer(4, "004")));
            order.Update(new Order(3, new Customer(4, "004")));
            CollectionAssert.Equals(test, order);
        }

        [TestMethod]
        public void TestGetByID()
        {
            Order order1 = new Order(1, new Customer(1, "001"));
            Order test = order.GetById(1);
            CollectionAssert.Equals(test, order1);
        }

        [TestMethod]
        public void TestSort()
        {
            OrderService test = new OrderService();
            test.AddOrder(new Order(3, new Customer(4, "004")));
            test.AddOrder(new Order(2, new Customer(2, "002")));
            test.AddOrder(new Order(1, new Customer(1, "001")));
            test.Sort((o1, o2) => o2.Id.CompareTo(o1.Id));
            CollectionAssert.Equals(test, order);
        }
    }
}
