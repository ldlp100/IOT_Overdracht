using IoTEx.WaternetIoT.DAL;
using IoTEx.WaternetIoT.Model.DTOs.API;
using IoTEx.Waternet.Parser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;
using IoTEx.WaternetIoT.Model.PortalModels;
using IoTEx.WaternetIoT.Model.ViewModels;
using IoTEx.WaternetIoT.Model.DTOs;
using IoTEx.Waternet.FnConnector.PIMS.Models;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Azure.Cosmos.Serialization.HybridRow;
using Microsoft.Azure.Cosmos.Linq;

namespace IoTEx.Waternet.FnConnector
{
    public class FnPIMS
    {
        [Function("SendInfoToPIM")]
        public static async Task<APIResultDTO<string>> SendInfoToPIM(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {

            APIResultDTO<string> result = new APIResultDTO<string>();

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            try
            {
                DeviceMessageDTO msgIoT = JsonConvert.DeserializeObject<DeviceMessageDTO>(requestBody);
                return await InternSendInfoToPIM(msgIoT,log);
            }
            catch (Exception ex)
            {
                log.LogError($"Unexpected Error");
                result.Error = $"Unexpected Error";
                return result;
            }

        }

        public static async Task<APIResultDTO<string>> InternSendInfoToPIM(DeviceMessageDTO msgIoT, ILogger log)
        {

            APIResultDTO<string> result = new APIResultDTO<string>();

            try
            {
                if (msgIoT != null)
                {
                    MessagePIMSModel msgPIMS = ConvertIoTMessageToPIM(msgIoT, log);
                    if (msgPIMS.timeSeries.Count > 0)
                    {
                        APIResultDTO<string> resultSent = await SendToPIM(msgPIMS, log);
                        if (resultSent.IsOk)
                        {
                            log.LogInformation($"IoT Message with Id:'{msgIoT.id}' Sent to PIMS");
                            result.IsOk = true;
                            result.Value = $"IoT Message with Id:'{msgIoT.id}' Sent to PIMS";
                            return result;
                        }

                        log.LogError($"IoT Message with Id:'{msgIoT.id}' NOT to PIMS");
                        result.Error = $"IoT Message with Id:'{msgIoT.id}' NOT to PIMS";
                        return result;

                    }
                    log.LogError($"No Process Code found in Message Id:'{msgIoT.id}'");
                    result.Error = $"No Process Code found in Message Id:'{msgIoT.id}'";
                    return result;

                }
                else
                {
                    log.LogError($"IoT Message cannot be serialized");
                    result.Error = $"IoT Message cannot be serialized";
                    return result;
                }
            }
            catch (Exception ex)
            {
                log.LogError($"Unexpected Error");
                result.Error = $"Unexpected Error";
                return result;
            }

        }

        private static MessagePIMSModel ConvertIoTMessageToPIM(DeviceMessageDTO message, ILogger log)
        {
            MessagePIMSModel msgPIMS = new MessagePIMSModel();
            msgPIMS.version = "1.23";
            msgPIMS.timeZone = "0.0";
            msgPIMS.timeSeries = new System.Collections.Generic.List<TimeSeriesPIMSModel>();

            foreach (DeviceMessageEventDTO evt in message.events)
            {
                if (evt.pc != null)
                {
                    TimeSeriesPIMSModel timeseries = new TimeSeriesPIMSModel();
                    timeseries.header = new HeaderPIMSModel() { locationId = evt.pc, parameterId = "actual", type = "instantaneous" };
                    timeseries.events = new System.Collections.Generic.List<EventPIMSModel>();
                    EventPIMSModel evtPIMS = new EventPIMSModel() { date = evt.received?.ToString("yyyy-MM-dd"), time = evt.received?.ToString("HH:mm:ss"), flag = "0", value = evt.pcValue };
                    timeseries.events.Add(evtPIMS);
                    msgPIMS.timeSeries.Add(timeseries);
                }
            }
            return msgPIMS;
        }
        private static async Task<APIResultDTO<string>> SendToPIM(MessagePIMSModel msgPIMS, ILogger log)
        {
            APIResultDTO<string> result = new APIResultDTO<string>();

            HttpClient client = new HttpClient();
            string url = Environment.GetEnvironmentVariable("URI_PIMS");
            if (string.IsNullOrEmpty(url))
            {
                log.LogError("URI_PIMS variable not set in the setting file.");
                result.Error = "URI_PIMS variable not set in the setting file.";
                return result;
            }

            try
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);

                string data = JsonConvert.SerializeObject(msgPIMS);
                HttpContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string payLoad = await response.Content.ReadAsStringAsync();
                    dynamic mdata = JsonConvert.DeserializeObject(payLoad);
                    result.IsOk = true;
                    return result;
                }
                else
                {
                    result.Error = "Response code (" + response.StatusCode.ToString() + ")";
                    return result;
                }

            }
            catch (Exception ex)
            {
                log.LogError("UNEXPECTED_ERROR in method 'SendToPIMS'" + ex.Message);
                result.Error = "UNEXPECTED_ERROR in method 'SendToPIMS'" + ex.Message;
                return result;
            }


        }
    }
}
