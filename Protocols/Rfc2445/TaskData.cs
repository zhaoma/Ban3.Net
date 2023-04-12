using System;

namespace Ban3.Protocols.Rfc2445
{
    /// <summary>
    /// 任务/计划数据
    /// </summary>
    [Serializable]
    public class TaskData
    {
        /// <summary>
        /// 标识
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 实例化
        /// </summary>
        public TaskData() {}

        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public TaskData( string id, string name )
        {
            Id = id;
            Name = name;
        }
    }
}