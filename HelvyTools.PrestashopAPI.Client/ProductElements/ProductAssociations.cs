using System.Xml.Serialization;
using HelvyTools.PrestashopAPI.Client.Data;

namespace HelvyTools.PrestashopAPI.Client.ProductElements
{
    /// <summary>
    /// Product Category Association
    /// </summary>
    [XmlRoot("category")]
    public class ProductCategoryAssociation : Association
    {
        // Inherits Id from Association base class
    }

    /// <summary>
    /// Product Image Association
    /// </summary>
    [XmlRoot("image")]
    public class ProductImageAssociation : Association
    {
        // Inherits Id from Association base class
    }

    /// <summary>
    /// Product Feature Association
    /// </summary>
    [XmlRoot("product_feature")]
    public class ProductFeatureAssociation : Association
    {
        [XmlAttribute("id_feature_value")]
        public long IdFeatureValue { get; set; }
    }

    /// <summary>
    /// Product Option Association
    /// </summary>
    [XmlRoot("product_option_value")]
    public class ProductOptionAssociation : Association
    {
        // Inherits Id from Association base class
    }

    /// <summary>
    /// Product Bundle/Pack Association
    /// </summary>
    [XmlRoot("product_bundle")]
    public class ProductBundleAssociation : Association
    {
        [XmlAttribute("quantity")]
        public int Quantity { get; set; }
    }

    /// <summary>
    /// Stock Available for Product
    /// </summary>
    [XmlRoot("stock_available")]
    public class StockAvailable : BaseElement
    {
        [XmlElement("id_product")]
        public long? IdProduct { get; set; }

        [XmlElement("id_product_attribute")]
        public long? IdProductAttribute { get; set; }

        [XmlElement("id_shop")]
        public long? IdShop { get; set; }

        [XmlElement("id_shop_group")]
        public long? IdShopGroup { get; set; }

        [XmlElement("quantity")]
        public int? Quantity { get; set; }

        [XmlElement("depends_on_stock")]
        public int? DependsOnStock { get; set; }

        [XmlElement("out_of_stock")]
        public int? OutOfStock { get; set; }

        [XmlElement("location")]
        public string? Location { get; set; }
    }
}