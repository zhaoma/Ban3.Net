using System;
using System.IO;
using System.Net.Http;
using System.Text;

namespace Ban3.Infrastructures.NetHttp.Request;

public class Body
{
    public byte[] Bytes { get; set; }

    public Stream StreamContent { get; set; }

    public string StringContent { get; set; } = string.Empty;

    public string ContentMediaType { get; set; } = "application/json";

    public string ContentEncoding { get; set; } = "utf-8";

    public HttpContent Content()
    {
        if (Bytes != null)
            return new ByteArrayContent(Bytes);

        if (StreamContent != null)
            return new StreamContent(StreamContent);

        if (!String.IsNullOrEmpty(StringContent))
            return new StringContent(StringContent, Encoding.GetEncoding(ContentEncoding), ContentMediaType);

        return null;
    }
}
