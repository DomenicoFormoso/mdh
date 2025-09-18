using System.Xml.Serialization;
using HelvyTools.PrestashopAPI.Client.Data;

namespace HelvyTools.PrestashopAPI.Client.Elements
{
    /// <summary>
    /// Prestashop Image element
    /// </summary>
    [XmlRoot("image")]
    public class Image : BaseElement
    {
        [XmlElement("id_product")]
        public long? IdProduct { get; set; }

        [XmlElement("position")]
        public int? Position { get; set; }

        [XmlElement("cover")]
        public int? Cover { get; set; }

        [XmlElement("legend")]
        public Languages? Legend { get; set; }
    }

    /// <summary>
    /// Prestashop Group element
    /// </summary>
    [XmlRoot("group")]
    public class Group : BaseElement
    {
        [XmlElement("reduction")]
        public decimal? Reduction { get; set; }

        [XmlElement("price_display_method")]
        public int? PriceDisplayMethod { get; set; }

        [XmlElement("show_prices")]
        public int? ShowPrices { get; set; }

        [XmlElement("date_add")]
        public DateTime? DateAdd { get; set; }

        [XmlElement("date_upd")]
        public DateTime? DateUpd { get; set; }

        [XmlElement("name")]
        public Languages? Name { get; set; }
    }

    /// <summary>
    /// Prestashop Country element
    /// </summary>
    [XmlRoot("country")]
    public class Country : BaseElement
    {
        [XmlElement("id_zone")]
        public long? IdZone { get; set; }

        [XmlElement("id_currency")]
        public long? IdCurrency { get; set; }

        [XmlElement("iso_code")]
        public string? IsoCode { get; set; }

        [XmlElement("call_prefix")]
        public int? CallPrefix { get; set; }

        [XmlElement("active")]
        public int? Active { get; set; }

        [XmlElement("contains_states")]
        public int? ContainsStates { get; set; }

        [XmlElement("need_identification_number")]
        public int? NeedIdentificationNumber { get; set; }

        [XmlElement("need_zip_code")]
        public int? NeedZipCode { get; set; }

        [XmlElement("zip_code_format")]
        public string? ZipCodeFormat { get; set; }

        [XmlElement("display_tax_label")]
        public int? DisplayTaxLabel { get; set; }

        [XmlElement("name")]
        public Languages? Name { get; set; }
    }

    /// <summary>
    /// Prestashop State element
    /// </summary>
    [XmlRoot("state")]
    public class State : BaseElement
    {
        [XmlElement("id_country")]
        public long? IdCountry { get; set; }

        [XmlElement("id_zone")]
        public long? IdZone { get; set; }

        [XmlElement("iso_code")]
        public string? IsoCode { get; set; }

        [XmlElement("active")]
        public int? Active { get; set; }

        [XmlElement("name")]
        public string? Name { get; set; }
    }

    /// <summary>
    /// Prestashop Cart element
    /// </summary>
    [XmlRoot("cart")]
    public class Cart : BaseElement
    {
        [XmlElement("id_address_delivery")]
        public long? IdAddressDelivery { get; set; }

        [XmlElement("id_address_invoice")]
        public long? IdAddressInvoice { get; set; }

        [XmlElement("id_currency")]
        public long? IdCurrency { get; set; }

        [XmlElement("id_customer")]
        public long? IdCustomer { get; set; }

        [XmlElement("id_guest")]
        public long? IdGuest { get; set; }

        [XmlElement("id_lang")]
        public long? IdLang { get; set; }

        [XmlElement("id_shop_group")]
        public long? IdShopGroup { get; set; }

        [XmlElement("id_shop")]
        public long? IdShop { get; set; }

        [XmlElement("id_carrier")]
        public long? IdCarrier { get; set; }

        [XmlElement("recyclable")]
        public int? Recyclable { get; set; }

        [XmlElement("gift")]
        public int? Gift { get; set; }

        [XmlElement("gift_message")]
        public string? GiftMessage { get; set; }

        [XmlElement("mobile_theme")]
        public int? MobileTheme { get; set; }

        [XmlElement("delivery_option")]
        public string? DeliveryOption { get; set; }

        [XmlElement("secure_key")]
        public string? SecureKey { get; set; }

        [XmlElement("allow_seperated_package")]
        public int? AllowSeperatedPackage { get; set; }

        [XmlElement("date_add")]
        public DateTime? DateAdd { get; set; }

        [XmlElement("date_upd")]
        public DateTime? DateUpd { get; set; }
    }
}