namespace REST.Common.Data
{
    using REST.Common.Validation;
    using System;
    using System.Collections.Generic;
    using System.Net;
    public class ResponseData
    {
        public object Data { get; set; }
        public HttpStatusCode Status { get; set; }
        public IList<ValidationError> Errors { get; set; }

        public ResponseData()
        {
            this.Status = HttpStatusCode.OK;
            this.Errors = new List<ValidationError>();
        }
        internal void SetData(object data)
        {
            this.Status = HttpStatusCode.OK;    
            this.Data = data;
        }

        internal void SetErrors(IList<ValidationError> errors)
        {
            this.Status = HttpStatusCode.BadRequest;
            this.Errors = errors;
        }

        internal void SetStatus(HttpStatusCode status)
        {
            this.Status = status;
        }
    }
}