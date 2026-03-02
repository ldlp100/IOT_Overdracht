using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;


namespace IoTEx.Waternet.Storage
{
    public class StorageAccountManager
    {
        private BlobServiceClient _blobServiceClient;
        private readonly ILogger _logger;
        private string containerDeviceConfiguration= "iotdevices";
        private string containerData = "iotdata";
        public StorageAccountManager(BlobServiceClient blobServiceClient) {
            _blobServiceClient = blobServiceClient;
            
        }
        //public async Task<APIResultDTO<string>> SaveDeviceConfiguration(Guid deviceId, DeviceMetaDataDTO doc)
        //{
        //    string json = JsonConvert.SerializeObject(doc);
        //    APIResultDTO<string> result = new APIResultDTO<string>();

        //    try
        //    {                
        //        var containerClient = _blobServiceClient.GetBlobContainerClient(containerDeviceConfiguration);
        //        var blobClient = containerClient.GetBlobClient($"{deviceId.ToString()}.json");
                
        //        await blobClient.UploadAsync(new MemoryStream(Encoding.UTF8.GetBytes(json)), true);
                
        //        result.Value = json;
        //        result.IsOk = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Error = ex.Message;
        //        result.IsOk = false;
        //    }
            
        //    return result;
        //}

        //public async Task<string> GetDeviceConfiguration(string deviceId)
        //{
        //    BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerDeviceConfiguration);
        //    BlobClient blobClient = containerClient.GetBlobClient($"{deviceId}.json");
        //    BlobDownloadInfo downloadInfo = await blobClient.DownloadAsync();

        //    // Read the content
        //    using (StreamReader readerInstance = new StreamReader(downloadInfo.Content))
        //    {
        //        string json = await readerInstance.ReadToEndAsync();
        //        return json;
        //    }
        //}
        ////public async Task<string> SaveTelemetry(DateTime dt, string deviceId, string content)
        ////{
        ////    BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerData);
        ////    string pathBlob = getPathTelemetry(deviceId, dt, Guid.NewGuid().ToString());
        ////    BlobClient blobClient = containerClient.GetBlobClient(pathBlob);
        ////    using (MemoryStream stream = new MemoryStream())
        ////    {
        ////        stream.Write(Encoding.UTF8.GetBytes(content));
        ////        stream.Position = 0;
        ////        await blobClient.UploadAsync(stream);
        ////    }
        ////    return blobClient.Uri.ToString();

        ////}
        ////public IEnumerable<BlobItem> GetTelenetryBlobsInDirectory(string path)
        ////{
        ////    BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerData);            
        ////    var lastModifiedBlobs = containerClient.GetBlobs(prefix: path).OrderByDescending(b => b.Properties.LastModified);
        ////    return lastModifiedBlobs;
        ////}
        ////private string getPathTelemetry(string deviceId, DateTime dateTime, string uniqueId)
        ////{
        ////    return $"{dateTime.Year}/{dateTime.Month.ToString("0#")}/{dateTime.Month.ToString("0#")}/{dateTime.Day.ToString("0#")}/" +
        ////            $"{deviceId}/{uniqueId}_" +
        ////            $"{dateTime.Hour.ToString("0#")}_{dateTime.Minute.ToString("0#")}_{dateTime.Second.ToString("0#")}_" +
        ////            $"{dateTime.Millisecond.ToString("00#")}.json";
        ////}
        ////public async Task<string> GetTelemetry(string pathBlob)
        ////{
        ////    BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerData);
        ////    BlobClient blobClient = containerClient.GetBlobClient(pathBlob);
        ////    if (blobClient.Exists())
        ////    {
        ////        BlobDownloadInfo downloadInfo = await blobClient.DownloadAsync();
        ////        using (StreamReader readerInstance = new StreamReader(downloadInfo.Content))
        ////        {
        ////            string content = await readerInstance.ReadToEndAsync();
        ////            return content;
        ////        }
        ////    }
        ////    return "";
        ////}
        ////public async Task<bool> UpdateDeviceIndexFile(string deviceId, DateTime dt)
        ////{
        ////    string pathBlob = $"/devices/{deviceId}.txt";
        ////    BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerData);
        ////    BlobClient blobClient = containerClient.GetBlobClient(pathBlob);
        ////    if (!blobClient.Exists())
        ////    {
        ////        await blobClient.UploadAsync(new MemoryStream(Encoding.UTF8.GetBytes(dt.ToString("/yyyy/MM/dd/"))), true);
        ////    }
        ////    else
        ////    {
        ////        BlobDownloadInfo downloadInfo = await blobClient.DownloadAsync();
        ////        using (StreamReader readerInstance = new StreamReader(downloadInfo.Content))
        ////        {
        ////            string content = await readerInstance.ReadToEndAsync();
        ////            string strDT = dt.ToString("/yyyy/MM/dd/");
        ////            if (content.IndexOf(strDT)==-1)
        ////                content += "\n" + strDT;

        ////            await blobClient.UploadAsync(new MemoryStream(Encoding.UTF8.GetBytes(content)), true);
        ////        }
        ////    }
        ////    return true;
        ////}
        ////public async Task<List<string>> GetDeviceIndexFile(string deviceId)
        ////{
        ////    string pathBlob = $"/devices/{deviceId}.txt";
        ////    BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerData);
        ////    BlobClient blobClient = containerClient.GetBlobClient(pathBlob);
        ////    if (blobClient.Exists())
        ////    {
        ////        BlobDownloadInfo downloadInfo = await blobClient.DownloadAsync();
        ////        using (StreamReader readerInstance = new StreamReader(downloadInfo.Content))
        ////        {
        ////            string content = await readerInstance.ReadToEndAsync();
        ////            return content.Split('\n').ToList();
        ////        }
        ////    }
        ////    return new List<string>();
        ////}
        ////public async Task<List<DeviceTelemetryViewModel>> GetMessagesForDevice(Guid deviceTypeId, Guid deviceBatchId, Guid deviceId)
        ////{
        ////    List<DeviceTelemetryViewModel> result = new List<DeviceTelemetryViewModel>();

        ////    BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerData);

        ////    BlobClient blobIndex = containerClient.GetBlobClient($"/devices/{deviceId}.txt");
        ////    BlobDownloadInfo downloadIndex = await blobIndex.DownloadAsync();

        ////    using (StreamReader reader = new StreamReader(downloadIndex.Content))
        ////    {
        ////        string DirectoryName = null;

        ////        int count = 100;
        ////        while ((DirectoryName = await reader.ReadLineAsync()) != null)
        ////        {

        ////            // Get the list of blobs in the container
        ////            var blobs = containerClient.GetBlobs(prefix: DirectoryName + deviceId);

        ////            // Get the last modified blob
        ////            var lastModifiedBlobs = blobs.OrderByDescending(b => b.Properties.LastModified);

        ////            foreach (var blob in lastModifiedBlobs)
        ////            {
        ////                string[] path = blob.Name.Split('/');
        ////                //if (path.Length == request.PageSize)
        ////                if (path.Length == 5)
        ////                {
        ////                    string name = path[path.Length - 1];
        ////                    string id = name.Substring(0, 36);

        ////                    int year = Int32.Parse(path[0]);
        ////                    int month = Int32.Parse(path[1]);
        ////                    int day = Int32.Parse(path[2]);
        ////                    int hour = Int32.Parse(name.Substring(37, 2));
        ////                    int minute = Int32.Parse(name.Substring(40, 2));
        ////                    int second = Int32.Parse(name.Substring(43, 2));
        ////                    int second2 = Int32.Parse(name.Substring(46, 2)); // TODO
        ////                    int second3 = Int32.Parse(name.Substring(49, 2)); // TODO
        ////                    int second4 = Int32.Parse(name.Substring(52, 2)); // TODO

        ////                    DateTime DateTime = new DateTime(year, month, day, hour, minute, second);

        ////                    result.Add(new DeviceTelemetryViewModel() { Id = Guid.Parse(id), Received = DateTime, DeviceTypeId = deviceTypeId, DeviceBatchId = deviceBatchId, DeviceId = deviceId, Path = blob.Name });
        ////                    count--;
        ////                    if (count == 1)
        ////                        break;

        ////                }
        ////            }
        ////        }
        ////        return result;
        ////    }
        ////}

    }
}
