using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Data.Entity;

namespace OrderApp {

  /**
   * The service class to manage orders
   * */
  public class OrderService {
    public OrderService()
        {
            using (var db = new OrderDB())
            {
                if (db.Customer.Count() == 0)
                {
                    Customer customer1 = new Customer ("001");
                    Customer customer2 = new Customer ("002");
                    db.Customer.Add(customer1);
                    db.Customer.Add(customer2);
                    db.SaveChanges();
                    
                }
                if (db.Goods.Count() == 0)
                {
                    Goods apple = new Goods("apple", 1.1);
                    Goods egg = new Goods("egg", 1.2);
                    db.Goods.Add(apple);
                    db.Goods.Add(egg);
                    db.SaveChanges();
                }
                
                
                /*
                var od1 = new OrderDetail { Index = 1, GoodsId = "1", Quantity = 2 };
                var od2 = new OrderDetail { Index = 2, GoodsId = "2", Quantity = 3 };
                var od3 = new OrderDetail { Index = 3, GoodsId = "1", Quantity = 4 };
                db.Orderdetails.Add(od1);
                db.Orderdetails.Add(od2);
                db.Orderdetails.Add(od3);
                var order1 = new Order
                {
                    OrderId = 1,
                    CustomerId = "1",
                    CreateTime = DateTime.Now
                };
                order1.Details = new List<OrderDetail>() { od1, od2 };
                var order2 = new Order
                {
                    OrderId = 2,
                    CustomerId = "2",
                    CreateTime = DateTime.Now
                };
                order2.Details = new List<OrderDetail>() { od2, od3 };
                */
            }
        }

    //the order list
    private List<Order> orders;

    
    public List<Order> Orders {
      //get => orders;
      get{
        using(var orderdb=new OrderDB())
            {
                return orderdb.Orders.Include(o => o.Details.Select(g => g.GoodsItem)).
                    Include("Customer").ToList<Order>();
            }
      }
    }

    public Order GetOrder(int id) {
        using (var orderdb=new OrderDB())
            {
                return orderdb.Orders.Include(o => o.Details.Select(g => g.GoodsItem)).
                    SingleOrDefault(o => o.OrderId == id);
            }
        }

        //避免级联添加或修改Customer和Goods
        private static void FixOrder(Order neworder)
        {
            neworder.CustomerId = neworder.Customer.Id;
            neworder.Customer = null;
            neworder.Details.ForEach(d =>
            {
                d.GoodsId = d.GoodsItem.Id;
                d.GoodsItem = null;
            });
        }

    public void AddOrder(Order order) {
        FixOrder(order);
            using(var orderdb=new OrderDB())
            {
                orderdb.Orders.Add(order);
                orderdb.SaveChanges();
            }
    }

    public void RemoveOrder(int orderId) {
      using(var orderdb=new OrderDB())
            {
                var order = orderdb.Orders.Include("Details").SingleOrDefault(o => o.OrderId == orderId);
                if (order == null) return;
                orderdb.Orderdetails.RemoveRange(order.Details);
                orderdb.Orders.Remove(order);
                orderdb.SaveChanges();
            }
    }

    public List<Order> QueryOrdersByGoodsName(string goodsName) {
        using(var orderdb=new OrderDB())
            {
                var result = orderdb.Orders.Include(o => o.Details.Select(d => d.GoodsItem)).Include("Customer").
                    Where(order => order.Details.Any(item => item.GoodsItem.Name == goodsName));
                return result.ToList();
            }
    }

    public List<Order> QueryOrdersByCustomerName(string customerName) {
            using (var orderdb = new OrderDB())
            {
                var result = orderdb.Orders.Include(o => o.Details.Select(d => d.GoodsItem)).Include("Customer").
                    Where(order => order.Customer.Name == customerName);
                return result.ToList();
            }
        }

    public void UpdateOrder(Order newOrder) {
            RemoveOrder(newOrder.OrderId);
            AddOrder(newOrder);
    }

    public void Sort() {
      orders.Sort();
    }

    public void Sort(Func<Order, Order, int> func) {
      Orders.Sort((o1,o2)=>func(o1,o2));
    }

    public void Export(String fileName) {
      XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
      using (FileStream fs = new FileStream(fileName, FileMode.Create)) {
        xs.Serialize(fs, Orders);
      }
    }

    public void Import(string path) {
      XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
      using (FileStream fs = new FileStream(path, FileMode.Open)) {
          using (var orderdb=new OrderDB())
          {
              List<Order> temp = (List<Order>)xs.Deserialize(fs);
                    temp.ForEach(order =>
                    {
                        if (orderdb.Orders.SingleOrDefault(o => o.OrderId == order.OrderId) == null)
                        {
                            FixOrder(order);
                            orderdb.Orders.Add(order);
                        }
                    });
                    orderdb.SaveChanges();
          }              
      }
    }

    public object QueryByTotalAmount(float amout) {
      return orders
         .Where(order => order.TotalPrice >= amout)
         .OrderByDescending(o => o.TotalPrice)
         .ToList();
    }
  }
}
