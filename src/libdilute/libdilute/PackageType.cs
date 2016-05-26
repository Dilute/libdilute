namespace libdilute
{
    /// <summary>
    /// The different types of packages
    /// </summary>
    public enum PackageType
    {
        /// <summary>
        /// Only used when construcing a new package. An error will be recorded when a package with this type is installed.
        /// </summary>
        UNASSIGNED,
        /// <summary>
        /// A library is typically used in order to reduce the amount of code every mod has to contain by including it in one shared dependency.
        /// </summary>
        LIBRARY,
        /// <summary>
        /// A mod typically utilizes libraries in order to modify game content.
        /// </summary>
        MOD
    }
}