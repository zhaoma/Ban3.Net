/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            CalDAV服务实现
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.Xml;
using System;
using System.Collections.Generic;
using System.Threading.Channels;
using CalDAV = Ban3.Infrastructures.Common.Contracts.Entities.Particulars.CalDAV;
using log4net;

namespace Ban3.Infrastructures.Particulars.UtilizeCalDAV
{
    /// <summary>
    /// CalDAV服务实现
    /// </summary>
    public class Service
        :Interfaces.Particulars.ICalDAV
    {

        private readonly ILog _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public Service(ILog logger)
        {
            _logger = logger;
        }


        /*
        
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="responseContent"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        public CalDAV.XmlPack DeserializeXmlContent(string responseContent, Uri uri)
        {
            try
            {
                XmlDocument responseBody = new XmlDocument();
                responseBody.LoadXml(responseContent);

                XmlNamespaceManager namespaceManager = new XmlNamespaceManager(responseBody.NameTable);

                namespaceManager.AddNamespace("D", "DAV:");
                namespaceManager.AddNamespace("C", "urn:ietf:params:xml:ns:caldav");
                namespaceManager.AddNamespace("A", "urn:ietf:params:xml:ns:carddav");
                namespaceManager.AddNamespace("E", "http://apple.com/ns/ical/");

                return new CalDAV.XmlPack(responseBody, namespaceManager, uri);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            return null;
        }


        /// <summary>
        /// 是否支持日历或是通讯录
        /// </summary>
        /// <param name="url"></param>
        /// <param name="feature">
        /// calendar-access
        /// addressbook
        /// </param>
        /// <returns></returns>
        public bool Supported(string url, string feature = "calendar-access")
        {
            var result = false;

            var resp = Avatar.Submit2WebDav("OPTIONS", url);

            var options = new List<string>();
            if (resp.Headers.ContainsKey("DAV"))
            {
                options.AddRange((resp.Headers["DAV"] + "").Split(','));
            }

            if (resp.Headers.ContainsKey("Allow"))
            {
                options.AddRange((resp.Headers["Allow"] + "").Split(','));
            }

            result = options.Any(option => option.Contains(feature));

            return result;
        }

        /// <summary>
        /// 判断资源类型是否支持
        /// IsResourceType ("C", "calendar");
        /// IsResourceType ("A", "addressbook");
        /// </summary>
        /// <param name="url"></param>
        /// <param name="ns"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsResource(string url, string ns, string name)
        {
            var resp = Avatar.Submit2WebDav(
                "PROPFIND",
                url,
                Defined.RequestResourceType);

            var xmlPack = DeserializeXmlContent(resp.Content, new Uri(Channel.ChannelUrl));

            XmlNode resourceTypeNode = xmlPack.XmlDocument.SelectSingleNode(
                $"/D:multistatus/D:response/D:propstat/D:prop/D:resourcetype/{ns}:{name}",
                xmlPack.XmlNamespaceManager);

            return resourceTypeNode != null;
        }

        /// <summary>
        /// 查询支持的服务
        /// </summary>
        /// <param name="url"></param>
        /// <param name="ns"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool SupportedReport(string url, string ns = "C", string name = "calendar-query")
        {
            var resp = Avatar.Submit2WebDav(
                "PROPFIND",
                url,
                Defined.RequestSupportedReport);

            var xmlPack = DeserializeXmlContent(resp.Content, new Uri(Channel.ChannelUrl));

            XmlNode reportSetNode = xmlPack.XmlDocument.SelectSingleNode(
                $"/D:multistatus/D:response/D:propstat/D:prop/D:supported-report-set/D:supported-report/D:report/{ns}:{name}",
                xmlPack.XmlNamespaceManager);

            return reportSetNode != null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Uri GetCurrentUserPrincipal(string url)
        {
            var resp = Avatar.Submit2WebDav(
                "PROPFIND",
                url,
                Defined.RequestCurrentUserPrincipal);

            var xmlPack = DeserializeXmlContent(resp.Content, new Uri(url));
            XmlNode principalUrlNode =
                xmlPack.XmlDocument.SelectSingleNode(
                    "/D:multistatus/D:response/D:propstat/D:prop/D:current-user-principal",
                    xmlPack.XmlNamespaceManager);
            if (principalUrlNode == null || string.IsNullOrEmpty(principalUrlNode.InnerText))
                principalUrlNode = xmlPack.XmlDocument.SelectSingleNode(
                    "/D:multistatus/D:response/D:propstat/D:prop/D:principal-URL",
                    xmlPack.XmlNamespaceManager);

            if (principalUrlNode != null && !string.IsNullOrEmpty(principalUrlNode.InnerText))
                return new Uri(xmlPack.DocumentUri.GetLeftPart(UriPartial.Authority) + principalUrlNode.InnerText);
            else
                return null;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="url"></param>
        /// <param name="etag"></param>
        /// <returns></returns>
        public bool TryDeleteEntity(string url, string etag)
        {
            try
            {
                var resp = Avatar.Submit2WebDav(
                    "DELETE",
                    url, "", "text/xml",
                    -1, string.Empty, etag);

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            return false;
        }

        */
    }
}
