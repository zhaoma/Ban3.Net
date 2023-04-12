using System;
using System.Collections.Generic;
using System.Text;

namespace  Ban3.Infrastructures.Charts.Elements
{
    public class GeneralComponent
        : IHasIdentity, IHasPosition
    {
        #region IHasIdentity

        /// 
        public string? Id { get; set; }

        /// 
        public bool? Show { get; set; }

        /// 
        public int? ZLevel { get; set; }

        /// 
        public int? Z { get; set; }

        #endregion

        #region IHasPosition

        /// 
        public object? Left { get; set; } = "auto";

        /// 
        public object? Top { get; set; } = "auto";

        /// 
        public object? Right { get; set; } = "auto";

        /// 
        public object? Bottom { get; set; } = "auto";

        ///
        public object? Width { get; set; } = "auto";

        /// 
        public object? Height { get; set; } = "auto";

        #endregion
    }
}
