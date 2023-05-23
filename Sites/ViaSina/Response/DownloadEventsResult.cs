//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/9/25 09:41
//  function:	DownloadEventsResult.cs
//  reference:	https://
//  ————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;
using Ban3.Sites.ViaSina.Entries;

namespace Ban3.Sites.ViaSina.Response;

public class DownloadEventsResult
{
    public List<ShareBonus> Data { get; set; }
}

