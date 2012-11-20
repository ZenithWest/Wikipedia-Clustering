// ***** Guidance generated code © Catharsis ***** //
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using Antlr.Runtime.Tree;

namespace ProjectBase.Tools.Wiki
{
    public partial class WikiTree
    {
        #region members
        const string ImageTemplate = "<img src=\"{0}\" alt=\"{0}\" style=\"";
        const string AnchorTemplate = "<a href=\"{0}\" title=\"{0}\" >";
        const string NewLine = "\r\n";
        const string BreakLine = "<br />\r\n";
        readonly StringBuilder builder = new StringBuilder();
        bool _isInsideBlock;
        bool _isInsideCode;
        bool _isInsideHtml;
        bool _isInsidePre;
        bool _isInsideXml;
        bool _isSpecialText;
        string _specialText;
        #endregion members

        public WikiTree.execute_return Execute()
        {
            return execute();
        }

        #region static tag collections
        static readonly IList<string> Blocks = new List<string>
        {
            "p", "pr", "pc", "p1", "p2", "p3"
            , "code", "xml", "html", "ol", "ul", "li"
            , "h1", "h2", "h3", "h4", "h5", "h6"
            , "div", "pre", "cite", "blockquote", "bq"
        };

        static readonly IDictionary<string, string> BlockExtended = new Dictionary<string, string>
        {
            {"p0", "p"}, {"pr", "p"}, {"pc", "p"}, {"p1", "p"}, {"p2", "p"}, {"p3", "p"}
            , {"bq", "blockquote"}, {"xml", "code"}, {"html", "code"}, {"code", "code"}
            , {"div", "div"}, {"pre", "pre"}, {"cite", "cite"}
        };

        static readonly IDictionary<string, string> Inlines = new Dictionary<string, string>
        {
            {"b", "b"}, {"i", "i"}, {"u", "ins"}, {"s", "del"}
            , {"v", "var"}, {"var", "var"}, {"samp", "samp"}
            , {"sub", "sub"}, {"sup", "sup"}, {"big", "big"}, {"small", "small"}
            , {"img", "img"}, {"url", "a"}, {"a", "a"}, {"name", "a"}
            , {"def", "dfn"}, {"dfn", "dfn"}
        };

        static readonly IDictionary<string, string> Colors = new Dictionary<string, string>
        {
            {"blue", "Blue"}, {"red", "Red"}, {"green", "Green"}
            , {"olive", "Olive"}, {"lime", "Lime"}, {"purple", "Purple"}
            , {"yellow", "Yellow"}, {"maroon", "Maroon"}, {"silver", "Silver"}
            , {"orange", "Orange"}, {"navy", "Navy"}, {"teal", "Teal"}, {"pink", "Pink"}
        };
        #endregion static tags collections

        public virtual string Text
        {
            get { return builder.ToString(); }
        }

        #region Block tag
        /// <summary>
        ///     Block elements are nested in the HTML elements
        ///     Named uses their values (code, div) empty are decorated with "p"
        /// </summary>
        /// <param name = "text"></param>
        /// <param name = "isClosing"></param>
        protected virtual void BlockTag(string text, bool isClosing)
        {
            var closing = isClosing
                              ? "/"
                              : string.Empty; // the sign for the closing tag
            var css = string.Empty; // css class name
            // the WIKI element name now will be converted e.g. [CODE -> code
            var tag = text.Replace("[", "").Replace("|", "").Replace("|", "").ToLower().Trim().ToLower();

            if (!Blocks.Contains(tag)) // special handling for "empty" element
            {
                if (_isInsideBlock) // inside named blocks (CODE, XML)
                {
                    // will be empty blocks only provided
                    builder.Append(isClosing // with the break line at the end
                                       ? BreakLine
                                       : string.Empty);
                }
                else // "empty" element as the root
                {
                    // will be extended with the "p" tag (for the simple text)
                    builder.Append(isClosing
                                       ? "</p>" + NewLine // close
                                       : "<p>"); // open
                }
                return;
            }
            InsideBlockSwitch(tag, isClosing); // set switch to be able lately decorate keywords (e.g. CODE -> 'virtual' to SPAN
            if (BlockExtended.ContainsKey(tag)) // named blocks could be extended with the class name
            {
                // for later rendering adjustments (e.g. different colors for XML ver HTML)
                css = isClosing
                          ? string.Empty
                          : " class=\"" + tag + "\" ";
                tag = BlockExtended[tag]; // at this moment we must convert WIKI name into existing HTML tag name
            }
            builder.Append("<" + closing + tag + css + ">" + NewLine); // and finally append it
        }

        /// <summary>
        ///     Keeps the information about being in the inner CODE, XML or HTML section.
        ///     This information can be used for decorating specific keywords with the SPAN tag
        /// </summary>
        /// <param name = "tag"></param>
        /// <param name = "isClosing"></param>
        protected virtual void InsideBlockSwitch(string tag, bool isClosing)
        {
            _isInsideBlock = !isClosing; // this is common switch keeping the information about beeing in some non-empty BLOCK
            switch (tag) // more grained settting for CODE, XML, HTML
            {
                case "code": // this settings could be used for SPAN class rendering
                    _isInsideCode = !isClosing;
                    return; // decorating the keywords
                case "xml":
                    _isInsideXml = !isClosing;
                    return;
                case "html":
                    _isInsideHtml = !isClosing;
                    return;
                case "pre":
                    _isInsidePre = !isClosing;
                    return;
            }
        }
        #endregion Block tag

        #region Inline tag
        public virtual void InlineTag(string text, bool isClosing)
        {
            var closing = isClosing
                              ? "/"
                              : string.Empty;
            var key = text.Replace("[", "").Replace(":", "").ToLower().Trim().ToLower();
            var tag = string.Empty;
            if (Inlines.ContainsKey(key)
                || Colors.ContainsKey(key))
            {
                var attr = string.Empty;
                tag = Inlines.ContainsKey(key)
                          ? Inlines[key]
                          : "span";
                if (!isClosing
                    && Colors.ContainsKey(key))
                {
                    attr = " style=\"color:" + Colors[key] + ";\" ";
                }
                tag = "<" + closing + tag + attr + ">"; // +NewLine;
            }
            builder.Append(tag);
        }
        #endregion Inline tag

        #region Append to builder
        /// <summary>
        ///     Appends the text to the builder.
        ///     If the _isSpecialText is true, then string is stored in the temp string
        ///     to be lately converted into the URL
        /// </summary>
        /// <param name = "text"></param>
        public virtual void Append(string text)
        {
            if (_isSpecialText) // this means, that started the image "src" stream
            {
                _specialText += text;
            }
            else // standard text appending
            {
                builder.Append(text);
            }
        }

        public virtual void Append(CommonTree tree)
        {
            Append(tree.Text);
        }
        #endregion Append to builder

        #region Tag <element>
        public virtual void TagElement(bool isClosing)
        {
            Append(isClosing
                       ? "</span>"
                       : "<span class=\"tag\" >");
        }
        #endregion Tag <element>

        #region Style and Color
        /// <summary>
        ///     Color handling via style 'color' (as the parameter text) is used here
        /// </summary>
        /// <param name = "text">e.g. the 'color' as the name of the style</param>
        /// <param name = "style">e.g. 'Maroon' as the value of the style attribute</param>
        public virtual void SpanStyleTag(string text, string style)
        {
            builder.Append(string.Format("<span style=\"{1}\" >{0}</span>", text, style));
        }

        /// <summary>
        ///     Keywords could be docrated with the SPAN element and specific css class name.
        ///     This should be done only isnide correct elements (e.g. CSharp keywords in CODE).
        ///     In other cases, only text is rendered
        /// </summary>
        /// <param name = "text"></param>
        /// <param name = "cssClass"></param>
        public virtual void SpanClassTag(string text, string cssClass)
        {
            bool useText = true;
            switch (cssClass) // based on nesting parent, the span with class name is appended
            {
                case "html":
                    useText = !_isInsideHtml;
                    break;
                case "cmmnt":
                    useText = !(_isInsideHtml || _isInsideCode || _isInsideXml);
                    if (!useText) // for multi row comments /* */ must be <br> appended
                    {
                        text = text.Replace("\n", "\n</span><br /><span class=\"cmmnt\" >");
                    }
                    break;
                case "qtd":
                    useText = !(_isInsideHtml || _isInsideCode || _isInsideXml);
                    break;
                case "smbl":
                    useText = !(_isInsideHtml || _isInsideCode || _isInsideXml);
                    break;
                case "base":
                    useText = !_isInsideCode;
                    break;
                case "flw":
                    useText = !_isInsideCode;
                    break;
                case "spcl":
                    useText = !_isInsideCode;
                    break;
                case "type":
                    useText = !(_isInsideCode || _isInsideHtml);
                    break;
            }
            builder.Append(useText
                               ? text // for usual text no decoration is appended
                               : string.Format("<span class=\"{1}\" >{0}</span>", text, cssClass));
        }
        #endregion Style and Color

        #region Escape and white space
        /// <summary>
        ///     There are defined escaped patterns e.g. the '[[]' for the '[' sign.
        ///     This will remove the opening and closing braces
        /// </summary>
        /// <param name = "text"></param>
        public virtual string EscapedText(string text)
        {
            var length = text.Length - 2; // remove leading and ending []
            return text.Substring(1, length);
        }

        /// <summary>
        ///     More White-spaces are removed from rendereing in every browser.
        ///     Therefore every 2 spaces are converted into the "&nbsp;&nbsp;"
        ///     to keep intended spacing.
        ///     The only exception comes for the PRE element, which is smarter in this way
        /// </summary>
        /// <param name = "text"></param>
        public virtual string WhiteSpaceText(string text)
        {
            var whiteSpace = text;
            if (!_isInsidePre) // if not isnide the PRE element, then the spaces are converted
            {
                whiteSpace = (text == " ") ? " " : "&nbsp;&nbsp;";
            }
            return whiteSpace;
        }
        #endregion Escape and white space

        #region Img Url
        /// <summary>
        ///     Not se good way how to switch the builder filling and the image "src" filling
        ///     this should be improved later...
        ///     Only turns on the _isSpecialText switch
        /// </summary>
        public virtual void SpecialTextStart()
        {
            _isSpecialText = true;
        }

        /// <summary>
        ///     Calls the ProjectBase.Core extension to create the working image path.
        ///     Expecting that the provided path is base on the root of the web project (virtual directory).
        ///     Turns off the _isSpecialText switch and also appends converted string as the URL
        /// </summary>
        public virtual void SpecialTextEnd(string template)
        {
            _isSpecialText = false;

            var specialText = ExtractText(_specialText.Trim());
            const string http = "http://";
            const string https = "https://";
            const string mailto = "mailto:";
            const string file = "file://";
            const string hash = "#";
            if (specialText.StartsWith(http, StringComparison.OrdinalIgnoreCase)
                || specialText.StartsWith(hash, StringComparison.OrdinalIgnoreCase)
                || specialText.StartsWith(https, StringComparison.OrdinalIgnoreCase)
                || specialText.StartsWith(file, StringComparison.OrdinalIgnoreCase)
                || specialText.StartsWith(mailto, StringComparison.OrdinalIgnoreCase)
                )
            {
                builder.Append(string.Format(template, specialText));
            }
            else
            {
                builder.Append(string.Format(template, HttpContext.Current.CreateUrl(specialText)));
            }
            _specialText = string.Empty;
        }

        protected virtual string ExtractText(string text)
        {
            var txt = text;
            if (txt.StartsWith("&quot;", StringComparison.OrdinalIgnoreCase)
               && txt.EndsWith("&quot;", StringComparison.OrdinalIgnoreCase))
            {
                txt = txt.TrimStart('&', 'q', 'u', 'o', 't', ';')
                         .TrimEnd(';', 't', 'o', 'u', 'q', '&');
            }
            else if (txt.StartsWith("\"", StringComparison.OrdinalIgnoreCase)
               && txt.EndsWith("\"", StringComparison.OrdinalIgnoreCase))
            {
                txt = txt.TrimStart('"').TrimEnd('"');
            }
            return txt;
        }

        /// <summary>
        ///     Special attribute handling for the IMG element
        ///     (width, float...)
        /// </summary>
        /// <param name = "text"></param>
        /// <param name = "attribute"></param>
        public virtual void ImageAttr(string text, string attribute)
        {
            if (attribute.Equals("height", StringComparison.OrdinalIgnoreCase))
            {
                builder.Append(string.Format("height: {0};", text));
            }
            if (attribute.Equals("width", StringComparison.OrdinalIgnoreCase))
            {
                builder.Append(string.Format("width: {0};", text));
            }
            if (attribute.Equals("float", StringComparison.OrdinalIgnoreCase))
            {
                builder.Append(string.Format("float: {0};", text));
            }
        }
        #endregion Img
    }
}