using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ApiFirebase
{
    [Serializable,JsonObject]
    public class FirebaseIdentity
    {
        [JsonProperty("identities")]
        public Identities Identities { get; set; }  

    }
    public class Identities
    {
        [JsonProperty("email")]
        public List<string> Emails { get; set;}
    }
}
