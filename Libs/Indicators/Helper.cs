using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Indicators.Enums;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Infrastructures.Indicators.Outputs;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ban3.Infrastructures.Common.Attributes;

namespace Ban3.Infrastructures.Indicators
{
    [TracingIt]
    public static class Helper
    {
        static readonly ILog Logger = LogManager.GetLogger(typeof(Helper));
        
    }
}
