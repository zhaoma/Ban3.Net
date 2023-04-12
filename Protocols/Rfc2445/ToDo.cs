using System;
using System.Collections.Generic;
using System.Linq;

using Ban3.Protocols.Rfc2445.Enums;
using Ban3.Protocols.Rfc2445.Interfaces;

namespace Ban3.Protocols.Rfc2445
{
    /// <summary>
    /// 待办事项
    /// </summary>
    public class ToDo : ICalendarObject
    {
        /// <summary>
        /// 
        /// </summary>
        public ToDo()
        {
            Categories = new List<string>();
            Properties = new List<Tuple<string, string, System.Collections.Specialized.NameValueCollection>>();
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual string UID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        internal DateTime? DTSTAMP;

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? Start { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? Due { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Summary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Classes? Class { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<string> Categories { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual int? Priority { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Statuses? Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Calendar Calendar { get; set; }

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
        public virtual DateTime? Completed { get; set; }

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
                    case "UID":
                        UID = value;
                        break;
                    case "DTSTAMP":
                        DTSTAMP = value.ToDateTime();
                        break;
                    case "DTSTART":
                        Start = value.ToDateTime();
                        break;
                    case "DUE":
                        Due = value.ToDateTime();
                        break;
                    case "SUMMARY":
                        Summary = value;
                        break;
                    case "CLASS":
                        Class = value.ToEnum<Classes>();
                        break;
                    case "CATEGORIES":
                        Categories = value.SplitEscaped().ToList();
                        break;
                    case "PRIORITY":
                        Priority = value.ToInt();
                        break;
                    case "STATUS":
                        Status = value.ToEnum<Statuses>();
                        break;
                    case "LAST-MODIFIED":
                        LastModified = value.ToDateTime();
                        break;
                    case "COMPLETED":
                        Completed = value.ToDateTime();
                        break;
                    case "SEQUENCE":
                        Sequence = value.ToInt();
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
            wrtr.BeginBlock( "VTODO" );
            wrtr.Property( "UID", UID );
            wrtr.Property( "DTSTAMP", DTSTAMP );
            wrtr.Property( "DTSTART", Start );
            wrtr.Property( "DUE", Due );
            wrtr.Property( "SUMMARY", Summary );
            wrtr.Property( "CLASS", Class );
            wrtr.Property( "CATEGORIES", Categories );
            wrtr.Property( "PRIORITY", Priority );
            wrtr.Property( "STATUS", Status );
            wrtr.Property( "SEQUENCE", Sequence );
            wrtr.Property( "LAST-MODIFIED", LastModified );

            if( Properties != null )
                foreach( var prop in Properties )
                    wrtr.Property( prop.Item1, prop.Item2, parameters : prop.Item3 );

            wrtr.EndBlock( "VTODO" );
        }
    }
}