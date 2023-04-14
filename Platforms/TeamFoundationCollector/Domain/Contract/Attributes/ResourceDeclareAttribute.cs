using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Attributes
{
    /// <summary>
    /// 资源的属性定义(路径)
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ResourceDeclareAttribute
        : Attribute
    {
        public ResourceDeclareAttribute(
            string method,
            string path,
            bool pathNeedId=false,
            bool pathNeedAddition=false
            
            )
        {
            Method =method;
            Path = path;
        }

        public string Method { get; set; }

        public string Path { get; set; }

        public bool PathNeedId { get; set; }

        public bool PathNeedAddition { get; set; }

        public bool PathIncludeProjectId { get; set; }
    }
}
