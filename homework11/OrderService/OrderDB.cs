using MySql.Data.EntityFramework;
using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;


namespace OrderApp
{
    public class OrderDB : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“OrderDB”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“OrderForm.OrderDB”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“OrderDB”
        //连接字符串。
        public OrderDB() : base("OrderDataBases")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<OrderDB>());
        }  
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<OrderDetail> Orderdetails { get; set; }
        public DbSet<Order> Orders { get; set; }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

   
    /*public class Orderdetail
    {
        [Key]
        public int OrderdetailId { get; set; }
        public int GoodId { get; set; }
        public int Quantity { get; set; }
        public Orders Order { get; set; }
    }
    
    public class Orders
    {
        [Key]
        public int OrdersId { get; set; }
        public String CustomersId { get; set; }
        public DateTime CreateTime { get; set; }
        public List<Orderdetail> Orderdetails { get; set; }
    }*/
}