using System;
using System.Collections.Generic;

namespace libdilute
{
    /// <summary>
    /// The main class of the Dilute library. Provides initialization methods and other configuration options.
    /// </summary>
    public class Dilute
    {
        /// <summary>
        /// The actual stack containing every message, error and warning that was reported to Dilute.
        /// </summary>
        private static readonly Stack<Tuple<Level, string>> msgCache = new Stack<Tuple<Level, string>>();

        /// <summary>
        /// Queues a message to be displayed via <see cref="nextMessage"/>.
        /// </summary>
        /// <param name="msg">The message to display.</param>
        internal static void info(string msg)
        {
            msgCache.Push(new Tuple<Level, string>(Level.INFO, msg));
        }

        /// <summary>
        /// Queues a warning with a message to be displayed via <see cref="nextMessage"/>.
        /// </summary>
        /// <param name="msg">The message to display.</param>
        internal static void warning(string msg)
        {
            msgCache.Push(new Tuple<Level, string>(Level.WARNING, msg));
        }

        /// <summary>
        /// Queues an error message to be displayed via <see cref="nextMessage"/>.
        /// </summary>
        /// <param name="msg">The message to display.</param>
        internal static void error(string msg)
        {
            msgCache.Push(new Tuple<Level, string>(Level.ERROR, msg));
        }

        /// <summary>
        /// Gets the next level and message waiting to be processed.
        /// </summary>
        /// <returns></returns>
        public static Tuple<Level, String> nextMessage()
        {
            return msgCache.Count > 0 ? msgCache.Pop() : null;
        }
    }
}
