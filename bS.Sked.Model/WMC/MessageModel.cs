using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.WMC
{
  public class MessageModel
    {
        // We declare Left and Top as lowercase with 
        // JsonProperty to sync the client and server models
        [JsonProperty("severity")]
        public string Severity { get; set; }
        [JsonProperty("severityid")]
        public int SeverityId { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("datetime")]
        public DateTime Date { get; set; }
        [JsonIgnore]
        public string MessageId { get; set; }
    }
}
