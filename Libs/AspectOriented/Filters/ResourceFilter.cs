//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/12/11 19:27
//  function:	ResourceFilter.cs
//  reference:	https://
//  ————————————————————————————————————————————————————————————————————————————
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ban3.Infrastructures.AspectOriented.Filters
{
    public class ResourceFilter
        : ResultFilterAttribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("CustomerResourceFilterAttribute.OnResourceExecuting");
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine("CustomerResourceFilterAttribute.OnResourceExecuted");
        }
    }
}