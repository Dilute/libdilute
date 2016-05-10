namespace libdilute
{
    /// <summary>
    /// Different levels of severity for messages recieved via <see cref="Dilute.nextMessage"/>.
    /// </summary>
    public enum Level
    {
        /// <summary>
        /// Indicates that the message contains information. Messages with this level can point to problems, but shouldn't be severe.
        /// </summary>
        INFO,
        /// <summary>
        /// A warning means that something is wrong, but the program will probably still be operational.
        /// </summary>
        WARNING,
        /// <summary>
        /// This level means that something is severely wrong and that the program is likely to fail.
        /// </summary>
        ERROR
    }
}
