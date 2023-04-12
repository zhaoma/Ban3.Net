using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Enums
{
    public enum BuildStatus
    {
        All, //All status.
        Cancelling, //The build is cancelling
        Completed, //The build has completed.
        InProgress, //The build is currently in progress.
        None, //No status.
        NotStarted, //The build has not yet started.
        Postponed //The build is inactive in the queue.
    }
}