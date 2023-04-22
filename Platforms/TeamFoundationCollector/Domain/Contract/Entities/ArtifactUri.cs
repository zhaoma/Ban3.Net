using System;
using System.Net;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities
{
	public class ArtifactUri
    {
		public ArtifactUri(int changesetId)
		{
			Type = ArtifactType.Changeset;
			Id = changesetId + "";
		}

		public ArtifactUri(string shelvesetId, string shelvesetOwner)
		{
			Type = ArtifactType.Shelveset;
			Id = shelvesetId;
			Query = $"shelvesetOwner={shelvesetOwner}";
			NeedUrlEncode = true;
		}

		public ArtifactType Type { get; set; }

		public string Query { get; set; } = string.Empty;

        public string Id { get; set; } = string.Empty;

		public bool NeedUrlEncode { get; set; }

		public override string ToString()
		{
			var uri = $"vstfs:///VersionControl/{Type}/{Id}";
			if (!string.IsNullOrEmpty(Query))
				uri += $"&{Query}";

			return NeedUrlEncode
				? WebUtility.UrlEncode(uri)
				: uri;
		}
	}
}

