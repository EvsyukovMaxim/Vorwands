using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;
using DoubleGIS.Vorwands.Client.Responses;

namespace DoubleGIS.Vorwands.Client
{
    class YouLaClient
    {
        public async Task<UserInfo> GetCurrentUser()
        {
            using (var client = await GetClient())
            {
                return await client.GetAsync<UserInfo>("/CurrentUser?format=json");
            }
        }

        public async Task<VorwandSearchResult> GetVorwands()
        {
            using (var client = await GetClient())
            {
                return await client.GetAsync<VorwandSearchResult>("Vorwands/AdvancedSearch?format=json");
            }
        }

        public async Task<VorwandFull> GetFullVorwand(long vorwandId)
        {
            using (var client = await GetClient())
            {
                return await client.GetAsync<VorwandFull>($"Vorwands/{vorwandId}/Full?format=json");
            }
        }

        private async Task<JsonServiceClient> GetClient()
        {
            var client = new JsonServiceClient
            {
                AllowAutoRedirect = true,
                CookieContainer = new System.Net.CookieContainer(),
                BaseUri = "http://uk-youla-iis/api"
            };
            await client.PostAsync<object>("/Auth?format=json", new { Username = "local\\a", Password = "a" });

            return client;
        }
    }
}
