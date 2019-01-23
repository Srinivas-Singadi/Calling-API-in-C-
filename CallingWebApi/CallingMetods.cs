using CallingWebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using  Newtonsoft.Json;
using System.Net.Http.Formatting;
using System.Net;
using System.IO;

namespace CallingWebApi
{
     public  class CallingMetods
    {

        public void GetUsers()
        {
            string URL = string.Format("http://localhost:52522/api/values");


            var credentilas = new NetworkCredential();
            var httpHelper = new HttpClientHandler { Credentials = credentilas };
            HttpClient client = new HttpClient(httpHelper);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           // client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");



            //Get

            HttpResponseMessage response = client.GetAsync(URL).Result;
            {
                if (response.IsSuccessStatusCode)
                {
                   string str = response.Content.ReadAsStringAsync().Result;

                    //its creating model class to for our object
                     List<Customer> ObjList = JsonConvert.DeserializeObject<List<Customer>>(str);

                    //this is for without creating any models , runtime object
                    dynamic Object2 = JsonConvert.DeserializeObject(str,typeof(object));

                    foreach (KeyValuePair<string,dynamic> user in Object2["users"])
                    {
                        string str1 = Convert .ToString(user.Key + ": " + user.Value["userName"]);
                    }

                    //var Object1 = Object2;
                    //object[] objectJsonStr = Object1;

                    //List<object[]> obj = new List<object[]>();
                    //obj.Add(objectJsonStr);

                    //for (int i = 0; i <= objectJsonStr.Length-1; i++)
                    //{
                    //    string name =Convert.ToString(objectJsonStr[i]["CustomName"]);
                    //}

                   // return Object1;

                }
                else
                {

                    throw new Exception("Internal Server Error!!");

                }
            }
        }







        public  async Task<Customer> GetProductAsync(string path)
        {
            var cresdentilas = new NetworkCredential("user", "passworkd");
            var handler = new HttpClientHandler {Credentials = cresdentilas };
            var client = new HttpClient(handler);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("http://localhost:52522/");
            Customer product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                Customer result = await response.Content.ReadAsAsync<Customer>();
                
                
            }
            return product;
        }

       


        public void Page_Load()
        {
            string URL = string.Format("https://jsonplaceholder.typicode.com/posts");

            WebRequest webRequestObject = WebRequest.Create(URL);
            //if you have any credetials


            //GET Method 
            webRequestObject.Method = "GET";
            HttpWebResponse responseObject = null;
            responseObject =(HttpWebResponse)webRequestObject.GetResponse();

            string str = null;

            using (Stream stream = responseObject.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                str = sr.ReadToEnd();
                sr.Close();
            }
        }
          
        }


    }


