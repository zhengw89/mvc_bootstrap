using System.Collections.Generic;
using Mvc.Bootstrap.Widgets;

namespace Mvc.Bootstrap.Builders
{
    public class BuilderFactory
    {
        public ButtonBuilder Button()
        {
            return new ButtonBuilder(new Button());
        }

        public AlertBuilder Alert()
        {
            return new AlertBuilder(new Alert());
        }

        public PagingBuilder Paging()
        {
            return new PagingBuilder(new Paging());
        }

        public TableBuilder<T> Table<T>(List<T> data)
            where T : class
        {
            return new TableBuilder<T>(new Table<T>(data));
        }
    }
}
