using Ban3.Protocols.Rfc2445.Interfaces;

namespace Ban3.Protocols.Rfc2445
{
    /// <summary>
    /// 提醒(类似OUTLOOK/GOOGLE的REMINDER)
    /// </summary>
    public class Alarm : ISerializeToICAL
    {
        /// <summary>
        /// 提醒时的动作
        /// This property defines the action to be invoked when an alarm is triggered.
        /// AUDIO/DISPLAY/PROCEDURE
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// This property specifies when an alarm will trigger.
        /// The default value type is DURATION.
        /// </summary>
        public Trigger Trigger { get; set; }

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
                switch( name )
                {
                    case "ACTION":
                        Action = value;
                        break;
                    case "DESCRIPTION":
                        Description = value;
                        break;
                    case "TRIGGER":
                        Trigger = serializer.GetService<Trigger>();
                        Trigger.Deserialize( value, parameters );
                        break;
                    case "END":
                        return;
                }
            }
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="wrtr"></param>
        public void Serialize( System.IO.TextWriter wrtr )
        {
            wrtr.BeginBlock( "VALARM" );
            wrtr.Property( "ACTION", Action );
            wrtr.Property( "DESCRIPTION", Description );
            wrtr.Property( "TRIGGER", Trigger );
            wrtr.Property( "X-WR-ALARMUID", System.Guid.NewGuid().ToString( "D" ) );
            wrtr.EndBlock( "VALARM" );
        }
    }
}