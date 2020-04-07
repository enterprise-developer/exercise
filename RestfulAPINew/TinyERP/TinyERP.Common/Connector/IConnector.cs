namespace TinyERP.Common.Connector
{
    public interface IConnector
    {
        TData Post<TData>(string url, object value);
    }
}
