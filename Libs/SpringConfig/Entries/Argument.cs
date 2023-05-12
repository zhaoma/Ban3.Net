using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.SpringConfig.Entries
{
    public class Argument
    {

        /// <summary>
        /// 参数名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 引用接口
        /// </summary>
        public string Ref { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FactoryObject { get; set; }

        public string Value { get; set; }

        /// <summary>
        /// 是否为集合
        /// </summary>
        public bool IsEnumerable { get; set; }

        /// <summary>
        /// 列表参数
        /// </summary>

        public List<string> Refs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public List<string> AssemblyNames { get; set; }

        public bool Exists(string k)
        {
            if (IsEnumerable && Refs != null)
                return Refs.Any(x => x.ToUpper().Contains(k.ToUpper()));

            return Ref.ToUpper().Contains(k.ToUpper());
        }

        public string GetAssemblyName()
        {
            if ((Name + "").ToUpper() == "TYPENAME")
            {
                var ts = (Value + "").Split(',').Select(o => o.Trim()).ToList();
                if (ts.Count() == 2)
                    return ts[1];
            }

            if ((Name + "").ToUpper() == "STR")
            {
                return "System.Runtime";
            }


            if ((Name + "").ToUpper() == "LOGGER")
            {
                return Ref;
            }

            return String.Empty;
        }

        public string Html()
        {
            var sb = new StringBuilder();

            if (!string.IsNullOrEmpty(Name))
            {
                sb.Append($"Name:<u>{Name}</u>;");
            }

            if (!string.IsNullOrEmpty(Ref))
            {
                sb.Append($"Ref:<u>{Ref}</u>;");
            }

            if (!string.IsNullOrEmpty(Value))
            {
                sb.Append($"Value:<u>{Value}</u>;");
            }

            if (!string.IsNullOrEmpty(FactoryObject))
            {
                sb.Append($"FactoryObject:<u>{FactoryObject}</u>;");
            }

            if (Refs != null && Refs.Any())
            {
                foreach (var a in Refs)
                {
                    sb.AppendLine($"<br/><i>{a}</i>");
                }
            }

            return sb.ToString();
        }
    }
}