namespace TinyERP.Common.Connector
{
    public static class ConnectorFactory
    {
        public static IConnector Create(ConnectorType type)
        {
            switch (type)
            {
                case ConnectorType.Json:
                default:
                    return new JsonConnector();
            }
        }

    }
}
