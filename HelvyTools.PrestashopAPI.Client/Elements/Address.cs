using System.Xml.Serialization;
using HelvyTools.PrestashopAPI.Client.Data;

namespace HelvyTools.PrestashopAPI.Client.Elements
{
    /// <summary>
    /// Prestashop Address element
    /// </summary>
    [XmlRoot("address")]
    public class Address : BaseElement
    {
        [XmlElement("id_customer")]
        public long? IdCustomer { get; set; }

        [XmlElement("id_manufacturer")]
        public long? IdManufacturer { get; set; }

        [XmlElement("id_supplier")]
        public long? IdSupplier { get; set; }

        [XmlElement("id_warehouse")]
        public long? IdWarehouse { get; set; }

        [XmlElement("id_country")]
        public long? IdCountry { get; set; }

        [XmlElement("id_state")]
        public long? IdState { get; set; }

        [XmlElement("alias")]
        public string? Alias { get; set; }

        [XmlElement("company")]
        public string? Company { get; set; }

        [XmlElement("lastname")]
        public string? Lastname { get; set; }

        [XmlElement("firstname")]
        public string? Firstname { get; set; }

        [XmlElement("address1")]
        public string? Address1 { get; set; }

        [XmlElement("address2")]
        public string? Address2 { get; set; }

        [XmlElement("postcode")]
        public string? Postcode { get; set; }

        [XmlElement("city")]
        public string? City { get; set; }

        [XmlElement("other")]
        public string? Other { get; set; }

        [XmlElement("phone")]
        public string? Phone { get; set; }

        [XmlElement("phone_mobile")]
        public string? PhoneMobile { get; set; }

        [XmlElement("vat_number")]
        public string? VatNumber { get; set; }

        [XmlElement("dni")]
        public string? Dni { get; set; }

        [XmlElement("date_add")]
        public DateTime? DateAdd { get; set; }

        [XmlElement("date_upd")]
        public DateTime? DateUpd { get; set; }

        [XmlElement("active")]
        public int? Active { get; set; }

        [XmlElement("deleted")]
        public int? Deleted { get; set; }
    }
}