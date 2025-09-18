using System.Xml.Serialization;

namespace HelvyTools.PrestashopAPI.Client.Data
{
    /// <summary>
    /// Represents a multilingual description field in Prestashop
    /// </summary>
    [XmlRoot("description")]
    public class Description
    {
        [XmlAttribute("id")]
        public long Id { get; set; }

        [XmlText]
        public string Value { get; set; } = string.Empty;
    }

    /// <summary>
    /// Collection of multilingual descriptions
    /// </summary>
    [XmlRoot("descriptions")]
    public class Descriptions
    {
        [XmlElement("description")]
        public List<Description> Items { get; set; } = new List<Description>();
    }
}