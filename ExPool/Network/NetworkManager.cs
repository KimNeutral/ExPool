using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ExPool.Network
{
    public partial class NetworkManager
    {
        private const string SERVER_URL = "";
        private const int TIME_OUT = 30000;

        /// <summary>
        /// RestClient를 만듭니다.
        /// </summary>
        /// <returns>RestClient</returns>
        public static RestClient CreateClient()
        {
            var restClient = new RestClient(SERVER_URL) {Timeout = TIME_OUT};
            return restClient;
        }

        /// <summary>
        /// RestRequest를 생성합니다.
        /// </summary>
        /// <param name="resource">리소스 url</param>
        /// <param name="method">요청 메서드</param>
        /// <param name="parameterJson">기본 null. POST,PUT,DELETE때 Body</param>
        /// <param name="urlSegments">기본 null. url파라미터</param>
        /// <param name="headers">기본 null. 헤더</param>
        /// <returns>RestRequest</returns>
        public static RestRequest CreateRequest(string resource, Method method, string parameterJson, UrlSegment[] urlSegments = null, Header[] headers = null)
        {
            var restRequest = new RestRequest(resource, method) { Timeout = TIME_OUT };
            restRequest = AddToRequest(restRequest, parameterJson, urlSegments, headers);

            return restRequest;
        }

        /// <summary>
        /// token, json,urlsegments, headers를 restrequest에 손쉽게 넣어줍니다.
        /// </summary>
        /// <param name="restRequest">목표 RestRequest객체</param>
        /// <param name="json">JSON</param>
        /// <param name="urlSegments">UrlSegement</param>
        /// <param name="headers">Header</param>
        /// <returns></returns>
        public static RestRequest AddToRequest(RestRequest restRequest,string json = null, UrlSegment[] urlSegments = null, Header[] headers = null)
        {
            if (urlSegments != null)
            {
                foreach (var urlSegment in urlSegments)
                {
                    restRequest.AddUrlSegment(urlSegment.Name, urlSegment.Value);
                }
            }

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    restRequest.AddHeader(header.Name, header.Value);
                }
            }

            if (!string.IsNullOrEmpty(json))
            {
                restRequest.AddHeader("Content-Type", "application/json");
                restRequest.AddParameter("application/json", json, ParameterType.RequestBody);
            }

            return restRequest;
        }

        /// <summary>
        /// snake_case로 이뤄진 Json을 PascalCase로 역직렬화.
        /// </summary>
        /// <typeparam name="T">반환 형태</typeparam>
        /// <param name="json">목표 Json</param>
        /// <returns>역직렬화된 Json</returns>
        public static T DeserializeSnakeCase<T>(string json)
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };

            try
            {
                var resp = JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
                {
                    ContractResolver = contractResolver,
                    Formatting = Formatting.Indented
                });
                return resp;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return default(T);
        }

        /// <summary>
        /// 손쉽게 Response를 얻어옵니다.
        /// </summary>
        /// <typeparam name="T">TResponse의 반환 형태</typeparam>
        /// <param name="resource">리소스 url</param>
        /// <param name="method">요청 메서드</param>
        /// <param name="parameterJson">기본 null. POST,PUT,DELETE때 Body</param>
        /// <param name="token">기본 null. 토큰</param>
        /// <param name="urlSegments">기본 null. url파라미터</param>
        /// <param name="headers">기본 null. 헤더</param>
        /// <returns>통신후 TResponse를 반환합니다.</returns>
        public async Task<TResponse<T>> GetResponse<T>(string resource, Method method, string parameterJson = null, UrlSegment[] urlSegments = null, Header[] headers = null)
        {
            var client = CreateClient();
            var restRequest = CreateRequest(resource, method, parameterJson, urlSegments, headers);
            var response = await client.ExecuteTaskAsync(restRequest);

            var resp = DeserializeSnakeCase<TResponse<T>>(response.Content);
            return resp;
        }

        public class UrlSegment
        {
            public string Name { get; set; }
            public object Value { get; set; }

            public UrlSegment(string name, object value)
            {
                Name = name;
                Value = value;
            }
        }

        public class Header
        {
            public string Name { get; set; }
            public string Value { get; set; }

            public Header(string name, string value)
            {
                Name = name;
                Value = value;
            }
        }
    }
}
