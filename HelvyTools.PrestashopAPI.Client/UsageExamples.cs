using HelvyTools.PrestashopAPI.Client.Clients;
using HelvyTools.PrestashopAPI.Client.Elements;
using HelvyTools.PrestashopAPI.Client.Helpers;

namespace HelvyTools.PrestashopAPI.Client.Examples
{
    /// <summary>
    /// Example usage of the Prestashop API Client
    /// </summary>
    public class UsageExamples
    {
        private readonly PrestashopApiClient _apiClient;

        public UsageExamples(string baseUrl, string apiKey)
        {
            _apiClient = new PrestashopApiClient(baseUrl, apiKey);
        }

        /// <summary>
        /// Example: Working with Products
        /// </summary>
        public async Task ProductExamples()
        {
            // Get all products
            var products = await _apiClient.Products.GetAllAsync();
            Console.WriteLine($"Found {products.Count} products");

            // Create a new product with multilingual name
            var newProduct = new Product
            {
                Name = MultilingualHelper.CreateLanguages(new Dictionary<long, string>
                {
                    { 1, "Example Product" },
                    { 2, "Produit Exemple" }
                }),
                Description = MultilingualHelper.CreateSingleLanguage(1, "This is an example product"),
                Price = 29.99m,
                Active = 1,
                IdCategoryDefault = 2, // Assign to category
                Reference = "EX001"
            };

            var createdProduct = await _apiClient.Products.AddAsync(newProduct);
            Console.WriteLine($"Created product with ID: {createdProduct?.Id}");

            // Update the product
            if (createdProduct != null)
            {
                createdProduct.Price = 34.99m;
                var updatedProduct = await _apiClient.Products.UpdateAsync(createdProduct);
                Console.WriteLine($"Updated product price to: {updatedProduct?.Price}");
            }
        }

        /// <summary>
        /// Example: Working with Customers
        /// </summary>
        public async Task CustomerExamples()
        {
            // Get all customers
            var customers = await _apiClient.Customers.GetAllAsync();
            Console.WriteLine($"Found {customers.Count} customers");

            // Create a new customer
            var newCustomer = new Customer
            {
                Firstname = "John",
                Lastname = "Doe",
                Email = "john.doe@example.com",
                IdLang = 1,
                IdDefaultGroup = 3,
                Active = 1
            };

            var createdCustomer = await _apiClient.Customers.AddAsync(newCustomer);
            Console.WriteLine($"Created customer with ID: {createdCustomer?.Id}");

            // Find customer by email
            var foundCustomers = await _apiClient.Customers.GetByEmailAsync("john.doe@example.com");
            Console.WriteLine($"Found {foundCustomers.Count} customers with that email");
        }

        /// <summary>
        /// Example: Working with Categories
        /// </summary>
        public async Task CategoryExamples()
        {
            // Get all categories
            var categories = await _apiClient.Categories.GetAllAsync();
            Console.WriteLine($"Found {categories.Count} categories");

            // Create a new category
            var newCategory = new Category
            {
                Name = MultilingualHelper.CreateLanguages(new Dictionary<long, string>
                {
                    { 1, "New Category" },
                    { 2, "Nouvelle Catégorie" }
                }),
                Description = MultilingualHelper.CreateSingleLanguage(1, "Category description"),
                IdParent = 2, // Parent category
                Active = 1
            };

            var createdCategory = await _apiClient.Categories.AddAsync(newCategory);
            Console.WriteLine($"Created category with ID: {createdCategory?.Id}");

            // Get child categories
            if (createdCategory != null)
            {
                var childCategories = await _apiClient.Categories.GetByParentAsync(createdCategory.Id);
                Console.WriteLine($"Found {childCategories.Count} child categories");
            }
        }

        /// <summary>
        /// Example: Working with Languages
        /// </summary>
        public async Task LanguageExamples()
        {
            // Get all active languages
            var activeLanguages = await _apiClient.Languages.GetActiveAsync();
            Console.WriteLine($"Found {activeLanguages.Count} active languages");

            // Get language by ISO code
            var englishLanguages = await _apiClient.Languages.GetByIsoCodeAsync("en");
            Console.WriteLine($"Found {englishLanguages.Count} English languages");

            // Print all languages
            foreach (var lang in activeLanguages)
            {
                Console.WriteLine($"Language: {lang.Name} (ISO: {lang.IsoCode})");
            }
        }

        /// <summary>
        /// Example: Using helper methods
        /// </summary>
        public void HelperExamples()
        {
            // Working with multilingual fields
            var multilingualName = MultilingualHelper.CreateLanguages(new Dictionary<long, string>
            {
                { 1, "English Name" },
                { 2, "French Name" },
                { 3, "Spanish Name" }
            });

            // Get value for specific language
            var englishName = MultilingualHelper.GetLanguageValue(multilingualName, 1);
            Console.WriteLine($"English name: {englishName}");

            // Get all language values
            var allValues = MultilingualHelper.GetAllLanguageValues(multilingualName);
            foreach (var kvp in allValues)
            {
                Console.WriteLine($"Language {kvp.Key}: {kvp.Value}");
            }

            // Update a language value
            MultilingualHelper.SetLanguageValue(multilingualName, 1, "Updated English Name");
            Console.WriteLine($"Updated English name: {MultilingualHelper.GetLanguageValue(multilingualName, 1)}");
        }

        public void Dispose()
        {
            _apiClient?.Dispose();
        }
    }
}