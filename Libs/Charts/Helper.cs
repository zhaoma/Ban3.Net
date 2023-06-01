using System;
using System.Collections.Generic;
using Ban3.Infrastructures.Charts.Cogs;
using Ban3.Infrastructures.Charts.Components;
using Ban3.Infrastructures.Charts.Composites;
using  Ban3.Infrastructures.Charts.Elements;
using Ban3.Infrastructures.Charts.Styles;

namespace Ban3.Infrastructures.Charts
{
    public static partial class Helper
    {
        #region Diagram

        /// TODO : init default values
        public static Diagram CreateDiagram()
        {
            return new Diagram();
        }

        public static Diagram SetTitle(this Diagram diagram, Title[] title)
        {
            diagram.Title = title;
            return diagram;
        }

        public static Diagram SetLegend(this Diagram diagram, Legend[] legend)
        {
            diagram.Legend = legend;
            return diagram;
        }

        public static Diagram SetGrid(this Diagram diagram, Grid[] grid)
        {
            diagram.Grid = grid;
            return diagram;
        }

        public static Diagram SetXAxis(this Diagram diagram, IAxis[] axis)
        {
            diagram.XAxis = axis;
            return diagram;
        }

        public static Diagram SetYAxis(this Diagram diagram, IAxis[] axis)
        {
            diagram.YAxis = axis;
            return diagram;
        }

        public static Diagram SetDataZoom(this Diagram diagram, DataZoom[] dataZoom)
        {
            diagram.DataZoom = dataZoom;
            return diagram;
        }

        ///
        public static Diagram AddSeries(
            this Diagram diagram,
            ISeries series)
        {
            diagram.AddSeries(new[] { series });

            return diagram;
        }

        public static Diagram AddSeries(
            this Diagram diagram,
            ISeries[] series)
        {
            diagram.Series = diagram.Series ?? new List<ISeries>();

            diagram.Series.AddRange(series);

            return diagram;
        }

        #endregion

        #region Series

        ///
        public static ISeries CreateSeries(
            this Enums.SeriesType seriesType, string name, object? data, int? index)
        {
            return new Series
            {
                Name = name,
                Type = seriesType,
                Data = data,
                XAxisIndex = index,
                YAxisIndex = index,
                Smooth=true,
                LineStyle=new LineStyle{Opacity=0.3M}
            };
        }

        #endregion


    }
}