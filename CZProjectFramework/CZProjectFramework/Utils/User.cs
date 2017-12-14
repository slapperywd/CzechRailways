using System.Xml.Serialization;

namespace CZProjectFramework.Utils
{
    [XmlRoot("User")]
    public class User
    {
        [XmlElement("name")]
        public string UserName { get; set; }

        [XmlElement("surname")]
        public string UserSurName { get; set; }

        [XmlElement("email")]
        public string Email { get; set; }

        [XmlElement("password")]
        public string Password { get; set; }

        [XmlElement("city")]
        public string City { get; set; }

        [XmlElement("street")]
        public string Street { get; set; }

        [XmlElement("country")]
        public string Country { get; set; }
    }
}
