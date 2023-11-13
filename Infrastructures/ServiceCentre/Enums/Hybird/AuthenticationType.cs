// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;

namespace Ban3.Infrastructures.ServiceCentre.Enums.Hybird;

/// <summary>
/// 服务器认证方式
/// </summary>
public enum AuthenticationType
{
    /// <summary>
    /// 匿名
    /// </summary>
    [Description("None")]
    None,

    /// <summary>
    /// 基本认证
    /// 服务端的401响应中包含一个认证要求（authentication challenge），此认证要求中含有“Basic”关键字和一个用以表明访问的被保护资源名称的“名称=值”对，如下：
    /// WWW-Authenticate: Basic realm =”Protected page”
    /// 如果你使用的浏览器，浏览器在接收到401响应时，将会弹出窗口让你输入用户名密码，然后发送认证请求。认证请求中同样包含”Basic”关键字，此外还有Base64编码后的用户名密码，如下：
    /// Authorization: Basic QWRlcGxveSdzIGJsb2c =
    /// 服务器将用户名密码解码后比对，成功匹配后即认证成功。
    /// 因为Base64不算是一种加密方法：无密钥的可逆加密，任何人都可解密（百度搜索一下”在线解码“一大堆）。因此基本认证被认为是明文传输，安全性不好。极易出现密码被窃听和重放攻击等安全性问题。
    /// </summary>
    [Description("Basic")]
    Basic,

    /// <summary>
    /// 摘要认证
    /// 摘要认证被设计用来弥补基本认证的缺点。摘要认证基于请求-响应（challenge-response）模式，而且使用了哈希加密算法（常用为MD5），从而某些程度上解决了基本认证安全性的问题。
    /// 服务器返回的初始401响应的www认证头（WWW-Authenticate header）中多出了一个称为nonce的随机数的字段。服务端保证每个401响应中的nonce值唯一。如：
    /// Authorization: Digest username =”admin”, realm =”HiPER”
    /// 接下来的客户端响应中将包含由用户名、密码、nonce和其他信息组成的数据的哈希值（如使用MD5加密）。所有被加密的数据服务端也具有，因此服务端执行同样加密过程。如果二者一直则认证成功。
    /// 因为如MD5等哈希加密算法是不可逆的，因此用户名密码明文无法被窃听破解。因为服务器对同一个nonce的请求只接受一次客户端请求，从而能避免重放攻击。
    /// 但是，digest的安全性也有缺点：
    /// 1）只有密码密码被加密，而客户端最终请求的被保护资源是明文传送的，可被窃听
    /// 2）客户端无法确认服务端的正确身份，缺少对服务端的认证方式
    /// 3）近年来，随着计算机性能的提高等因素，传统高强度加密算法的破解已成可能。而MD5更是已有破解方法。更多安全性问题请参考RFC2617。
    /// </summary>
    [Description("Digest")]
    Digest,

    /// <summary>
    /// NT LAN Manager
    /// NTLM是一种网络认证协议，与NTLM Hash的关系就是：NTLM 网络认证协议是以 NTLM Hash 作为根本凭证进行认证的协议。也就是说，NTLM与NTLM Hash 相互对应。
    /// 在本地认证的过程中，其实就是将用户输入的密码转换为 NTLM Hash 与 SAM 中的 NTLM Hash 进行比较。
    /// NTLM Hash的产生
    /// 1.先将用户的密码转化为十六进制格式。   
    /// 2.将十六进制格式的密码进行 Unicode 编码。
    /// 3.使用 MD4 摘要算法对 Unicode 编码数据进行 Hash 计算。
    /// 假设我的密码是admin，那么操作系统会将admin转换为十六进制，经过Unicode转换后，再调用MD4加密算法加密，这个加密结果的十六进制就是NTLM Hash。
    /// 1 admin                 -> hex(16进制编码)       = 61646d696e 
    /// 2 61646d696e            -> Unicode              = 610064006d0069006e00
    /// 3 610064006d0069006e00  -> MD4                  = 209c6174da490caeb422f3fa5a7ae634
    /// </summary>
    [Description("NTLM")]
    NTLM,

    /// <summary>
    /// Kerberose相比NTML有很大改善：速度快，而且允许相互认证、认证代理和简单的信任关系。
    /// </summary>
    [Description("Negotiate")]
    Negotiate,

    /// <summary>
    /// 服务器与客户端通过第三方的Kerberos服务器完成认证。
    /// Kerberose相比NTML有很大改善：速度快，而且允许相互认证、认证代理和简单的信任关系。
    /// </summary>
    [Description("Kerberos")]
    Kerberos,

    /// <summary>
    /// 全称是Simple and Protected GSS-API Negotiation，是微软提供的一种使用GSS-API认证机制的安全协议，用于使Webserver共享Windows Credentials，它扩展了Kerberos(一种网络认证协议)。
    /// SPNEGO适用于客户端需要认证，但是客户端服务端都不清楚对方支持什么认证协议的场合。
    /// SPENGO其实是一种”伪认证机制“（pseudo-mechanism），用以协商出真正的认证机制。
    /// 最常见的是微软的HTTP协商认证扩展（HTTP Negotiate authentication extension），协商的最终机制在NTML和Kerberos中选择。Kerberos因其优点优先使用。
    /// </summary>
    [Description("SPNEGO")]
    SPNEGO
}

