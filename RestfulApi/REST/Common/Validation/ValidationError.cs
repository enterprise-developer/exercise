using REST.Common.Helper;
using System.Collections.Generic;

namespace REST.Common.Validation
{
    public class ValidationError
    {

        public string ErrorKey { get; set; }
        public Dictionary<string, string> Params { get; set; }
        public ValidationError(string errorKey, params string[] args)
        {
            this.ErrorKey = errorKey;
            this.Params = new Dictionary<string, string>();
            if (args.Length == 0) { return; }
            if (NumberHelper.Div(args.Length, 2) != 0) { return; }
            for (int index = 0; index < args.Length; index+=2) {
                this.Params[args[index]] = args[index + 1];
            }
        }
    }
}