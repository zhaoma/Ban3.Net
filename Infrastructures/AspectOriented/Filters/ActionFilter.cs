using Microsoft.AspNetCore.Mvc.Filters;

namespace Ban3.Infrastructures.AspectOriented.Filters
{
    public class ActionFilter
        : ActionFilterAttribute, IActionFilter
    {
        /// <summary>
        /// action前执行校验
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //执行action前执行这个方法,比如做身份验证

        }

        /// <summary>
        ///  action后执行方法
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //执行action后执行这个方法 比如做操作日志
        }
    }
}
