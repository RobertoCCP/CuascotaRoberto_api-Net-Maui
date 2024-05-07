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

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
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

        public static T Read_ById(string url, int id)
        {
            using (HttpClient client = new HttpClient())
            {
                url = url + "/" + id;
                var response = client.GetStringAsync(url);
                response.Wait();

                var json = response.Result;
                var result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }

        public static void Update(string url, int id, T data)
        {
            using (HttpClient client = new HttpClient())
            {
                url = url + "/" + id;
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(
                        System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json")
                    );

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                var request = new HttpRequestMessage(HttpMethod.Put, url);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.SendAsync(request);
                response.Wait();

                json = response.Result.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<T>(json);
            }
        }

        public static void Delete(string url, int id)
        {
            using (HttpClient client = new HttpClient())
            {
                url = url + "/" + id;
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(
                        System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json")
                    );
                var response = client.DeleteAsync(url);
                response.Wait();
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
