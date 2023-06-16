//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    
//  reference:
//  ————————————————————————————————————————————————————————————————————————————

using  Ban3.Infrastructures.Charts.Cogs;
using  Ban3.Infrastructures.Charts.Elements;
using  Ban3.Infrastructures.Charts.Styles;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ECharts =  Ban3.Infrastructures.Charts.Enums;

namespace  Ban3.Infrastructures.Charts.Styles
{
    public class CheckpointStyle
        : GeneralStyle, IHasSymbol
    {
        #region IHasSymbol

        /// 
        public ECharts.Symbol? Symbol { get; set; }

        /// 
        public object? SymbolSize { get; set; }

        /// 
        public int? SymbolRotate { get; set; }

        /// 
        public bool? SymbolKeepAspect { get; set; }

        /// 
        public object? SymbolOffset { get; set; }

        #endregion
    }
}
