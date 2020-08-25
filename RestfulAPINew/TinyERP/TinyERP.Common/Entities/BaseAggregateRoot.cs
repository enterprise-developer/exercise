using System.Collections.Generic;
using TinyERP.Common.CQRS;
using TinyERP.Common.Helpers;

namespace TinyERP.Common.Entities
{
    public class BaseAggregateRoot : BaseEntity
    {
        public IList<IEvent> Events { get; set; }
        public void PublishEvents()
        {
            EventHelper.InvokeEventHandle(this.Events);
        }
    }
}
