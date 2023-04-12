//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/9/25 09:47
//  function:	Gtimg.cs
//  reference:	https://
//  ————————————————————————————————————————————————————————————————————————————
using System;
namespace Ban3.Infrastructures.Common.Contracts.Servers
{
	public class Gtimg
	{
		public Gtimg()
		{
		}

		public static string UrlForReadBidANdAsk(string code) => $"http://qt.gtimg.cn/q=s_pksz000858";

		public static string UrlForReadBrief(string code) => $"http://qt.gtimg.cn/q=s_sz000858";
	}
}

