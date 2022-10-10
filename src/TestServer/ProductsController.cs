using System.Collections.Generic;
using System.Web.Http;

namespace TestServer
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {

        [Route("")]
        public IList<Product> GetAll()
        {
            using (AppContext ac = new AppContext())
            {
                return new InventoryAdapter(ac).GetProducts();
            }
        }
    }
}
