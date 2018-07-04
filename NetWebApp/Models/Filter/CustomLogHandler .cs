using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace NetWebApp.App_Start.Filter
{
    public class CustomLogHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var logMetadata = BuildRequestMetadata(request);
            var response = await base.SendAsync(request, cancellationToken);

            logMetadata = BuildResponseMetadata(logMetadata, response);

            SendToLog(logMetadata);

            return response;
        }

        #region Helpers

        private LogMetadata BuildRequestMetadata(HttpRequestMessage request)
        {
            try
            {
                LogMetadata log = new LogMetadata
                {
                    RequestMethod = request.Method.Method,
                    RequestTimestamp = DateTime.Now,
                    RequestUri = request.RequestUri.ToString()
                };
                return log;
            }
            catch (Exception)
            {
            }

            return null;
        }
        private LogMetadata BuildResponseMetadata(LogMetadata logMetadata, HttpResponseMessage response)
        {
            try
            {
                logMetadata.ResponseStatusCode = response.StatusCode;
                logMetadata.ResponseTimestamp = DateTime.Now;
                logMetadata.ResponseContentType = response.Content?.Headers.ContentType.MediaType;

                return logMetadata;
            }
            catch (Exception)
            {
            }

            return null;
        }

        private void SendToLog(LogMetadata logMetadata)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            log.Info(logMetadata);
        }

        #endregion

    }
}