using System;

namespace TinyERP.Common.CQRS
{
    public interface IBaseCommand
    {
        Guid AggregateId { get; }
    }
}
