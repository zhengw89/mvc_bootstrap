using System.Collections.Generic;
using System.Web.Mvc;

namespace Mvc.Bootstrap.Widgets
{
    public abstract class BaseWidget : IWidget
    {
        private readonly string _rootTag;
        public string Id { get; set; }

        public IDictionary<string, string> HtmlAttributes { get; private set; }

        protected BaseWidget(string rootTag)
        {
            this._rootTag = rootTag;
            this.HtmlAttributes = new Dictionary<string, string>();
        }

        internal TagBuilder BuildBaseTag()
        {
            var tag = new TagBuilder(this._rootTag);
            if (!string.IsNullOrEmpty(this.Id))
            {
                tag.MergeAttribute("id", this.Id);
            }

            foreach (var attribute in HtmlAttributes)
            {
                tag.MergeAttribute(attribute.Key, attribute.Value);
            }

            return tag;
        }
    }
}
