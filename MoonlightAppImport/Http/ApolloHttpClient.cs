using MoonlightAppImport.Models;
using Newtonsoft.Json;
using Playnite.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace MoonlightAppImport.Http
{
    public class ApolloHttpClient : SunshineHttpClient
    {
        public ApolloHttpClient(MoonlightAppImportSettings moonlightAppImportSettings) : base(moonlightAppImportSettings)
        {
        }

        public override async Task<MoonlightApps> GetGamesAsync()
        {
            bool authenticated = await AuthenticateWithCookieAuthAsync();
            if (!authenticated)
                throw new AuthenticationException("Could not authenticate with the provided username & password!");

            return await GetGamesInternalAsync();
        }

        private async Task<bool> AuthenticateWithCookieAuthAsync()
        {
            _logger.Info($"Starting to authenticate to Apollo using cookie authentication.\nHost = {_settings.SunshineHost}\nUsername = {_settings.SunshineUsername}\nPassword = A password with {_settings.SunshinePassword.Length} length...");

            // Clear any existing authentication headers
            _sunshinePrivateApiClient.DefaultRequestHeaders.Authorization = null;

            // Create login form content
            var loginData = new
            {
                username = _settings.SunshineUsername,
                password = _settings.SunshinePassword
            };

            var jsonContent = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");

            // Post to login endpoint
            var response = await _sunshinePrivateApiClient.PostAsync("/api/login", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                _logger.Info("Successfully authenticated to Apollo using cookie authentication.");
                // Cookies are automatically handled by the CookieContainer
                return true;
            }
            else
            {
                _logger.Error($"Authentication to Apollo failed! Error {response.StatusCode}: {response.ReasonPhrase}");
                return false;
            }
        }
    }
}
