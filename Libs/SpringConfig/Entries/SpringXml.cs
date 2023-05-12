using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ban3.Infrastructures.SpringConfig.Entries
{
    public class SpringXml
    {
        public string FileName { get; set; }

        public string FilePath { get; set; }

        /// <summary>
        /// path:file
        /// </summary>
        public List<string> Imports { get; set; }

        public List<AliasObject> AliasList { get; set; }

        public List<Declare> Declares { get; set; }

        public string Html()
        {
            if (Declares == null || !Declares.Any())
                return "NO objects.";

            var sb = new StringBuilder();

            sb.Append("<ol>");

            foreach (var declare in Declares)
            {
                sb.Append($"<li r='{declare.AssemblyName}'>{declare.Id}:<font color=red>{declare.AssemblyName}</font>");
                sb.Append(declare.Html());
                sb.Append("</li>");
            }

            sb.Append("</ol>");

            return sb.ToString();
        }

    }
}