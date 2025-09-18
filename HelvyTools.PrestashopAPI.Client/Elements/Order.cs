using System.Xml.Serialization;
using HelvyTools.PrestashopAPI.Client.Data;

namespace HelvyTools.PrestashopAPI.Client.Elements
{
    /// <summary>
    /// Prestashop Order element
    /// </summary>
    [XmlRoot("order")]
    public class Order : BaseElement
    {
        [XmlElement("id_address_delivery")]
        public long? IdAddressDelivery { get; set; }

        [XmlElement("id_address_invoice")]
        public long? IdAddressInvoice { get; set; }

        [XmlElement("id_cart")]
        public long? IdCart { get; set; }

        [XmlElement("id_currency")]
        public long? IdCurrency { get; set; }

        [XmlElement("id_lang")]
        public long? IdLang { get; set; }

        [XmlElement("id_customer")]
        public long? IdCustomer { get; set; }

        [XmlElement("id_carrier")]
        public long? IdCarrier { get; set; }

        [XmlElement("current_state")]
        public long? CurrentState { get; set; }

        [XmlElement("module")]
        public string? Module { get; set; }

        [XmlElement("invoice_number")]
        public long? InvoiceNumber { get; set; }

        [XmlElement("invoice_date")]
        public DateTime? InvoiceDate { get; set; }

        [XmlElement("delivery_number")]
        public long? DeliveryNumber { get; set; }

        [XmlElement("delivery_date")]
        public DateTime? DeliveryDate { get; set; }

        [XmlElement("valid")]
        public int? Valid { get; set; }

        [XmlElement("date_add")]
        public DateTime? DateAdd { get; set; }

        [XmlElement("date_upd")]
        public DateTime? DateUpd { get; set; }

        [XmlElement("shipping_number")]
        public string? ShippingNumber { get; set; }

        [XmlElement("note")]
        public string? Note { get; set; }

        [XmlElement("id_shop_group")]
        public long? IdShopGroup { get; set; }

        [XmlElement("id_shop")]
        public long? IdShop { get; set; }

        [XmlElement("secure_key")]
        public string? SecureKey { get; set; }

        [XmlElement("payment")]
        public string? Payment { get; set; }

        [XmlElement("recyclable")]
        public int? Recyclable { get; set; }

        [XmlElement("gift")]
        public int? Gift { get; set; }

        [XmlElement("gift_message")]
        public string? GiftMessage { get; set; }

        [XmlElement("mobile_theme")]
        public int? MobileTheme { get; set; }

        [XmlElement("total_discounts")]
        public decimal? TotalDiscounts { get; set; }

        [XmlElement("total_discounts_tax_incl")]
        public decimal? TotalDiscountsTaxIncl { get; set; }

        [XmlElement("total_discounts_tax_excl")]
        public decimal? TotalDiscountsTaxExcl { get; set; }

        [XmlElement("total_paid")]
        public decimal? TotalPaid { get; set; }

        [XmlElement("total_paid_tax_incl")]
        public decimal? TotalPaidTaxIncl { get; set; }

        [XmlElement("total_paid_tax_excl")]
        public decimal? TotalPaidTaxExcl { get; set; }

        [XmlElement("total_paid_real")]
        public decimal? TotalPaidReal { get; set; }

        [XmlElement("total_products")]
        public decimal? TotalProducts { get; set; }

        [XmlElement("total_products_wt")]
        public decimal? TotalProductsWt { get; set; }

        [XmlElement("total_shipping")]
        public decimal? TotalShipping { get; set; }

        [XmlElement("total_shipping_tax_incl")]
        public decimal? TotalShippingTaxIncl { get; set; }

        [XmlElement("total_shipping_tax_excl")]
        public decimal? TotalShippingTaxExcl { get; set; }

        [XmlElement("carrier_tax_rate")]
        public decimal? CarrierTaxRate { get; set; }

        [XmlElement("total_wrapping")]
        public decimal? TotalWrapping { get; set; }

        [XmlElement("total_wrapping_tax_incl")]
        public decimal? TotalWrappingTaxIncl { get; set; }

        [XmlElement("total_wrapping_tax_excl")]
        public decimal? TotalWrappingTaxExcl { get; set; }

        [XmlElement("round_mode")]
        public int? RoundMode { get; set; }

        [XmlElement("round_type")]
        public int? RoundType { get; set; }

        [XmlElement("conversion_rate")]
        public decimal? ConversionRate { get; set; }

        [XmlElement("reference")]
        public string? Reference { get; set; }
    }
}