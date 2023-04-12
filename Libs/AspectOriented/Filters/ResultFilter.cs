//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/12/11 11:39
//  function:	ResultFilter.cs
//  reference:	https://
//  ————————————————————————————————————————————————————————————————————————————
using System;
using log4net;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ban3.Infrastructures.AspectOriented.Filters
{
	public class ResultFilter 
		: ResultFilterAttribute, IResultFilter
	{
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //执行完action后跳转后执行
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //执行完action后跳转前执行
        }
    }
}

