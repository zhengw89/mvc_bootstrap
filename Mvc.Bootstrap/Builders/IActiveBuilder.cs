using Mvc.Bootstrap.Widgets;

namespace Mvc.Bootstrap.Builders
{
    public interface IActiveBuilder<TW, TB>
        where TW : BaseWidget
        where TB : BaseWidgetBuilder<TW, TB>
    {
        TB Active();

        TB Inactive();
    }
}
