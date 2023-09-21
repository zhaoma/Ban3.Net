using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Sites.ViaMicrosoft.Models;

public class SummaryIdentity
{
    public string Id { get; set; }

    public string DisplayName { get; set; }

    public string UniqueName { get; set; }

    public int ShelvesetCount { get; set; }

    public int ChangesetCount { get; set; }

    public int PassRatio { get; set; }
}