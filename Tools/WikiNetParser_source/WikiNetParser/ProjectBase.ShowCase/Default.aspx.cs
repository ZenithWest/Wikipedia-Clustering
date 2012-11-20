using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProjectBase.Tools.Wiki;

namespace ProjectBase.ShowCase
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var html = string.Empty;
            var txt = txtarea.Value;
            if (IsPostBack)
            {
                txt = Request.Form["txtarea"];
            }
            html = new WikiConverter().ConvertToHtml(txt);
            converted.Text = html;
            source.Text = HttpUtility.HtmlEncode(html).Replace("\r\n", "<br />");
        }
    }
}