﻿/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（记录基类）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Indicators.Entries
{
    /// <summary>
    /// 记录基类
    /// </summary>
    [Serializable, DataContract]
    public class Record
    {
        /// <summary>
        /// 记录时间
        /// </summary>
        [DataMember(Name = "markTime")]
        public DateTime MarkTime { get; set; }
    }
}