using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;

namespace Ban3.Sites.ViaMicrosoft.Enums;

/// <summary>
/// The current state of the project.
/// </summary>
public enum ProjectState
{
    /// <summary>
    /// All projects regardless of state.
    /// </summary>
    All,

    /// <summary>
    /// Project has been queued for creation, but the process has not yet started.
    /// </summary>
    CreatePending,

    /// <summary>
    /// Project has been deleted.
    /// </summary>
    Deleted,

    /// <summary>
    /// Project is in the process of being deleted.
    /// </summary>
    Deleting,

    /// <summary>
    /// Project is in the process of being created.
    /// </summary>
    New,

    /// <summary>
    /// Project has not been changed.
    /// </summary>
    Unchanged,

    /// <summary>
    /// Project is completely created and ready to use.
    /// </summary>
    WellFormed
}