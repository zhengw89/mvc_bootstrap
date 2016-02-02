using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Mvc.Bootstrap.Widgets
{
    public class Table<T> : BaseWidget
        where T : class
    {
        private readonly List<T> _data;

        public List<T> Data
        {
            get
            {
                return this._data;
            }
        }

        public Table(List<T> data)
            : base("table")
        {
            this._data = data;
        }
    }

    public class TableColumns<T> : List<TableColumn<T>>
    {

        public void Bound(Func<T, object> property)
        {
            int i = 0;
            i++;
            //var xx = property.Invoke();
        }

        public TableColumn<T> Bound(string property)
        {
            return this.Bound(null, property);
        }

        public TableColumn<T> Bound(string title, string property)
        {
            var column = new TableColumn<T>(title, property);
            Add(column);
            return column;
        }
    }

    public class TableColumn<T>
    {
        private string _title;
        private readonly string _property;
        private string _width;
        private Func<T, string> _columnTemplate;

        public string ColumnTitle
        {
            get
            {
                if (string.IsNullOrEmpty(this._title)) return this._property;
                return this._title;
            }
        }
        public string ColumnProperty { get { return this._property; } }
        public string ColumnWidth { get { return this._width; } }
        public Func<T, string> ColumnTemplate { get { return this._columnTemplate; } }

        public TableColumn(string property)
            : this(property, property)
        {

        }

        public TableColumn(string title, string property)
            : this(title, property, null)
        {

        }

        public TableColumn(string title, string property, string width)
        {
            this._title = title;
            this._property = property;
            this._width = width;
        }

        public TableColumn<T> Title(string title)
        {
            this._title = title;
            return this;
        }

        public TableColumn<T> Width(string width)
        {
            this._width = width;
            return this;
        }

        public TableColumn<T> Template(Func<T, string> template)
        {
            this._columnTemplate = template;
            return this;
        }
    }
}
