using Ban3.Infrastructures.Common.Attributes;
using log4net;

namespace Ban3.Infrastructures.ServiceCentre.Applications;

[TracingIt]
public class Zero
{
     protected readonly ILog Logger = LogManager.GetLogger(typeof(Zero));
}

