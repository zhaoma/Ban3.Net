using System;

namespace Ban3.Protocols.Rfc2445.Interfaces
{
    /// <summary>
    /// 日历对象接口
    /// </summary>
    public interface ICalendarObject : ISerializeToICAL
    {
        /// <summary>
        /// 
        /// </summary>
        string UID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        int? Sequence { get; set; }

        /// <summary>
        /// 
        /// </summary>
        DateTime? LastModified { get; set; }

        /// <summary>
        /// 
        /// </summary>
        Calendar Calendar { get; set; }
    }
}