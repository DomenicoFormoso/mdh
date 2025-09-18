namespace HelvyTools.PrestashopAPI.Client.Clients
{
    /// <summary>
    /// Factory for creating Prestashop API clients
    /// </summary>
    public class PrestashopClientFactory
    {
        private readonly string _baseUrl;
        private readonly string _apiKey;

        public PrestashopClientFactory(string baseUrl, string apiKey)
        {
            _baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        }

        /// <summary>
        /// Create a Product client
        /// </summary>
        public ProductClient CreateProductClient()
        {
            return new ProductClient(_baseUrl, _apiKey);
        }

        /// <summary>
        /// Create a Customer client
        /// </summary>
        public CustomerClient CreateCustomerClient()
        {
            return new CustomerClient(_baseUrl, _apiKey);
        }

        /// <summary>
        /// Create a Category client
        /// </summary>
        public CategoryClient CreateCategoryClient()
        {
            return new CategoryClient(_baseUrl, _apiKey);
        }

        /// <summary>
        /// Create a Language client
        /// </summary>
        public LanguageClient CreateLanguageClient()
        {
            return new LanguageClient(_baseUrl, _apiKey);
        }
    }

    /// <summary>
    /// Main Prestashop API client that provides access to all resources
    /// </summary>
    public class PrestashopApiClient : IDisposable
    {
        private readonly PrestashopClientFactory _factory;
        private bool _disposed = false;

        // Lazy initialization of clients
        private readonly Lazy<ProductClient> _productClient;
        private readonly Lazy<CustomerClient> _customerClient;
        private readonly Lazy<CategoryClient> _categoryClient;
        private readonly Lazy<LanguageClient> _languageClient;

        public PrestashopApiClient(string baseUrl, string apiKey)
        {
            _factory = new PrestashopClientFactory(baseUrl, apiKey);
            
            _productClient = new Lazy<ProductClient>(() => _factory.CreateProductClient());
            _customerClient = new Lazy<CustomerClient>(() => _factory.CreateCustomerClient());
            _categoryClient = new Lazy<CategoryClient>(() => _factory.CreateCategoryClient());
            _languageClient = new Lazy<LanguageClient>(() => _factory.CreateLanguageClient());
        }

        /// <summary>
        /// Product operations client
        /// </summary>
        public ProductClient Products => _productClient.Value;

        /// <summary>
        /// Customer operations client
        /// </summary>
        public CustomerClient Customers => _customerClient.Value;

        /// <summary>
        /// Category operations client
        /// </summary>
        public CategoryClient Categories => _categoryClient.Value;

        /// <summary>
        /// Language operations client
        /// </summary>
        public LanguageClient Languages => _languageClient.Value;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                if (_productClient.IsValueCreated)
                    _productClient.Value.Dispose();
                if (_customerClient.IsValueCreated)
                    _customerClient.Value.Dispose();
                if (_categoryClient.IsValueCreated)
                    _categoryClient.Value.Dispose();
                if (_languageClient.IsValueCreated)
                    _languageClient.Value.Dispose();

                _disposed = true;
            }
        }
    }
}