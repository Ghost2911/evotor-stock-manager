using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
namespace EvotorStockManager
{
    class EvotorAPI
    {
        const string ADDRESS = "https://api.evotor.ru/";
        const string STORE_ID = "";
        const string TOKEN = "";

        static public RootItemsJSON GetProducts(string cursor)
        {
            var path = ADDRESS+"stores/"+STORE_ID+"/products/?cursor=" + cursor;
            var request = WebRequest.Create(path);
            request.Headers["Authorization"] = TOKEN;
            request.Method = "GET";
            request.ContentType = "application/vnd.evotor.v2+json";

            string json = String.Empty;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                json += reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<RootItemsJSON>(json);
        }

        static public RootItemsJSON GetGroups(string cursor)
        {
            var path = ADDRESS + "stores/" + STORE_ID + "/product-groups/?cursor=" + cursor;
            var request = WebRequest.Create(path);
            request.Headers["Authorization"] = TOKEN;
            request.Method = "GET";
            request.ContentType = "application/vnd.evotor.v2+json";

            string json = String.Empty;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                json += reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<RootItemsJSON>(json);
        }
        static public string CreateGroup(string groupName)
        {
            var path = ADDRESS + "stores/" + STORE_ID + "/product-groups";
            var request = WebRequest.Create(path);
            request.Headers["Authorization"] = TOKEN;
            request.Method = "POST";
            request.ContentType = "application/vnd.evotor.v2+json";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string js = "{\"name\":\"" + groupName + "\"" + "}";
                streamWriter.Write(js);
            }

            string json = String.Empty;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                json += reader.ReadToEnd();
            }

            StatusTask status = JsonConvert.DeserializeObject<StatusTask>(json);

            return status.id;
        }

        static public string CreateProduct(EvotorProductV2 product)
        {
            var path = ADDRESS + "stores/" + STORE_ID + "/products";
            var request = WebRequest.Create(path);
            request.Headers["Authorization"] = TOKEN;
            request.Method = "POST";
            request.ContentType = "application/vnd.evotor.v2+json";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string js = "{\"code\":\"" + product.code + "\",\"name\":\"" + product.name + "\",\"allow_to_sell\":true,"+ "\"type\":\"NORMAL\",\"quantity\":" + product.quantity + ",\"measure_name\":\"шт\",\"tax\":\"NO_VAT\",\"price\":" + product.price +
                            ",\"cost_price\":" + product.cost_price + ",\"description\":\"" + product.description + "\"" + ",\"article_number\":\"" + product.article_number + "\""  /*",\"barCodes\":[\"" + row["CLASSIFICATION_CODE"] + "\"]"*/ + "}";
                streamWriter.Write(js);
            }

            string json = String.Empty;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                json += reader.ReadToEnd();
            }

            StatusTask status = JsonConvert.DeserializeObject<StatusTask>(json);

            return status.id;
        }

        static public int DeleteProduct(string productId)
        {
            var path = ADDRESS + "stores/" + STORE_ID + "/products/" + productId;
            var request = WebRequest.Create(path);
            request.Headers["Authorization"] = TOKEN;
            request.Method = "DELETE";
            request.ContentType = "application/vnd.evotor.v2+json";

            string json = String.Empty;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                json += reader.ReadToEnd();
            }

            return 1;
        }

        static public int UpdateProduct(EvotorProductV2 product)
        {
            var path = ADDRESS + "stores/" + STORE_ID + "/products/"+product.id;
            var request = WebRequest.Create(path);
            request.Headers["Authorization"] = TOKEN;
            request.Method = "PUT";
            request.ContentType = "application/vnd.evotor.v2+json";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string js = "{\"code\":\"" + product.code + "\",\"name\":\"" + product.name +"\",\"id\":\"" + product.id + "\",\"allow_to_sell\":true," + "\"type\":\"NORMAL\",\"quantity\":" + product.quantity + ",\"measure_name\":\"шт\",\"tax\":\"NO_VAT\",\"price\":" + product.price +
                            ",\"cost_price\":" + product.cost_price + ",\"description\":\"" + product.description + "\"" + ",\"article_number\":\"" + product.article_number + "\""  /*",\"barCodes\":[\"" + row["CLASSIFICATION_CODE"] + "\"]"*/ + "}";
                streamWriter.Write(js);
            }

            string json = String.Empty;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                json += reader.ReadToEnd();
            }

            return 1;
        }

        static public List<EvotorProduct> GetProductsOLD()
        {
            var path = ADDRESS+"api/v1/inventories/stores/"+STORE_ID+"/products";
            var request = WebRequest.Create(path);
            request.Headers["Authorization"] = TOKEN;
            request.Method = "GET";
            request.ContentType = "application/vnd.evotor.v2+json";

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;            
            
            string json = String.Empty;
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                json += reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<EvotorProduct>>(json);
        }


        static public int Add(DataTable dt)
        {
        
            var path = "https://api.evotor.ru/api/v1/inventories/stores/"+STORE_ID+"/products";
            var request = WebRequest.Create(path);
            request.Headers["Authorization"] = TOKEN;
            request.Method = "POST";
            request.ContentType = "application/json";
            string js = "[";
            
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                foreach (DataRow row in dt.Rows)
                {
                    string _name = row[4].ToString().Replace("\"", "'");
                    string _desc = row["DESCRIPTION"].ToString().Replace("\"", "'");
                    string _article = row["ARTICLE_NUMBER"].ToString().Replace("\"", "'");
                    if (Convert.ToBoolean(row[7]))
                    {
                        js += "{\"uuid\":\"" + row[1] + "\",\"name\":\"" + _name + "\",\"group\":true"+((row["PARENT_UUID"].ToString().Length==0)?"":",\"parentUuid\":\""+row["PARENT_UUID"]+"\"")+"}";
                    }
                    else
                    {
                        js += "{\"uuid\":\"" + row[1] + "\",\"name\":\"" + _name + "\",\"group\":false,\"parentUuid\":\""+row["PARENT_UUID"]+"\",\"type\":\"NORMAL\",\"quantity\":" + row["QUANTITY"] + ",\"measureName\":\"шт\",\"tax\":\"NO_VAT\",\"price\":" + row["PRICE_OUT"] +
                             ",\"costPrice\":" + row["COST_PRICE"] + ",\"description\":\"" + _desc + "\"" + ",\"articleNumber\":\"" + _article + "\"" + ",\"allowToSell\":true" + ",\"code\":\""+row["CODE"] + "\"" /*",\"barCodes\":[\"" + row["CLASSIFICATION_CODE"] + "\"]"*/ + "}";
                    }
                    js += ",";
                }
                js = js.Remove(js.Length - 1)+"]";
                
                streamWriter.Write(js);
            }
            
            string json = String.Empty;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                json += reader.ReadToEnd();
            }
            Console.WriteLine(json);
            return 0;
        }


        static public void DeleteAll()
        {
            var path = ADDRESS + "api/v1/inventories/stores/" + STORE_ID + "/products/delete";
            var request = WebRequest.Create(path);
            request.Headers["Authorization"] = TOKEN;
            request.Method = "POST";
            request.ContentType = "application/json";
            /*
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string js = "{\"uuid\":\"c4b1c26b-cec0-478b-8cb2-772ce6995483\"}";
                streamWriter.Write(js);
            }
            */
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        }
        
    }
}
