using System.Net;
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

        public async Task<CommentsResponse> GetComments(long vorwandId)
        {
            using (var client = await GetClient())
            {
                return await client.GetAsync<CommentsResponse>($"/Comments?type=4&entityId={vorwandId}&format=json");
            }
        }

        public async Task UpdateComment(long commentId, string text)
        {
            using (var client = await GetClient())
            {
                await client.PostAsync<object>("/json/reply/UpdateCommentRequest", new { commentId, text });
            }
        }

        public async Task AddComment(string type, long entityId, string text)
        {
            using (var client = await GetClient())
            {
                await client.PostAsync<object>("/json/reply/AddCommentRequest", new { type, entityId, text });
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

        public async Task EditVorwandName(long vorwandId, string name)
        {
            using (var client = await GetClient())
            {
                await client.PostAsync<object>($"/Vorwands/Edit/{vorwandId}/Name", new { vorwandId, name});
            }
        }

        public async Task EditVorwandDescription(long vorwandId, string description)
        {
            using (var client = await GetClient())
            {
                await client.PostAsync<object>($"/Vorwands/Edit/{vorwandId}/Description", new { vorwandId, description });
            }
        }

        private async Task<JsonServiceClient> GetClient()
        {
            var client = new JsonServiceClient
            {
                AllowAutoRedirect = true,
                CookieContainer = new System.Net.CookieContainer(),
                BaseUri = "http://uk-youla-iis/apiw",
               
            };
            client.Credentials = CredentialCache.DefaultNetworkCredentials;
            await client.PostAsync<object>("/auth/windows", null);

            return client;
        }
    }
}
