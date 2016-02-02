using System.Collections.Generic;

namespace Mvc.Bootstrap.Widgets
{
    public interface IWidget
    {
        IDictionary<string, string> HtmlAttributes
        {
            get;
        }
    }
}
