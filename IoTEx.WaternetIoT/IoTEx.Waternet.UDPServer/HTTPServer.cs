using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace IoT.UDPServer
{
    public class HTTPServer
    {
        private readonly ILogger _logger;
        private HttpListener listener;
        public static IConfigurationRoot configuration;
        public HTTPServer(ILogger<UDPListener> logger) { _logger = logger; }
        public bool Start()
        {
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}- Creating HTTP Probe on port {80}");
            listener = new HttpListener();
            listener.Prefixes.Add("http://+:80/");
            
            listener.Start();
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}- Probe Setup on port 80!");
            listener.BeginGetContext(new AsyncCallback(this.ListenerCallback), listener);
            return true;
        }
        public  void ListenerCallback(IAsyncResult result)
        {
            try
            {
                HttpListener listener = (HttpListener)result.AsyncState;
                listener.BeginGetContext(new AsyncCallback(ListenerCallback), listener);
                _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}-Probe response");

                HttpListenerContext context = listener.EndGetContext(result);
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                byte[] page = Encoding.UTF8.GetBytes("IoT-UDPServer-Probe:OK");

                response.ContentLength64 = page.Length;
                Stream output = response.OutputStream;
                output.Write(page, 0, page.Length);
                output.Close();
            } 
            catch (Exception ex)
            {

            }
        }
    }
}
