using System.Net.Http;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using HelvyTools.PrestashopAPI.Client.Data;

namespace HelvyTools.PrestashopAPI.Client.Clients
{
    /// <summary>
    /// Base client for Prestashop API operations
    /// </summary>
    public abstract class BaseClient : IDisposable
    {
        protected readonly HttpClient _httpClient;
        protected readonly string _baseUrl;
        protected readonly string _apiKey;

        protected BaseClient(string baseUrl, string apiKey)
        {
            _baseUrl = baseUrl.TrimEnd('/');
            _apiKey = apiKey;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {Convert.ToBase64String(Encoding.ASCII.GetBytes($"{apiKey}:"))}");
        }

        protected abstract string ResourceName { get; }

        /// <summary>
        /// Serializes an object to XML string
        /// </summary>
        protected string SerializeToXml<T>(T obj) where T : class
        {
            var serializer = new XmlSerializer(typeof(T));
            using var stringWriter = new StringWriter();
            using var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true });
            serializer.Serialize(xmlWriter, obj);
            return stringWriter.ToString();
        }

        /// <summary>
        /// Deserializes XML string to object
        /// </summary>
        protected T? DeserializeFromXml<T>(string xml) where T : class
        {
            if (string.IsNullOrEmpty(xml)) return null;
            
            var serializer = new XmlSerializer(typeof(T));
            using var stringReader = new StringReader(xml);
            return serializer.Deserialize(stringReader) as T;
        }

        /// <summary>
        /// Builds the API URL for the resource
        /// </summary>
        protected string BuildUrl(long? id = null, string? format = "xml")
        {
            var url = $"{_baseUrl}/api/{ResourceName}";
            if (id.HasValue)
                url += $"/{id}";
            if (!string.IsNullOrEmpty(format))
                url += $"?output_format={format}";
            return url;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _httpClient?.Dispose();
            }
        }
    }
}