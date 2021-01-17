using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace ExcelQuiz.Models
{
    public class WebApiProxy
    {
        HttpClient client = new HttpClient();
        string baseUrl = ConfigurationManager.AppSettings["baseUrl"];
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