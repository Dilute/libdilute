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
        /// The XML tag used to denote a package list.
        /// </summary>
        private static readonly string XML_PACKAGE_LIST = "packagelist";
        /// <summary>
        /// The XML tag used to denote a package.
        /// </summary>
        private static readonly string XML_PACKAGE= "package";

        /// <summary>
        /// Parses a package-list file.
        /// </summary>
        /// <param name="stream">The stream to read the XML file from.</param>
        /// <returns>A list <see cref="Package"/> instances describing the information in the XML document.</returns>
        public static List<Package> ParsePackageList(Stream stream)
        {
            List<Package> ret = new List<Package>();
            XmlDocument doc = new XmlDocument();
            doc.Load(stream);

            if(doc.FirstChild != null)
            {
                if(doc.FirstChild.Name.Equals(XML_PACKAGE_LIST))
                {
                    foreach(XmlNode node in doc.FirstChild.ChildNodes)
                    {
                        ret.Add(new Package(node));
                    }
                    return ret;
                }
                Dilute.Error("Failed to parse PackageList XML: Expected top-level 'packagelist' tag, but got top-level '" + doc.FirstChild.Name + "' tag instead");
                return null;
            }
            Dilute.Error("Failed to parse PackageList XML: Expected top-level 'packagelist' tag, but got null instead");
            return null;
        }

        /// <summary>
        /// Parses a library_info or mod_info file.
        /// </summary>
        /// <param name="stream">The stream to read the XML file from.</param>
        /// <returns>A <see cref="Package"/> instance describing the information in the XML document.</returns>
        // TODO Probably useless now that library_info and mod_info have been changed
        public static Package ParsePackage(Stream stream)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(stream);
            if(doc.FirstChild != null)
            {
                if(doc.FirstChild.Name.Equals(XML_PACKAGE))
                {
                    return new Package(doc.FirstChild);
                }
                Dilute.Error("Failed to parse Package XML: Expected top-level 'package' tag, but got top-level '" + doc.FirstChild.Name + "' tag instead");
                return null;
            }
            Dilute.Error("Failed to parse Package XML: Expected top-level 'package' tag, but got null instead");
            return null;
        }
    }
}
