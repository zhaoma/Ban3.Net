using System;
using System.Collections.Generic;
using  Ban3.Infrastructures.Charts.Elements;

namespace Ban3.Infrastructures.Charts
{
	public static partial class Helper
	{
		#region Series

		///
		public static ISeries CreateSeries(
			this Enums.SeriesType seriesType)
		{
			return new Components.Series { Type = seriesType };
		}

        #endregion

        #region Diagram

        ///
        public static Charts.Composites.Diagram CreateDiagram(
			this Enums.SeriesType mainSeries
		)
		{
			return new Charts.Composites.Diagram
			{
				Series = new List<ISeries> { mainSeries.CreateSeries() }
			};
		}

		///
		public static Charts.Composites.Diagram AddSeries(
			this Charts.Composites.Diagram diagram,
			ISeries series)
		{
			var seriesArray = diagram.Series??new List<ISeries>();

			seriesArray.Add(series);

			return diagram;
		}

		#endregion
	}
}