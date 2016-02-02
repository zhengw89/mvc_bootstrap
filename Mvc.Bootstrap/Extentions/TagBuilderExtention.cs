using System.Text;
using System.Web.Mvc;

namespace Mvc.Bootstrap.Extentions
{
    public static class TagBuilderExtention
    {
        public static void AppendInnerBuilder(this TagBuilder builder, TagBuilder tag)
        {
            var sb = new StringBuilder(builder.InnerHtml);
            sb.Append(tag);
            builder.InnerHtml = sb.ToString();
        }
    }
}
