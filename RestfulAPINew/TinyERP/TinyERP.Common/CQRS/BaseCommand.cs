using System;

namespace TinyERP.Common.CQRS
{
    public class BaseCommand : IBaseCommand
    {
        public Guid AggregateId { get; private set; }
        public BaseCommand()
        {
            this.AggregateId = Guid.Empty;
        }
        public BaseCommand(Guid aggregateId)
        {
            this.AggregateId = aggregateId;
        }

        public void SetAggregateId(Guid aggregateId)
        {
            this.AggregateId = aggregateId;
        }
    }
}
