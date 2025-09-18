using System.Net.Http;
using System.Text;
using HelvyTools.PrestashopAPI.Client.Data;
using HelvyTools.PrestashopAPI.Client.Elements;

namespace HelvyTools.PrestashopAPI.Client.Clients
{
    /// <summary>
    /// CRUD client for Customer operations
    /// </summary>
    public class CustomerClient : BaseClient
    {
        protected override string ResourceName => "customers";

        public CustomerClient(string baseUrl, string apiKey) : base(baseUrl, apiKey)
        {
        }

        /// <summary>
        /// Get a customer by ID
        /// </summary>
        public async Task<Customer?> GetAsync(long id)
        {
            try
            {
                var url = BuildUrl(id);
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var xml = await response.Content.ReadAsStringAsync();
                var prestashopResponse = DeserializeFromXml<PrestashopResponse<Customer>>(xml);
                return prestashopResponse?.Data;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to get customer {id}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Get all customers
        /// </summary>
        public async Task<List<Customer>> GetAllAsync()
        {
            try
            {
                var url = BuildUrl();
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var xml = await response.Content.ReadAsStringAsync();
                var prestashopResponse = DeserializeFromXml<PrestashopCollectionResponse<Customer>>(xml);
                return prestashopResponse?.Items ?? new List<Customer>();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to get customers: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Add a new customer
        /// </summary>
        public async Task<Customer?> AddAsync(Customer customer)
        {
            try
            {
                var prestashopRequest = new PrestashopResponse<Customer> { Data = customer };
                var xml = SerializeToXml(prestashopRequest);
                var content = new StringContent(xml, Encoding.UTF8, "application/xml");

                var url = BuildUrl();
                var response = await _httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                var responseXml = await response.Content.ReadAsStringAsync();
                var prestashopResponse = DeserializeFromXml<PrestashopResponse<Customer>>(responseXml);
                return prestashopResponse?.Data;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to add customer: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Update an existing customer
        /// </summary>
        public async Task<Customer?> UpdateAsync(Customer customer)
        {
            try
            {
                if (customer.Id <= 0)
                    throw new ArgumentException("Customer ID is required for update operation");

                var prestashopRequest = new PrestashopResponse<Customer> { Data = customer };
                var xml = SerializeToXml(prestashopRequest);
                var content = new StringContent(xml, Encoding.UTF8, "application/xml");

                var url = BuildUrl(customer.Id);
                var response = await _httpClient.PutAsync(url, content);
                response.EnsureSuccessStatusCode();

                var responseXml = await response.Content.ReadAsStringAsync();
                var prestashopResponse = DeserializeFromXml<PrestashopResponse<Customer>>(responseXml);
                return prestashopResponse?.Data;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to update customer {customer.Id}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Delete a customer
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
                throw new InvalidOperationException($"Failed to delete customer {id}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Get customer by email
        /// </summary>
        public async Task<List<Customer>> GetByEmailAsync(string email)
        {
            try
            {
                var url = $"{BuildUrl()}?filter[email]={Uri.EscapeDataString(email)}";
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var xml = await response.Content.ReadAsStringAsync();
                var prestashopResponse = DeserializeFromXml<PrestashopCollectionResponse<Customer>>(xml);
                return prestashopResponse?.Items ?? new List<Customer>();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to get customer by email {email}: {ex.Message}", ex);
            }
        }
    }
}