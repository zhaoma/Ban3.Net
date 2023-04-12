using System.Collections.Generic;
using Ban3.Infrastructures.Platforms.ViaMicrosoft.Enums;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Request.Reports
{
    public class DataFilter
    {
        /// <summary>
        /// 限定组
        /// </summary>
        public List<string> LimitTeamIds { get; set; }

        /// <summary>
        /// 限定创建者
        /// </summary>
        public List<string> LimitIdentityIds { get; set; }

        /// <summary>
        /// 包含关键字
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// 不包含关键字
        /// </summary>
        public string Exclude { get; set; }

        /// <summary>
        /// 起始日期
        /// </summary>
        public string FromDate { get; set; }

        /// <summary>
        /// 截至日期
        /// </summary>
        public string ToDate { get; set; }

        /// <summary>
        /// 页尺寸
        /// </summary>
        public int PageSize { get; set; } = 20;

        /// <summary>
        /// 页码
        /// </summary>
        public int PageNo { get; set; } = 1;

        /// <summary>
        /// 评论作者
        /// </summary>
        public string CommentAuthor { get; set; }

        /// <summary>
        /// 报告目标，changeset/shelveset
        /// </summary>
        public ReportRef Ref { get; set; } = ReportRef.Shelveset;

        public bool HasComments { get; set; }
    }
}
