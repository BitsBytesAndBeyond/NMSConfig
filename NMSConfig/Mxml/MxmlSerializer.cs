using System.IO;
using System.Xml.Serialization;

namespace NMSConfig.Mxml
{
    public static class MxmlSerializer
    {
        public static void Serialize(MxmlData mxmlData, string path)
        {
            XmlSerializer mXmlSerializer = new XmlSerializer(typeof(MxmlData));

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            // remove any empty properties.
            mxmlData.Property.RemoveAll(property => string.IsNullOrWhiteSpace(property.Name));

            using (Stream fileStream = File.Open(path, FileMode.Create))

            {
                mXmlSerializer.Serialize(fileStream, mxmlData, ns);
            }
        }

        public static MxmlData Deserialize(string path)
        {
            XmlSerializer mXmlSerializer = new XmlSerializer(typeof(MxmlData));

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            using (var stream = File.OpenRead(path))
            {
               return mXmlSerializer.Deserialize(stream) as MxmlData;
            }
        }
    }
}