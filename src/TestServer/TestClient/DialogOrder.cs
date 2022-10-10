using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TestServer;

namespace TestClient
{
    public partial class DialogOrder : Form
    {
        private Basket basket;

        public DialogOrder(IList<Product> availableproducts, Basket basket)
        {
            InitializeComponent();
            this.basket = basket;
            comboBoxItems.Items.AddRange(availableproducts.ToArray());
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //get selected product
            var item = comboBoxItems.SelectedItem;
            if (item is null) return;
            var prod = (Product)item;
            //search if it's already in the basket
            var basketEntry = basket.Products.Find(p => p.Product.id == prod.id);
            if (basketEntry is null)
            {
                //add new product to the basket
                basket.Products.Add(new BasketEntry() { Product = prod, Quantity = 1 });
            }
            else
            {
                //increase quantity
                basketEntry.Quantity++;
            }
            //reload list
            ShowBasket();
        }

        private void ShowBasket()
        {
            BindingSource bns = new BindingSource();
            bns.DataSource = basket.Products;
            listBoxBasket.DataSource = bns;
        }

        private void listBoxBasket_Format(object sender, ListControlConvertEventArgs e)
        {
            var item = e.ListItem;
            if (item is null) return;
            var prod = (BasketEntry)item;
            e.Value = string.Format("{0}: {1} pcs.; ${2}", prod.Product.Name, prod.Quantity, prod.Quantity * prod.Product.Value);
        }

        private void comboBoxItems_Format(object sender, ListControlConvertEventArgs e)
        {
            var item = e.ListItem;
            if (item is null) return;
            var prod = (Product)item;
            e.Value = string.Format("{0}: ${1}", prod.Name, prod.Value);
        }
    }
}
