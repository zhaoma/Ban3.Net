using System;
namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Request
{
	public interface IRequest
	{
		/// <summary>
        /// 准备请求的方法
        /// </summary>
        /// <returns></returns>
		string Method();

		/// <summary>
        /// 准备请求的资源地址
        /// </summary>
        /// <returns></returns>
		string Resource();

        /// <summary>
        /// 准备请求Body
        /// </summary>
        /// <returns></returns>
        string JsonBody();
    }
}

