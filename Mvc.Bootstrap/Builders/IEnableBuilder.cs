using Mvc.Bootstrap.Widgets;

namespace Mvc.Bootstrap.Builders
{
    public interface IEnableBuilder<TW, TB>
        where TW : BaseWidget
        where TB : BaseWidgetBuilder<TW, TB>
    {
        TB Enable();

        TB Disable();
    }
}
