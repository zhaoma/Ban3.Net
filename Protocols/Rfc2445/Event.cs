using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

using Ban3.Protocols.Rfc2445.Enums;
using Ban3.Protocols.Rfc2445.Interfaces;

namespace Ban3.Protocols.Rfc2445
{
    /// <summary>
    /// 事件信息定义
    /// </summary>
    public class Event : ICalendarObject
    {
        private DateTime DTSTAMP = DateTime.UtcNow;

        /// <summary>
        /// 
        /// </summary>
        public Event()
        {
            Attendees = new List<Contact>();
            Alarms = new List<Alarm>();
            Categories = new List<string>();
            Recurrences = new List<Recurrence>();
            Properties = new List<Tuple<string, string, System.Collections.Specialized.NameValueCollection>>();
            Attachments = new List<Uri>();
        }

        /// <summary>
        /// 日历
        /// </summary>
        public virtual Calendar Calendar { get; set; }

        /// <summary>
        /// 相关人
        /// </summary>
        public virtual ICollection<Contact> Attendees { get; set; }

        /// <summary>
        /// 提醒/闹铃
        /// </summary>
        public virtual ICollection<Alarm> Alarms { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public virtual ICollection<string> Categories { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        public virtual ICollection<Uri> Attachments { get; set; }

        /// <summary>
        /// 保护等级
        /// </summary>
        public virtual Classes? Class { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime? Created { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// 全天事件
        /// </summary>
        public virtual bool IsAllDay { get; set; }

        /// <summary>
        /// 最后修改
        /// </summary>
        public virtual DateTime? LastModified { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public virtual DateTime? Start { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public virtual DateTime? End { get; set; }

        /// <summary>
        /// 地点
        /// </summary>
        public virtual string Location { get; set; }

        /// <summary>
        /// 时区
        /// </summary>
        public virtual string Tzid { get; set; }

        /// <summary>
        /// 重要程度
        /// </summary>
        public virtual int? Priority { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public virtual Statuses? Status { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public virtual int? Sequence { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Summary { get; set; }

        /// <summary>
        /// 透明？
        /// </summary>
        public virtual string Transparency { get; set; }

        /// <summary>
        /// 标识
        /// </summary>
        public virtual string UID { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public virtual Uri Url { get; set; }

        /// <summary>
        /// 组织
        /// </summary>
        public virtual Contact Organizer { get; set; }

        /// <summary>
        /// 循环定义
        /// </summary>
        public virtual ICollection<Recurrence> Recurrences { get; set; }

        /// <summary>
        /// 属性
        /// </summary>
        public ICollection<Tuple<string, string, System.Collections.Specialized.NameValueCollection>> Properties { get; set; }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="rdr"></param>
        /// <param name="serializer"></param>
        public void Deserialize( System.IO.TextReader rdr, Serializer serializer )
        {
            string name, value;
            var parameters = new System.Collections.Specialized.NameValueCollection();

            var start = "";

            while( rdr.Property( out name, out value, parameters ) && !string.IsNullOrEmpty( name ) )
            {
                switch( name.ToUpper() )
                {
                    case "BEGIN":
                        switch( value )
                        {
                            case "VALARM":
                                var a = serializer.GetService<Alarm>();
                                a.Deserialize( rdr, serializer );
                                Alarms.Add( a );
                                break;
                        }

                        break;
                    case "ATTENDEE":
                        var contact = new Contact();
                        contact.Deserialize( value, parameters );
                        Attendees.Add( contact );
                        break;
                    case "CATEGORIES":
                        Categories = value.SplitEscaped().ToList();
                        break;
                    case "CLASS":
                        Class = value.ToEnum<Classes>();
                        break;
                    case "CREATED":
                        Created = value.ToDateTime();
                        break;
                    case "DESCRIPTION":
                        Description = value;
                        break;
                    case "DTEND":
                        End = value.ToDateTime();
                        break;
                    case "DTSTAMP":
                        DTSTAMP = value.ToDateTime().GetValueOrDefault();
                        break;
                    case "DTSTART":
                        start = value;
                        IsAllDay = start.Length == 8;
                        Start = value.ToDateTime();
                        break;
                    case "LAST-MODIFIED":
                        LastModified = value.ToDateTime();
                        break;
                    case "LOCATION":
                        Location = value;
                        break;
                    case "TZID":
                        Tzid = value;
                        break;
                    case "ORGANIZER":
                        Organizer = serializer.GetService<Contact>();
                        Organizer.Deserialize( value, parameters );
                        break;
                    case "PRIORITY":
                        Priority = value.ToInt();
                        break;
                    case "SEQUENCE":
                        Sequence = value.ToInt();
                        break;
                    case "STATUS":
                        Status = value.ToEnum<Statuses>();
                        break;
                    case "SUMMARY":
                        Summary = value;
                        break;
                    case "TRANSP":
                        Transparency = value;
                        break;
                    case "UID":
                        UID = value;
                        break;
                    case "URL":
                        Url = value.ToUri();
                        break;
                    case "ATTACH":
                        var attach = value.ToUri();
                        if( attach != null )
                            Attachments.Add( attach );
                        break;
                    case "RRULE":
                        var rule = serializer.GetService<Recurrence>();
                        rule.Deserialize( null, parameters );
                        Recurrences.Add( rule );
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
        /// 序列化成iCalendar Content
        /// </summary>
        /// <param name="wrtr"></param>
        public void Serialize( System.IO.TextWriter wrtr )
        {
            if( End != null && Start != null && End < Start )
                End = Start;

            wrtr.BeginBlock( "VEVENT" );
            wrtr.Property( "UID", UID );
            if( Attendees != null )
                foreach( var attendee in Attendees )
                    wrtr.Property( "ATTENDEE", attendee );
            if( Categories != null && Categories.Count > 0 )
                wrtr.Property( "CATEGORIES", Categories );
            wrtr.Property( "CLASS", Class );
            wrtr.Property( "CREATED", Created );
            wrtr.Property( "DESCRIPTION", Description );

            var tzid = new NameValueCollection { { "TZID", Tzid } };
            var date = new NameValueCollection { { "VALUE", "DATE" } };

            wrtr.Property( "DTEND",
                           IsAllDay
                                   ? End?.ToString( "yyyyMMdd" )
                                   : End?.ToString( "yyyyMMddTHHmmss" )
                           , false, IsAllDay ? date : tzid );
            wrtr.Property( "DTSTART",
                           IsAllDay
                                   ? Start?.ToString( "yyyyMMdd" )
                                   : Start?.ToString( "yyyyMMddTHHmmss" )
                           , false, IsAllDay ? date : tzid );

            wrtr.Property( "DTSTAMP", DTSTAMP );
            //wrtr.Property("DTSTART",( IsAllDay ? (Start ?? End.Value).Date : Start.Value).ToString("yyyyMMddTHHmmssZ"));

            if( Recurrences != null )
            {
                foreach( var recurrence in Recurrences )
                {
                    wrtr.Property( "RRULE", recurrence.ToString() );
                }
            }

            wrtr.Property( "LAST-MODIFIED", LastModified );
            wrtr.Property( "LOCATION", Location );
            wrtr.Property( "TZID", Tzid );
            wrtr.Property( "ORGANIZER", Organizer );
            wrtr.Property( "PRIORITY", Priority );
            wrtr.Property( "SEQUENCE", Sequence );
            wrtr.Property( "STATUS", Status );
            wrtr.Property( "SUMMARY", Summary );
            wrtr.Property( "TRANSP", Transparency );
            wrtr.Property( "URL", Url );

            if( Properties != null )
                foreach( var prop in Properties )
                    wrtr.Property( prop.Item1, prop.Item2, parameters : prop.Item3 );

            if( Alarms != null )
                foreach( var alarm in Alarms )
                    alarm.Serialize( wrtr );
            wrtr.EndBlock( "VEVENT" );
        }
    }
}