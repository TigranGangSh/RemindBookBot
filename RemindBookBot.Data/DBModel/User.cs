using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RemindBookBot.Data.Model
{
    public class User
    {
        [JsonProperty(PropertyName = "message_id", Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "from", Required = Required.Default)]
        public string Username { get; set; }
    }
}
