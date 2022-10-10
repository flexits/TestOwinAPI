using System.Collections.Generic;
using System.Web.Http;

namespace TestServer
{
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        private CustomersAdapter ca;

        public CustomersController()
        {
            ca = new CustomersAdapter();
        }

        [Route("")]
        public IList<Customer> GetAll()
        {
            return ca.GetCustomers();
        }

        [Route("{name}")]
        public int GetCustByName(string name)
        {
            return ca.GetCustomerId(name);
        }
    }
}
