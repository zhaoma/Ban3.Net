using System;
using System.Collections.Generic;
using System.Linq;

using Ban3.Protocols.Rfc2445.Enums;
using Ban3.Protocols.Rfc2445.Interfaces;

namespace Ban3.Protocols.Rfc2445
{
    /// <summary>
    /// 日志定义
    /// </summary>
    public class JournalEntry : ICalendarObject
    {
        /// <summary>
        /// 
        /// </summary>
        public JournalEntry()
        {
            DTSTAMP = DateTime.UtcNow;
            Properties = new List<Tuple<string, string, System.Collections.Specialized.NameValueCollection>>();
        }

        DateTime? DTSTAMP;

        /// <summary>
        /// 隐私等级
        /// </summary>
        public virtual Classes? Class { get; set; }

        /// <summary>
        /// 标识
        /// </summary>
        public virtual string UID { get; set; }

        /// <summary>
        /// 组织者
        /// </summary>
        public virtual Contact Organizer { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public virtual Statuses? Status { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public virtual ICollection<string> Categories { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// 序列
        /// </summary>
        public virtual int? Sequence { get; set; }

        /// <summary>
        /// 最后更新
        /// </summary>
        public virtual DateTime? LastModified { get; set; }

        /// <summary>
        /// 日历
        /// </summary>
        public virtual Calendar Calendar { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Tuple<string, string, System.Collections.Specialized.NameValueCollection>> Properties { get; set; }

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="rdr"></param>
        /// <param name="serializer"></param>
        public void Deserialize( System.IO.TextReader rdr, Serializer serializer )
        {
            string name, value;
            var parameters = new System.Collections.Specialized.NameValueCollection();
            while( rdr.Property( out name, out value, parameters ) && !string.IsNullOrEmpty( name ) )
            {
                switch( name.ToUpper() )
                {
                    case "CLASS":
                        Class = value.ToEnum<Classes>();
                        break;
                    case "STATUS":
                        Status = value.ToEnum<Statuses>();
                        break;
                    case "UID":
                        UID = value;
                        break;
                    case "ORGANIZER":
                        Organizer = new Contact();
                        Organizer.Deserialize( value, parameters );
                        break;
                    case "CATEGORIES":
                        Categories = value.SplitEscaped().ToList();
                        break;
                    case "DESCRIPTION":
                        Description = value;
                        break;
                    case "SEQUENCE":
                        Sequence = value.ToInt();
                        break;
                    case "LAST-MODIFIED":
                        LastModified = value.ToDateTime();
                        break;
                    case "DTSTAMP":
                        DTSTAMP = value.ToDateTime();
                        break;
                    case "END":
                        return;
                    default:
                        Properties.Add( Tuple.Create( name, value, parameters ) );
                        break;
                }
            }
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="wrtr"></param>
        public void Serialize( System.IO.TextWriter wrtr )
        {
            wrtr.BeginBlock( "VJOURNAL" );
            wrtr.Property( "ORGANIZER", Organizer );
            wrtr.Property( "CLASS", Class );
            wrtr.Property( "UID", UID );
            wrtr.Property( "SEQUENCE", Sequence );
            wrtr.Property( "LAST-MODIFIED", LastModified );
            wrtr.EndBlock( "VJOURNAL" );
        }
    }
}