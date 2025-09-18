using System.Xml.Serialization;

namespace HelvyTools.PrestashopAPI.Client.Data
{
    /// <summary>
    /// Represents a Prestashop API response wrapper
    /// </summary>
    /// <typeparam name="T">Type of the contained element</typeparam>
    [XmlRoot("prestashop")]
    public class PrestashopResponse<T> where T : class
    {
        [XmlElement]
        public T? Data { get; set; }

        [XmlAttribute("xmlns:xlink")]
        public string XLink { get; set; } = "http://www.w3.org/1999/xlink";
    }

    /// <summary>
    /// Generic collection response for lists
    /// </summary>
    /// <typeparam name="T">Type of elements in the collection</typeparam>
    [XmlRoot("prestashop")]
    public class PrestashopCollectionResponse<T> where T : class
    {
        [XmlArray]
        [XmlArrayItem]
        public List<T> Items { get; set; } = new List<T>();

        [XmlAttribute("xmlns:xlink")]
        public string XLink { get; set; } = "http://www.w3.org/1999/xlink";
    }
}