using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ordertest {

 public class OrderService {

    private List<Order> orderList=new List<Order>();

    public OrderService() {
    }

    public OrderService(List<Order> list)
    {
        this.orderList = list;
    }

    public void AddOrder(Order order) {
      if (orderList.Contains(order)) {
        throw new ApplicationException($"the order {order.Id} already exists!");
      }
      orderList.Add(order);
    }

    public void Update(Order order) {
      RemoveOrder(order.Id);
      orderList.Add(order);
    }

    public Order GetById(int orderId) {
      return orderList.Where(o => o.Id == orderId).FirstOrDefault();
    }

    public void RemoveOrder(int orderId) {
      orderList.RemoveAll(o => o.Id == orderId);
    }

    public List<Order> QueryAll() {
      return orderList;
    }

    public IEnumerable<Order> Query(Predicate<Order> condition) {
      return  orderList.Where(o => condition(o));
    }

    public List<Order> QueryByGoodsName(string goodsName) {
      var query = orderList.Where(
        o => o.Details.Any(d => d.Goods.Name == goodsName));
      return query.ToList();
    }

    public List<Order> QueryByTotalAmount(float totalAmount) {
      var query = orderList.Where(o=>o.TotalAmount>=totalAmount);
      return query.ToList();
    }

    public List<Order> QueryByCustomerName(string customerName) {
      var query = orderList
          .Where(o => o.Customer.Name == customerName);
      return query.ToList();
    }

    public void Sort(Comparison<Order> comparison) {
      orderList.Sort(comparison);
    }

    public void Export(string targrtAdress)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
        using (FileStream fs = new FileStream(targrtAdress, FileMode.Open, FileAccess.Read))
        {
            xmlSerializer.Serialize(fs, orderList);
        }
    }
    public void Import(string targetAddress)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
        using (FileStream fs = new FileStream(targetAddress, FileMode.Open, FileAccess.Read))
        {
                orderList = (List<Order>)xmlSerializer.Deserialize(fs);
        }

    }
  }
}
