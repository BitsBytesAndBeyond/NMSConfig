using System.Xml.Serialization;

namespace NMSConfig.Mxml
{
    [XmlRoot(ElementName = "Property")]
    public class MxmlProperty
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
}