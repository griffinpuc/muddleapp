using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace muddleapp.Models
{
    public class Api
    {

        public async Task<string> searchDrinksAsync(string drink)
        {
            var url = "https://www.thecocktaildb.com/api/json/v1/1/search.php?s=" + drink;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string strResult = await response.Content.ReadAsStringAsync();

                    return strResult;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<string> searchById(string drinkId)
        {
            var url = "https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i=" + drinkId;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string strResult = await response.Content.ReadAsStringAsync();

                    return strResult;
                }
                else
                {
                    return null;
                }
            }
        }

    }

}
