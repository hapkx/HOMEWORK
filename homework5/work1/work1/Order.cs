using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace work1
{
    class Order : IComparable
    {
        public Order(string id, string client)
        {
            this.ID = id;
            this.Client = client;
        }
        public string ID { get; set; }
        public string Client { get; set; }
        public double sumPrice { get => Details.Sum(d => d.Quantity * d.Price); }

        public List<OrderDetails> Details { get; } = new List<OrderDetails>();

        public void AddDetails(OrderDetails orderDetail)
        {
            if (this.Details.Contains(orderDetail))
            {
                throw new ApplicationException($"The goods exist in order {ID}");
            }
            Details.Add(orderDetail);
        }
        public void RemoveDetails(int num)
        {
            Details.RemoveAt(num);
        }

        public override bool Equals(object obj)
        {
            var o1 = obj as Order;
            if (o1 == null)
                throw
                    new Exception("错误");
            return (ID == o1.ID);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            String result = $"订单编号：{ID} 客户：{Client} 订单总金额：{sumPrice} \n";
            Details.ForEach(detail => result += "\n\t" + detail);
            return result;
        }

        //比较器
        public int CompareTo(object obj)
        {
            Order neworder = obj as Order;
            if (neworder == null) return 1;
            return Int32.Parse(this.ID) - Int32.Parse(neworder.ID);
        }
    }
}
