namespace TinyERP.Common.CQRS
{
    public class BaseCommand : IBaseCommand
    {
        public int AggregateId { get; private set; }
        public BaseCommand(int aggregateId = 0)
        {
            this.AggregateId = aggregateId;
        }

        public void SetAggregateId(int aggregateId)
        {
            this.AggregateId = aggregateId;
        }
    }
}
