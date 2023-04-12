using System.Collections.Specialized;
using System.Net.Mail;

using Ban3.Protocols.Rfc2445.Interfaces;

namespace Ban3.Protocols.Rfc2445
{
    /// <summary>
    /// 联系人(日历事件相关)
    /// </summary>
    public class Contact : IHasParameters
    {
        /// <summary>
        /// 
        /// </summary>
        public Contact() {}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addr"></param>
        public Contact( MailAddress addr )
        {
            Name = addr.DisplayName;
            Email = addr.Address;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SentBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Directory { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        public static implicit operator MailAddress( Contact c )
        {
            return new MailAddress( c.Email, c.Name );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public NameValueCollection GetParameters()
        {
            var values = new NameValueCollection();
            if( !string.IsNullOrEmpty( Name ) ) values[ "CN" ] = Name;
            if( !string.IsNullOrEmpty( Directory ) ) values[ "DIR" ] = Directory;
            if( !string.IsNullOrEmpty( SentBy ) ) values[ "SENT-BY" ] = SentBy;
            return values;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "MAILTO:" + Email;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameters"></param>
        public void Deserialize( string value, NameValueCollection parameters )
        {
            Email = value.Substring( value.IndexOf( ':' ) + 1 );
            Name = parameters[ "CN" ];
            SentBy = parameters[ "SENT-BY" ];
            if( !string.IsNullOrEmpty( SentBy ) )
            {
                SentBy = SentBy.Substring( SentBy.IndexOf( ':' ) + 1 );
            }

            Directory = parameters[ "DIR" ];
        }
    }
}