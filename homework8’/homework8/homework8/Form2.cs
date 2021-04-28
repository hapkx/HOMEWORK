using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ordertest;

namespace homework8
{
    public partial class Form2 : Form
    {
        private OrderService orderService1;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(OrderService orderService, int id)
        {
            InitializeComponent();

            Id.Text = id.ToString().Trim();
            

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(Id.Text.Trim());
            string customer = Customer.Text.Trim();
            DateTime date = monthCalendar1.SelectionStart;
            int cId = Int32.Parse(cusId.Text.Trim());
            Customer newcuestomer = new Customer((uint)cId, customer);
            Order newOrder = new Order(id, newcuestomer);
            newOrder.CreateTime = date;
            orderService1.AddOrder(newOrder);

            this.Close();
        }

        private void btn_addDetail_Click(object sender, EventArgs e)
        {

        }
    }
}
