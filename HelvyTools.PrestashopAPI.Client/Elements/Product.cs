using System.Xml.Serialization;
using HelvyTools.PrestashopAPI.Client.Data;

namespace HelvyTools.PrestashopAPI.Client.Elements
{
    /// <summary>
    /// Prestashop Product element
    /// </summary>
    [XmlRoot("product")]
    public class Product : BaseElement
    {
        [XmlElement("id_manufacturer")]
        public long? IdManufacturer { get; set; }

        [XmlElement("id_supplier")]
        public long? IdSupplier { get; set; }

        [XmlElement("id_category_default")]
        public long? IdCategoryDefault { get; set; }

        [XmlElement("new")]
        public int? New { get; set; }

        [XmlElement("cache_default_attribute")]
        public long? CacheDefaultAttribute { get; set; }

        [XmlElement("id_default_image")]
        public long? IdDefaultImage { get; set; }

        [XmlElement("id_default_combination")]
        public long? IdDefaultCombination { get; set; }

        [XmlElement("id_tax_rules_group")]
        public long? IdTaxRulesGroup { get; set; }

        [XmlElement("position_in_category")]
        public int? PositionInCategory { get; set; }

        [XmlElement("manufacturer_name")]
        public string? ManufacturerName { get; set; }

        [XmlElement("quantity")]
        public int? Quantity { get; set; }

        [XmlElement("type")]
        public string? Type { get; set; }

        [XmlElement("id_shop_default")]
        public long? IdShopDefault { get; set; }

        [XmlElement("reference")]
        public string? Reference { get; set; }

        [XmlElement("supplier_reference")]
        public string? SupplierReference { get; set; }

        [XmlElement("location")]
        public string? Location { get; set; }

        [XmlElement("width")]
        public decimal? Width { get; set; }

        [XmlElement("height")]
        public decimal? Height { get; set; }

        [XmlElement("depth")]
        public decimal? Depth { get; set; }

        [XmlElement("weight")]
        public decimal? Weight { get; set; }

        [XmlElement("out_of_stock")]
        public int? OutOfStock { get; set; }

        [XmlElement("additional_shipping_cost")]
        public decimal? AdditionalShippingCost { get; set; }

        [XmlElement("quantity_discount")]
        public int? QuantityDiscount { get; set; }

        [XmlElement("ean13")]
        public string? Ean13 { get; set; }

        [XmlElement("isbn")]
        public string? Isbn { get; set; }

        [XmlElement("upc")]
        public string? Upc { get; set; }

        [XmlElement("mpn")]
        public string? Mpn { get; set; }

        [XmlElement("ecotax")]
        public decimal? Ecotax { get; set; }

        [XmlElement("unity")]
        public string? Unity { get; set; }

        [XmlElement("unit_price_ratio")]
        public decimal? UnitPriceRatio { get; set; }

        [XmlElement("minimal_quantity")]
        public int? MinimalQuantity { get; set; }

        [XmlElement("low_stock_threshold")]
        public int? LowStockThreshold { get; set; }

        [XmlElement("low_stock_alert")]
        public int? LowStockAlert { get; set; }

        [XmlElement("price")]
        public decimal? Price { get; set; }

        [XmlElement("wholesale_price")]
        public decimal? WholesalePrice { get; set; }

        [XmlElement("on_sale")]
        public int? OnSale { get; set; }

        [XmlElement("online_only")]
        public int? OnlineOnly { get; set; }

        [XmlElement("redirect_type")]
        public string? RedirectType { get; set; }

        [XmlElement("id_type_redirected")]
        public long? IdTypeRedirected { get; set; }

        [XmlElement("available_for_order")]
        public int? AvailableForOrder { get; set; }

        [XmlElement("available_date")]
        public DateTime? AvailableDate { get; set; }

        [XmlElement("show_condition")]
        public int? ShowCondition { get; set; }

        [XmlElement("condition")]
        public string? Condition { get; set; }

        [XmlElement("show_price")]
        public int? ShowPrice { get; set; }

        [XmlElement("indexed")]
        public int? Indexed { get; set; }

        [XmlElement("visibility")]
        public string? Visibility { get; set; }

        [XmlElement("advanced_stock_management")]
        public int? AdvancedStockManagement { get; set; }

        [XmlElement("date_add")]
        public DateTime? DateAdd { get; set; }

        [XmlElement("date_upd")]
        public DateTime? DateUpd { get; set; }

        [XmlElement("pack_stock_type")]
        public int? PackStockType { get; set; }

        [XmlElement("state")]
        public int? State { get; set; }

        [XmlElement("active")]
        public int? Active { get; set; }

        // Multilingual fields
        [XmlElement("name")]
        public Languages? Name { get; set; }

        [XmlElement("description")]
        public Languages? Description { get; set; }

        [XmlElement("description_short")]
        public Languages? DescriptionShort { get; set; }

        [XmlElement("link_rewrite")]
        public Languages? LinkRewrite { get; set; }

        [XmlElement("meta_description")]
        public Languages? MetaDescription { get; set; }

        [XmlElement("meta_keywords")]
        public Languages? MetaKeywords { get; set; }

        [XmlElement("meta_title")]
        public Languages? MetaTitle { get; set; }

        [XmlElement("available_now")]
        public Languages? AvailableNow { get; set; }

        [XmlElement("available_later")]
        public Languages? AvailableLater { get; set; }

        [XmlElement("delivery_in_stock")]
        public Languages? DeliveryInStock { get; set; }

        [XmlElement("delivery_out_stock")]
        public Languages? DeliveryOutStock { get; set; }
    }
}