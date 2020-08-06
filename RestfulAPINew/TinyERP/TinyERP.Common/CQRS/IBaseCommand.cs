namespace TinyERP.Common.CQRS
{
    public interface IBaseCommand
    {
        int AggregateId { get; }
    }
}
