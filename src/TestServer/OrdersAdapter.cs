using System.Collections.Generic;
using System.Linq;

namespace TestServer
{
    public class OrderView
    {
        public int OrderId { get; set; }
        public Customer Cust { get; set; }
        public Status Status { get; set; }
        public Basket Basket { get; set; }
    }

    public class OrderResult    //result of order creation or modification
    {
        public OResults Result { get; set; }
        public int Id { get; set; }
    }

    public enum OResults
    {
        Success,
        ArgNull,
        OutOfStock,
        Error
    }

    internal class OrdersAdapter
    {
        internal OrderResult CreateOrder(OrderView newOrderView) //return order Id or -1
        {
            if (newOrderView is null) return new OrderResult() { Result = OResults.ArgNull };

            using (AppContext ac = new AppContext())
            {
                InventoryAdapter ia = new InventoryAdapter(ac);
                //check items' availability in stock
                if (!ia.IsBasketAvailable(newOrderView.Basket))
                {
                    return new OrderResult() { Result = OResults.OutOfStock };
                }
                //save order
                Order o = ac.Orders.Add(new Order { Cust_id = newOrderView.Cust.id, Status_id = newOrderView.Status.id });
                _ = ac.SaveChanges();
                //remove basket contents from stock
                ia.ProcessBasket(o, newOrderView.Basket);
                return new OrderResult() { Result = OResults.Success, Id = o.id };
            }
        }

        internal List<OrderView> GetOrdersByCustomer(int customerId)
        {
            using (AppContext ac = new AppContext())
            {
                //get orders by customer Id, populating an OrderView by corresponding objects
                var orders = (from o in ac.Orders
                              where o.Cust_id == customerId
                              join c in ac.Customers on customerId equals c.id
                              join s in ac.Statuses on o.Status_id equals s.id
                              select new OrderView { OrderId = o.id, Status = s, Cust = c }).ToList();
                //collect the basket for each order
                InventoryAdapter ia = new InventoryAdapter(ac);
                foreach (OrderView ov in orders)
                {
                    ov.Basket = ia.GetBasketOfOrder(ov.OrderId);
                }
                return orders;
            }
        }

        internal OrderResult AlterOrderStatus(int orderId, int newStatusId)
        {
            using (AppContext ac = new AppContext())
            {
                Order o = (from ord in ac.Orders
                           where ord.id == orderId
                           select ord).FirstOrDefault();
                if (o is null) return new OrderResult() { Result = OResults.ArgNull };
                Status s = (from st in ac.Statuses
                            where st.id == newStatusId
                            select st).FirstOrDefault();
                if (s is null) return new OrderResult() { Result = OResults.ArgNull };
                o.Status_id = newStatusId;
                _ = ac.SaveChanges();
                //remove or add basket contents
                new InventoryAdapter(ac).ProcessBasket(o);
                return new OrderResult() { Result = OResults.Success, Id = o.id };
            }
        }

        internal List<Status> GetOrderStatuses()
        {
            using (AppContext ac = new AppContext())
            {
                return ac.Statuses.ToList();
            }
        }
    }
}
