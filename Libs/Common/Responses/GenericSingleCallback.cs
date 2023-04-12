
namespace Ban3.Infrastructures.Common.Responses
{
    /// <summary>
    /// 单结果返回
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericSingleCallback<T>
            : Result
    {
        /// <summary>
        /// 结果
        /// </summary>
        public T Data { get; set; }
    }
}