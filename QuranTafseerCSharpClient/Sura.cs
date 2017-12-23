using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuranTafseer
{
    [JsonObject()]
    public class Sura
    {
        [JsonProperty(PropertyName ="index")]
        public int Index { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        public Sura()
        {

        }
        public Sura(int index,string name)
        {
            this.Index = index;
            this.Name = name;
        }
    }
}
