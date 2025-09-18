using System.Xml.Serialization;

namespace HelvyTools.PrestashopAPI.Client.Data
{
    /// <summary>
    /// Base class for all Prestashop API elements
    /// </summary>
    [XmlRoot]
    public abstract class BaseElement
    {
        [XmlAttribute("id")]
        public long Id { get; set; }

        [XmlAttribute("href")]
        public string? Href { get; set; }
    }
}