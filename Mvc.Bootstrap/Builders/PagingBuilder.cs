using System;
using System.Text;
using System.Web.Mvc;
using Mvc.Bootstrap.Widgets;

namespace Mvc.Bootstrap.Builders
{
    public class PagingBuilder : BaseWidgetBuilder<Paging, PagingBuilder>
    {
        private Func<int, string> _pageUrlFunc;

        public PagingBuilder(Paging widget)
            : base(widget)
        {
        }

        public PagingBuilder Index(int index)
        {
            base.Widget.Index = index;
            return this;
        }

        public PagingBuilder PageCount(int count)
        {
            base.Widget.PageCount = count;
            return this;
        }

        public PagingBuilder PageUrl(Func<int, string> pageUrl)
        {
            this._pageUrlFunc = pageUrl;
            return this;
        }

        protected override bool CheckArg()
        {
            if (this._pageUrlFunc == null) return false;
            if (base.Widget.Index > base.Widget.PageCount) return false;

            return base.CheckArg();
        }

        protected override TagBuilder BuildDetail(TagBuilder rootTagBuilder)
        {
            rootTagBuilder.AddCssClass("pagination");

            var sb = new StringBuilder();

            sb.Append(BuildPrevItem());

            var startIndex = (base.Widget.Index <= base.Widget.IndexBufferSize + 1)
                ? 1
                : (base.Widget.Index - base.Widget.IndexBufferSize);
            var endIndex = (base.Widget.Index > (base.Widget.PageCount - base.Widget.IndexBufferSize))
                ? base.Widget.PageCount
                : base.Widget.Index + base.Widget.IndexBufferSize;

            sb.Append(BuildRange(startIndex, base.Widget.Index - 1));

            sb.Append(BuildPagingItem(this._pageUrlFunc(base.Widget.Index), base.Widget.Index.ToString(), true));

            sb.Append(BuildRange(base.Widget.Index + 1, endIndex));

            sb.Append(BuildNextItem());

            rootTagBuilder.InnerHtml = sb.ToString();

            return rootTagBuilder;
        }

        private string BuildPrevItem()
        {
            return (base.Widget.Index == 1)
                ? BuildPagingItem(this._pageUrlFunc(base.Widget.Index - 1), "<", false, true)
                : BuildPagingItem(this._pageUrlFunc(base.Widget.Index - 1), "<");
        }

        private string BuildNextItem()
        {
            return (base.Widget.Index >= base.Widget.PageCount)
                ? BuildPagingItem(this._pageUrlFunc(base.Widget.Index + 1), ">", false, true)
                : BuildPagingItem(this._pageUrlFunc(base.Widget.Index + 1), ">");
        }

        private string BuildRange(int startIndex, int endIndex)
        {
            var sb = new StringBuilder();

            for (int i = startIndex; i <= endIndex; i++)
            {
                sb.Append(BuildPagingItem(this._pageUrlFunc(i), i.ToString()));
            }

            return sb.ToString();
        }

        private string BuildPagingItem(string url, string display, bool active = false, bool disabled = false)
        {
            var liTag = new TagBuilder("li");

            if (disabled)
            {
                liTag.MergeAttribute("class", "disabled");
                var spanTag = new TagBuilder("span") { InnerHtml = display };
                liTag.InnerHtml = spanTag.ToString();
            }
            else
            {
                if (active)
                {
                    liTag.MergeAttribute("class", "active");
                }
                var tag = new TagBuilder("a");
                tag.MergeAttribute("href", url);
                tag.InnerHtml = display;
                liTag.InnerHtml = tag.ToString();
            }
            return liTag.ToString();
        }

    }
}
