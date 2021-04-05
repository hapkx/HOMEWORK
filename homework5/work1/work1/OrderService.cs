using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace work1
{
    class OrderService
    {
        public delegate void sorting(Order order1, Order order2);
        private List<Order> orderList;
        public OrderService()
        {
            orderList = new List<Order>();
        }

        //添加订单
        public void Add(object obj)
        {
            Order neworder = obj as Order;
            if (neworder == null)
                throw new Exception("添加错误");
            foreach(Order odr in orderList)
            {
                if (neworder.ID == odr.ID) throw new Exception("添加错误");
            }
            orderList.Add(neworder);
        }

        //根据订单ID删除
        public void Delete(string id)
        {
            List<Order> searchResult = this.SearchByID(id);
            if (searchResult.Count == 0)
            {
                throw new ArgumentException("订单号不存在");
            }
            for (int i = 0; i < searchResult.Count; i++)
            {
                orderList.Remove(searchResult[i]);
            }
        }
        
        //修改订单
        public void Modify(string type, string before, string after)
        {
            List<Order> searchResult;
            if (type.ToLower() == "id")
            {
                searchResult = this.SearchByID(before);
                if (searchResult.Count == 0)
                {
                    throw new ArgumentException("订单号不存在");
                }
                foreach (Order odr in orderList)
                {
                    if (odr.ID == before)
                    {
                        odr.ID = after;
                    }
                }
            }else if (type.ToLower() == "client")
            {
                searchResult = this.SearchByClient(before);
                if (searchResult.Count == 0)
                {
                    throw new ArgumentException("客户不存在");
                }
                foreach (Order odr in orderList)
                {
                    if (odr.ID == before)
                    {
                        odr.Client = after;
                    }                    
                }
            }else
            {
                searchResult = null;
                throw new ArgumentException("typeError");
            }

        }

        //查询所需订单，当查询结果为空的时候抛出异常
        public List<Order> SearchByID(string name)
        {
            var order = from odr in orderList where odr.ID == name orderby odr.sumPrice select odr;
            List<Order> result = order.ToList();
            if (result == null)
                throw new ArgumentException("doesn't exist.");
            return result;
        }

        public List<Order> SearchByClient(string name)
        {
            var order = from odr in orderList where odr.Client == name orderby odr.sumPrice select odr;
            List<Order> result = order.ToList();
            if (result == null)
                throw new ArgumentException("doesn't exist.");
            return result;
        }

        //排序方法
        public void Sort(Comparison<Order> comparison)
        {
            orderList.Sort(comparison);
        }

        public void Display()
        {
            Console.WriteLine("{0,-5}{1,-22}{2,-5}{5}",
                "订单号", "客户", "总金额", "订单");

            foreach (Order o in orderList)
            {
                Console.WriteLine(o.ToString());
            }
        }
        /* public List<Order> Sort(string type)
        {
            List<Order> result;
            if(type.ToLower() == "id")
            {
                result=
            }
            /*switch (type)
            {
                case:"ID"
            }
            return result;
        } */
    }
}
