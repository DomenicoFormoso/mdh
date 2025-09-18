using System.Xml.Serialization;

namespace HelvyTools.PrestashopAPI.Client.Data
{
    /// <summary>
    /// Base class for associations between entities
    /// </summary>
    [XmlRoot]
    public class Association
    {
        [XmlAttribute("id")]
        public long Id { get; set; }
    }

    /// <summary>
    /// Generic association collection
    /// </summary>
    /// <typeparam name="T">Type of association</typeparam>
    public class AssociationCollection<T> where T : Association
    {
        [XmlElement]
        public List<T> Items { get; set; } = new List<T>();
    }
}