using System.Collections.Generic;
using System.Web.Http;

namespace TestServer
{
    [RoutePrefix("api/inventory")]
    public class InventoryController : ApiController
    {

        [Route("")]
        public List<InventoryItem> GetAll()
        {
            using (AppContext ac = new AppContext())
            {
                return new InventoryAdapter(ac).GetStock();
            }
        }
    }
}
