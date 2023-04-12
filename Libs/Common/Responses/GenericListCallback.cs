/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            集合结果返回
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.Collections.Generic;

namespace Ban3.Infrastructures.Common.Responses
{
    /// <summary>
    /// 集合结果返回
    /// </summary>
    /// <typeparam name="T"></typeparam>
	public class GenericListCallback<T>
        : Result
    {
        /// <summary>
        /// 集合结果
        /// </summary>
        public List<T> Data { get; set; }
    }
}

