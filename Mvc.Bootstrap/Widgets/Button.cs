namespace Mvc.Bootstrap.Widgets
{
    public enum ButtonType
    {
        Default,
        Primary,
        Success,
        Info,
        Warning,
        Danger,
        Link
    }

    public enum ButtonSize
    {
        Large,
        Default,
        Small,
        ExrtaSmall
    }

    public class Button : BaseWidget, IEnableWidget, IActiveWidget
    {
        public bool Enable { get; set; }
        public bool Active { get; set; }

        public ButtonType Type { get; set; }
        public ButtonSize Size { get; set; }
        public string Text { get; set; }

        public Button()
            : base("button")
        {
            this.Type = ButtonType.Default;
            this.Size = ButtonSize.Default;
            this.Enable = true;
        }

    }
}
