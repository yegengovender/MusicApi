using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace MusicApi.Controllers
{
    public class WebApiHelper
    {
        private readonly NozipWebClient _client = new NozipWebClient();
        private readonly JavaScriptSerializer _js = new JavaScriptSerializer();

        public string GetJsonResult(string url)
        {
            var stationsString = _client.DownloadString(url);
            //var response = new HttpWebRequest() Request.CreateResponse(HttpStatusCode.OK);
            //response.Content = new StringContent(genres, Encoding.UTF8, "application/json");


            return stationsString;
        }
        public object GetApiResult(string url)
        {
            var stationsString = _client.DownloadString(url);
            var stations = _js.Deserialize<object>(stationsString);

            return stations;
        }
    }

    class NozipWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address) as HttpWebRequest;
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate,sdch");
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/28.0.1500.95 Safari/537.36";
            return request;
        }
    }
}