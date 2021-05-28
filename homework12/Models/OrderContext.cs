using Microsoft.EntityFrameworkCore;

namespace homework12.Models
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) 
        : base(options)
        {
        }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<OrderDetail> Orderdetails { get; set; }
        public DbSet<Order> Orders { get; set; }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

}