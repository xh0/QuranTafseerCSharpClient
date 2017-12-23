using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuranTafseer
{
    [JsonObject()]
    public class Tafseer
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        public Tafseer()
        {

        }
        public Tafseer(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
