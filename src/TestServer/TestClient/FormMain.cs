using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TestServer;

namespace TestClient
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            toolStripTextBoxAddr.Text = Constants.DEFAULT_ADDR;
        }

        private ApiClient ac;
        private List<Status> statuses;

        private void toolStripButtonConnect_Click(object sender, EventArgs e)
        {
            string addr = toolStripTextBoxAddr.Text.Trim();
            if (addr.Length <= 0)
            {
                MessageBox.Show("No address specified");
                return;
            }
            //load lists of customers and statuses
            ac = new ApiClient(addr);
            var clients = ac.GetCustomers();
            BindingSource bnsCli = new BindingSource();
            bnsCli.DataSource = clients;
            listBoxClients.DataSource = bnsCli;
            listBoxClients.DisplayMember = "Name";
            statuses = ac.GetStatuses();
        }

        private void LoadOrders(Customer cust)
        {
            var orders = ac.GetOrders(cust);
            BindingSource bnsOrd = new BindingSource();
            bnsOrd.DataSource = orders;
            listBoxOrders.DataSource = bnsOrd;
        }

        private void listBoxClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            //upon cutomer selection - load related orders
            var item = listBoxClients.SelectedItem;
            if (item is null) return;
            LoadOrders((Customer)item);
        }

        private void listBoxOrders_Format(object sender, ListControlConvertEventArgs e)
        {
            var item = e.ListItem;
            if (item is null) return;
            var order = (OrderView)item;
            e.Value = string.Format("Orders' {0} status is {1}", order.OrderId, order.Status.Name);
        }

        private void listBoxOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            //upon order selection - load containing basket
            var item = listBoxOrders.SelectedItem;
            if (item is null) return;
            var basket = ((OrderView)item).Basket;
            if (basket is null || basket.Products is null) return;
            BindingSource bnsBsk = new BindingSource();
            bnsBsk.DataSource = basket.Products;
            listBoxBasket.DataSource = bnsBsk;
        }

        private void listBoxBasket_Format(object sender, ListControlConvertEventArgs e)
        {
            var item = e.ListItem;
            if (item is null) return;
            var prod = (BasketEntry)item;
            e.Value = string.Format("{0}: {1} pcs.; ${2}", prod.Product.Name, prod.Quantity, prod.Quantity * prod.Product.Value);
        }

        private void toolStripButtonChangeStatus_Click(object sender, EventArgs e)
        {
            //get selected order and invoke status selection dialog
            var item = listBoxOrders.SelectedItem;
            if (item is null) return;
            var order = (OrderView)item;
            DialogResult dr = new DialogStatus(order, statuses).ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                var result = ac.UpdateOrder(order);
                ParseOrderResult(result);
                var cli = listBoxClients.SelectedItem;
                if (cli is null) return;
                LoadOrders((Customer)cli);
            }
        }

        private void toolStripButtonStock_Click(object sender, EventArgs e)
        {
            BindingSource bnsStk = new BindingSource();
            bnsStk.DataSource = ac.GetItemsStock();
            listBoxStock.DataSource = bnsStk;
        }

        private void listBoxStock_Format(object sender, ListControlConvertEventArgs e)
        {
            var item = e.ListItem;
            if (item is null) return;
            var prod = (InventoryItem)item;
            e.Value = string.Format("{0}: {1} pcs.", prod.Product.Name, prod.Remainder);
        }

        private void toolStripButtonAddOrd_Click(object sender, EventArgs e)
        {
            //get selected client
            var item = listBoxClients.SelectedItem;
            if (item is null) return;                   //nothing selected
            //load products list
            var availableproducts = ac.GetProducts();
            if (availableproducts.Count <= 0) return;   //no products to add
            //compose a new order template
            OrderView ov = new OrderView()
            {
                Cust = (Customer)item,
                Status = statuses.Find(s => s.id == 1),
                Basket = new Basket() { Products = new List<BasketEntry>() }
            };
            //invoke cart add dialog
            DialogResult dr = new DialogOrder(availableproducts, ov.Basket).ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                var result = ac.CreateOrder(ov);
                ParseOrderResult(result);
                LoadOrders(ov.Cust);
            }
        }

        private void ParseOrderResult(OrderResult result)
        {
            switch (result.Result)
            {
                case OResults.Error:
                    MessageBox.Show("An error occured", "Error", MessageBoxButtons.OK);
                    break;
                case OResults.ArgNull:
                    MessageBox.Show("A requred argument was not specified", "Error", MessageBoxButtons.OK);
                    break;
                case OResults.OutOfStock:
                    MessageBox.Show("Product out of stock", "Error", MessageBoxButtons.OK);
                    break;
                default:
                    return;
            }
        }
    }
}
