namespace TinyERP.Common.Common
{
    public class PagingInfo
    {
        private int index = 0;
        public int Index
        {
            get {
                return this.index;
            } internal set
            {
                this.index = value;
                this.Next = string.Format("http://localhost:60105/api/users?pageindex={0}", value+1);
                this.Previous = string.Format("http://localhost:60105/api/users?pageindex={0}", value - 1);
            }
        }
        public int Total { get; internal set; }
        public string Next { get; set; }
        public string Previous { get; set; }
    }
}