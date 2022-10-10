using System;
using System.Collections.Generic;
using System.Linq;

namespace TestServer
{
    public class Basket                 //represents a basket with products
    {
        public List<BasketEntry> Products { get; set; }

        public int GetTotalValue()      //total value of all the products in the basket
        {
            int total = 0;
            foreach (var product in Products)
            {
                total += product.Quantity * product.Product.Value;
            }
            return total;
        }
    }

    public class BasketEntry            //an entry of the basket: a product and its quantity
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    public class InventoryItem          //represents a product with its quantity in stock
    {
        public Product Product { get; set; }
        public int Remainder { get; set; }
    }

    internal class InventoryAdapter     //a warehouse logic is here
    {
        private AppContext ac;
        public InventoryAdapter(AppContext ac)
        {
            if (ac is null) throw new ArgumentNullException();
            this.ac = ac;
        }

        //list of available products
        internal List<Product> GetProducts()
        {
            return ac.Products.ToList();
        }

        //products and quantities
        internal List<InventoryItem> GetStock()
        {
            var query = from p in ac.Products
                        let withdrawn = (from w in ac.Withdrawals
                                         where w.Prod_id == p.id
                                         select w).Sum(w => (int?)w.Amount)
                        let advanced = (from a in ac.Advances
                                        where a.Prod_id == p.id
                                        select a).Sum(a => (int?)a.Amount)
                        select new InventoryItem { Product = p, Remainder = (advanced ?? 0) - (withdrawn ?? 0) };
            return query.ToList();
        }

        //quantity of a particular product
        internal int GetStockByProduct(int prodId)
        {
            int? withdrawn = (from w in ac.Withdrawals
                              where w.Prod_id == prodId
                              select w).Sum(w => (int?)w.Amount);
            int? advanced = (from a in ac.Advances
                             where a.Prod_id == prodId
                             select a).Sum(a => (int?)a.Amount);
            return (advanced ?? 0) - (withdrawn ?? 0);
        }

        //collect a basket of products for a specified order
        internal Basket GetBasketOfOrder(int orderId)
        {
            var products = from w in ac.Withdrawals
                           where w.Order_id == orderId
                           group w by w.Prod_id into g
                           join m in ac.Products on g.Key equals m.id
                           select new BasketEntry { Product = m, Quantity = g.Sum(p => p.Amount) };
            return new Basket { Products = products.ToList() };
        }

        //a basket withdrawal decreases amount of goods
        private void WithdrawBasket(int orderId, Basket basket)
        {
            //clear previous product movements
            _ = ac.Advances.RemoveRange(ac.Advances.Where(a => a.Doc_id == orderId));
            _ = ac.Withdrawals.RemoveRange(ac.Withdrawals.Where(w => w.Order_id == orderId));
            //withdraw items from stock
            foreach (BasketEntry ba in basket.Products)
            {
                ac.Withdrawals.Add(new Withdrawal { Order_id = orderId, Prod_id = ba.Product.id, Amount = ba.Quantity });
            }
            _ = ac.SaveChanges();
        }

        //return basket back to stock
        private void AdvanceBasket(int orderId, Basket basket)
        {
            foreach (BasketEntry ba in basket.Products)
            {
                ac.Advances.Add(new Advance { Doc_id = orderId, Prod_id = ba.Product.id, Amount = ba.Quantity });
            }
            _ = ac.SaveChanges();
        }

        //withdraw or advance goods in a basket depending on the order's status
        internal void ProcessBasket(Order order, Basket basket)
        {
            if (order is null || basket is null || basket.Products is null) return;
            if (basket.Products.Count == 0) return;

            if (order.Status_id == Constants.STATUS_ACCEPTED)    //TODO the status check is ugly(
            {
                //withdraw basket contents from stock
                WithdrawBasket(order.id, basket);
            }
            else if (order.Status_id == Constants.STATUS_CANCELLED)
            {
                //advance basket contents in stock
                AdvanceBasket(order.id, basket);
            }
        }

        internal void ProcessBasket(Order order)
        {
            if (order is null) return;
            Basket basket = GetBasketOfOrder(order.id);
            ProcessBasket(order, basket);
        }

        //check if there's sufficient amount of goods for the desired basket
        internal bool IsBasketAvailable(Basket basket)
        {
            if (basket is null || basket.Products is null) return false;

            foreach (BasketEntry ba in basket.Products)
            {
                if (GetStockByProduct(ba.Product.id) <= 0) return false;
            }

            return true;
        }
    }
}
