/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            eastmoney的资源定义
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

namespace Ban3.Infrastructures.Common.Contracts.Servers
{
    /// <summary>
    /// eastmoney的资源定义
    /// </summary>
    public class Eastmoney
    {
        /// <summary>
        /// 从东财获取所有标的（代码与名称）
        /// </summary>
        public const string UrlForGetCodes =
                "http://76.push2.eastmoney.com/api/qt/clist/get?cb=eastmoney&pn=1&pz=10000&po=1&np=1&ut=bd1d9ddb04089700cf9c27f6f7426281&fltt=2&invt=2&fid=f3&fs=m:0+t:6,m:0+t:13,m:0+t:80,m:1+t:2,m:1+t:23&fields=f12,f14&_=1568202837032";

        /// <summary>
        /// 流通股东
        /// https://datacenter-web.eastmoney.com/api/data/v1/get?callback=jQuery112307888408437963645_1669787027513&sortColumns=UPDATE_DATE%2CSECURITY_CODE%2CHOLDER_RANK&sortTypes=-1%2C1%2C1&pageSize=50&pageNumber=1&reportName=RPT_CUSTOM_F10_EH_FREEHOLDERS_JOIN_FREEHOLDER_SHAREANALYSIS&columns=ALL%3BD10_ADJCHRATE%2CD30_ADJCHRATE%2CD60_ADJCHRATE&source=WEB&client=WEB&filter=(END_DATE%3E%3D%272022-09-30%27)
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        private static string UrlForHoldersA( int page = 1, int ps = 300 )
        {
            return $"http://dcfm.eastmoney.com//em_mutisvcexpandinterface/api/js/get?type=NSHDDETAILLA&token=70f12f2f4f091e459a279469fe49eca5&cmd=&st=NDATE,SCODE,RANK&sr=1&p={page}&ps={ps}" +
                   "&js={\"pages\":(tp),\"data\":(x)}";
        }

        /// <summary>
        /// 十大股东
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        private static string UrlForHoldersB( int page = 1, int ps = 300 )
        {
            return
                    $"http://dcfm.eastmoney.com//em_mutisvcexpandinterface/api/js/get?type=HDDETAILLA&token=70f12f2f4f091e459a279469fe49eca5&cmd=&st=NDATE,SCODE,RANK&sr=1&p={page}&ps={ps}" +
                    "&js={\"pages\":(tp),\"data\":(x)}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code">十大股东？A/B</param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static string UrlForHolders( string code, int page )
        {
            return code == "A"
                           ? UrlForHoldersA( page )
                           : UrlForHoldersB( page );
        }
    }
}