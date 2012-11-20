using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using Antlr.Runtime;
using Antlr.Runtime.Tree;

namespace ProjectBase.Tools.Wiki
{
    [Obsolete("Use WikiConverter instead")]
    public static class WikiProvider
    {
        [Obsolete("Use WikiConverter.ConvertToHtml(string text) instead")]
        public static string ConvertToHtml(string text)
        {
            return new WikiConverter().ConvertToHtml(text);
        }
    }
}
