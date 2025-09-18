using System.Xml.Serialization;
using HelvyTools.PrestashopAPI.Client.Data;

namespace HelvyTools.PrestashopAPI.Client.Elements
{
    /// <summary>
    /// Prestashop Category element
    /// </summary>
    [XmlRoot("category")]
    public class Category : BaseElement
    {
        [XmlElement("id_parent")]
        public long? IdParent { get; set; }

        [XmlElement("id_shop_default")]
        public long? IdShopDefault { get; set; }

        [XmlElement("level_depth")]
        public int? LevelDepth { get; set; }

        [XmlElement("nleft")]
        public int? Nleft { get; set; }

        [XmlElement("nright")]
        public int? Nright { get; set; }

        [XmlElement("active")]
        public int? Active { get; set; }

        [XmlElement("date_add")]
        public DateTime? DateAdd { get; set; }

        [XmlElement("date_upd")]
        public DateTime? DateUpd { get; set; }

        [XmlElement("position")]
        public int? Position { get; set; }

        [XmlElement("is_root_category")]
        public int? IsRootCategory { get; set; }

        // Multilingual fields
        [XmlElement("name")]
        public Languages? Name { get; set; }

        [XmlElement("description")]
        public Languages? Description { get; set; }

        [XmlElement("link_rewrite")]
        public Languages? LinkRewrite { get; set; }

        [XmlElement("meta_title")]
        public Languages? MetaTitle { get; set; }

        [XmlElement("meta_description")]
        public Languages? MetaDescription { get; set; }

        [XmlElement("meta_keywords")]
        public Languages? MetaKeywords { get; set; }
    }
}