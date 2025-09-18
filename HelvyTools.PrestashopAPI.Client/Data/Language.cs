using System.Xml.Serialization;

namespace HelvyTools.PrestashopAPI.Client.Data
{
    /// <summary>
    /// Represents a language reference with ID for multilingual fields
    /// </summary>
    [XmlRoot("language")]
    public class Language
    {
        [XmlAttribute("id")]
        public long Id { get; set; }

        [XmlText]
        public string Value { get; set; } = string.Empty;
    }

    /// <summary>
    /// Collection of language items
    /// </summary>
    [XmlRoot("languages")]
    public class Languages
    {
        [XmlElement("language")]
        public List<Language> Items { get; set; } = new List<Language>();
    }
}