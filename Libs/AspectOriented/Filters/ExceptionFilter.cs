//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/12/11 11:27
//  function:	ExceptionFilter.cs
//  reference:	https://
//  ————————————————————————————————————————————————————————————————————————————
using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ban3.Infrastructures.AspectOriented.Filters
{
    public class ExceptionFilter
        : ExceptionFilterAttribute, IExceptionFilter
    {
        //发生异常时会执行这段代码
        public override void OnException(ExceptionContext filterContext)
        {
            //在这里你可以记录发生异常时你要干什么，比例写日志

            //这一行告诉系统，这个异常已经处理了，不用再处理
            filterContext.ExceptionHandled = true;
        }
    }
}

