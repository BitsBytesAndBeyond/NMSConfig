using System.Collections.Generic;
using System.Xml.Serialization;

namespace NMSConfig.Mxml
{
    [XmlRoot(ElementName = "Data")]
    public class MxmlData
    {
        [XmlElement(ElementName = "Property")]
        public List<MxmlProperty> Property { get; set; }

        [XmlAttribute(AttributeName = "template")]
        public string Template { get; set; }
    }

}
