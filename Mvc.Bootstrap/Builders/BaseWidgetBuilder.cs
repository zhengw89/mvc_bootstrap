using System;
using System.Web.Mvc;
using Mvc.Bootstrap.Widgets;

namespace Mvc.Bootstrap.Builders
{
    public abstract class BaseWidgetBuilder<TW, TB>
        where TW : BaseWidget
        where TB : BaseWidgetBuilder<TW, TB>
    {
        private readonly TW _widget;
        protected TW Widget { get { return this._widget; } }

        protected BaseWidgetBuilder(TW widget)
        {
            this._widget = widget;
        }

        public TB Id(string id)
        {
            this._widget.Id = id;
            return this as TB;
        }

        public TB MergeAttribute(string key, string value)
        {
            if (!this._widget.HtmlAttributes.ContainsKey(key))
            {
                this._widget.HtmlAttributes.Add(key, string.Empty);
            }

            this._widget.HtmlAttributes[key] += string.Format("{0} ", value);

            return this as TB;
        }

        public MvcHtmlString Build()
        {
            if (!CheckArg())
            {
                throw new ArgumentException();
            }

            var rootTagBuilder = this._widget.BuildBaseTag();

            return MvcHtmlString.Create(this.BuildDetail(rootTagBuilder).ToString());
        }

        protected abstract TagBuilder BuildDetail(TagBuilder rootTagBuilder);

        protected virtual bool CheckArg()
        {
            return true;
        }
    }
}
