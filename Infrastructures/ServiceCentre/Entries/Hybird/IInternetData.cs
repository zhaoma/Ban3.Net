using System.IO;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

public interface IInternetData
{
    byte[] Bytes { get; set; }

    Stream StreamContent { get; set; }

    string StringContent { get; set; }

    string ContentMediaType { get; set; }

    string ContentEncoding { get; set; }
}