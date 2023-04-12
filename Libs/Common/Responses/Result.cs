/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            响应基类
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using Ban3.Infrastructures.Common.Enums;

namespace Ban3.Infrastructures.Common.Responses
{
    /// <summary>
    /// 服务端响应
    /// </summary>
    public class Result
    {
        public ResponseStatusCode StatusCode { get; set; }

        /// <summary>
        /// 成功？
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 错误消息（source+message）
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 成功响应
        /// </summary>
        public Result()
        {
            Success = true;
        }

        /// <summary>
        /// 失败响应
        /// </summary>
        /// <param name="message"></param>
        public Result(string message)
        {
            Message = message;
        }

        public Result(ResponseStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}