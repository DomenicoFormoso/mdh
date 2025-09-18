using System.Xml.Serialization;
using HelvyTools.PrestashopAPI.Client.Data;

namespace HelvyTools.PrestashopAPI.Client.CategoryElements
{
    /// <summary>
    /// Category Product Association
    /// </summary>
    [XmlRoot("product")]
    public class CategoryProductAssociation : Association
    {
        // Inherits Id from Association base class
    }

    /// <summary>
    /// Category Group Association
    /// </summary>
    [XmlRoot("group")]
    public class CategoryGroupAssociation : Association
    {
        // Inherits Id from Association base class
    }

    /// <summary>
    /// Category Tree Structure
    /// </summary>
    [XmlRoot("category_tree")]
    public class CategoryTree : BaseElement
    {
        [XmlElement("id_parent")]
        public long? IdParent { get; set; }

        [XmlElement("level_depth")]
        public int? LevelDepth { get; set; }

        [XmlElement("name")]
        public Languages? Name { get; set; }

        [XmlElement("children")]
        public List<CategoryTree>? Children { get; set; }
    }
}