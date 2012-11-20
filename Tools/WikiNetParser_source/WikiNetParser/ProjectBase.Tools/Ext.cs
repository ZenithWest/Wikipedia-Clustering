using System;
using System.Collections.Generic;
//using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Web;

namespace ProjectBase.Tools
{
    public static class Ext
    {
        #region CreateUrl
        const string Solidus = "/";

        /// <summary>
        ///     Smart way how to create functional relative url.
        ///     Does not matter if running on root or virtual directory.
        ///     Controller without action needs different relative path then the one with action
        ///     in the uri
        /// </summary>
        /// <param name = "context">the object which gets this abbility</param>
        /// <param name = "target">relative path from root like "/Content/Css/01Basic.css"</param>
        /// <returns>corrected url, working from any page, any controller and action</returns>
        public static string CreateUrl(this HttpContext context, string target)
        {
            //Contract.Requires(target.IsNotEmpty(), "cannot create relative url for null or empty target parameter ");
            //Contract.Requires(context.Is(), "Cannot create URL, while passed context is null");

            var result = context.Request.ApplicationPath ?? string.Empty;
            var path = target;

            if (path.StartsWith(Solidus, StringComparison.OrdinalIgnoreCase))
            {
                path = path.Remove(0, 1);
            }

            if (!result.EndsWith(Solidus, StringComparison.OrdinalIgnoreCase))
            {
                result += Solidus;
            }

            return result + path;
        }
        #endregion CreateUrl

        #region Is()
        /// <summary>
        ///     Returns 'true' if value is NOT null.
        /// </summary>
        /// <param name = "value"></param>
        /// <returns>true if object is not null</returns>
        //[Pure]
        public static bool Is(this object value)
        {
            return value != null;
        }

        //[Pure]
        public static bool Is<T>(this T? value)
            where T : struct
        {
            return value.HasValue;
        }
        #endregion Is()

        #region IsNull()
        /// <summary>
        ///     if value is null 'true' is returned
        /// </summary>
        /// <param name = "value"></param>
        /// <returns>returns true if object is null</returns>
        //[Pure]
        public static bool IsNull(this object value)
        {
            return value == null;
        }

        //[Pure]
        public static bool IsNull<T>(this T? value)
            where T : struct
        {
            return !value.HasValue;
        }
        #endregion IsNull()

        #region IsEmpty() IsNotEmpty() string
        /// <summary>
        ///     abbr. for (!string.IsNullOrEmpty(value)) : value.IsNotEmpty()
        /// </summary>
        /// <returns>true if not null NOR empty</returns>
        //[Pure]
        public static bool IsNotEmpty(this string value)
        {
            return !value.IsEmpty();
        }

        /// <summary>
        ///     abbr. for 'string.IsNullOrEmpty(value)' : value.IsEmpty()
        /// </summary>
        /// <returns>true if null or empty</returns>
        //[Pure]
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }
        #endregion IsEmpty() IsNotEmpty() string

        #region IsEmpty() IsNotEmpty() Enumerable
        /// <summary>
        ///     abbr. for value.Is() && value.Count() > 0;
        /// </summary>
        /// <returns>true if not null NOR empty</returns>
        //[Pure]
        public static bool IsNotEmpty<T>(this IEnumerable<T> value)
        {
            return !value.IsEmpty();
        }

        /// <summary>
        ///     abbr. for 'value.IsNull() || value.Count() == 0;'
        /// </summary>
        /// <returns>true if null or empty</returns>
        //[Pure]
        public static bool IsEmpty<T>(this IEnumerable<T> value)
        {
            return value.IsNull() || value.Count() == 0;
        }
        #endregion IsNotEmpty()

        #region IList<>.Append()
        public static IList<T> Append<T>(this IList<T> list, T value)
        {
            list.Add(value);
            return list;
        }
        #endregion IList<>.Append()

    }
}
