//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/9/25 09:42
//  function:	DownloadLiftsResult.cs
//  reference:	https://
//  ————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;
using Ban3.Sites.ViaSina.Entries;

namespace Ban3.Sites.ViaSina.Response;

public class DownloadLiftsResult
{
    public List<ShareBonus> Data { get; set; }
}