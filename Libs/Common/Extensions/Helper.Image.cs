/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            扩展方法定义（图像）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Ban3.Infrastructures.Common.Extensions
{
    /// <summary>
    /// 图像扩展方法
    /// windows only
    /// </summary>
    public static partial class Helper
    {
        /// <summary>
        /// 将图片转为二进制
        /// </summary>
        /// <param name="path">图片路径</param>
        /// <returns></returns>
        public static byte[] ImageToBinary( string path )
        {
            Image returnImage = Image.FromFile( path );

            using( MemoryStream ms = new MemoryStream() )
            {
                returnImage.Save( ms, ImageFormat.Jpeg );
                ms.Flush();
                byte[] byteArrayImage = ms.ToArray();
                return byteArrayImage;
            }
        }

        /// <summary>
        /// 将二进制转为图片
        /// </summary>
        /// <param name="byteArrayImage">图片字节组</param>
        public static Image BinaryToImage( byte[] byteArrayImage )
        {
            using( MemoryStream ms = new MemoryStream( byteArrayImage ) )
            {
                Image returnImage = Image.FromStream( ms );
                ms.Flush();
                return returnImage;
                //returnImage.Save(filePath);
            }
        }
    }
}