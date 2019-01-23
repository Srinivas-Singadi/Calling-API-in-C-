using CallingWebApi.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CallingWebApi
{
    public class ToTest
    {
        public  void getCustomers()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("http://localhost/50024/");


            //Get Method 

            HttpResponseMessage response = client.GetAsync("http://localhost/").Result;

            if (response.IsSuccessStatusCode)
            {
                string str =  response.Content.ReadAsStringAsync().Result;

                List<Customer> customer = JsonConvert.DeserializeObject<List<Customer>>(str);

                
            }
            else
            {
                throw new Exception("Internal server error!!");
            }
        }

    }
}
