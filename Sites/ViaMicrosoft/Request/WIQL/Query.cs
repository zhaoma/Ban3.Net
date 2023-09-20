using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Sites.ViaMicrosoft.Request.WIQL
{
    public class Query
        : IRequest
    {
        public string Method() => "POST";

        public string Resource()
            => Enums.APIResource.WIQL.ToAPIResourceString();

        public string JsonBody() => new{query= QueryCommand }.ObjToJson();

        public Query(){}


        public string QueryCommand { get; set; }
    }
}
