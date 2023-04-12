using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Common.Contracts.Servers
{
    public class WeChat
    {
        #region 获取授权

        /// <summary>
        /// 获取访问token
        /// </summary>
        public const string UrlForGetAccessToken =
                "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";

        /// <summary>
        /// 获取到网页授权access_token
        /// </summary>
        public const string UrlForGetAccessTokenOnWeb =
                "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code";

        #endregion

        #region 创建菜单

        /// <summary>
        /// 创建菜单
        /// </summary>
        public const string UrlForCreateMenu =
                "https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}";

        /// <summary>
        /// 创建个性化菜单
        /// </summary>
        public const string UrlForCreateConditionalMenu =
                "https://api.weixin.qq.com/cgi-bin/menu/addconditional?access_token={0}";

        #endregion

        #region 用户标签

        /// <summary>
        /// 
        /// </summary>
        public const string UrlForGetUserTags =
                "https://api.weixin.qq.com/cgi-bin/tags/get?access_token={0}";

        /// <summary>
        /// 
        /// </summary>
        public const string UrlForCreateUserTags
                = "https://api.weixin.qq.com/cgi-bin/tags/create?access_token={0}";

        /// <summary>
        /// 
        /// </summary>
        public const string UrlForUpdateUserTags
                = "https://api.weixin.qq.com/cgi-bin/tags/update?access_token={0}";

        /// <summary>
        /// 
        /// </summary>
        public const string UrlForDeleteUserTags
                = "https://api.weixin.qq.com/cgi-bin/tags/delete?access_token={0}";

        #endregion

        #region 获取用户信息

        /// <summary>
        /// 获取用户列表
        /// </summary>
        public const string UrlForGetUsers = "https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}&next_openid={1}";

        /// <summary>
        /// 读取用户信息
        /// </summary>
        public const string UrlForReadGuest =
                "https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}";

        /// <summary>
        /// 不弹出授权页面，直接跳转，只能获取用户openid
        /// </summary>
        public const string UrlForApiBase =
                "https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_base&state=tinder#wechat_redirect";

        /// <summary>
        /// 弹出授权页面，可通过openid拿到昵称、性别、所在地。并且，即使在未关注的情况下，只要用户授权，也能获取其信息
        /// </summary>
        public const string UrlForApiUserInfo =
                "https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_userinfo&state=tinder#wechat_redirect";

        #endregion

        #region 图文素材

        /// <summary>
        /// 发送消息
        /// </summary>
        public const string UrlForMessage =
                "https://api.weixin.qq.com/cgi-bin/message/mass/send?access_token={0}";

        /// <summary>
        /// 上传图片
        /// </summary>
        public const string UrlForUploadimg =
                "https://api.weixin.qq.com/cgi-bin/media/uploadimg?access_token={0}";

        /// <summary>
        /// 
        /// </summary>
        public const string UrlForBatchgetMaterial =
                "https://api.weixin.qq.com/cgi-bin/material/batchget_material?access_token={0}";

        /// <summary>
        /// 新增图文素材
        /// </summary>
        public const string UrlForAddNews =
                "https://api.weixin.qq.com/cgi-bin/material/add_news?access_token={0}";

        /// <summary>
        /// 新增媒体素材
        /// </summary>
        public const string UrlForAddMaterial =
                "https://api.weixin.qq.com/cgi-bin/material/add_material?access_token={0}&type={1}";

        /// <summary>
        /// 新增多媒体
        /// </summary>
        public const string UrlForAddMedia =
                "https://api.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}";

        #endregion

        #region 二维码

        /// <summary>
        /// 生成场景二维码
        /// </summary>
        public const string UrlForCreateQrcode =
                "https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token={0}";

        /// <summary>
        /// 下载二维码图片
        /// </summary>
        public const string UrlForCreateQrcodeImage =
                "https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket={0}";

        /// <summary>
        /// 生成短链接
        /// </summary>
        public const string UrlForGenerateShortUrl
                = "https://api.weixin.qq.com/cgi-bin/shorturl?access_token={0}";

        #endregion

        #region 模板消息

        /// <summary>
        /// 模板消息推送Url(公众号)
        /// </summary>
        public const string UrlForSendTemplateMessage =
                "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}";

        /// <summary>
        /// 模板消息推送Url(小程序)
        /// </summary>
        private static readonly string UrlForSendMpTemplateMessage =
                "https://api.weixin.qq.com/cgi-bin/message/wxopen/template/send?access_token={0}";

        #endregion

        #region 开放平台

        /// <summary>
        /// 刷新或续期access_token使用
        /// </summary>
        public const string UrlForOpenRefreshToken = "https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={0}&grant_type=refresh_token&refresh_token={1}";

        #endregion

        /// <summary>
        /// JS-SDK使用权限签名算法（jsapi_ticket）
        /// </summary>
        public const string UrlForGetJsapiTicket =
                "https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=jsapi";
    }
}