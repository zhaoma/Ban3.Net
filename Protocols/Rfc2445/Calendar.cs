﻿using System;
using System.Collections.Generic;
using System.Linq;

using Ban3.Protocols.Rfc2445.Interfaces;

using TimeZone = Ban3.Protocols.Rfc2445.TimeZone;

namespace Ban3.Protocols.Rfc2445
{
    /// <summary>
    /// 日历数据定义
    /// </summary>
    public class Calendar : ISerializeToICAL
    {
        /// <summary>
        /// 实例化
        /// </summary>
        public Calendar()
        {
            Events = new List<Event>();
            TimeZones = new List<TimeZone>();
            ToDos = new List<ToDo>();
            JournalEntries = new List<JournalEntry>();
            FreeBusy = new List<FreeBusy>();
            Properties = new List<Tuple<string, string, System.Collections.Specialized.NameValueCollection>>();
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string ProdID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Event> Events { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<ToDo> ToDos { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<TimeZone> TimeZones { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<JournalEntry> JournalEntries { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<FreeBusy> FreeBusy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Tuple<string, string, System.Collections.Specialized.NameValueCollection>> Properties { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IQueryable<ICalendarObject> Items
        {
            get
            {
                return Events.OfType<ICalendarObject>()
                             .Union( ToDos ).Union( JournalEntries ).Union( FreeBusy )
                             .AsQueryable();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public virtual void AddItem( ICalendarObject obj )
        {
            if( obj == null ) return;
            else if( obj is Event ) Events.Add( (Event)obj );
            else if( obj is ToDo ) ToDos.Add( (ToDo)obj );
            else if( obj is JournalEntry ) JournalEntries.Add( (JournalEntry)obj );
            else if( obj is FreeBusy ) FreeBusy.Add( (FreeBusy)obj );
            else throw new InvalidCastException();
        }

        /// <summary>
        /// 
        /// </summary>
        public string Scale { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rdr"></param>
        /// <param name="serializer"></param>
        public virtual void Deserialize( System.IO.TextReader rdr, Serializer? serializer = null )
        {
            if( serializer == null ) serializer = new Serializer();
            string name, value;
            var parameters = new System.Collections.Specialized.NameValueCollection();
            while( rdr.Property( out name, out value, parameters ) && !string.IsNullOrEmpty( name ) )
            {
                switch( name.ToUpper() )
                {
                    case "BEGIN":
                        switch( value )
                        {
                            case "VEVENT":
                                var e = serializer.GetService<Event>();
                                e.Calendar = this;
                                Events.Add( e );
                                e.Deserialize( rdr, serializer );
                                break;
                            case "VTIMEZONE":
                                var tz = serializer.GetService<TimeZone>();
                                tz.Calendar = this;
                                TimeZones.Add( tz );
                                tz.Deserialize( rdr, serializer );
                                break;
                            case "VTODO":
                                var td = serializer.GetService<ToDo>();
                                td.Calendar = this;
                                ToDos.Add( td );
                                td.Deserialize( rdr, serializer );
                                break;
                            case "VFREEBUSY":
                                var fb = serializer.GetService<FreeBusy>();
                                fb.Calendar = this;
                                FreeBusy.Add( fb );
                                fb.Deserialize( rdr, serializer );
                                break;
                            case "VJOURNAL":
                                var jn = serializer.GetService<JournalEntry>();
                                jn.Calendar = this;
                                JournalEntries.Add( jn );
                                jn.Deserialize( rdr, serializer );
                                break;
                        }

                        break;
                    case "CALSCALE":
                        Scale = value;
                        break;
                    case "VERSION":
                        Version = value;
                        break;
                    case "PRODID":
                        ProdID = value;
                        break;
                    case "END":
                        if( value == "VCALENDAR" )
                            return;
                        break;
                    default:
                        Properties.Add( Tuple.Create( name, value, parameters ) );
                        break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrtr"></param>
        public virtual void Serialize( System.IO.TextWriter wrtr )
        {
            wrtr.BeginBlock( "VCALENDAR" );
            wrtr.Property( "VERSION", Version ?? "2.0" );
            wrtr.Property( "PRODID", Common.PRODID );
            wrtr.Property( "CALSCALE", Scale );

            if( Properties != null )
                foreach( var prop in Properties )
                    wrtr.Property( prop.Item1, prop.Item2, parameters : prop.Item3 );

            foreach( var tz in TimeZones )
            {
                tz.Calendar = this;
                tz.Serialize( wrtr );
            }

            foreach( var e in Events )
            {
                e.Calendar = this;
                e.Serialize( wrtr );
            }

            foreach( var td in ToDos )
            {
                td.Calendar = this;
                td.Serialize( wrtr );
            }

            foreach( var fb in FreeBusy )
            {
                fb.Calendar = this;
                fb.Serialize( wrtr );
            }

            foreach( var jn in JournalEntries )
            {
                jn.Calendar = this;
                jn.Serialize( wrtr );
            }

            wrtr.EndBlock( "VCALENDAR" );
        }
    }
}