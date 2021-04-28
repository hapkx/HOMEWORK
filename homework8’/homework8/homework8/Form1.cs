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
    public partial class Form1 : Form
    {
        OrderService orderService;
        Form2 form2;

        public Form1()
        {
            InitializeComponent();
            Order order1 = new Order(1, new Customer(1, "aa"));
            order1.AddDetails(new OrderDetail(new Goods(1, "bread", (float)3.3), 3));
            order1.AddDetails(new OrderDetail(new Goods(2, "books", (float)4.4), 4));
            orderService.AddOrder(order1);
            Order order2 = new Order(2, new Customer(2, "bb"));
            order2.AddDetails(new OrderDetail(new Goods(2, "books", (float)4.4), 5));
            order2.AddDetails(new OrderDetail(new Goods(3, "apple", (float)2.2), 2));
            orderService.AddOrder(order2);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            orderService = new OrderService();
            searchBy.Items.Add("Id");
            searchBy.Items.Add("Customer");
            searchBy.SelectedItem = searchBy.Items[0];
        }

        //删除
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int currentOrderNumber = orderGridView.CurrentRow.Index;
            int orderToRemove = Int32.Parse(orderGridView.Rows[currentOrderNumber].Cells[0].Value.ToString().Trim());
            try
            {
                orderService.RemoveOrder(orderToRemove);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Successfully remove!");
        }

        //导入
        private void ImportButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = "c:\\";
            openFile.Filter = "xml文件|*.xml";
            openFile.Title = "选择导入的xml文件";
            string filepath = "";
            try
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    filepath = openFile.FileName;
                }
                else
                {
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("文件导入失败");
            }
            orderService.Import(filepath);
            orderBindingSource.DataSource = orderService.OrderList;
        }

        //导出
        private void ExportButton_Click(object sender, EventArgs e)
        {
            string filepath = "";
            OpenFileDialog exportFile = new OpenFileDialog();
            exportFile.Title = "选择导出的xml文件";
            exportFile.Filter = "xml文件|*.xml";
            try
            {
                if (exportFile.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                filepath = exportFile.FileName;
            }
            catch(Exception ex)
            {
                MessageBox.Show("导出失败");
            }
            orderService.Export(filepath);
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            Form2 createOrderForm = new Form2();
            createOrderForm.Show();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            int currentOrderNumber = orderGridView.CurrentRow.Index;
            int orderToUpdate = Int32.Parse(orderGridView.Rows[currentOrderNumber].Cells[0].Value.ToString().Trim());
            Form2 updateWin = new Form2(this.orderService, orderToUpdate);
            updateWin.Show();
        }
    }
}



