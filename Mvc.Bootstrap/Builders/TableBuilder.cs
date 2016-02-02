using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using Mvc.Bootstrap.Extentions;
using Mvc.Bootstrap.Widgets;

namespace Mvc.Bootstrap.Builders
{
    public class TableBuilder<T> : BaseWidgetBuilder<Table<T>, TableBuilder<T>>
        where T : class
    {
        private readonly TableColumns<T> _tableColumns;
        private bool _striped, _borderd, _hover, _condensed;

        public TableBuilder(Table<T> widget)
            : base(widget)
        {
            this._tableColumns = new TableColumns<T>();
        }

        #region Config

        public TableBuilder<T> Columns(Action<TableColumns<T>> columns)
        {
            columns(_tableColumns);

            return this;
        }

        public TableBuilder<T> Striped()
        {
            this._striped = true;
            return this;
        }

        public TableBuilder<T> Borderd()
        {
            this._borderd = true;
            return this;
        }

        public TableBuilder<T> Hover()
        {
            this._hover = true;
            return this;
        }

        public TableBuilder<T> Condensed()
        {
            this._condensed = true;
            return this;
        }

        #endregion

        protected override TagBuilder BuildDetail(TagBuilder rootTagBuilder)
        {
            rootTagBuilder.AddCssClass("table");
            if (this._striped)
            {
                rootTagBuilder.AddCssClass("table-striped");
            }
            if (this._borderd)
            {
                rootTagBuilder.AddCssClass("table-bordered");
            }
            if (this._hover)
            {
                rootTagBuilder.AddCssClass("table-hover");
            }
            if (this._condensed)
            {
                rootTagBuilder.AddCssClass("table-condensed");
            }

            var tableHeader = this.BuildTableHeader();
            var tableBody = this.BuildTableBody();

            rootTagBuilder.AppendInnerBuilder(tableHeader);
            rootTagBuilder.AppendInnerBuilder(tableBody);

            return rootTagBuilder;
        }

        #region Private Method

        private TagBuilder BuildTableHeader()
        {
            var thead = new TagBuilder("thead");
            var tr = new TagBuilder("tr");

            if (this._tableColumns != null && this._tableColumns.Any())
            {
                foreach (var column in this._tableColumns)
                {
                    var headerItem = new TagBuilder("th") { InnerHtml = column.ColumnTitle };

                    if (!string.IsNullOrEmpty(column.ColumnWidth))
                    {
                        headerItem.MergeAttribute("style", string.Format("width:{0}", column.ColumnWidth));
                    }

                    tr.AppendInnerBuilder(headerItem);
                }
            }
            thead.AppendInnerBuilder(tr);

            return thead;
        }

        private TagBuilder BuildTableBody()
        {
            var tbody = new TagBuilder("tbody");

            if (base.Widget != null && base.Widget.Data != null && base.Widget.Data.Any())
            {
                Type dataType = typeof(T);

                string[,] cells = new string[base.Widget.Data.Count, this._tableColumns.Count];
                for (int i = 0; i < this._tableColumns.Count; i++)
                {
                    var column = this._tableColumns[i];
                    var property = dataType.GetProperty(column.ColumnProperty);

                    for (int j = 0; j < base.Widget.Data.Count; j++)
                    {
                        var item = base.Widget.Data[j];

                        cells[j, i] = column.ColumnTemplate != null
                                    ? column.ColumnTemplate.Invoke(item)
                                    : property.GetValue(item, null).ToString();
                    }
                }

                for (int i = 0; i < base.Widget.Data.Count; i++)
                {
                    var tr = new TagBuilder("tr");

                    for (int j = 0; j < this._tableColumns.Count; j++)
                    {
                        var td = new TagBuilder("td")
                        {
                            InnerHtml = cells[i, j]
                        };
                        tr.AppendInnerBuilder(td);
                    }
                    tbody.AppendInnerBuilder(tr);
                }
            }

            return tbody;
        }

        #endregion
    }
}
