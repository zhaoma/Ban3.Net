using System;
using System.Collections.Generic;
using System.Linq;

using Ban3.Protocols.Rfc2445.Interfaces;

namespace Ban3.Protocols.Rfc2445
{
    /// <summary>
    /// 
    /// </summary>
    public class FreeBusy : ICalendarObject
    {
        /// <summary>
        /// 
        /// </summary>
        public FreeBusy()
        {
            DTSTAMP = DateTime.UtcNow;
            Details = new List<DateTimeRange>();
            Properties = new List<Tuple<string, string, System.Collections.Specialized.NameValueCollection>>();
        }

        /// <summary>
        /// 
        /// </summary>
        DateTime? DTSTAMP;

        /// <summary>
        /// 
        /// </summary>
        public virtual string UID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Uri Url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual int? Sequence { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? LastModified { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? Start { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? End { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Contact Organizer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Calendar Calendar { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<DateTimeRange> Details { get; set; }

        /// <summary>
        /// 
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
            while( rdr.Property( out name, out value, parameters ) && !string.IsNullOrEmpty( name ) )
            {
                switch( name.ToUpper() )
                {
                    case "UID":
                        UID = value;
                        break;
                    case "ORGANIZER":
                        Organizer = new Contact();
                        Organizer.Deserialize( value, parameters );
                        break;
                    case "SEQUENCE":
                        Sequence = value.ToInt();
                        break;
                    case "LAST-MODIFIED":
                        LastModified = value.ToDateTime();
                        break;
                    case "DTSTART":
                        LastModified = value.ToDateTime();
                        break;
                    case "DTEND":
                        LastModified = value.ToDateTime();
                        break;
                    case "DTSTAMP":
                        DTSTAMP = value.ToDateTime();
                        break;
                    case "FREEBUSY":
                        var parts = value.Split( '/' );
                        Details.Add( new DateTimeRange
                        {
                                From = parts.FirstOrDefault().ToDateTime(),
                                To = parts.ElementAtOrDefault( 1 ).ToDateTime()
                        } );
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
            wrtr.BeginBlock( "VFREEBUSY" );
            wrtr.Property( "ORGANIZER", Organizer );
            wrtr.Property( "UID", UID );
            wrtr.Property( "SEQUENCE", Sequence );
            wrtr.Property( "LAST-MODIFIED", LastModified );
            wrtr.Property( "DTSTART", Start );
            wrtr.Property( "DTEND", End );
            wrtr.Property( "Url", Url );
            foreach( var detail in Details )
            {
                wrtr.Property( "FREEBUSY",
                               (detail.From == null ? null : Common.FormatDate( detail.From.Value )) + "/"
                                                                                                     + (detail.To == null ? null : Common.FormatDate( detail.To.Value ))
                             );
            }

            wrtr.EndBlock( "VFREEBUSY" );
        }
    }
}