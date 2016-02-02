using System;
using System.Web.Mvc;
using Mvc.Bootstrap.Widgets;

namespace Mvc.Bootstrap.Builders
{
    public class ButtonBuilder : BaseWidgetBuilder<Button, ButtonBuilder>, IEnableBuilder<Button, ButtonBuilder>, IActiveBuilder<Button, ButtonBuilder>
    {
        public ButtonBuilder(Button widget)
            : base(widget)
        {
        }

        public ButtonBuilder Type(ButtonType type)
        {
            base.Widget.Type = type;
            return this;
        }

        public ButtonBuilder Size(ButtonSize size)
        {
            base.Widget.Size = size;
            return this;
        }

        public ButtonBuilder Text(string text)
        {
            base.Widget.Text = text;
            return this;
        }

        protected override TagBuilder BuildDetail(TagBuilder rootTagBuilder)
        {
            rootTagBuilder.MergeAttribute("type", "button");
            rootTagBuilder.AddCssClass("btn");

            if (!base.Widget.Enable)
            {
                rootTagBuilder.MergeAttribute("disabled", "disabled");
            }

            if (base.Widget.Active)
            {
                rootTagBuilder.AddCssClass("active");
            }

            switch (base.Widget.Type)
            {
                case ButtonType.Danger:
                    rootTagBuilder.AddCssClass("btn-danger");
                    break;
                case ButtonType.Default:
                    rootTagBuilder.AddCssClass("btn-default");
                    break;
                case ButtonType.Info:
                    rootTagBuilder.AddCssClass("btn-info");
                    break;
                case ButtonType.Link:
                    rootTagBuilder.AddCssClass("btn-link");
                    break;
                case ButtonType.Primary:
                    rootTagBuilder.AddCssClass("btn-primary");
                    break;
                case ButtonType.Success:
                    rootTagBuilder.AddCssClass("btn-success");
                    break;
                case ButtonType.Warning:
                    rootTagBuilder.AddCssClass("btn-warning");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (base.Widget.Size)
            {
                case ButtonSize.Default:
                    break;
                case ButtonSize.ExrtaSmall:
                    rootTagBuilder.AddCssClass("btn-xs");
                    break;
                case ButtonSize.Large:
                    rootTagBuilder.AddCssClass("btn-lg");
                    break;
                case ButtonSize.Small:
                    rootTagBuilder.AddCssClass("btn-sm");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            rootTagBuilder.InnerHtml = base.Widget.Text;

            return rootTagBuilder;
        }

        public ButtonBuilder Enable()
        {
            base.Widget.Enable = true;
            return this;
        }

        public ButtonBuilder Disable()
        {
            base.Widget.Enable = false;
            return this;
        }

        public ButtonBuilder Active()
        {
            base.Widget.Active = true;
            return this;
        }

        public ButtonBuilder Inactive()
        {
            base.Widget.Active = false;
            return this;
        }
    }
}
