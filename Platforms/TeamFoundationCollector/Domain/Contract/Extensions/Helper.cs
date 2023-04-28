using log4net;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;

public static partial  class Helper
{
    static readonly ILog Logger = LogManager.GetLogger(typeof(Helper));

    static readonly object ObjLock = new object();

    static readonly ReaderWriterLockSlim LockSlim = new ReaderWriterLockSlim();

    const int LockSlimTimeout = 1000;

    public static bool IsIgnored(this string str)
        => Config.IgnoredKeys.Any(str.Contains);
}