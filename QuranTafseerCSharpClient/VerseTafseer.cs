using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuranTafseer
{
    [JsonObject()]
    public class VerseTafseer
    {
        [JsonProperty(PropertyName = "tafseer_id")]
        public int TafseerId { get; set; }

        [JsonProperty(PropertyName = "tafseer_name")]
        public string TafseerName { get; set; }

        [JsonProperty(PropertyName = "ayah_url")]
        public string AyahURL { get; set; }

        [JsonProperty(PropertyName = "ayah_number")]
        public string AyahNumber { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        public Tafseer Tafseer => new Tafseer(this.TafseerId, TafseerName);

    }
}
