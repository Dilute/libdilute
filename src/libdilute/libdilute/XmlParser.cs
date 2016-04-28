using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace libdilute
{
    /// <summary>
    /// Simple XML parser that can parse the various XML documents we need.
    /// </summary>
    class XmlParser
    {
        /// <summary>
        /// Parses a package-list file.
        /// </summary>
        /// <param name="stream">The stream to read the XML file from.</param>
        public static List<Package> ParsePackageList(Stream stream)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(stream);

            return null;
        }
    }
}
