using System;
using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Sites.ViaTushare.Entries
{
	public class DateRange
	{
		public DateRange()
		{
			StartDate = DateTime.Now.AddMonths(-1).ToYmd();
			EndDate = DateTime.Now.ToYmd();
		}

        public DateRange(int days)
        {
            StartDate = DateTime.Now.AddDays(-days).ToYmd();
            EndDate = DateTime.Now.ToYmd();
        }

        public DateRange(int years, int freq)
		{
			var endDate = DateTime.Now.AddYears(-freq * years);
			var startDate = endDate.AddYears(-years);

			StartDate = startDate.ToYmd();
            EndDate = endDate.ToYmd();
        }

		public string StartDate { get; set; }

		public string EndDate { get; set; }
	}
}

