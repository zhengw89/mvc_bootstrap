namespace Mvc.Bootstrap.Widgets
{
    public enum AlertType
    {
        Success,
        Info,
        Warning,
        Danger,
    }

    public class Alert : BaseWidget
    {
        public AlertType Type { get; set; }
        public string Message { get; set; }
        public string GlyphIcon { get; set; }
        public bool CloseButton { get; set; }

        public Alert()
            : base("div")
        {
            this.Type = AlertType.Info;
            this.CloseButton = false;
        }
    }
}
