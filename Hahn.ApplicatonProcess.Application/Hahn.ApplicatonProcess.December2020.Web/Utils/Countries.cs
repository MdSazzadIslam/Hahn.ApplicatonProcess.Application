using System.Net.Http;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web.Utils
{
    public class Countries
    {
        // HttpClient is intended to be instantiated once per application, rather than per-use. 
        private static readonly HttpClient _client = new HttpClient();
         
        public static async Task<string> GetCountryById(string countryName)
        {

         
            var ulr = "https://restcountries.eu/rest/v2/name/" + countryName + "" + "?fullText=true";
            var response = await _client.GetAsync(ulr);
            if(response.IsSuccessStatusCode)
            {
                return "OK";
            }
            else
            {
                return "NotFound";
            }

            //var content = await response.Content.ReadAsStringAsync();
            //return content;

        }

      



    }


}
