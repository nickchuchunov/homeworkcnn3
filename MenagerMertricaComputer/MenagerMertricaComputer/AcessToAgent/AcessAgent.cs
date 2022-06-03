using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using System.Data.SQLite;
using Microsoft.Data.Sqlite;

namespace MenagerMertricaComputer
{
    public class AcessAgent1 : InterfaceMeneger
    {


        public readonly HttpClient _httpClient;
        public readonly ILogger _logger;

       public AcessAgent1(HttpClient httpClient, ILogger logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }





        public IList<CpuMenegerMetrica>  GetAllCpuMetrics(GetAllCpuMetricsApiRequest request)
         {
            var fromParameter = request.StartTimr;
            var toParameter = request.EndTime;

            var httpRequest = new HttpRequestMessage(HttpMethod.Get, request.URL+ "/{fromParameter="+ fromParameter+ "}/to/{toParameter="+ toParameter+ "}"); // создание http запроса к методу агента

            try
            {
                var httpclient = new HttpClient();

                var response = httpclient.SendAsync((HttpRequestMessage) httpRequest).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<IList<CpuMenegerMetrica>>(responseStream).Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
           
            }


            return null;

        }
 




            

        
        public   IList<HddMenegerMetrica>  GetAllHddMetrics(GetAllHddMetricsApiRequest request)
        {

            var fromParameter = request.StartTimr;
            var toParameter = request.EndTime;
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, request.URL + "/{fromParameter=" + fromParameter + "}/to/{toParameter=" + toParameter + "}"); // создание http запроса к методу агента

            try
            {
                var httpclient = new HttpClient();

                var response = httpclient.SendAsync((HttpRequestMessage)httpRequest).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<IList<HddMenegerMetrica>>(responseStream).Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

            }


            return null;






        }

      public IList<DotNetMetricsMenegerMetrica>  GetAllNetMetrics(GetAllDotNetMetricsApiRequest request)
        {
            var fromParameter = request.StartTimr;
            var toParameter = request.EndTime;
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, request.URL + "/{fromParameter=" + fromParameter + "}/to/{toParameter=" + toParameter + "}"); // создание http запроса к методу агента

            try
            {
                var httpclient = new HttpClient();

                var response = httpclient.SendAsync((HttpRequestMessage)httpRequest).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<IList<DotNetMetricsMenegerMetrica>>(responseStream).Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

            }


            return null;

        }

      public IList<NetworcMenegerMetrica>  GetAllNetworcMetrics(GetAllNetvorcMetricsApiRequest request)
        {
            var fromParameter = request.StartTimr;
            var toParameter = request.EndTime;
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, request.URL + "/{fromParameter=" + fromParameter + "}/to/{toParameter=" + toParameter + "}"); // создание http запроса к методу агента

            try
            {
                var httpclient = new HttpClient();

                var response = httpclient.SendAsync((HttpRequestMessage)httpRequest).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<IList<NetworcMenegerMetrica>>(responseStream).Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

            }


            return null;
        }

      public  IList<RamMenegertMetrica>  GetAllRamMetrics(GetAllRamMetricsApiRequest request)
        {
            var fromParameter = request.StartTimr;
            var toParameter = request.EndTime;
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, request.URL + "/{fromParameter=" + fromParameter + "}/to/{toParameter=" + toParameter + "}"); // создание http запроса к методу агента

            try
            {
                var httpclient = new HttpClient();

                var response = httpclient.SendAsync((HttpRequestMessage)httpRequest).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<IList<RamMenegertMetrica>>(responseStream).Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

            }


            return null;
        }
    }
}
