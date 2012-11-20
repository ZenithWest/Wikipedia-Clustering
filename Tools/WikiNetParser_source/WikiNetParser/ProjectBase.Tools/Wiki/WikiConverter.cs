using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using Antlr.Runtime;
using Antlr.Runtime.Tree;

namespace ProjectBase.Tools.Wiki
{
    public class WikiConverter
    {
        public virtual string ConvertToHtml(string text)
        {
            var encoded = HttpUtility.HtmlEncode(text);
            var stringStream = new ANTLRStringStream(encoded);
            var lexture = new WikiLexer(stringStream);
            var cts = new CommonTokenStream(lexture);

            var parser = new WikiParser(cts);

            var r = parser.Execute();
            var ast = (CommonTree)r.Tree;
            if (ast == null)
            {
                return string.Empty;
            }

            var nodes = new CommonTreeNodeStream(ast);
            var walker = new WikiTree(nodes);

            walker.Execute();

            return walker.Text;
        }
    }
}
