using System.Net.Http;
using System.Text;
using HelvyTools.PrestashopAPI.Client.Data;
using HelvyTools.PrestashopAPI.Client.Elements;

namespace HelvyTools.PrestashopAPI.Client.Clients
{
    /// <summary>
    /// CRUD client for Category operations
    /// </summary>
    public class CategoryClient : BaseClient
    {
        protected override string ResourceName => "categories";

        public CategoryClient(string baseUrl, string apiKey) : base(baseUrl, apiKey)
        {
        }

        /// <summary>
        /// Get a category by ID
        /// </summary>
        public async Task<Category?> GetAsync(long id)
        {
            try
            {
                var url = BuildUrl(id);
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var xml = await response.Content.ReadAsStringAsync();
                var prestashopResponse = DeserializeFromXml<PrestashopResponse<Category>>(xml);
                return prestashopResponse?.Data;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to get category {id}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        public async Task<List<Category>> GetAllAsync()
        {
            try
            {
                var url = BuildUrl();
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var xml = await response.Content.ReadAsStringAsync();
                var prestashopResponse = DeserializeFromXml<PrestashopCollectionResponse<Category>>(xml);
                return prestashopResponse?.Items ?? new List<Category>();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to get categories: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Add a new category
        /// </summary>
        public async Task<Category?> AddAsync(Category category)
        {
            try
            {
                var prestashopRequest = new PrestashopResponse<Category> { Data = category };
                var xml = SerializeToXml(prestashopRequest);
                var content = new StringContent(xml, Encoding.UTF8, "application/xml");

                var url = BuildUrl();
                var response = await _httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                var responseXml = await response.Content.ReadAsStringAsync();
                var prestashopResponse = DeserializeFromXml<PrestashopResponse<Category>>(responseXml);
                return prestashopResponse?.Data;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to add category: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Update an existing category
        /// </summary>
        public async Task<Category?> UpdateAsync(Category category)
        {
            try
            {
                if (category.Id <= 0)
                    throw new ArgumentException("Category ID is required for update operation");

                var prestashopRequest = new PrestashopResponse<Category> { Data = category };
                var xml = SerializeToXml(prestashopRequest);
                var content = new StringContent(xml, Encoding.UTF8, "application/xml");

                var url = BuildUrl(category.Id);
                var response = await _httpClient.PutAsync(url, content);
                response.EnsureSuccessStatusCode();

                var responseXml = await response.Content.ReadAsStringAsync();
                var prestashopResponse = DeserializeFromXml<PrestashopResponse<Category>>(responseXml);
                return prestashopResponse?.Data;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to update category {category.Id}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Delete a category
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
                throw new InvalidOperationException($"Failed to delete category {id}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Get categories by parent ID
        /// </summary>
        public async Task<List<Category>> GetByParentAsync(long parentId)
        {
            try
            {
                var url = $"{BuildUrl()}?filter[id_parent]={parentId}";
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var xml = await response.Content.ReadAsStringAsync();
                var prestashopResponse = DeserializeFromXml<PrestashopCollectionResponse<Category>>(xml);
                return prestashopResponse?.Items ?? new List<Category>();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to get categories by parent {parentId}: {ex.Message}", ex);
            }
        }
    }
}