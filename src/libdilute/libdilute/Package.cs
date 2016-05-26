using System.Collections.Generic;
using System.Xml;

namespace libdilute
{
    /// <summary>
    /// This class describes a single Dilute package. Can be created via <see cref="XmlParser"/>.
    /// </summary>
    public class Package
    {
        /// <summary>
        /// The unique ID of this package.
        /// </summary>
        public readonly string id;
        /// <summary>
        /// The type of this package.
        /// </summary>
        public readonly PackageType type = PackageType.UNASSIGNED;
        /// <summary>
        /// The different download options available for this package.
        /// </summary>
        public readonly List<Download> downloads;
        /// <summary>
        /// The requirements needed in order to use this package. Every individual download can override these requirements.
        /// </summary>
        public readonly List<Requirement> requirements;
        /// <summary>
        /// A relative URL linking to a file that contains a license that needs to be accepted in order to use this package. Every individual download can override this license.
        /// </summary>
        public readonly string license;

        /// <summary>
        /// Parses the specified XML node into a package.
        /// </summary>
        /// <param name="node">The XML node containing the package information.</param>
        public Package(XmlNode node)
        {
            foreach(XmlNode attrib in node.ChildNodes)
            {
                switch(attrib.Name)
                {
                    case "id":
                        if(id == null)
                        {
                            id = attrib.Value;
                        }
                        else
                        {
                            Dilute.Error("Duplicate 'id' tag in package node");
                        }
                        break;
                    case "type":
                        if(type == PackageType.UNASSIGNED)
                        {
                            type = Package
                        }
                        else
                        {
                            Dilute.Error("Duplicate 'id' tag in package node");
                        }
                        break;
                    default:
                        Dilute.Error("Unknown tag '" + attrib.Name + "' in package node");
                        break;
                }
            }
        }
    }
}