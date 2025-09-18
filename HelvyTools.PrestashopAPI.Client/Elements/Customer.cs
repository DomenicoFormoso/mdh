using System.Xml.Serialization;
using HelvyTools.PrestashopAPI.Client.Data;

namespace HelvyTools.PrestashopAPI.Client.Elements
{
    /// <summary>
    /// Prestashop Customer element
    /// </summary>
    [XmlRoot("customer")]
    public class Customer : BaseElement
    {
        [XmlElement("id_default_group")]
        public long? IdDefaultGroup { get; set; }

        [XmlElement("id_lang")]
        public long? IdLang { get; set; }

        [XmlElement("newsletter_date_add")]
        public DateTime? NewsletterDateAdd { get; set; }

        [XmlElement("ip_registration_newsletter")]
        public string? IpRegistrationNewsletter { get; set; }

        [XmlElement("last_passwd_gen")]
        public DateTime? LastPasswdGen { get; set; }

        [XmlElement("secure_key")]
        public string? SecureKey { get; set; }

        [XmlElement("deleted")]
        public int? Deleted { get; set; }

        [XmlElement("passwd")]
        public string? Passwd { get; set; }

        [XmlElement("lastname")]
        public string? Lastname { get; set; }

        [XmlElement("firstname")]
        public string? Firstname { get; set; }

        [XmlElement("email")]
        public string? Email { get; set; }

        [XmlElement("id_gender")]
        public long? IdGender { get; set; }

        [XmlElement("birthday")]
        public DateTime? Birthday { get; set; }

        [XmlElement("newsletter")]
        public int? Newsletter { get; set; }

        [XmlElement("optin")]
        public int? Optin { get; set; }

        [XmlElement("website")]
        public string? Website { get; set; }

        [XmlElement("company")]
        public string? Company { get; set; }

        [XmlElement("siret")]
        public string? Siret { get; set; }

        [XmlElement("ape")]
        public string? Ape { get; set; }

        [XmlElement("outstanding_allow_amount")]
        public decimal? OutstandingAllowAmount { get; set; }

        [XmlElement("show_public_prices")]
        public int? ShowPublicPrices { get; set; }

        [XmlElement("id_risk")]
        public long? IdRisk { get; set; }

        [XmlElement("max_payment_days")]
        public int? MaxPaymentDays { get; set; }

        [XmlElement("active")]
        public int? Active { get; set; }

        [XmlElement("note")]
        public string? Note { get; set; }

        [XmlElement("is_guest")]
        public int? IsGuest { get; set; }

        [XmlElement("id_shop")]
        public long? IdShop { get; set; }

        [XmlElement("id_shop_group")]
        public long? IdShopGroup { get; set; }

        [XmlElement("date_add")]
        public DateTime? DateAdd { get; set; }

        [XmlElement("date_upd")]
        public DateTime? DateUpd { get; set; }

        [XmlElement("reset_password_token")]
        public string? ResetPasswordToken { get; set; }

        [XmlElement("reset_password_validity")]
        public DateTime? ResetPasswordValidity { get; set; }
    }
}