namespace Mvc.Bootstrap.Widgets
{
    public class Paging : BaseWidget
    {
        private int _index, _pageCount, _indexBufferSize;

        public int Index
        {
            get
            {
                return this._index;
            }
            set
            {
                this._index = value < 1 ? 1 : value;
            }
        }
        public int PageCount
        {
            get
            {
                return this._pageCount;
            }
            set
            {
                this._pageCount = value < 1 ? 1 : value;
            }
        }
        public int IndexBufferSize
        {
            get
            {
                return this._indexBufferSize;
            }
            set
            {
                this._indexBufferSize = value > 0 ? value : 1;
            }
        }

        public Paging()
            : base("ul")
        {
            this._index = 1;
            this._pageCount = 1;
            this._indexBufferSize = 3;
        }
    }
}
