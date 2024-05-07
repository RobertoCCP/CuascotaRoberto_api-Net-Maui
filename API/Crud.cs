using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace API
{
    public class Crud<T>
    {
        public static T Create(string url, T data)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(
                        System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json")
                    );

                var json = JsonConvert.SerializeObject(data);
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.SendAsync(request);
                response.Wait();

                json = response.Result.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }

        public static T[] Read(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetStringAsync(url);
                response.Wait();

                var json = response.Result;
                var result = JsonConvert.DeserializeObject<T[]>(json);
                return result;
            }
        }

        public static (T, bool) Read_ById(string url, int id)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = client.GetStringAsync(url + "/" + id).Result;
                    var result = JsonConvert.DeserializeObject<T>(response);
                    return (result, true);
                }
                catch
                {
                    return (default(T), false);
                }
            }
        }

        public static bool Update(string url, int id, T data)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var json = JsonConvert.SerializeObject(data);
                    var request = new HttpRequestMessage(HttpMethod.Put, url + "/" + id)
                    {
                        Content = new StringContent(json, Encoding.UTF8, "application/json")
                    };
                    var response = client.SendAsync(request).Result;
                    return response.IsSuccessStatusCode;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool Delete(string url, int id)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = client.DeleteAsync(url + "/" + id).Result;
                    return response.IsSuccessStatusCode;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static List<T> LeerCredenciales(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetStringAsync(url);
                response.Wait();

                var json = response.Result;

                // Deserializar el JSON como un array de credenciales
                var credenciales = JsonConvert.DeserializeObject<List<T>>(json);
                return credenciales;
            }
        }
    }
}
