namespace Bars.Core.Extensions
{
    
    ///<summary>
    /// Extension to <see cref="string"/>
    ///</summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Returns the result of calling <seealso cref="string.Format(string,object[])"/> with the supplied arguments
        /// </summary>
        /// <param name="formatString"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string FormatWith(this string formatString, params object[] args)
        {
            return args == null || args.Length == 0 ? formatString : string.Format(formatString, args);
        }

    }
}
