namespace StorageAPI.Models
{
    public class Data
    {
        public Data(string referrer, string userAgent, string ipAddress)
        {
            this.Referrer = referrer;
            this.UserAgent = userAgent;
            this.IpAddress = ipAddress;
        }

        public string Referrer { get; set; }
        public string UserAgent { get; set; }
        public string? IpAddress { get; set; }
    }
}