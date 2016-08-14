using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NMSConfig
{
    [XmlRoot(ElementName = "Property")]
    public class MxmlProperty
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "Data")]
    public class MxmlData
    {
        [XmlElement(ElementName = "Property")]
        public List<MxmlProperty> Property { get; set; }

        [XmlAttribute(AttributeName = "template")]
        public string Template { get; set; }
    }

}
