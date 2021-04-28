﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest {

  public class OrderDetail {

    public Goods Goods { get; set; }

    public uint Quantity { get; set; }

    public float Amount {
      get => Goods.Price * Quantity;
    }

    public OrderDetail(Goods goods, uint quantity) {
      this.Goods = goods;
      this.Quantity = quantity;
    }

    public override bool Equals(object obj) {
      var detail = obj as OrderDetail;
      return detail != null &&
             EqualityComparer<Goods>.Default.Equals(Goods, detail.Goods);
    }

    public override int GetHashCode() {
      return 785010553 + EqualityComparer<Goods>.Default.GetHashCode(Goods);
    }

    public override string ToString() {
      return $"OrderDetail:{Goods},{Quantity}";
    }
  }
}
