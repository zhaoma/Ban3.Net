using System;

namespace Ban3.Infrastructures.Common.Requests
{
    public class PagedQuery
    {
        public PagedQuery() { }

        public string Keyword { get; set; }

        public int PageSize { get; set; } = 20;

        public int PageNo { get; set; } = 1;

        public string OrderField { get; set; } = " Id DESC ";
    }
}