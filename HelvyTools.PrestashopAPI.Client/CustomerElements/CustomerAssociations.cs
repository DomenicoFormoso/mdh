using System.Xml.Serialization;
using HelvyTools.PrestashopAPI.Client.Data;

namespace HelvyTools.PrestashopAPI.Client.CustomerElements
{
    /// <summary>
    /// Customer Group Association
    /// </summary>
    [XmlRoot("group")]
    public class CustomerGroupAssociation : Association
    {
        // Inherits Id from Association base class
    }

    /// <summary>
    /// Customer Address Association
    /// </summary>
    [XmlRoot("address")]
    public class CustomerAddressAssociation : Association
    {
        // Inherits Id from Association base class
    }

    /// <summary>
    /// Customer Order Association
    /// </summary>
    [XmlRoot("order")]
    public class CustomerOrderAssociation : Association
    {
        // Inherits Id from Association base class
    }

    /// <summary>
    /// Customer Message/Thread Association
    /// </summary>
    [XmlRoot("message")]
    public class CustomerMessageAssociation : Association
    {
        [XmlElement("id_customer_thread")]
        public long? IdCustomerThread { get; set; }

        [XmlElement("message")]
        public string? Message { get; set; }

        [XmlElement("date_add")]
        public DateTime? DateAdd { get; set; }
    }
}