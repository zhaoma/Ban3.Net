﻿/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            扩展方法定义（汉语拼音）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.Collections;
using System.Text;

namespace Ban3.Infrastructures.Common.Extensions
{
    /// <summary>
    /// 汉语拼音扩展方法
    /// </summary>
    public static partial class Helper
    {
        #region static stor.

        /// <summary>
        /// 拼音哈希表
        /// </summary>
        private static Hashtable PinyinHash
                = new Hashtable
                {
                        { -20319, "a" },
                        { -20317, "ai" },
                        { -20304, "an" },
                        { -20295, "ang" },
                        { -20292, "ao" },
                        { -20283, "ba" },
                        { -20265, "bai" },
                        { -20257, "ban" },
                        { -20242, "bang" },
                        { -20230, "bao" },
                        { -20051, "bei" },
                        { -20036, "ben" },
                        { -20032, "beng" },
                        { -20026, "bi" },
                        { -20002, "bian" },
                        { -19990, "biao" },
                        { -19986, "bie" },
                        { -19982, "bin" },
                        { -19976, "bing" },
                        { -19805, "bo" },
                        { -19784, "bu" },
                        { -19775, "ca" },
                        { -19774, "cai" },
                        { -19763, "can" },
                        { -19756, "cang" },
                        { -19751, "cao" },
                        { -19746, "ce" },
                        { -19741, "ceng" },
                        { -19739, "cha" },
                        { -19728, "chai" },
                        { -19725, "chan" },
                        { -19715, "chang" },
                        { -19540, "chao" },
                        { -19531, "che" },
                        { -19525, "chen" },
                        { -19515, "cheng" },
                        { -19500, "chi" },
                        { -19484, "chong" },
                        { -19479, "chou" },
                        { -19467, "chu" },
                        { -19289, "chuai" },
                        { -19288, "chuan" },
                        { -19281, "chuang" },
                        { -19275, "chui" },
                        { -19270, "chun" },
                        { -19263, "chuo" },
                        { -19261, "ci" },
                        { -19249, "cong" },
                        { -19243, "cou" },
                        { -19242, "cu" },
                        { -19238, "cuan" },
                        { -19235, "cui" },
                        { -19227, "cun" },
                        { -19224, "cuo" },
                        { -19218, "da" },
                        { -19212, "dai" },
                        { -19038, "dan" },
                        { -19023, "dang" },
                        { -19018, "dao" },
                        { -19006, "de" },
                        { -19003, "deng" },
                        { -18996, "di" },
                        { -18977, "dian" },
                        { -18961, "diao" },
                        { -18952, "die" },
                        { -18783, "ding" },
                        { -18774, "diu" },
                        { -18773, "dong" },
                        { -18763, "dou" },
                        { -18756, "du" },
                        { -18741, "duan" },
                        { -18735, "dui" },
                        { -18731, "dun" },
                        { -18722, "duo" },
                        { -18710, "e" },
                        { -18697, "en" },
                        { -18696, "er" },
                        { -18526, "fa" },
                        { -18518, "fan" },
                        { -18501, "fang" },
                        { -18490, "fei" },
                        { -18478, "fen" },
                        { -18463, "feng" },
                        { -18448, "fo" },
                        { -18447, "fou" },
                        { -18446, "fu" },
                        { -18239, "ga" },
                        { -18237, "gai" },
                        { -18231, "gan" },
                        { -18220, "gang" },
                        { -18211, "gao" },
                        { -18201, "ge" },
                        { -18184, "gei" },
                        { -18183, "gen" },
                        { -18181, "geng" },
                        { -18012, "gong" },
                        { -17997, "gou" },
                        { -17988, "gu" },
                        { -17970, "gua" },
                        { -17964, "guai" },
                        { -17961, "guan" },
                        { -17950, "guang" },
                        { -17947, "gui" },
                        { -17931, "gun" },
                        { -17928, "guo" },
                        { -17922, "ha" },
                        { -17759, "hai" },
                        { -17752, "han" },
                        { -17733, "hang" },
                        { -17730, "hao" },
                        { -17721, "he" },
                        { -17703, "hei" },
                        { -17701, "hen" },
                        { -17697, "heng" },
                        { -17692, "hong" },
                        { -17683, "hou" },
                        { -17676, "hu" },
                        { -17496, "hua" },
                        { -17487, "huai" },
                        { -17482, "huan" },
                        { -17468, "huang" },
                        { -17454, "hui" },
                        { -17433, "hun" },
                        { -17427, "huo" },
                        { -17417, "ji" },
                        { -17202, "jia" },
                        { -17185, "jian" },
                        { -16983, "jiang" },
                        { -16970, "jiao" },
                        { -16942, "jie" },
                        { -16915, "jin" },
                        { -16733, "jing" },
                        { -16708, "jiong" },
                        { -16706, "jiu" },
                        { -16689, "ju" },
                        { -16664, "juan" },
                        { -16657, "jue" },
                        { -16647, "jun" },
                        { -16474, "ka" },
                        { -16470, "kai" },
                        { -16465, "kan" },
                        { -16459, "kang" },
                        { -16452, "kao" },
                        { -16448, "ke" },
                        { -16433, "ken" },
                        { -16429, "keng" },
                        { -16427, "kong" },
                        { -16423, "kou" },
                        { -16419, "ku" },
                        { -16412, "kua" },
                        { -16407, "kuai" },
                        { -16403, "kuan" },
                        { -16401, "kuang" },
                        { -16393, "kui" },
                        { -16220, "kun" },
                        { -16216, "kuo" },
                        { -16212, "la" },
                        { -16205, "lai" },
                        { -16202, "lan" },
                        { -16187, "lang" },
                        { -16180, "lao" },
                        { -16171, "le" },
                        { -16169, "lei" },
                        { -16158, "leng" },
                        { -16155, "li" },
                        { -15959, "lia" },
                        { -15958, "lian" },
                        { -15944, "liang" },
                        { -15933, "liao" },
                        { -15920, "lie" },
                        { -15915, "lin" },
                        { -15903, "ling" },
                        { -15889, "liu" },
                        { -15878, "long" },
                        { -15707, "lou" },
                        { -15701, "lu" },
                        { -15681, "lv" },
                        { -15667, "luan" },
                        { -15661, "lue" },
                        { -15659, "lun" },
                        { -15652, "luo" },
                        { -15640, "ma" },
                        { -15631, "mai" },
                        { -15625, "man" },
                        { -15454, "mang" },
                        { -15448, "mao" },
                        { -15436, "me" },
                        { -15435, "mei" },
                        { -15419, "men" },
                        { -15416, "meng" },
                        { -15408, "mi" },
                        { -15394, "mian" },
                        { -15385, "miao" },
                        { -15377, "mie" },
                        { -15375, "min" },
                        { -15369, "ming" },
                        { -15363, "miu" },
                        { -15362, "mo" },
                        { -15183, "mou" },
                        { -15180, "mu" },
                        { -15165, "na" },
                        { -15158, "nai" },
                        { -15153, "nan" },
                        { -15150, "nang" },
                        { -15149, "nao" },
                        { -15144, "ne" },
                        { -15143, "nei" },
                        { -15141, "nen" },
                        { -15140, "neng" },
                        { -15139, "ni" },
                        { -15128, "nian" },
                        { -15121, "niang" },
                        { -15119, "niao" },
                        { -15117, "nie" },
                        { -15110, "nin" },
                        { -15109, "ning" },
                        { -14941, "niu" },
                        { -14937, "nong" },
                        { -14933, "nu" },
                        { -14930, "nv" },
                        { -14929, "nuan" },
                        { -14928, "nue" },
                        { -14926, "nuo" },
                        { -14922, "o" },
                        { -14921, "ou" },
                        { -14914, "pa" },
                        { -14908, "pai" },
                        { -14902, "pan" },
                        { -14894, "pang" },
                        { -14889, "pao" },
                        { -14882, "pei" },
                        { -14873, "pen" },
                        { -14871, "peng" },
                        { -14857, "pi" },
                        { -14678, "pian" },
                        { -14674, "piao" },
                        { -14670, "pie" },
                        { -14668, "pin" },
                        { -14663, "ping" },
                        { -14654, "po" },
                        { -14645, "pu" },
                        { -14630, "qi" },
                        { -14594, "qia" },
                        { -14429, "qian" },
                        { -14407, "qiang" },
                        { -14399, "qiao" },
                        { -14384, "qie" },
                        { -14379, "qin" },
                        { -14368, "qing" },
                        { -14355, "qiong" },
                        { -14353, "qiu" },
                        { -14345, "qu" },
                        { -14170, "quan" },
                        { -14159, "que" },
                        { -14151, "qun" },
                        { -14149, "ran" },
                        { -14145, "rang" },
                        { -14140, "rao" },
                        { -14137, "re" },
                        { -14135, "ren" },
                        { -14125, "reng" },
                        { -14123, "ri" },
                        { -14122, "rong" },
                        { -14112, "rou" },
                        { -14109, "ru" },
                        { -14099, "ruan" },
                        { -14097, "rui" },
                        { -14094, "run" },
                        { -14092, "ruo" },
                        { -14090, "sa" },
                        { -14087, "sai" },
                        { -14083, "san" },
                        { -13917, "sang" },
                        { -13914, "sao" },
                        { -13910, "se" },
                        { -13907, "sen" },
                        { -13906, "seng" },
                        { -13905, "sha" },
                        { -13896, "shai" },
                        { -13894, "shan" },
                        { -13878, "shang" },
                        { -13870, "shao" },
                        { -13859, "she" },
                        { -13847, "shen" },
                        { -13831, "sheng" },
                        { -13658, "shi" },
                        { -13611, "shou" },
                        { -13601, "shu" },
                        { -13406, "shua" },
                        { -13404, "shuai" },
                        { -13400, "shuan" },
                        { -13398, "shuang" },
                        { -13395, "shui" },
                        { -13391, "shun" },
                        { -13387, "shuo" },
                        { -13383, "si" },
                        { -13367, "song" },
                        { -13359, "sou" },
                        { -13356, "su" },
                        { -13343, "suan" },
                        { -13340, "sui" },
                        { -13329, "sun" },
                        { -13326, "suo" },
                        { -13318, "ta" },
                        { -13147, "tai" },
                        { -13138, "tan" },
                        { -13120, "tang" },
                        { -13107, "tao" },
                        { -13096, "te" },
                        { -13095, "teng" },
                        { -13091, "ti" },
                        { -13076, "tian" },
                        { -13068, "tiao" },
                        { -13063, "tie" },
                        { -13060, "ting" },
                        { -12888, "tong" },
                        { -12875, "tou" },
                        { -12871, "tu" },
                        { -12860, "tuan" },
                        { -12858, "tui" },
                        { -12852, "tun" },
                        { -12849, "tuo" },
                        { -12838, "wa" },
                        { -12831, "wai" },
                        { -12829, "wan" },
                        { -12812, "wang" },
                        { -12802, "wei" },
                        { -12607, "wen" },
                        { -12597, "weng" },
                        { -12594, "wo" },
                        { -12585, "wu" },
                        { -12556, "xi" },
                        { -12359, "xia" },
                        { -12346, "xian" },
                        { -12320, "xiang" },
                        { -12300, "xiao" },
                        { -12120, "xie" },
                        { -12099, "xin" },
                        { -12089, "xing" },
                        { -12074, "xiong" },
                        { -12067, "xiu" },
                        { -12058, "xu" },
                        { -12039, "xuan" },
                        { -11867, "xue" },
                        { -11861, "xun" },
                        { -11847, "ya" },
                        { -11831, "yan" },
                        { -11798, "yang" },
                        { -11781, "yao" },
                        { -11604, "ye" },
                        { -11589, "yi" },
                        { -11536, "yin" },
                        { -11358, "ying" },
                        { -11340, "yo" },
                        { -11339, "yong" },
                        { -11324, "you" },
                        { -11303, "yu" },
                        { -11097, "yuan" },
                        { -11077, "yue" },
                        { -11067, "yun" },
                        { -11055, "za" },
                        { -11052, "zai" },
                        { -11045, "zan" },
                        { -11041, "zang" },
                        { -11038, "zao" },
                        { -11024, "ze" },
                        { -11020, "zei" },
                        { -11019, "zen" },
                        { -11018, "zeng" },
                        { -11014, "zha" },
                        { -10838, "zhai" },
                        { -10832, "zhan" },
                        { -10815, "zhang" },
                        { -10800, "zhao" },
                        { -10790, "zhe" },
                        { -10780, "zhen" },
                        { -10764, "zheng" },
                        { -10587, "zhi" },
                        { -10544, "zhong" },
                        { -10533, "zhou" },
                        { -10519, "zhu" },
                        { -10331, "zhua" },
                        { -10329, "zhuai" },
                        { -10328, "zhuan" },
                        { -10322, "zhuang" },
                        { -10315, "zhui" },
                        { -10309, "zhun" },
                        { -10307, "zhuo" },
                        { -10296, "zi" },
                        { -10281, "zong" },
                        { -10274, "zou" },
                        { -10270, "zu" },
                        { -10262, "zuan" },
                        { -10260, "zui" },
                        { -10256, "zun" },
                        { -10254, "zuo" },
                        { -10247, "zz" }
                };

        /// <summary>
        /// Gets the pinyin.
        /// </summary>
        /// <param name="charValue">The char value.</param>
        /// <returns></returns>
        private static string GetPinyin( this int charValue )
        {
            if( charValue < -20319 || charValue > -10247 )
                return "";

            while( !PinyinHash.ContainsKey( charValue ) )
                charValue--;

            return (string)PinyinHash[ charValue ];
        }

        #endregion

        /// <summary>
        /// Gets the pinyin.
        /// </summary>
        /// <param name="chineseChars">The chinese chars.</param>
        /// <returns></returns>
        public static string GetPinyin( this string chineseChars )
        {
            byte[] byteArray = System.Text.Encoding.Default.GetBytes( chineseChars );
            int byteValue;
            StringBuilder sb = new StringBuilder( chineseChars.Length * 4 );
            for( int i = 0; i < byteArray.Length; i++ )
            {
                byteValue = (int)byteArray[ i ];
                if( byteValue > 160 )
                {
                    byteValue = byteValue * 256 + byteArray[ ++i ] - 65536;
                    sb.Append( byteValue.GetPinyin() );
                }
                else
                {
                    sb.Append( (char)byteValue );
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Gets the short pinyin.
        /// </summary>
        /// <param name="chineseChars">The chinese chars.</param>
        /// <returns></returns>
        public static string GetShortPinyin( this string chineseChars )
        {
            byte[] byteArray = System.Text.Encoding.Default.GetBytes( chineseChars );
            int byteValue;
            StringBuilder sb = new StringBuilder( chineseChars.Length * 4 );
            for( int i = 0; i < byteArray.Length; i++ )
            {
                byteValue = (int)byteArray[ i ];
                if( byteValue > 160 )
                {
                    byteValue = byteValue * 256 + byteArray[ ++i ] - 65536;
                    string charPinyin = byteValue.GetPinyin();
                    if( !string.IsNullOrEmpty( charPinyin ) )
                    {
                        charPinyin = new string( charPinyin[ 0 ], 1 );
                    }

                    sb.Append( charPinyin );
                }
                else
                {
                    sb.Append( (char)byteValue );
                }
            }

            return sb.ToString();
        }
    }
}