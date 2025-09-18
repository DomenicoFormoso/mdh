# HelvyTools.PrestashopAPI.Client

A comprehensive .NET SDK for Prestashop Web Service API providing full CRUD operations for all major Prestashop resources.

## Features

- ✅ Complete CRUD operations (Create, Read, Update, Delete)
- ✅ Full XML serialization support
- ✅ Multilingual field support
- ✅ Association management
- ✅ Type-safe client operations
- ✅ Modern async/await patterns
- ✅ Resource-specific clients
- ✅ Helper utilities for common operations

## Supported Resources

### Core Resources
- **Products** - Complete product management with multilingual support
- **Categories** - Category hierarchy and management
- **Customers** - Customer information and relationships
- **Orders** - Order processing and management
- **Languages** - Language configuration and management

### Additional Resources
- **Addresses** - Customer and supplier addresses
- **Manufacturers** - Manufacturer information
- **Suppliers** - Supplier management
- **Images** - Product image associations
- **Groups** - Customer groups
- **Countries & States** - Geographic data
- **Carts** - Shopping cart management

## Quick Start

### Installation

```bash
dotnet add package HelvyTools.PrestashopAPI.Client
```

### Basic Usage

```csharp
using HelvyTools.PrestashopAPI.Client.Clients;
using HelvyTools.PrestashopAPI.Client.Elements;

// Initialize the API client
var apiClient = new PrestashopApiClient("https://your-prestashop-store.com", "your-api-key");

// Get all products
var products = await apiClient.Products.GetAllAsync();

// Get a specific product
var product = await apiClient.Products.GetAsync(1);

// Create a new product
var newProduct = new Product
{
    Name = MultilingualHelper.CreateSingleLanguage(1, "My Product"),
    Price = 29.99m,
    Active = 1
};
var createdProduct = await apiClient.Products.AddAsync(newProduct);

// Update a product
product.Price = 34.99m;
var updatedProduct = await apiClient.Products.UpdateAsync(product);

// Delete a product
var deleted = await apiClient.Products.DeleteAsync(product.Id);
```

## Working with Multilingual Fields

Many Prestashop fields support multiple languages. Use the `MultilingualHelper` class to work with these fields:

```csharp
using HelvyTools.PrestashopAPI.Client.Helpers;

// Create multilingual name
var productName = MultilingualHelper.CreateLanguages(new Dictionary<long, string>
{
    { 1, "English Product Name" },
    { 2, "French Product Name" },
    { 3, "Spanish Product Name" }
});

// Set on product
var product = new Product
{
    Name = productName,
    Description = MultilingualHelper.CreateSingleLanguage(1, "Product description")
};

// Get specific language value
var englishName = MultilingualHelper.GetLanguageValue(product.Name, 1);

// Update a language value
MultilingualHelper.SetLanguageValue(product.Name, 1, "Updated English Name");
```

## Resource-Specific Clients

### Product Operations

```csharp
var productClient = apiClient.Products;

// Get all products
var allProducts = await productClient.GetAllAsync();

// Get product by ID
var product = await productClient.GetAsync(123);

// Add new product
var newProduct = await productClient.AddAsync(product);

// Update product
var updatedProduct = await productClient.UpdateAsync(product);

// Delete product
var success = await productClient.DeleteAsync(123);
```

### Customer Operations

```csharp
var customerClient = apiClient.Customers;

// Get customer by email
var customers = await customerClient.GetByEmailAsync("customer@example.com");

// Standard CRUD operations
var customer = await customerClient.GetAsync(456);
var newCustomer = await customerClient.AddAsync(customer);
var updatedCustomer = await customerClient.UpdateAsync(customer);
var deleted = await customerClient.DeleteAsync(456);
```

### Category Operations

```csharp
var categoryClient = apiClient.Categories;

// Get categories by parent
var childCategories = await categoryClient.GetByParentAsync(2);

// Standard CRUD operations
var category = await categoryClient.GetAsync(789);
var newCategory = await categoryClient.AddAsync(category);
var updatedCategory = await categoryClient.UpdateAsync(category);
var deleted = await categoryClient.DeleteAsync(789);
```

### Language Operations

```csharp
var languageClient = apiClient.Languages;

// Get active languages
var activeLanguages = await languageClient.GetActiveAsync();

// Get by ISO code
var language = await languageClient.GetByIsoCodeAsync("en");

// Standard CRUD operations
var lang = await languageClient.GetAsync(1);
var newLang = await languageClient.AddAsync(language);
var updatedLang = await languageClient.UpdateAsync(language);
var deleted = await languageClient.DeleteAsync(1);
```

## Project Structure

```
HelvyTools.PrestashopAPI.Client/
├── Data/                    # Base data structures and responses
├── Elements/               # Core Prestashop element models
├── ProductElements/        # Product-specific models and associations
├── CategoryElements/       # Category-specific models and associations
├── CustomerElements/       # Customer-specific models and associations
├── LanguageElements/       # Language-specific models
├── Clients/               # API client implementations
└── Helpers/              # Utility classes and helpers
```

## XML Serialization

All models are designed for XML serialization with proper Prestashop API compatibility:

```csharp
// Models include proper XML attributes
[XmlRoot("product")]
public class Product : BaseElement
{
    [XmlElement("name")]
    public Languages? Name { get; set; }
    
    [XmlElement("price")]
    public decimal? Price { get; set; }
    
    // ... other properties
}
```

## Error Handling

The SDK includes comprehensive error handling:

```csharp
try
{
    var product = await apiClient.Products.GetAsync(999);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"API Error: {ex.Message}");
}
```

## Disposing Resources

Remember to dispose of the API client when done:

```csharp
using var apiClient = new PrestashopApiClient(baseUrl, apiKey);
// Use the client...
// Automatic disposal when exiting using block
```

## License

This project is licensed under the MIT License.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.