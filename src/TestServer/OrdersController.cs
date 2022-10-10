using System.Collections.Generic;
using System.Web.Http;

namespace TestServer
{
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        private OrdersAdapter oa;

        public OrdersController()
        {
            oa = new OrdersAdapter();
        }

        [Route("~/api/customers/{id:int}/orders")]
        [HttpGet]
        public List<OrderView> GetCustOrders(int id)
        {
            return oa.GetOrdersByCustomer(id);
        }

        [Route("~/api/statuses")]
        [HttpGet]
        public List<Status> GetStatuses()
        {
            return oa.GetOrderStatuses();
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult CreateOrder([FromBody] OrderView order)
        {
            if (order is null || order.Cust is null || order.Basket is null) return Json(new OrderResult() { Result = OResults.ArgNull });
            return Json<OrderResult>(oa.CreateOrder(order));
        }

        [Route("{id:int}")]
        [HttpPut]
        public IHttpActionResult UpdateOrder(int id, [FromBody] OrderView order)
        {
            if (order is null || order.OrderId != id) return Json(new OrderResult() { Result = OResults.ArgNull });
            return Json<OrderResult>(oa.AlterOrderStatus(id, order.Status.id));
        }
    }
}
