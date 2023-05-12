using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ban3.Infrastructures.SpringConfig.Entries
{
    public class Declare
    {

        /// <summary>
        /// XML file name
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// object id
        /// </summary>
        public string Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Parent { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string TypeName { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string FactoryObject { get; set; }


        [JsonProperty("assemblyName")]
        public string AssemblyName { get; set; }

        [JsonProperty("args", NullValueHandling = NullValueHandling.Ignore)]
        public List<Argument> Args { get; set; }

        public string Html()
        {
            if (Args == null || !Args.Any())
                return "<font color='#663300'>NO arguments.</font>";

            var sb = new StringBuilder();

            sb.Append("<ul>");

            foreach (var a in Args)
            {
                sb.Append($"<li>{a.Html()}</li>");
            }

            sb.Append("</ul>");

            return sb.ToString();
        }

        public bool HasArg(string k)
        {
            if (Args == null || !Args.Any()) return false;

            return Args.Any(o => o.Exists(k));
        }
    }
}