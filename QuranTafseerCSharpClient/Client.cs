using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuranTafseer
{
    public class Client : IDisposable
    {
        System.Net.Http.HttpClient _httpClient = new System.Net.Http.HttpClient();

        //TODO: Implement more advanced cash
        Dictionary<string, string> _cash = new Dictionary<string, string>();

        public Client()
        {

        }

        async Task<string> RequestJsonAsync(string url)
        {
            if (_cash.ContainsKey(url)) return _cash[url];

            string response = await _httpClient.GetStringAsync(url);

            _cash.Add(url, response);

            return response;
        }


        /// <summary>
        /// Get a list of Quran chapters/Sura
        /// </summary>
        /// <returns></returns>
        public async Task<List<Sura>> GetSuraListAsync()
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Sura>>(await RequestJsonAsync(Endpoints.Chapters));
        }

        public async Task<Verse> GetVerseDetails(int suraNumber, int ayahNumber)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Verse>(await RequestJsonAsync(String.Format(Endpoints.VerseDetails, suraNumber, ayahNumber)));
        }

        public async Task<List<Tafseer>> GetAvailableTafseersListAsync()
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Tafseer>>(await RequestJsonAsync(Endpoints.AvailableTafseers));
        }

        public async Task<VerseTafseer> GetVerseTafseerAsync(int tafseerId, int suraNumber, int ayahNumber)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<VerseTafseer>(await RequestJsonAsync(String.Format(Endpoints.VerseTafseer, tafseerId, suraNumber, ayahNumber)));
        }

        public async Task<VerseTafseer> GetVerseTafseerAsync(int tafseerId, Verse verse)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<VerseTafseer>(await RequestJsonAsync(String.Format(Endpoints.VerseTafseer, tafseerId, verse.SuraIndex, verse.AyahNumber)));
        }

        bool _disposed;
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        protected void Dispose(bool disposing)
        {
            throw new NotImplementedException();
        }

    }
}
