using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Threading.Tasks;
using Kusto.Data.Net.Client;
using Kusto.Data;
using Kusto.Data.Common;
using Azure.Identity;
using Kusto.Ingest;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System.Data;
using IoTEx.WaternetIoT.Model.ViewModels;
using IoTEx.WaternetIoT.Model.DTOs;
using System.Text.RegularExpressions;
using Azure.Core;
using static System.Formats.Asn1.AsnWriter;
using Newtonsoft.Json.Linq;

namespace IoTEx.WaternetIoT.DAL
{


    public interface IKustoService
    {
        List<DeviceTelemetryAggregateDTO> GetAggregateTelemetriesForDevice(Guid deviceId, DateTime startDate, DateTime endDate, string window);
        List<DeviceTelemetryDTO> GetTelemetriesForDevice(Guid deviceId);
        DeviceTelemetryDTO GetTelemetryForDevice(Guid deviceId, Guid id);
        List<DeviceMessageViewModel> GetMessagesForDevice(Guid deviceId, int skip, int pageSize, bool isDesc=true);
        DeviceMessageViewModel GetMessageForDevice(Guid deviceId, Guid id);
        bool CreateTableTelemetry();
        bool CreateTableMessage();
        bool CreateTableDevice();
        DeviceDefinitionPublishedDTO GetDevice(Guid deviceId);
        DeviceDefinitionPublishedDTO GetDeviceByNetworkId(string imei);
        DeviceMessageViewModel GetLastMessageForDevice(Guid deviceId);
        Task<bool> InsertDevice(DeviceDefinitionPublishedDTO document);
        Task<bool> InsertTelemetry(DeviceTelemetryDTO telemetry, string targetDB);
        Task<bool> InsertMessage(DeviceMessageViewModel message);
    }

    public class KustoService : IKustoService
    {
        private readonly DefaultAzureCredential _credential;
        private readonly string _token;
        private readonly string _clusterUri;
        private readonly bool _runLocal;
        private readonly string _databaseName = "main_iot";
        private readonly string _clientId;
        private readonly string _userAssignedClientId;
        private readonly string _clientSecret;
        private readonly string _tenantId;
        private readonly string _TableTelemetryName = "RAW_TELEMETRY";
        private readonly string _TableMessageName = "RAW_MESSAGE";
        private readonly string _TableDeviceName = "RAW_DEVICE";
        private KustoConnectionStringBuilder _kustoConnectionStringBuilder;

        public KustoService(string clusterUri, string userAssignedClientId)//, string tenantId, string clientId, string clientSecret)
        {
            _clusterUri = clusterUri;
            _userAssignedClientId = userAssignedClientId;
            _runLocal = false;
            var accessToken = GetAccessTokenAsync().Result;
            _kustoConnectionStringBuilder = new KustoConnectionStringBuilder(_clusterUri)
            .WithAadApplicationTokenAuthentication(accessToken);
            
            
        }
        public KustoService(string clusterUri, string tenantId, string clientId, string clientSecret)
        {
            _clusterUri = clusterUri;
            _tenantId = tenantId;
            _clientId = clientId;
            _clientSecret = clientSecret; 
            _runLocal = true;
            var accessToken = GetAccessTokenAsync().Result;
            _kustoConnectionStringBuilder = new KustoConnectionStringBuilder(_clusterUri)
            .WithAadApplicationTokenAuthentication(accessToken);
            

        }

        public async Task<string> GetAccessTokenAsync()
        {
            AccessToken token = new AccessToken();
            if (_runLocal)
            {
                var confidentialClient = ConfidentialClientApplicationBuilder.Create(_clientId)
                .WithClientSecret(_clientSecret)
                .WithAuthority(new Uri($"https://login.microsoftonline.com/{_tenantId}"))
                .Build();

                var authResult = await confidentialClient.AcquireTokenForClient(
                    new[] { $"{_clusterUri}/.default" }) // Resource scope
                    .ExecuteAsync();
                
                return authResult.AccessToken;
                
            }
            else
            {
                var credential = new ManagedIdentityCredential(_userAssignedClientId);
                token = credential.GetToken(new TokenRequestContext(new[] { "https://westeurope.kusto.windows.net/.default" }));
                return token.Token;
            }
           
        }
        public bool CreateTableTelemetry()
        {
            
            // Create a Kusto client to execute commands
            using (var client = KustoClientFactory.CreateCslAdminProvider(_kustoConnectionStringBuilder))
            {
                try
                {
                    // Define the query to create a table
                    string createTableQuery = $@"
                        .create table {_TableTelemetryName} (
                            Id: guid,
                            MsgId:guid,
                            Received:datetime,                            
                            Name:string,
                            Value:double,
                            Unit:string,
                            IsAlert:bool,                            
                            AssetUID:string,                            
                            NetworkId:string,
                            DeviceId:guid,                                                      
                            DeviceName:string,
                            DevicePosLong:double,
                            DevicePosLat:double,
                            DeviceTypeId:guid,
                            DeviceTypeName:string,
                            DeviceBatchId:guid,
                            DeviceBatchName:string,
                            PC:string,
                            PCValue:string,
                            PCUnit:string,
                            ProjectName:string
                )";

                    // Execute the query to create the table
                    var queryProvider = client.ExecuteControlCommand(_databaseName, createTableQuery);
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                    return false;
                }
                return true;
            }
            return false;
        }
        public bool CreateTableMessage()
        {

            // Create a Kusto client to execute commands
            using (var client = KustoClientFactory.CreateCslAdminProvider(_kustoConnectionStringBuilder))
            {
                try
                {
                    // Define the query to create a table
                    string createTableQuery = $@"
                        .create table {_TableMessageName} (
                            Id: guid,
                            Received:datetime,                            
                            DeviceId:string,                                                      
                            Content:string,
                            IsError:bool
                )";

                    // Execute the query to create the table
                    var queryProvider = client.ExecuteControlCommand(_databaseName, createTableQuery);
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                    return false;
                }
                return true;
            }
            return false;
        }
        public bool CreateTableDevice()
        {

            // Create a Kusto client to execute commands
            using (var client = KustoClientFactory.CreateCslAdminProvider(_kustoConnectionStringBuilder))
            {
                try
                {
                    // Define the query to create a table
                    string createTableQuery = $@"
                        .create table {_TableDeviceName} (
                            DeviceId: string,
                            IsActive:bool,
                            JSON:string,
                            NetworkId:string,
                            Published:datetime    
                )";

                    // Execute the query to create the table
                    var queryProvider = client.ExecuteControlCommand(_databaseName, createTableQuery);
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                    return false;
                }
                return true;
            }
            return false;
        }
        public DeviceDefinitionPublishedDTO GetDevice(Guid deviceId)
        {
            DeviceDefinitionPublishedDTO device = new DeviceDefinitionPublishedDTO();
            using (var queryProvider = KustoClientFactory.CreateCslQueryProvider(_kustoConnectionStringBuilder))
            {
                string query = $@"{_TableDeviceName} | where DeviceId=='{deviceId.ToString()}' | order by Published desc;";

                var clientRequestProperties = new ClientRequestProperties();

                using (var reader = queryProvider.ExecuteQuery(_databaseName, query, clientRequestProperties))
                {
                    try
                    {
                        List<DeviceDefinitionPublishedDTO> list = reader.SerializeToList<DeviceDefinitionPublishedDTO>();

                        return list.FirstOrDefault();
                    }
                    catch(Exception ex)
                    {

                    }
                }
            }
            return device;
        }
        public DeviceDefinitionPublishedDTO GetDeviceByNetworkId(string networkId)
        {
            DeviceDefinitionPublishedDTO device = new DeviceDefinitionPublishedDTO();
            using (var queryProvider = KustoClientFactory.CreateCslQueryProvider(_kustoConnectionStringBuilder))
            {
                string query = $@"{_TableDeviceName} | where NetworkId=='{networkId}' | order by Published desc;";

                var clientRequestProperties = new ClientRequestProperties();

                using (var reader = queryProvider.ExecuteQuery(_databaseName, query, clientRequestProperties))
                {
                    List<DeviceDefinitionPublishedDTO> list = reader.SerializeToList<DeviceDefinitionPublishedDTO>();

                    return list.FirstOrDefault();
                }
            }
            return device;
        }

        public async Task<bool> InsertDevice(DeviceDefinitionPublishedDTO document)
        {
            using (var ingestClient = KustoIngestFactory.CreateManagedStreamingIngestClient(_kustoConnectionStringBuilder))
            {
                try
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        KustoIngestionProperties _ingestionProperties = new KustoIngestionProperties(_databaseName,
                                                                                                _TableDeviceName)
                        {
                            Format = DataSourceFormat.json
                        };

                        string json = JsonConvert.SerializeObject(document);
                        byte[] buffer = Encoding.UTF8.GetBytes(json);
                        stream.Write(buffer);
                        stream.Flush();
                        stream.Position = 0;

                        await ingestClient.IngestFromStreamAsync(stream, _ingestionProperties);


                    }
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
            return true;
            
        }
        public List<DeviceTelemetryDTO> GetTelemetriesForDevice(Guid deviceId)
        {

            List<DeviceTelemetryDTO> telemetries = new List<DeviceTelemetryDTO>();
            using (var queryProvider = KustoClientFactory.CreateCslQueryProvider(_kustoConnectionStringBuilder))
            {
                string query = $@"{_TableTelemetryName} | where DeviceId=='{deviceId.ToString()}'; ";
                
                var clientRequestProperties = new ClientRequestProperties();

                using (var reader = queryProvider.ExecuteQuery(_databaseName, query, clientRequestProperties))
                {
                    telemetries = reader.SerializeToList<DeviceTelemetryDTO>();

                }
            }
            return telemetries;
        }
        public DeviceTelemetryDTO GetTelemetryForDevice(Guid deviceId, Guid id)
        {

            List<DeviceTelemetryDTO> telemetries = new List<DeviceTelemetryDTO>();
            using (var queryProvider = KustoClientFactory.CreateCslQueryProvider(_kustoConnectionStringBuilder))
            {
                string query = $@"{_TableTelemetryName} | where Id='{id}' and DeviceId=='{deviceId.ToString()}'; ";

                var clientRequestProperties = new ClientRequestProperties();

                using (var reader = queryProvider.ExecuteQuery(_databaseName, query, clientRequestProperties))
                {
                    telemetries = reader.SerializeToList<DeviceTelemetryDTO>();

                }
            }
            return  (telemetries.Count>0) ? telemetries[0] : null;
        }
        public List<DeviceMessageViewModel> GetMessagesForDevice(Guid deviceId, int skip, int pageSize, bool isDesc=true)
        {
            
            List<DeviceMessageViewModel> messages = new List<DeviceMessageViewModel>();
            using (var queryProvider = KustoClientFactory.CreateCslQueryProvider(_kustoConnectionStringBuilder))
            {
                string query = $@"{_TableMessageName} | where DeviceId=='{deviceId.ToString()}' | order by Received "+ (isDesc? "desc":"asc") + $" | serialize RowNum = row_number() | where RowNum >={pageSize*skip} and RowNum < {pageSize * skip+ pageSize}; ";

                var clientRequestProperties = new ClientRequestProperties();


                using (var reader = queryProvider.ExecuteQuery(_databaseName, query, clientRequestProperties))
                {
                    try
                    {
                        messages = reader.SerializeToList<DeviceMessageViewModel>();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            return messages;
        }
        public DeviceMessageViewModel GetMessageForDevice(Guid deviceId, Guid id)
        {

            List<DeviceMessageViewModel> messages = new List<DeviceMessageViewModel>();
            using (var queryProvider = KustoClientFactory.CreateCslQueryProvider(_kustoConnectionStringBuilder))
            {
                string query = $@"{_TableMessageName} | where Id=='{id}' and DeviceId=='{deviceId.ToString()}' | order by Received desc; ";

                var clientRequestProperties = new ClientRequestProperties();

                using (var reader = queryProvider.ExecuteQuery(_databaseName, query, clientRequestProperties))
                {
                    messages = reader.SerializeToList<DeviceMessageViewModel>();

                }
            }
            return (messages.Count > 0) ? messages[0] : null;
        }
        public DeviceMessageViewModel GetLastMessageForDevice(Guid deviceId)
        {

            List<DeviceMessageViewModel> messages = new List<DeviceMessageViewModel>();
            using (var queryProvider = KustoClientFactory.CreateCslQueryProvider(_kustoConnectionStringBuilder))
            {
                string query = $@"{_TableMessageName} | where DeviceId=='{deviceId.ToString()}' | order by Received desc | take 1; ";

                var clientRequestProperties = new ClientRequestProperties();
                try
                {
                    using (var reader = queryProvider.ExecuteQuery(_databaseName, query, clientRequestProperties))
                    {
                        messages = reader.SerializeToList<DeviceMessageViewModel>();

                    }
                }
                catch (Exception ex)
                {

                }
            }
            return (messages.Count > 0) ? messages[0] : null;
        }
        private TelemetryViewModel ConvertToTelemetryObject(IDataReader reader)
        {
            TelemetryViewModel message = new TelemetryViewModel();
            message.Id = reader.GetGuid(reader.GetOrdinal("Id"));
            message.IMEI = reader["IMEI"].ToString();            
            message.AssetUID = reader["AssetUID"].ToString(); 
            message.DeviceBatchId = reader.GetGuid(reader.GetOrdinal("DeviceBatchId"));  
            message.DeviceBatchName = reader["DeviceBatchName"].ToString();
            message.DeviceId = reader.GetGuid(reader.GetOrdinal("DeviceID"));
            message.DeviceName = reader["DeviceName"].ToString();
            message.DeviceTypeId = reader.GetGuid(reader.GetOrdinal("DeviceTypeId"));
            message.DeviceTypeName = reader["DeviceTypeName"].ToString();
            message.Name = reader["EventName"].ToString();
            message.Unit = reader["EventUnit"].ToString();
            message.Value = reader.GetDouble(reader.GetOrdinal("EventValue"));
            message.Received = reader.GetDateTime(reader.GetOrdinal("EVT_DATE"));            
            message.DevicePosLat = reader.GetDouble(reader.GetOrdinal("Lat")); 
            message.DevicePosLong = reader.GetDouble(reader.GetOrdinal("Long")); 
            message.PC = reader["PC"].ToString();
            message.PCValue = reader["PCValue"].ToString();
            message.PCUnit = reader["PCUnit"].ToString();
            message.ProjectName = reader["ProjectName"].ToString();
            return message;
        }
        public async Task<bool> InsertTelemetry(DeviceTelemetryDTO telemetry, string targetDB)
        {

            using (var ingestClient = KustoIngestFactory.CreateManagedStreamingIngestClient(_kustoConnectionStringBuilder))
            {
                try
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        KustoIngestionProperties _ingestionProperties = new KustoIngestionProperties((targetDB == "") ? _databaseName : targetDB, 
                                                                                                _TableTelemetryName)
                        {
                            Format = DataSourceFormat.json
                        };

                        string json = JsonConvert.SerializeObject(telemetry);
                        byte[] buffer = Encoding.UTF8.GetBytes(json);
                        stream.Write(buffer);
                        stream.Flush();
                        stream.Position = 0;

                        await ingestClient.IngestFromStreamAsync(stream, _ingestionProperties);


                    }
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
            return true;
        }
        public async Task<bool> InsertMessage(DeviceMessageViewModel message)
        {
            using (var ingestClient = KustoIngestFactory.CreateManagedStreamingIngestClient(_kustoConnectionStringBuilder))
            {
                try
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        KustoIngestionProperties _ingestionProperties = new KustoIngestionProperties(_databaseName, _TableMessageName)
                        {
                            Format = DataSourceFormat.json
                        };

                        string json = JsonConvert.SerializeObject(message);
                        byte[] buffer = Encoding.UTF8.GetBytes(json);
                        stream.Write(buffer);
                        stream.Flush();
                        stream.Position = 0;

                        await ingestClient.IngestFromStreamAsync(stream, _ingestionProperties);

                        
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            using (var ingestClient = KustoIngestFactory.CreateQueuedIngestClient(_kustoConnectionStringBuilder))
            {
                try
                {
                    // Set up the ingestion properties (e.g., data format)
                    var ingestionProperties = new KustoIngestionProperties()
                    {
                        Format = DataSourceFormat.json,  // Specify CSV format
                        DatabaseName = _databaseName,
                        TableName = _TableMessageName
                    };
                    MemoryStream stream = new MemoryStream();
                    string json = JsonConvert.SerializeObject(message);
                    byte[] buffer = Encoding.UTF8.GetBytes(json);
                    stream.Write(buffer);
                    stream.Position = 0;
                    await ingestClient.IngestFromStreamAsync(stream, ingestionProperties);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }

        public List<DeviceTelemetryAggregateDTO> GetAggregateTelemetriesForDevice(Guid deviceId, DateTime startDate, DateTime endDate, string window)
        {
            List<DeviceTelemetryAggregateDTO> telemetries = new List<DeviceTelemetryAggregateDTO>();
            using (var queryProvider = KustoClientFactory.CreateCslQueryProvider(_kustoConnectionStringBuilder))
            {
                int interval = int.Parse(window.Substring(0,window.Length-1));
                string windowStr = window.Substring(window.Length-1);
                string groupby = "";
                if (windowStr == "M")
                    groupby = "startofmonth(Received)";
                else
                    groupby = $"bin(Received, {window})";

                string query = $@"
                            let StartDate = datetime({startDate.ToString("yyyy-MM-dd HH:mm:ss")});
                            let EndDate = datetime({endDate.ToString("yyyy-MM-dd HH:mm:ss")});

                            {_TableTelemetryName}
                            | where Received between (StartDate ..  EndDate) and DeviceId =='{deviceId.ToString()}'
                            | summarize Min = min(Value), Max=max(Value),StdDev = stdev(Value), Avg = avg(Value), 
                                        Pct90 = percentile(Value,90), Count = count() by WindowDT={groupby}, Name
                            | project WindowDT , Name, Min, Max, StdDev, Pct90, Count, Avg,  
                                        WindowIdx=datetime_diff(""{TranslateWindowToDiff(windowStr)}"", WindowDT, StartDate)/{interval}
                            | order by Name,WindowIdx asc";
                
                var clientRequestProperties = new ClientRequestProperties();

                using (var reader = queryProvider.ExecuteQuery(_databaseName, query, clientRequestProperties))
                {
                    try
                    {
                        telemetries = reader.SerializeToList<DeviceTelemetryAggregateDTO>();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            return telemetries;
        }
        private string TranslateWindowToDiff(string window)
        {
            switch (window)
            {
                case "m":
                    return "minute";
                case "h":
                    return "hour";
                case "d":
                    return "day";
                case "w":
                    return "week";
                case "M":
                    return "month";
                case "y":
                    return "year";
            }
            return "day";
        }
    }
}
