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
        private OrderService order;
        
        [TestInitialize]
        public void TestInitialize()
        {
            orderlist.Add(new Order(1, new Customer(1, "001")));
            orderlist.Add(new Order(2, new Customer(2, "002")));
            orderlist.Add(new Order(3, new Customer(3, "003")));
            order = new OrderService(orderlist);
        }

        [TestMethod]
        public void TestAddOrder()
        {
            OrderService test1 = new OrderService();
            foreach(Order o in orderlist)
            {
                test1.AddOrder(o);
            }
            CollectionAssert.Equals(test1, order);
        }
        [TestMethod]
        public void TestRemove()
        {
            OrderService test = new OrderService();
            foreach(Order o in orderlist)
            {
                order.RemoveOrder(o.Id);
            }
            CollectionAssert.Equals(test, order);
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
