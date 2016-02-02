using System;
using System.Text;
using System.Web.Mvc;
using Mvc.Bootstrap.Widgets;

namespace Mvc.Bootstrap.Builders
{
    public class AlertBuilder : BaseWidgetBuilder<Alert, AlertBuilder>
    {
        public AlertBuilder(Alert widget)
            : base(widget)
        {
        }

        public AlertBuilder Type(AlertType type)
        {
            base.Widget.Type = type;
            return this;
        }

        public AlertBuilder Message(string message)
        {
            base.Widget.Message = message;
            return this;
        }

        public AlertBuilder GlyphIcon(string icon)
        {
            base.Widget.GlyphIcon = icon;
            return this;
        }

        public AlertBuilder CloseButton()
        {
            base.Widget.CloseButton = true;
            return this;
        }

        protected override TagBuilder BuildDetail(TagBuilder rootTagBuilder)
        {
            rootTagBuilder.MergeAttribute("role", "alert");
            rootTagBuilder.AddCssClass("alert");

            switch (base.Widget.Type)
            {
                case AlertType.Danger:
                    rootTagBuilder.AddCssClass("alert-danger");
                    break;
                case AlertType.Info:
                    rootTagBuilder.AddCssClass("alert-info");
                    break;
                case AlertType.Success:
                    rootTagBuilder.AddCssClass("alert-success");
                    break;
                case AlertType.Warning:
                    rootTagBuilder.AddCssClass("alert-warning");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var sb = new StringBuilder();
            if (!string.IsNullOrEmpty(base.Widget.GlyphIcon))
            {
                var iconTag = new TagBuilder("span");
                iconTag.AddCssClass("glyphicon");
                iconTag.AddCssClass(base.Widget.GlyphIcon);
                iconTag.MergeAttribute("aria-hidden", "true");
                sb.Append(iconTag);
            }

            if (base.Widget.CloseButton)
            {
                var closeBtnTag = new TagBuilder("button");
                closeBtnTag.AddCssClass("close");
                closeBtnTag.MergeAttribute("type", "button");
                closeBtnTag.MergeAttribute("data-dismiss", "alert");
                closeBtnTag.MergeAttribute("aria-label", "Close");
                closeBtnTag.InnerHtml = "<span aria-hidden=\"true\">&times;</span>";
                sb.Append(closeBtnTag);
            }

            sb.Append(base.Widget.Message);

            rootTagBuilder.InnerHtml = sb.ToString();

            return rootTagBuilder;
        }
    }
}
