using System;

namespace TinyERP.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string errorMessage): base(errorMessage)
        {
        }
    }
}
