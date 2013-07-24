using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using OpenMagic.DataAnnotations;

namespace HarvestMagic.Core
{
    public abstract class BaseHarvestApi
    {
        private HarvestAccount _Account;

        public BaseHarvestApi(HarvestAccount account)
        {
            this.Account = account;
        }

        public HarvestAccount Account
        {
            get { return _Account; }
            set
            {
                value.Validate();
                value.Freeze();

                _Account = value;
            }
        }

        protected T Deserialize<T>(string pathAndQueryString)
        {
            var json = GetJsonString(pathAndQueryString);
            var settings = new JsonSerializerSettings() { ContractResolver = new PascalCasePropertyNamesContractResolver() };
            var result = JsonConvert.DeserializeObject<T>(json, settings);

            return result;
        }

        private string GetJsonString(string pathAndQueryString)
        {
            // todo: use async.

            var request = NewWebRequest(pathAndQueryString);

            using (var response = request.GetResponse())
            {
                if (!request.HaveResponse)
                {
                    throw new WebException("Request does not get a response.");
                }

                if (response == null)
                {
                    throw new WebException("Request does not get a response.");
                }

                using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        private Uri FullUri(string pathAndQueryString)
        {
            var uri = Account.Uri;

            if (uri.EndsWith("/"))
            {
                uri = uri.Substring(0, uri.Length - 1);
            }

            if (!pathAndQueryString.StartsWith("/"))
            {
                pathAndQueryString = "/" + pathAndQueryString;
            }

            return new Uri(uri + pathAndQueryString);
        }

        private HttpWebRequest NewWebRequest(string pathAndQueryString)
        {
            var uri = FullUri(pathAndQueryString);
            var request = WebRequest.Create(uri) as HttpWebRequest;

            // todo: https://github.com/harvesthq/harvest_api_samples/blob/master/harvest_api_sample.cs
            // does the following 2 lines. Waiting to see is actually required.
            //request.MaximumAutomaticRedirections = 1;
            //request.AllowAutoRedirect = true;

            // https://github.com/harvesthq/harvest_api_samples/blob/master/harvest_api_sample.cs
            // It's important that both the Accept and ContentType headers are
            // set in order for this to be interpreted as an API request.
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.UserAgent = "HarvestMagic";
            request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(Account.UserName + ":" + Account.Password)));

            return request;
        }
    }
}