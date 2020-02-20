namespace TinyERP.Common.Vadations
{
    public class Error
    {
        public string Message { get; private set; }

        public Error(string message)
        {
            this.Message = message;
        }
    }
}
