using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Sites.ViaMicrosoft.Enums;

/// <summary>
/// Indicates whom the project is visible to.
/// </summary>
public enum ProjectVisibility
{
    /// <summary>
    /// The project is only visible to users with explicit access.
    /// </summary>
    Private,

    /// <summary>
    /// The project is visible to all.
    /// </summary>
    Public
}