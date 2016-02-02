using System.Web.Mvc;
using Mvc.Bootstrap.Builders;

namespace Mvc.Bootstrap.Extentions
{
    public static class HtmlHelperExtention
    {
        public static BuilderFactory BootStrap(this HtmlHelper html)
        {
            return new BuilderFactory();
        }
    }
}
