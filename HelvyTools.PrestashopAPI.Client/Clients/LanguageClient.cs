using System.Net.Http;
using System.Text;
using HelvyTools.PrestashopAPI.Client.Data;
using HelvyTools.PrestashopAPI.Client.LanguageElements;

namespace HelvyTools.PrestashopAPI.Client.Clients
{
    /// <summary>
    /// CRUD client for Language operations
    /// </summary>
    public class LanguageClient : BaseClient
    {
        protected override string ResourceName => "languages";

        public LanguageClient(string baseUrl, string apiKey) : base(baseUrl, apiKey)
        {
        }

        /// <summary>
        /// Get a language by ID
        /// </summary>
        public async Task<LanguageElement?> GetAsync(long id)
        {
            try
            {
                var url = BuildUrl(id);
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var xml = await response.Content.ReadAsStringAsync();
                var prestashopResponse = DeserializeFromXml<PrestashopResponse<LanguageElement>>(xml);
                return prestashopResponse?.Data;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to get language {id}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Get all languages
        /// </summary>
        public async Task<List<LanguageElement>> GetAllAsync()
        {
            try
            {
                var url = BuildUrl();
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var xml = await response.Content.ReadAsStringAsync();
                var prestashopResponse = DeserializeFromXml<PrestashopCollectionResponse<LanguageElement>>(xml);
                return prestashopResponse?.Items ?? new List<LanguageElement>();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to get languages: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Add a new language
        /// </summary>
        public async Task<LanguageElement?> AddAsync(LanguageElement language)
        {
            try
            {
                var prestashopRequest = new PrestashopResponse<LanguageElement> { Data = language };
                var xml = SerializeToXml(prestashopRequest);
                var content = new StringContent(xml, Encoding.UTF8, "application/xml");

                var url = BuildUrl();
                var response = await _httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                var responseXml = await response.Content.ReadAsStringAsync();
                var prestashopResponse = DeserializeFromXml<PrestashopResponse<LanguageElement>>(responseXml);
                return prestashopResponse?.Data;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to add language: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Update an existing language
        /// </summary>
        public async Task<LanguageElement?> UpdateAsync(LanguageElement language)
        {
            try
            {
                if (language.Id <= 0)
                    throw new ArgumentException("Language ID is required for update operation");

                var prestashopRequest = new PrestashopResponse<LanguageElement> { Data = language };
                var xml = SerializeToXml(prestashopRequest);
                var content = new StringContent(xml, Encoding.UTF8, "application/xml");

                var url = BuildUrl(language.Id);
                var response = await _httpClient.PutAsync(url, content);
                response.EnsureSuccessStatusCode();

                var responseXml = await response.Content.ReadAsStringAsync();
                var prestashopResponse = DeserializeFromXml<PrestashopResponse<LanguageElement>>(responseXml);
                return prestashopResponse?.Data;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to update language {language.Id}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Delete a language
        /// </summary>
        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                var url = BuildUrl(id);
                var response = await _httpClient.DeleteAsync(url);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to delete language {id}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Get language by ISO code
        /// </summary>
        public async Task<List<LanguageElement>> GetByIsoCodeAsync(string isoCode)
        {
            try
            {
                var url = $"{BuildUrl()}?filter[iso_code]={Uri.EscapeDataString(isoCode)}";
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var xml = await response.Content.ReadAsStringAsync();
                var prestashopResponse = DeserializeFromXml<PrestashopCollectionResponse<LanguageElement>>(xml);
                return prestashopResponse?.Items ?? new List<LanguageElement>();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to get language by ISO code {isoCode}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Get active languages only
        /// </summary>
        public async Task<List<LanguageElement>> GetActiveAsync()
        {
            try
            {
                var url = $"{BuildUrl()}?filter[active]=1";
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var xml = await response.Content.ReadAsStringAsync();
                var prestashopResponse = DeserializeFromXml<PrestashopCollectionResponse<LanguageElement>>(xml);
                return prestashopResponse?.Items ?? new List<LanguageElement>();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to get active languages: {ex.Message}", ex);
            }
        }
    }
}