// <copyright file="APIManager.cs" company="Eurofins">
// Copyright (c) Euro. All rights reserved.
// </copyright>

namespace Euro.Core.Automation.Utilities.API
{
    using System.Configuration;
    using Newtonsoft.Json.Linq;
    using RestSharp;

    /// <summary>
    /// Class incharge of rest calls to API.
    /// </summary>
    public class APIManager
    {
        private const string ContentType = "application/json; charset=utf-8";
        private const string ID = "id";

        /// <summary>
        /// Gets a Rest client connection.
        /// </summary>
        /// <param name="endpoint">the endpoint.</param>
        /// <returns>the RestClient</returns>
        public static RestClient GetRestClient(string endpoint)
        {
            return new RestClient(endpoint);
        }

        /// <summary>
        /// Helps to perform post request to api.
        /// </summary>
        /// <param name="endpoint">the endpoint.</param>
        /// <param name="resource">the resource name e.g '/v2/RETV3/BR_US/senders'</param>
        /// <param name="body">the body request</param>
        /// <param name="authorization"></param>
        /// <returns>The response of the request</returns>
        public static IRestResponse PostRequest(string endpoint, string resource, object body,string authorization=null)
        {
            RestRequest request = new RestRequest(resource, Method.POST);
            request.AddParameter(ContentType, body, ParameterType.RequestBody);
            request.AddHeader("Authorization", authorization);
            return GetRestClient(endpoint).Execute(request);
        }

        /// <summary>
        /// Helps to perform get request to api.
        /// </summary>
        /// <param name="endpoint">the endpoint.</param>
        /// <param name="resource">the resource name e.g '/v2/RETV3/BR_US/recipients/{id}'</param>
        /// <param name="id">the id of the object to be retrieved</param>
        /// <returns>The response of the request</returns>
        public static IRestResponse GetRequestById(string endpoint, string resource, string id)
        {
            RestRequest request = new RestRequest(resource, Method.GET);
            request.AddUrlSegment(ID, id);
            return GetRestClient(endpoint).Execute(request);
        }

        /// <summary>
        /// Helps to perform get request to api.
        /// </summary>
        /// <param name="endpoint">the endpoint.</param>
        /// <param name="resource">the resource name e.g '/v2/RETV3/BR_US/recipients'</param>
        /// <returns>The response of the request</returns>
        public static IRestResponse GetRequest(string endpoint, string resource)
        {
            RestRequest request = new RestRequest(resource, Method.GET);
            return GetRestClient(endpoint).Execute(request);
        }
    }
}
