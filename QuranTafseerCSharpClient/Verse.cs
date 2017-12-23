using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuranTafseer
{
    [JsonObject()]
    public class Verse
    {
        [JsonProperty(PropertyName = "sura_index")]
        public int SuraIndex { get; set; }

        [JsonProperty(PropertyName = "sura_name")]
        public string SuraName { get; set; }

        [JsonProperty(PropertyName = "ayah_number")]
        public int AyahNumber { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        public Sura Sura => new Sura(this.SuraIndex, this.SuraName);
    }
}
