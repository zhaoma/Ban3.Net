/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            表格显示样式信息
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;

namespace Ban3.Infrastructures.Common.Extensions.Consoles
{
    /// <summary>
    /// 表格显示样式信息
    /// 通过 Format 获取到的
    /// </summary>
    public class StyleInfo
    {
        public StyleInfo(string delimiterStr = "|", bool isShowTop_Down_DataBorder = true, string angleStr = "-")
        {
            DelimiterStr = delimiterStr;
            IsShowTop_Down_DataBorder = isShowTop_Down_DataBorder;
            AngleStr = angleStr;
        }

        /// <summary>
        /// 每一列数据之间的间隔字符串
        /// </summary>
        public string DelimiterStr { get; set; }

        /// <summary>
        /// 是否显示顶部，底部，和每一行数据之间的横向边框
        /// </summary>
        public bool IsShowTop_Down_DataBorder { get; set; }

        /// <summary>
        /// 边角字符串
        /// </summary>
        public string AngleStr { get; set; }
    }
}

