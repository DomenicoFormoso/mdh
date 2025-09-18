using System.Net.Http;
using System.Text;
using HelvyTools.PrestashopAPI.Client.Data;
using HelvyTools.PrestashopAPI.Client.Elements;

namespace HelvyTools.PrestashopAPI.Client.Clients
{
    /// <summary>
    /// CRUD client for Product operations
    /// </summary>
    public class ProductClient : BaseClient
    {
        protected override string ResourceName => "products";

        public ProductClient(string baseUrl, string apiKey) : base(baseUrl, apiKey)
        {
        }

        /// <summary>
        /// Get a product by ID
        /// </summary>
        public async Task<Product?> GetAsync(long id)
        {
            try
            {
                var url = BuildUrl(id);
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var xml = await response.Content.ReadAsStringAsync();
                var prestashopResponse = DeserializeFromXml<PrestashopResponse<Product>>(xml);
                return prestashopResponse?.Data;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to get product {id}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Get all products
        /// </summary>
        public async Task<List<Product>> GetAllAsync()
        {
            try
            {
                var url = BuildUrl();
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var xml = await response.Content.ReadAsStringAsync();
                var prestashopResponse = DeserializeFromXml<PrestashopCollectionResponse<Product>>(xml);
                return prestashopResponse?.Items ?? new List<Product>();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to get products: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Add a new product
        /// </summary>
        public async Task<Product?> AddAsync(Product product)
        {
            try
            {
                var prestashopRequest = new PrestashopResponse<Product> { Data = product };
                var xml = SerializeToXml(prestashopRequest);
                var content = new StringContent(xml, Encoding.UTF8, "application/xml");

                var url = BuildUrl();
                var response = await _httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                var responseXml = await response.Content.ReadAsStringAsync();
                var prestashopResponse = DeserializeFromXml<PrestashopResponse<Product>>(responseXml);
                return prestashopResponse?.Data;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to add product: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Update an existing product
        /// </summary>
        public async Task<Product?> UpdateAsync(Product product)
        {
            try
            {
                if (product.Id <= 0)
                    throw new ArgumentException("Product ID is required for update operation");

                var prestashopRequest = new PrestashopResponse<Product> { Data = product };
                var xml = SerializeToXml(prestashopRequest);
                var content = new StringContent(xml, Encoding.UTF8, "application/xml");

                var url = BuildUrl(product.Id);
                var response = await _httpClient.PutAsync(url, content);
                response.EnsureSuccessStatusCode();

                var responseXml = await response.Content.ReadAsStringAsync();
                var prestashopResponse = DeserializeFromXml<PrestashopResponse<Product>>(responseXml);
                return prestashopResponse?.Data;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to update product {product.Id}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Delete a product
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
                throw new InvalidOperationException($"Failed to delete product {id}: {ex.Message}", ex);
            }
        }
    }
}