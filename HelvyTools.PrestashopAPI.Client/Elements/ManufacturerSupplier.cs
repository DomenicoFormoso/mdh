using System.Xml.Serialization;
using HelvyTools.PrestashopAPI.Client.Data;

namespace HelvyTools.PrestashopAPI.Client.Elements
{
    /// <summary>
    /// Prestashop Manufacturer element
    /// </summary>
    [XmlRoot("manufacturer")]
    public class Manufacturer : BaseElement
    {
        [XmlElement("active")]
        public int? Active { get; set; }

        [XmlElement("name")]
        public string? Name { get; set; }

        [XmlElement("date_add")]
        public DateTime? DateAdd { get; set; }

        [XmlElement("date_upd")]
        public DateTime? DateUpd { get; set; }

        // Multilingual fields
        [XmlElement("description")]
        public Languages? Description { get; set; }

        [XmlElement("short_description")]
        public Languages? ShortDescription { get; set; }

        [XmlElement("meta_title")]
        public Languages? MetaTitle { get; set; }

        [XmlElement("meta_description")]
        public Languages? MetaDescription { get; set; }

        [XmlElement("meta_keywords")]
        public Languages? MetaKeywords { get; set; }
    }

    /// <summary>
    /// Prestashop Supplier element
    /// </summary>
    [XmlRoot("supplier")]
    public class Supplier : BaseElement
    {
        [XmlElement("active")]
        public int? Active { get; set; }

        [XmlElement("name")]
        public string? Name { get; set; }

        [XmlElement("date_add")]
        public DateTime? DateAdd { get; set; }

        [XmlElement("date_upd")]
        public DateTime? DateUpd { get; set; }

        // Multilingual fields
        [XmlElement("description")]
        public Languages? Description { get; set; }

        [XmlElement("meta_title")]
        public Languages? MetaTitle { get; set; }

        [XmlElement("meta_description")]
        public Languages? MetaDescription { get; set; }

        [XmlElement("meta_keywords")]
        public Languages? MetaKeywords { get; set; }
    }
}