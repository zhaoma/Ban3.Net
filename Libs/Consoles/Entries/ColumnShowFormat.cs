/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            列显示格式信息
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */


using Ban3.Infrastructures.Consoles.Enums;

namespace Ban3.Infrastructures.Consoles.Entries
{
    /// <summary>
    /// 列显示格式信息
    /// </summary>
    public class ColumnShowFormat
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="strLength"></param>
        /// <param name="alignment"></param>
        public ColumnShowFormat(int index, int strLength, Alignment alignment)
        {
            Index = index;
            StrLength = strLength;
            Alignment = alignment;
        }

        /// <summary>
        /// 索引，第几列数据
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 对其方式
        /// </summary>
        public Alignment Alignment { get; set; }

        /// <summary>
        /// 一列字符串长度
        /// </summary>
        public int StrLength { get; set; }
    }
}