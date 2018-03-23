using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Well.Common
{
    public class HttpHelper
    {

        /// <summary>
        /// 发起HTTP-Post请求
        /// </summary>
        /// <param name="client">httpClient对象</param>
        /// <param name="url">请求接口url</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="timeOutInMillisecond">超时时间</param>
        /// <returns></returns>
        public static String doPostAsync(String url, Dictionary<String, String> parameters, int timeOutInMillisecond)
        {
            HttpClient client = new HttpClient();
            HttpContent content = new FormUrlEncodedContent(parameters);
            Task<HttpResponseMessage> task = client.PostAsync(url, content);
            if (task.Wait(timeOutInMillisecond))
            {
                HttpResponseMessage response = task.Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Task<string> result = response.Content.ReadAsStringAsync();
                    result.Wait();
                    return result.Result;
                }
            }
            return null;
        }

        /// <summary>
        /// 发起HTTP-Get请求
        /// </summary>
        /// <param name="client">httpClient对象</param>
        /// <param name="url">请求接口url</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="timeOutInMillisecond">超时时间</param>
        /// <returns></returns>
        public static String doGetAsync(String url, Dictionary<String, String> parameters, int timeOutInMillisecond)
        {
            HttpClient client = new HttpClient();
            StringBuilder sb = new StringBuilder();
            foreach (var item in parameters)
            {
                sb.AppendFormat("{0}={1}&", item.Key, item.Value);
            }
            string strParams = sb.ToString();
            if (strParams.EndsWith("&"))
            {
                strParams = strParams.Remove(0, strParams.Length - 1);
            }

            if (url.EndsWith("?"))
            {
                url = url + strParams;
            }
            else
            {
                url = url + "?" + strParams;
            }

            Task<HttpResponseMessage> task = client.GetAsync(url);
            if (task.Wait(timeOutInMillisecond))
            {
                HttpResponseMessage response = task.Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Task<string> result = response.Content.ReadAsStringAsync();
                    result.Wait();
                    return result.Result;
                }
            }
            return null;
        }

        /// <summary>
        /// 发起HTTP-Get请求
        /// </summary>
        /// <param name="client">httpClient对象</param>
        /// <param name="url">请求接口url</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="timeOutInMillisecond">超时时间</param>
        /// <returns></returns>
        public static String doGetAsync(String url, int timeOutInMillisecond)
        {
            HttpClient client = new HttpClient();
            StringBuilder sb = new StringBuilder();
            Task<HttpResponseMessage> task = client.GetAsync(url);
            if (task.Wait(timeOutInMillisecond))
            {
                HttpResponseMessage response = task.Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Task<string> result = response.Content.ReadAsStringAsync();
                    result.Wait();
                    return result.Result;
                }
            }
            return null;
        }


        /// <summary>
        /// 发起HTTP-Post请求
        /// </summary>
        /// <param name="client">httpClient对象</param>
        /// <param name="url">请求接口url</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="timeOutInMillisecond">超时时间</param>
        /// <returns></returns>
        public static String doPostAsync(HttpClient client, String url, Dictionary<String, String> parameters, int timeOutInMillisecond)
        {
            HttpContent content = new FormUrlEncodedContent(parameters);
            Task<HttpResponseMessage> task = client.PostAsync(url, content);
            if (task.Wait(timeOutInMillisecond))
            {
                HttpResponseMessage response = task.Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Task<string> result = response.Content.ReadAsStringAsync();
                    result.Wait();
                    return result.Result;
                }
            }
            return null;
        }

        /// <summary>
        /// 发起HTTP-Get请求
        /// </summary>
        /// <param name="client">httpClient对象</param>
        /// <param name="url">请求接口url</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="timeOutInMillisecond">超时时间</param>
        /// <returns></returns>
        public static String doGetAsync(HttpClient client, String url, Dictionary<String, String> parameters, int timeOutInMillisecond)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in parameters)
            {
                sb.AppendFormat("{0}={1}&", item.Key, item.Value);
            }
            string strParams = sb.ToString();
            if (strParams.EndsWith("&"))
            {
                strParams = strParams.Remove(0, strParams.Length - 1);
            }

            if (url.EndsWith("?"))
            {
                url = url + strParams;
            }
            else
            {
                url = url + "?" + strParams;
            }

            Task<HttpResponseMessage> task = client.GetAsync(url);
            if (task.Wait(timeOutInMillisecond))
            {
                HttpResponseMessage response = task.Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Task<string> result = response.Content.ReadAsStringAsync();
                    result.Wait();
                    return result.Result;
                }
            }
            return null;
        }

        /// <summary>
        /// 发起HTTP-Get请求
        /// </summary>
        /// <param name="client">httpClient对象</param>
        /// <param name="url">请求接口url</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="timeOutInMillisecond">超时时间</param>
        /// <returns></returns>
        public static String doGetAsync(HttpClient client, String url, int timeOutInMillisecond)
        {
            StringBuilder sb = new StringBuilder();
            Task<HttpResponseMessage> task = client.GetAsync(url);
            if (task.Wait(timeOutInMillisecond))
            {
                HttpResponseMessage response = task.Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Task<string> result = response.Content.ReadAsStringAsync();
                    result.Wait();
                    return result.Result;
                }
            }
            return null;
        }
    }
}
