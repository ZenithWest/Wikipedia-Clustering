// ***** Guidance generated code © Catharsis ***** //
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectBase.Tools;

namespace ProjectBase.Test.Wiki
{
    public abstract class HttpContextTestBase : TestBase
    {
        public override void MyTestInitialize()
        {
            SetContext();
        }

        public override void MyTestCleanup()
        {
            // TODO
        }

        #region Context
        protected virtual void SetContext()
        {
            if (HttpContext.Current.Is())
            {
                return;
            }
            var path = Path.GetFullPath(@"..\..\..\Project.Test\$ProjectTest$\");
            var request = new HttpRequest(path, "http://localhost/", "");
            var response = new HttpResponse(new StringWriter());
            var context = new HttpContext(request, response);
            HttpContext.Current = context;
        }
        #endregion Context
    }
}
