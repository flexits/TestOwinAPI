using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using TestServer;

namespace TestClient
{
    internal class ApiClient
    {
        string addr;
        public ApiClient(string serverAddress)
        {
            if (string.IsNullOrWhiteSpace(serverAddress)) throw new ArgumentNullException();

            addr = serverAddress;
        }

        private List<T> GetFromServer<T>(string request)
        {
            if (string.IsNullOrWhiteSpace(request)) throw new ArgumentNullException();

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(request).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<T>>(content);
            }
        }

        internal List<Customer> GetCustomers()
        {
            return GetFromServer<Customer>(addr + "api/customers");
        }

        internal List<InventoryItem> GetItemsStock()
        {
            return GetFromServer<InventoryItem>(addr + "api/inventory");
        }

        internal List<Product> GetProducts()
        {
            return GetFromServer<Product>(addr + "api/products");
        }

        internal List<Status> GetStatuses()
        {
            return GetFromServer<Status>(addr + "api/statuses");
        }

        internal List<OrderView> GetOrders(Customer customer)
        {
            if (customer is null) throw new ArgumentNullException();
            var request = string.Format("{0}api/customers/{1}/orders", addr, customer.id.ToString());
            return GetFromServer<OrderView>(request);
        }

        internal OrderResult UpdateOrder(OrderView order)
        {
            if (order is null) throw new ArgumentNullException();

            using (var client = new HttpClient())
            {
                var request = string.Format("{0}api/orders/{1}", addr, order.OrderId.ToString());
                var jsonstr = JsonConvert.SerializeObject(order);
                var content = new StringContent(jsonstr, Encoding.UTF8, "application/json");
                var result = client.PutAsync(request, content).Result;
                return JsonConvert.DeserializeObject<OrderResult>(result.Content.ReadAsStringAsync().Result);
            }
        }

        internal OrderResult CreateOrder(OrderView order)
        {
            if (order is null) throw new ArgumentNullException();

            using (var client = new HttpClient())
            {
                var request = string.Format("{0}api/orders", addr, order.OrderId.ToString());
                var jsonstr = JsonConvert.SerializeObject(order);
                var content = new StringContent(jsonstr, Encoding.UTF8, "application/json");
                var result = client.PostAsync(request, content).Result;
                return JsonConvert.DeserializeObject<OrderResult>(result.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
