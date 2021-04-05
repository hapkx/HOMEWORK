using System;
using System.Collections.Generic;
using System.Text;

namespace work1
{
    class OrderDetails
    {
        public OrderDetails(string id, string name, double price, double quantity)
        {
            this.GoodsID = id;
            this.GoodsName = name;
            this.Price = price;
            this.Quantity = quantity;
        }
        public string GoodsID { get; set; }
        public string GoodsName { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public override bool Equals(object obj)
        {
            var o1 = obj as OrderDetails;
            if (o1 == null) return false;
            return (GoodsID == o1.GoodsID) && (GoodsName == o1.GoodsName);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return "商品编号：" + GoodsID + "\n 商品名称：" + GoodsName + "\n 商品单价：" + Price;
        }
    }
}
