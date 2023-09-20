using System;
using System.Collections.Generic;
using System.Text;
using Ban3.Sites.ViaMicrosoft.Enums;
using Ban3.Sites.ViaMicrosoft.Models;

namespace Ban3.Sites.ViaMicrosoft.Response.Reports
{
    public class DataReport
    {
        public CountedResult<ReportChangeset> Changesets { get; set; }

        public CountedResult<ReportShelveset> Shelvesets { get; set; }

        public List<ReportAuthor> Authors { get; set; }

        public Request.Reports.DataFilter Filter { get; set; }

        public int TotalPage
        {
            get
            {
                var total = Filter.Ref == ReportRef.Changeset
                    ? Changesets.Count
                    : Shelvesets.Count;

                return total % Filter.PageSize > 0
                    ? total / Filter.PageSize + 1
                    : total / Filter.PageSize;
            }
        }
    }
}
