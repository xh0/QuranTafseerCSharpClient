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
        System.Net.WebClient _webClient = new System.Net.WebClient();// sync support, I know I should use something else for both, I wil

        //TODO: Implement more advanced cash
        Dictionary<string, string> _cash = new Dictionary<string, string>();

        public Client()
        {

        }

        //TODO: Add error handling for RequestJsonAsync
        async Task<string> RequestJsonAsync(string url)
        {
            if (_cash.ContainsKey(url)) return _cash[url];

            string response = await _httpClient.GetStringAsync(url);

            _cash.Add(url, response);

            return response;
        }

        //TODO: Add error handling for RequestJson
        string RequestJson(string url)
        {
            if (_cash.ContainsKey(url)) return _cash[url];

            string response = _webClient.DownloadString(url);

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

        /// <summary>
        /// Get a list of Quran chapters/Sura
        /// </summary>
        /// <returns></returns>
        public List<Sura> GetSuraList()
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Sura>>(RequestJson(Endpoints.Chapters));
        }

        /// <summary>
        /// Get the text for specific Verse in Sura.
        /// </summary>
        /// <param name="suraNumber">The Sure number/index</param>
        /// <param name="ayahNumber">The Ayah number/index</param>
        /// <returns></returns>
        public async Task<Verse> GetVerseDetailsAsync(int suraNumber, int ayahNumber)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Verse>(await RequestJsonAsync(String.Format(Endpoints.VerseDetails, suraNumber, ayahNumber)));
        }

        /// <summary>
        /// Get the text for specific Verse in Sura.
        /// </summary>
        /// <param name="suraNumber">The Sure number/index</param>
        /// <param name="ayahNumber">The Ayah number/index</param>
        /// <returns></returns>
        public Verse GetVerseDetails(int suraNumber, int ayahNumber)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Verse>(RequestJson(String.Format(Endpoints.VerseDetails, suraNumber, ayahNumber)));
        }

        /// <summary>
        /// Get a list of Quran tafseer available in Tafseer API.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Tafseer>> GetAvailableTafseersListAsync()
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Tafseer>>(await RequestJsonAsync(Endpoints.AvailableTafseers));
        }

        /// <summary>
        /// Get a list of Quran tafseer available in Tafseer API.
        /// </summary>
        /// <returns></returns>
        public List<Tafseer> GetAvailableTafseersList()
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Tafseer>>(RequestJson(Endpoints.AvailableTafseers));
        }

        /// <summary>
        /// Get a specific tasfeer for verse in chapter/Sura.
        /// </summary>
        /// <param name="tafseerId">The id of the Tafsser</param>
        /// <param name="suraNumber">The Sure number/index</param>
        /// <param name="ayahNumber">The Ayah number/index</param>
        /// <returns></returns>
        public async Task<VerseTafseer> GetVerseTafseerAsync(int tafseerId, int suraNumber, int ayahNumber)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<VerseTafseer>(await RequestJsonAsync(String.Format(Endpoints.VerseTafseer, tafseerId, suraNumber, ayahNumber)));
        }

        /// <summary>
        /// Get a specific tasfeer for verse in chapter/Sura.
        /// </summary>
        /// <param name="tafseerId">The id of the Tafsser</param>
        /// <param name="suraNumber">The Sure number/index</param>
        /// <param name="ayahNumber">The Ayah number/index</param>
        /// <returns></returns>
        public VerseTafseer GetVerseTafseer(int tafseerId, int suraNumber, int ayahNumber)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<VerseTafseer>(RequestJson(String.Format(Endpoints.VerseTafseer, tafseerId, suraNumber, ayahNumber)));
        }

        /// <summary>
        /// Get a specific tasfeer for verse in chapter/Sura.
        /// </summary>
        /// <param name="tafseerId">The id of the Tafsser</param>
        /// <param name="verse">verse object the you want tafseer for</param>
        /// <returns></returns>
        public async Task<VerseTafseer> GetVerseTafseerAsync(int tafseerId, Verse verse)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<VerseTafseer>(await RequestJsonAsync(String.Format(Endpoints.VerseTafseer, tafseerId, verse.SuraIndex, verse.AyahNumber)));
        }

        /// <summary>
        /// Get a specific tasfeer for verse in chapter/Sura.
        /// </summary>
        /// <param name="tafseerId">The id of the Tafsser</param>
        /// <param name="verse">verse object the you want tafseer for</param>
        /// <returns></returns>
        public VerseTafseer GetVerseTafseer(int tafseerId, Verse verse)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<VerseTafseer>(RequestJson(String.Format(Endpoints.VerseTafseer, tafseerId, verse.SuraIndex, verse.AyahNumber)));
        }

        bool disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
                _httpClient.Dispose();
                _webClient.Dispose();
            }

            disposed = true;
        }

        ~Client()
        {
            Dispose(false);
        }
    }
}
