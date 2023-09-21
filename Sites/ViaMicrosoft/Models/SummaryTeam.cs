using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Sites.ViaMicrosoft.Models;

/// <summary>
/// 
/// </summary>
public class SummaryTeam
{
    public string Id { get; set; }

    public string Name { get; set; }

    public int ShelvesetCount { get; set; }

    public int ChangesetCount { get; set; }

    public int PassRatio { get; set; }
}