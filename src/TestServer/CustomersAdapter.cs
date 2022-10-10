using System;
using System.Collections.Generic;
using System.Linq;

namespace TestServer
{
    internal class CustomersAdapter
    {
        internal List<Customer> GetCustomers()
        {
            using (AppContext ac = new AppContext())
            {
                return ac.Customers.ToList();
            }
        }

        internal int GetCustomerId(string customerName)      //returns id or ERR_CODE if not found
        {
            using (AppContext ac = new AppContext())
            {
                if (string.IsNullOrEmpty(customerName)) return Constants.ERR_CODE;
                int id = (from c in ac.Customers where c.Name.Equals(customerName, StringComparison.OrdinalIgnoreCase) select c.id).FirstOrDefault();
                return id > 0 ? id : Constants.ERR_CODE;
            }
        }
    }
}
