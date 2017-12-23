using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuranTafseer
{
    static class Endpoints
    {
        /// <summary>
        ///  To get a list of Quran chapters.
        /// </summary>
        public const string Chapters = "http://api.quran-tafseer.com/quran";

        /// <summary>
        /// Get a text for specific Verse in Sura, you should pass Sura number and Ayah number as query parameter. 
        /// api.quran-tafseer.com/quran/{sura_number}/{ayah_number}
        /// </summary>
        public const string VerseDetails = "http://api.quran-tafseer.com/quran/{0}/{1}";

        /// <summary>
        ///  Get a list of Quran tafseer available in Tafseer API
        /// </summary>
        public const string AvailableTafseers = "http://api.quran-tafseer.com/tafseer";

        /// <summary>
        /// Get a specific tasfeer for verse in chapter, you should pass Tafseer Id which can get from Tafseer List Endpoint, Sura number, and Ayah number as query parameter. 
        /// api.quran-tafseer.com/tafseer/{tafseer_id}/{sura_number}/{ayah_number}
        /// </summary>
        public const string VerseTafseer = "http://api.quran-tafseer.com/tafseer/{0}/{1}/{2}";


    }
}
