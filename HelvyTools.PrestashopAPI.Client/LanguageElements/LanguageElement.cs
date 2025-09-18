using System.Xml.Serialization;
using HelvyTools.PrestashopAPI.Client.Data;

namespace HelvyTools.PrestashopAPI.Client.LanguageElements
{
    /// <summary>
    /// Prestashop Language element
    /// </summary>
    [XmlRoot("language")]
    public class LanguageElement : BaseElement
    {
        [XmlElement("name")]
        public string? Name { get; set; }

        [XmlElement("iso_code")]
        public string? IsoCode { get; set; }

        [XmlElement("language_code")]
        public string? LanguageCode { get; set; }

        [XmlElement("locale")]
        public string? Locale { get; set; }

        [XmlElement("date_format_lite")]
        public string? DateFormatLite { get; set; }

        [XmlElement("date_format_full")]
        public string? DateFormatFull { get; set; }

        [XmlElement("is_rtl")]
        public int? IsRtl { get; set; }

        [XmlElement("active")]
        public int? Active { get; set; }
    }
}