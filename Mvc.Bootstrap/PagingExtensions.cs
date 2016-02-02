using System;
using System.Text;
using System.Web.Mvc;

namespace Mvc.Bootstrap
{
    public static class PagingExtensions
    {
        private const int NavPageSize = 3;

        public static MvcHtmlString PageLinks(
            this HtmlHelper html,
            int currentPageIndex,
            int totalPageCount,
            Func<int, string> pageUrl)
        {
            var ulTag = new TagBuilder("ul");
            ulTag.AddCssClass("pagination");

            var result = new StringBuilder();

            string prevLink = (currentPageIndex == 1)
                ? BuildPagingItem(pageUrl(currentPageIndex - 1), "<", false, true)
                : BuildPagingItem(pageUrl(currentPageIndex - 1), "<");
            result.Append(prevLink);

            var start = (currentPageIndex <= NavPageSize + 1) ? 1 : (currentPageIndex - NavPageSize);
            var end = (currentPageIndex > (totalPageCount - NavPageSize)) ?
                totalPageCount :
                currentPageIndex + NavPageSize;

            for (int i = start; i < currentPageIndex; i++)
            {
                result.Append(BuildPagingItem(pageUrl(i), i.ToString()));
            }

            result.Append(BuildPagingItem(pageUrl(currentPageIndex), currentPageIndex.ToString(), true));

            for (int i = currentPageIndex + 1; i <= end; i++)
            {
                result.Append(BuildPagingItem(pageUrl(i), i.ToString()));
            }

            string nextLink = (currentPageIndex >= totalPageCount)
                ? BuildPagingItem(pageUrl(currentPageIndex + 1), ">", false, true)
                : BuildPagingItem(pageUrl(currentPageIndex + 1), ">");
            result.Append(nextLink);

            ulTag.InnerHtml = result.ToString();

            return MvcHtmlString.Create(ulTag.ToString());
        }

        private static string BuildPagingItem(string url, string display, bool active = false, bool disabled = false)
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
