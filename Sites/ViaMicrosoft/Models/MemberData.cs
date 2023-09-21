// ——————————————————————————————————————
// zhaoma @ 2022 :
// /Users/zhaoma/Projects/fintry/src/Tfvckits/Domain/Platform/Models/MemberData.cs
// ——————————————————————————————————————
using System;
using System.Collections.Generic;

namespace Ban3.Sites.ViaMicrosoft.Models;

public class MemberData
{
    public MemberData()
    {
    }

    public List<Entities.TFVC.TfvcChangesetRef> Changesets { get; set; }

    public List<Entities.TFVC.TfvcShelvesetRef> Shelvesets { get; set; }

    public List<Entities.TFVC.AssociatedWorkItem> WorkItems { get; set; }

    public List<Entities.Discussion.Thread> Threads { get; set; }

    public List<Entities.Discussion.Comment> Comments { get; set; }

    public List<RefererMapping> RefererMappings { get; set; }
}