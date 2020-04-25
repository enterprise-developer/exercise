using System;
using TinyERP.Common.Configurations;
using TinyERP.Common.Connector;

namespace TinyERP.Common.Logs
{
    public class RestApiLogger : ILogger
    {
        public void Error(Exception ex)
        {
            string url = $"{ConfigurationApp.Instance.Logger.Endpoint.Url}/api/loggers";
            IConnector connector = ConnectorFactory.Create(ConnectorType.Json);
            connector.Post<object>(url, ex);
        }
    }
}
