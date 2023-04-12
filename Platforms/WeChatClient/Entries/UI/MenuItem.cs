﻿using System.Runtime.Serialization;

namespace Ban3.Platforms.WeChatClient.Entries.UI
{
    /// <summary>
    /// 微信菜单项
    /// </summary>
    [DataContract]
    public class MenuItem
    {
        /// <summary>
        /// 菜单KEY值，用于消息接口推送，不超过128字节
        /// </summary>
        [DataMember(Name = "key")]
        public string Key { get; set; } = string.Empty;

        /// <summary>
        /// 按键链接
        /// view类型必须	网页链接，用户点击菜单可打开链接，不超过1024字节
        /// </summary>
        [DataMember(Name = "url")]
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// 菜单的响应动作类型
        /// 1、click：点击推事件
        /// 用户点击click类型按钮后，微信服务器会通过消息接口推送消息类型为event 的结构给开发者（参考消息接口指南），并且带上按钮中开发者填写的key值，开发者可以通过自定义的key值与用户进行交互；
        /// 2、view：跳转URL
        /// 用户点击view类型按钮后，微信客户端将会打开开发者在按钮中填写的网页URL，可与网页授权获取用户基本信息接口结合，获得用户基本信息。
        /// 3、scancode_push：扫码推事件
        /// 用户点击按钮后，微信客户端将调起扫一扫工具，完成扫码操作后显示扫描结果（如果是URL，将进入URL），且会将扫码的结果传给开发者，开发者可以下发消息。
        /// 4、scancode_waitmsg：扫码推事件且弹出“消息接收中”提示框
        /// 用户点击按钮后，微信客户端将调起扫一扫工具，完成扫码操作后，将扫码的结果传给开发者，同时收起扫一扫工具，然后弹出“消息接收中”提示框，随后可能会收到开发者下发的消息。
        /// 5、pic_sysphoto：弹出系统拍照发图
        /// 用户点击按钮后，微信客户端将调起系统相机，完成拍照操作后，会将拍摄的相片发送给开发者，并推送事件给开发者，同时收起系统相机，随后可能会收到开发者下发的消息。
        /// 6、pic_photo_or_album：弹出拍照或者相册发图
        /// 用户点击按钮后，微信客户端将弹出选择器供用户选择“拍照”或者“从手机相册选择”。用户选择后即走其他两种流程。
        /// 7、pic_weixin：弹出微信相册发图器
        /// 用户点击按钮后，微信客户端将调起微信相册，完成选择操作后，将选择的相片发送给开发者的服务器，并推送事件给开发者，同时收起相册，随后可能会收到开发者下发的消息。
        /// 8、location_select：弹出地理位置选择器
        /// 用户点击按钮后，微信客户端将调起地理位置选择工具，完成选择操作后，将选择的地理位置发送给开发者的服务器，同时收起位置选择工具，随后可能会收到开发者下发的消息。
        /// 9、media_id：下发消息（除文本消息）
        /// 用户点击media_id类型按钮后，微信服务器会将开发者填写的永久素材id对应的素材下发给用户，永久素材类型可以是图片、音频、视频、图文消息。请注意：永久素材id必须是在“素材管理/新增永久素材”接口上传后获得的合法id。
        /// 10、view_limited：跳转图文消息URL
        /// 用户点击view_limited类型按钮后，微信客户端将打开开发者在按钮中填写的永久素材id对应的图文消息URL，永久素材类型只支持图文消息。请注意：永久素材id必须是在“素材管理/新增永久素材”接口上传后获得的合法id。
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// 菜单标题，不超过16个字节，子菜单不超过40个字节
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// media_id类型和view_limited类型必须
        /// 调用新增永久素材接口返回的合法media_id
        /// </summary>
        [DataMember(Name = "media_id")]
        public string MediaId { get; set; } = string.Empty;
    }
}