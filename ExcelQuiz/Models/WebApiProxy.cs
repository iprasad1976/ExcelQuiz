using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Net.Http.Formatting;
using Newtonsoft.Json;

namespace ExcelQuiz.Models
{
    public class WebApiProxy
    {
       
        public static async Task<RP> WebAPIPostCall<RE, RP>(string actionName, RE obj)
        {
            return await WebAPIPostCall<RE, RP>(actionName, obj, string.Empty, string.Empty);
        }

        public static async Task<RP> WebAPIPostCall<RE, RP>(string actionName, RE obj, string userId)
        {
            return await WebAPIPostCall<RE, RP>(actionName, obj, userId, string.Empty);
        }

        public static async Task<RP> WebAPIPostCall<RE,RP>(string actionName, RE obj, string userId, string token)
        { 
            string baseUrl = ConfigurationManager.AppSettings["baseURI"];
            Uri uri = new Uri(baseUrl + actionName);
            HttpClient client = new HttpClient();
            MediaTypeFormatter jsonFormatter = new JsonMediaTypeFormatter();
            HttpContent content = new ObjectContent<RE>(obj, jsonFormatter);
            
            if(!string.IsNullOrEmpty(userId))
                client.DefaultRequestHeaders.Add("UserId", userId);
            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Add("Token", token);
         
            var response = client.PostAsync(uri, content).GetAwaiter().GetResult();

            string apiResponse = await response.Content.ReadAsStringAsync();
            RP responseDTO = JsonConvert.DeserializeObject<RP>(apiResponse);

            return responseDTO;
        }


        public static async Task<RP> WebAPIGetCall<RP>(string actionName)
        {
            return await WebAPIGetCall<RP>(actionName, string.Empty, string.Empty);
        }

        public static async Task<RP> WebAPIGetCall<RP>(string actionName, string userId)
        {
            return await WebAPIGetCall<RP>(actionName, userId, string.Empty);
        }

        public static async Task<RP> WebAPIGetCall<RP>(string actionName, string userId, string token)
        {
            string baseUrl = ConfigurationManager.AppSettings["baseURI"];
            Uri uri = new Uri(baseUrl + actionName);
            HttpClient client = new HttpClient();
           
            if (!string.IsNullOrEmpty(userId))
                client.DefaultRequestHeaders.Add("UserId", userId);
            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Add("Token", token);

            var response = client.GetAsync(uri).GetAwaiter().GetResult();

            string apiResponse = await response.Content.ReadAsStringAsync();
            RP responseDTO = JsonConvert.DeserializeObject<RP>(apiResponse);

            return responseDTO;
        }


        //[HttpGet]
        //public async Task GetCandidateLogins(int requestedPersonEmail)
        //{
        //    //TODO check for token presence and reject if issue

        //    var queryString = Request.QueryString;
        //    var response = await _httpClient.GetAsync(queryString.Value);
        //    var content = await response.Content.ReadAsStringAsync();

        //    Response.StatusCode = (int)response.StatusCode;
        //    Response.ContentType = response.Content.Headers.ContentType.ToString();
        //    Response.ContentLength = response.Content.Headers.ContentLength;

        //    await Response.WriteAsync(content);
        //}

        //[HttpPost]
        //public async Task PostStatement()
        //{
        //    using (var streamContent = new StreamContent(Request.Body))
        //    {
        //        //TODO check for token presence and reject if issue

        //        var response = await _httpClient.PostAsync(string.Empty, streamContent);
        //        var content = await response.Content.ReadAsStringAsync();

        //        Response.StatusCode = (int)response.StatusCode;

        //        Response.ContentType = response.Content.Headers.ContentType?.ToString();
        //        Response.ContentLength = response.Content.Headers.ContentLength;

        //        await Response.WriteAsync(content);
        //    }
        //}
    }
}